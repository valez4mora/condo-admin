using BLL;
using DTO;
using Integration.BCCR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Util.Enumeraciones;

namespace UI.Forms
{
    /// Formulario de Gestión de Propiedades.
    /// Permite registrar, buscar, actualizar y eliminar propiedades del condominio.
    /// Calcula automáticamente cuota de mantenimiento, fondo de reserva y
    /// convierte el monto a dólares mediante el servicio BCCR.
    public partial class FrmPropiedad : Form
    {
        // ── Servicios BLL / Integración ──────────────────────────────
        private readonly PropiedadBLL _propiedadBLL = new PropiedadBLL();
        private readonly PropietarioBLL _propietarioBLL = new PropietarioBLL();
        private readonly BCCRService _bccrService = new BCCRService();
        private readonly Dictionary<int, bool> _estadoMorosidadPropietarios =
            new Dictionary<int, bool>();

        // ── Estado interno ────────────────────────────────────────────
        private int _idPropiedadSeleccionada = 0;

        // ── Parámetros de configuración (App.config) ──────────────────
        private readonly decimal _tarifaConfigurada;
        private readonly decimal _cargoFijoConfigurado;
        private decimal _tarifaActual;
        private decimal _cargoFijoActual;
        private decimal _cuotaActual;

        // ── Constante financiera ──────────────────────────────────────
        private const decimal PORCENTAJE_FONDO_RESERVA = 0.10m;   // 10 %

        // ─────────────────────────────────────────────────────────────
        public FrmPropiedad()
        {
            InitializeComponent();

            _tarifaConfigurada = LeerParametroMonetario("TarifaPorM2", 450m);
            _cargoFijoConfigurado = LeerParametroMonetario("CargoFijoMantenimiento", 5000m);
            RestaurarParametrosConfigurados();
        }

        // CARGA DEL FORMULARIO
        private void FrmPropiedad_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarTiposPropiedad();
            CargarPropietarios();
            CargarTodas();

