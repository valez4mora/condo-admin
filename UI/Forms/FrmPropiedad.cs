using BLL;
using DTO;
using Integration.BCCR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Util.Enumeraciones;

namespace UI.Forms
{
    /// <summary>
    /// Formulario de Gestión de Propiedades.
    /// Permite registrar, buscar, actualizar y eliminar propiedades del condominio.
    /// Calcula automáticamente cuota de mantenimiento, fondo de reserva y
    /// convierte el monto a dólares mediante el servicio BCCR.
    /// </summary>
    public partial class FrmPropiedad : Form
    {
        // ── Servicios BLL / Integración ──────────────────────────────
        private readonly PropiedadBLL  _propiedadBLL  = new PropiedadBLL();
        private readonly PropietarioBLL _propietarioBLL = new PropietarioBLL();
        private readonly BCCRService   _bccrService   = new BCCRService();

        // ── Estado interno ────────────────────────────────────────────
        /// <summary>Id de la propiedad cargada en el formulario (0 = ninguna).</summary>
        private int _idPropiedadSeleccionada = 0;

        // ── Parámetros de configuración (App.config) ──────────────────
        private readonly decimal _tarifaPorM2;
        private readonly decimal _cargoFijo;

        // ── Constante financiera ──────────────────────────────────────
        private const decimal PORCENTAJE_FONDO_RESERVA = 0.10m;   // 10 %

        // ─────────────────────────────────────────────────────────────
        public FrmPropiedad()
        {
            InitializeComponent();

            // Leer configuración una sola vez
            decimal.TryParse(
                ConfigurationManager.AppSettings["TarifaPorM2"],
                out _tarifaPorM2);

            decimal.TryParse(
                ConfigurationManager.AppSettings["CargoFijoMantenimiento"],
                out _cargoFijo);
        }

        // ═════════════════════════════════════════════════════════════
        // CARGA DEL FORMULARIO
        // ═════════════════════════════════════════════════════════════
        private void FrmPropiedad_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarTiposPropiedad();
            CargarPropietarios();
            CargarTodas();