            MostrarParametrosFinancieros();
            RecalcularValoresFinancieros();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        // ── Configuración del DataGridView ────────────────────────────
        private void ConfigurarGrid()
        {
            dgvPropiedades.Columns.Clear();
            dgvPropiedades.AutoGenerateColumns = false;

            dgvPropiedades.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Codigo",
                    HeaderText       = "Código",
                    Width            = 90
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Tipo",
                    HeaderText       = "Tipo",
                    Width            = 100
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Area",
                    HeaderText       = "Área (m²)",
                    Width            = 80,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CantidadResidentes",
                    HeaderText       = "Residentes",
                    Width            = 80,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombrePropietario",
                    HeaderText       = "Propietario",
                    Width            = 170,
                    AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TarifaMetro",
                    HeaderText       = "Tarifa/m²",
                    Width            = 95,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CargoFijo",
                    HeaderText       = "Cargo fijo",
                    Width            = 95,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CuotaMantenimiento",
                    HeaderText       = "Cuota (₡)",
                    Width            = 110,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "EstadoMorosidad",
                    HeaderText       = "Estado",
                    Width            = 80
                }
            });
            dgvPropiedades.CellFormatting += dgvPropiedades_CellFormatting;

            dgvPropiedades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvPropiedades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPropiedades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPropiedades.EnableHeadersVisualStyles = false;
            dgvPropiedades.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvPropiedades.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvPropiedades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235);
            dgvPropiedades.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPropiedades.RowTemplate.Height = 28;
        }

        // ── ComboBox tipos de propiedad ───────────────────────────────
        private void CargarTiposPropiedad()
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(TipoPropiedad));
            cmbTipo.SelectedIndex = -1;
        }

        // ── ComboBox propietarios ─────────────────────────────────────
        private void CargarPropietarios()
        {
            try
            {
                var lista = _propietarioBLL.ObtenerTodos();
                _estadoMorosidadPropietarios.Clear();
                foreach (var propietario in lista)
                    _estadoMorosidadPropietarios[propietario.IdPersona] =
                        propietario.EstadoMorosidad;

                var fuente = lista
                    .Select(p => new
                    {
                        IdPersona = p.IdPersona,
                        NombreCompleto = $"{p.Nombre} {p.Apellidos}".Trim()
                    })
                    .ToList();

                cmbPropietario.DataSource = fuente;
                cmbPropietario.DisplayMember = "NombreCompleto";
                cmbPropietario.ValueMember = "IdPersona";
                cmbPropietario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar la lista de propietarios: " + ex.Message);
            }
        }

        private void cmbPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_idPropiedadSeleccionada > 0 || cmbPropietario.SelectedValue == null)
                return;

            int idPropietario;
            if (int.TryParse(cmbPropietario.SelectedValue.ToString(), out idPropietario) &&
                _estadoMorosidadPropietarios.ContainsKey(idPropietario))
                MostrarEstado(_estadoMorosidadPropietarios[idPropietario]);
        }

        // ── Cargar todas las propiedades ──────────────────────────────
        private void CargarTodas()
        {
            try
            {
                var lista = _propiedadBLL.ObtenerTodas();
                dgvPropiedades.DataSource = lista;
                ActualizarInfo(lista.Count);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar el listado: " + ex.Message);
            }
        }

        private void ActualizarInfo(int total)
        {
            lblInfo.Text = total > 0
                ? $"  {total} propiedad(es) encontrada(s). Haga clic en una fila para cargar los datos."
                : "  No se encontraron propiedades registradas.";
        }

        // CÁLCULOS FINANCIEROS AUTOMÁTICOS
        private void nudArea_ValueChanged(object sender, EventArgs e)
        {
            RecalcularValoresFinancieros();
        }

        private void RecalcularValoresFinancieros()
        {
            _cuotaActual = nudArea.Value > 0
                ? (nudArea.Value * _tarifaActual) + _cargoFijoActual
                : 0m;
            decimal fondo = _cuotaActual * PORCENTAJE_FONDO_RESERVA;

            txtCuotaColones.Text = $"₡ {_cuotaActual:N2}";
            txtFondoReserva.Text = $"₡ {fondo:N2}";
            txtCuotaDolares.Text = "$ —";
        }

        private void btnConvertirDolar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudArea.Value <= 0)
                {
                    MostrarAviso("Ingrese el área primero para calcular la cuota.");
                    return;
                }

                if (_cuotaActual <= 0)
                {
                    MostrarAviso("No se puede convertir porque la cuota calculada no es válida.");
                    return;
                }

                btnConvertirDolar.Enabled = false;
                btnConvertirDolar.Text = "...";

                decimal dolares = _bccrService.ConvertirColonesADolares(_cuotaActual);
                txtCuotaDolares.Text = $"$ {dolares:N2}";
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo obtener el tipo de cambio BCCR: " + ex.Message);
                txtCuotaDolares.Text = "$ (sin conexión)";
            }
            finally
            {
                btnConvertirDolar.Enabled = true;
                btnConvertirDolar.Text = "⟳ Convertir";
            }
        }

        private decimal ObtenerCuotaActual()
        {
            return _cuotaActual;
        }

        // BÚSQUEDA
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                MostrarAviso("Ingrese un código para buscar.");
                return;
            }

            try
            {
                PropiedadDTO propiedad = _propiedadBLL.ObtenerPorCodigo(codigo);

                if (propiedad == null)
                {
                    MostrarAviso($"No se encontró ninguna propiedad con el código \"{codigo}\".");
                    return;
                }

                CargarEnFormulario(propiedad);
                dgvPropiedades.DataSource = new List<PropiedadDTO> { propiedad };
                ActualizarInfo(1);
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void btnCargarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarTodas();
        }

        // ── Clic en fila - cargar formulario ──────────────────────────
        private void dgvPropiedades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            if (dgvPropiedades.Rows[e.RowIndex].DataBoundItem is PropiedadDTO propiedad)
                CargarEnFormulario(propiedad);
        }

        // ── Poblar formulario ─────────────────────────────────────────
        private void CargarEnFormulario(PropiedadDTO p)
        {
            _idPropiedadSeleccionada = p.IdPropiedad;

            txtCodigo.Text = p.Codigo;
            txtDireccion.Text = p.Direccion;
            nudResidentes.Value = p.CantidadResidentes;

            _tarifaActual = p.TarifaMetro > 0 ? p.TarifaMetro : _tarifaConfigurada;
            _cargoFijoActual = p.CargoFijo >= 0 ? p.CargoFijo : _cargoFijoConfigurado;
            MostrarParametrosFinancieros();
            nudArea.Value = p.Area;
            RecalcularValoresFinancieros();

            cmbTipo.SelectedItem = null;
            if (Enum.TryParse(p.Tipo, out TipoPropiedad tipo))
                cmbTipo.SelectedItem = tipo;

            cmbPropietario.SelectedValue = p.IdPropietario;

            MostrarEstado(p.EstadoMorosidad);
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        // ── Badge de estado morosidad ─────────────────────────────────
        private void MostrarEstado(bool esMorosa)
        {

            if (esMorosa)
            {
                lblEstadoValor.BackColor = Color.FromArgb(220, 38, 38);
                lblEstadoValor.Text = "MOROSO";
            }
            else
            {
                lblEstadoValor.BackColor = Color.FromArgb(22, 163, 74);
                lblEstadoValor.Text = "AL DÍA";
            }
        }


        // CRUD
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposObligatorios();

                PropiedadDTO propiedad = ConstruirDTO();
                bool ok = _propiedadBLL.Registrar(propiedad);

                if (ok)
                {
                    MostrarExito("La propiedad fue registrada correctamente.");
                    LimpiarFormulario();
                    CargarTodas();
                }
                else
                {
                    MostrarAviso("No se pudo registrar la propiedad. Verifique los datos.");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idPropiedadSeleccionada <= 0)
                    throw new Exception("Seleccione una propiedad del listado antes de actualizar.");

                ValidarCamposObligatorios();

                PropiedadDTO propiedad = ConstruirDTO();
                propiedad.IdPropiedad = _idPropiedadSeleccionada;

                bool ok = _propiedadBLL.Modificar(propiedad);

                if (ok)
                {
                    MostrarExito("La propiedad fue actualizada correctamente.");
                    LimpiarFormulario();
                    CargarTodas();
                }
                else
                {
                    MostrarAviso("No se pudo actualizar la propiedad. Verifique los datos.");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idPropiedadSeleccionada <= 0)
                    throw new Exception("Seleccione una propiedad del listado antes de eliminar.");

                DialogResult confirm = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la propiedad \"{txtCodigo.Text}\"?\n\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                bool ok = _propiedadBLL.Eliminar(_idPropiedadSeleccionada);

                if (ok)
                {
                    MostrarExito("La propiedad fue eliminada correctamente.");
                    LimpiarFormulario();
                    CargarTodas();
                }
                else
                {
                    MostrarAviso("No se pudo eliminar la propiedad.");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void btnReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "El reporte de propiedades se genera desde el módulo de Reportes.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // HELPERS PRIVADOS
        private PropiedadDTO ConstruirDTO()
        {
            return new PropiedadDTO
            {
                Codigo = txtCodigo.Text.Trim(),
                Tipo = cmbTipo.SelectedItem?.ToString(),
                Direccion = txtDireccion.Text.Trim(),
                Area = nudArea.Value,
                CantidadResidentes = (int)nudResidentes.Value,
                TarifaMetro = _tarifaActual,
                CargoFijo = _cargoFijoActual,
                CuotaMantenimiento = ObtenerCuotaActual(),
                IdPropietario = Convert.ToInt32(cmbPropietario.SelectedValue)
            };
        }

        private void ValidarCamposObligatorios()
        {
            if (_tarifaActual <= 0)
                throw new Exception("La tarifa por metro cuadrado no está configurada correctamente.");

            if (_cargoFijoActual < 0)
                throw new Exception("El cargo fijo no está configurado correctamente.");

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                throw new Exception("El código de la propiedad es obligatorio.");

            if (cmbTipo.SelectedIndex < 0)
                throw new Exception("Debe seleccionar el tipo de propiedad.");

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                throw new Exception("La dirección exacta es obligatoria.");

            if (nudArea.Value <= 0)
                throw new Exception("El área debe ser mayor a cero.");

            if (cmbPropietario.SelectedIndex < 0)
                throw new Exception("Debe seleccionar un propietario.");
        }

        private void LimpiarFormulario()
        {
            _idPropiedadSeleccionada = 0;
            RestaurarParametrosConfigurados();
            MostrarParametrosFinancieros();

            txtCodigo.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();

            nudArea.Value = 0;
            nudResidentes.Value = 0;

            txtCuotaColones.Text = "₡ 0.00";
            txtCuotaDolares.Text = "$ —";
            txtFondoReserva.Text = "₡ 0.00";

            cmbTipo.SelectedIndex = -1;
            cmbPropietario.SelectedIndex = -1;
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            // Estado neutro al limpiar
            lblEstadoValor.BackColor = Color.FromArgb(100, 116, 139);
            lblEstadoValor.Text = "Sin datos";

            dgvPropiedades.ClearSelection();
            txtCodigo.Focus();
        }

        private static decimal LeerParametroMonetario(string clave, decimal valorPredeterminado)
        {
            decimal valor;
            string configurado = ConfigurationManager.AppSettings[clave];
            if (decimal.TryParse(configurado, NumberStyles.Number,
                CultureInfo.InvariantCulture, out valor) && valor >= 0)
                return valor;

            if (decimal.TryParse(configurado, NumberStyles.Number,
                CultureInfo.CurrentCulture, out valor) && valor >= 0)
                return valor;

            return valorPredeterminado;
        }

        private void RestaurarParametrosConfigurados()
        {
            _tarifaActual = _tarifaConfigurada;
            _cargoFijoActual = _cargoFijoConfigurado;
        }

        private void MostrarParametrosFinancieros()
        {
            txtTarifaM2.Text = $"₡ {_tarifaActual:N2} / m²";
            txtCargoFijo.Text = $"₡ {_cargoFijoActual:N2}";
        }

        private void dgvPropiedades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 ||
                dgvPropiedades.Columns[e.ColumnIndex].DataPropertyName != "EstadoMorosidad" ||
                e.Value == null)
                return;

            bool morosa = Convert.ToBoolean(e.Value);
            e.Value = morosa ? "Morosa" : "Al día";
            e.CellStyle.ForeColor = morosa ? Color.Firebrick : Color.SeaGreen;
            e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            e.FormattingApplied = true;
        }

        // ── Mensajes ──────────────────────────────────────────────────
        private void MostrarExito(string mensaje) =>
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void MostrarAviso(string mensaje) =>
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarError(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