            // Mostrar valores de configuración (solo lectura, informativos)
            txtTarifaM2.Text  = $"₡ {_tarifaPorM2:N2} / m²";
            txtCargoFijo.Text = $"₡ {_cargoFijo:N2}";
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
                    DataPropertyName = "CuotaMantenimiento",
                    HeaderText       = "Cuota (₡)",
                    Width            = 110,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
                }
            });

            // Estilos de cabecera
            dgvPropiedades.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(26, 58, 92);
            dgvPropiedades.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgvPropiedades.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPropiedades.EnableHeadersVisualStyles               = false;

            // Filas alternas
            dgvPropiedades.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 243, 252);
            dgvPropiedades.DefaultCellStyle.Font                    = new Font("Segoe UI", 9F);
            dgvPropiedades.DefaultCellStyle.SelectionBackColor      = Color.FromArgb(41, 128, 185);
            dgvPropiedades.DefaultCellStyle.SelectionForeColor      = Color.White;
            dgvPropiedades.RowTemplate.Height                       = 28;
        }

        // ── Llenar ComboBox de tipos ──────────────────────────────────
        private void CargarTiposPropiedad()
        {
            cmbTipo.DataSource   = Enum.GetValues(typeof(TipoPropiedad));
            cmbTipo.SelectedIndex = -1;
        }

        // ── Llenar ComboBox de propietarios ──────────────────────────
        private void CargarPropietarios()
        {
            try
            {
                var lista = _propietarioBLL.ObtenerTodos();
                cmbPropietario.DataSource    = lista;
                cmbPropietario.DisplayMember = "Nombre";
                cmbPropietario.ValueMember   = "IdPersona";
                cmbPropietario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar la lista de propietarios: " + ex.Message);
            }
        }

        // ── Cargar todas las propiedades en el grid ───────────────────
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

        // ═════════════════════════════════════════════════════════════
        // CÁLCULOS FINANCIEROS AUTOMÁTICOS
        // ═════════════════════════════════════════════════════════════

        /// <summary>
        /// Recalcula cuota y fondo de reserva cada vez que cambia el área.
        /// Fórmula: Cuota = (Área × TarifaM2) + CargoFijo
        /// Fondo  = Cuota × 10 %
        /// </summary>
        private void nudArea_ValueChanged(object sender, EventArgs e)
        {
            decimal cuota = (nudArea.Value * _tarifaPorM2) + _cargoFijo;
            decimal fondo = cuota * PORCENTAJE_FONDO_RESERVA;

            txtCuotaColones.Text  = $"₡ {cuota:N2}";
            txtFondoReserva.Text  = $"₡ {fondo:N2}";
            txtCuotaDolares.Text  = "$ —";   // Requiere conversión explícita
        }

        /// <summary>
        /// Convierte la cuota actual a dólares usando el tipo de cambio BCCR (venta).
        /// </summary>
        private void btnConvertirDolar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal cuotaColones = ObtenerCuotaActual();

                if (cuotaColones <= 0)
                {
                    MostrarAviso("Ingrese el área primero para calcular la cuota.");
                    return;
                }

                btnConvertirDolar.Enabled = false;
                btnConvertirDolar.Text    = "...";

                decimal dolares = _bccrService.ConvertirColonesADolares(cuotaColones);
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
                btnConvertirDolar.Text    = "⟳ Convertir";
            }
        }

        /// <summary>Extrae el valor numérico de txtCuotaColones.</summary>
        private decimal ObtenerCuotaActual()
        {
            string raw = txtCuotaColones.Text.Replace("₡", "").Replace(",", "").Trim();
            return decimal.TryParse(raw, out decimal valor) ? valor : 0m;
        }

        // ═════════════════════════════════════════════════════════════
        // BÚSQUEDA
        // ═════════════════════════════════════════════════════════════

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
                    MostrarAviso("No se encontró ninguna propiedad con el código \"" + codigo + "\".");
                    return;
                }

                CargarEnFormulario(propiedad);

                // Filtrar grid para mostrar solo el resultado
                dgvPropiedades.DataSource = new List<PropiedadDTO> { propiedad };
                ActualizarInfo(1);
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        /// <summary>Permite buscar presionando Enter en el campo de búsqueda.</summary>
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

        // ── Clic en fila del grid → carga el formulario ───────────────
        private void dgvPropiedades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                string codigo = dgvPropiedades.Rows[e.RowIndex]
                                              .Cells["Codigo"].Value?.ToString();

                if (string.IsNullOrEmpty(codigo)) return;

                PropiedadDTO propiedad = _propiedadBLL.ObtenerPorCodigo(codigo);

                if (propiedad != null)
                    CargarEnFormulario(propiedad);
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        // ── Poblar formulario con datos de una propiedad ──────────────
        private void CargarEnFormulario(PropiedadDTO p)
        {
            _idPropiedadSeleccionada = p.IdPropiedad;

            txtCodigo.Text              = p.Codigo;
            txtDireccion.Text           = p.Direccion;
            nudResidentes.Value         = p.CantidadResidentes;
            nudArea.Value               = p.Area;          // dispara nudArea_ValueChanged

            cmbTipo.SelectedItem        = null;
            if (Enum.TryParse(p.Tipo, out TipoPropiedad tipo))
                cmbTipo.SelectedItem = tipo;

            cmbPropietario.SelectedValue = p.IdPropietario;

            // Estado: se determina desde el módulo de Morosidad;
            // aquí solo mostramos un indicador visual básico.
            MostrarEstado(p.CuotaMantenimiento > 0);
        }

        /// <summary>Muestra el badge de estado morosa / al día.</summary>
        private void MostrarEstado(bool tieneRegistro)
        {
            // La lógica real de morosidad vive en IndicadorMorosidadBLL.
            // Aquí solo mostramos si la propiedad tiene cuota asignada.
            if (!tieneRegistro)
            {
                lblEstadoValor.BackColor = Color.FromArgb(100, 120, 140);
                lblEstadoValor.Text      = "Sin datos";
            }
            else
            {
                // Para el estado real de morosidad conectar con IndicadorMorosidadBLL
                lblEstadoValor.BackColor = Color.FromArgb(39, 174, 96);
                lblEstadoValor.Text      = "✔ Al día";
            }
        }

        // ═════════════════════════════════════════════════════════════
        // CRUD
        // ═════════════════════════════════════════════════════════════

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
                propiedad.IdPropiedad  = _idPropiedadSeleccionada;

                bool ok = _propiedadBLL.Modificar(propiedad);

                if (ok)
                {
                    MostrarExito("La propiedad fue actualizada correctamente.");
                    LimpiarFormulario();
                    CargarTodas();
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
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "El reporte de propiedades se genera desde el módulo de Reportes.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ═════════════════════════════════════════════════════════════
        // HELPERS PRIVADOS
        // ═════════════════════════════════════════════════════════════

        /// <summary>Construye un PropiedadDTO con los datos actuales del formulario.</summary>
        private PropiedadDTO ConstruirDTO()
        {
            return new PropiedadDTO
            {
                Codigo              = txtCodigo.Text.Trim(),
                Tipo                = cmbTipo.SelectedItem?.ToString(),
                Direccion           = txtDireccion.Text.Trim(),
                Area                = nudArea.Value,
                CantidadResidentes  = (int)nudResidentes.Value,
                TarifaMetro         = _tarifaPorM2,
                CargoFijo           = _cargoFijo,
                CuotaMantenimiento  = ObtenerCuotaActual(),
                IdPropietario       = Convert.ToInt32(cmbPropietario.SelectedValue)
            };
        }

        /// <summary>Lanza excepción si falta algún campo obligatorio.</summary>
        private void ValidarCamposObligatorios()
        {
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

        /// <summary>Restablece el formulario a su estado inicial.</summary>
        private void LimpiarFormulario()
        {
            _idPropiedadSeleccionada = 0;

            txtCodigo.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();

            nudArea.Value       = 0;
            nudResidentes.Value = 0;

            txtCuotaColones.Text = "₡ 0.00";
            txtCuotaDolares.Text = "$ —";
            txtFondoReserva.Text = "₡ 0.00";

            cmbTipo.SelectedIndex       = -1;
            cmbPropietario.SelectedIndex = -1;

            lblEstadoValor.BackColor = Color.FromArgb(100, 120, 140);
            lblEstadoValor.Text      = "Sin datos";

            dgvPropiedades.ClearSelection();
            txtCodigo.Focus();
        }

        // ── Mensajes estandarizados ───────────────────────────────────
        private void MostrarExito(string mensaje) =>
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void MostrarAviso(string mensaje) =>
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarError(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
