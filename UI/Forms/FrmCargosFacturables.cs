using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Util.Enumeraciones;

namespace UI.Forms
{
    public partial class FrmCargosFacturables : Form
    {
        private readonly CargoFacturableBLL _cargoBLL     = new CargoFacturableBLL();
        private readonly PropiedadBLL       _propiedadBLL = new PropiedadBLL();
        private readonly FacturaBLL         _facturaBLL   = new FacturaBLL();

        private CargoFacturableDTO _cargoSeleccionado = null;
        private bool _modoEdicion = false;
        private List<CargoFacturableDTO> _cargos = new List<CargoFacturableDTO>();
        private bool _cargandoFiltros;

        public FrmCargosFacturables()
        {
            InitializeComponent();
        }

        // ── CARGA ─────────────────────────────────────────────────────

        private void FrmCargosFacturables_Load(object sender, EventArgs e)
        {
            CargarTiposCargo();
            CargarPropiedades();
            CargarFiltros();
            LimpiarFormulario();
            CargarCargos();
        }

        private void CargarTiposCargo()
        {
            cmbTipo.Items.Clear();
            // Solo tipos manuales — la cuota ordinaria se genera desde FrmGenerarCuota
            cmbTipo.Items.Add(TipoCargo.Multa.ToString());
            cmbTipo.Items.Add(TipoCargo.CuotaExtraordinaria.ToString());
            cmbTipo.Items.Add(TipoCargo.Reserva.ToString());
            cmbTipo.SelectedIndex = 0;
        }

        private void CargarPropiedades()
        {
            List<PropiedadDTO> lista = _propiedadBLL.ObtenerTodas();
            cmbPropiedad.DataSource    = lista;
            cmbPropiedad.DisplayMember = "Codigo";
            cmbPropiedad.ValueMember   = "IdPropiedad";
        }

        private void CargarCargos()
        {
            _cargos = _cargoBLL.ObtenerTodos() ?? new List<CargoFacturableDTO>();
            FormatearGrid();
            AplicarFiltros();
        }

        private void CargarFiltros()
        {
            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Vencido", "Pagado" });
            cmbFiltroEstado.Items.Add("Anulado");
            cmbFiltroEstado.SelectedIndex = 0;

            cmbFiltroPropiedad.Items.Clear();
            cmbFiltroPropiedad.Items.Add(new FiltroPropiedad(0, "Todas las propiedades"));
            foreach (PropiedadDTO p in (List<PropiedadDTO>)cmbPropiedad.DataSource)
                cmbFiltroPropiedad.Items.Add(new FiltroPropiedad(p.IdPropiedad, p.Codigo));
            cmbFiltroPropiedad.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            if (_cargandoFiltros) return;
            string buscar = txtBuscar.Text.Trim();
            string estado = cmbFiltroEstado.SelectedItem == null ? "Todos" : cmbFiltroEstado.SelectedItem.ToString();
            FiltroPropiedad propiedad = cmbFiltroPropiedad.SelectedItem as FiltroPropiedad;
            IEnumerable<CargoFacturableDTO> consulta = _cargos;

            if (!string.IsNullOrWhiteSpace(buscar))
                consulta = consulta.Where(c => (c.Descripcion ?? "").IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.Tipo ?? "").IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ObtenerCodigoPropiedad(c.IdPropiedad).IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0);
            if (propiedad != null && propiedad.Id > 0)
                consulta = consulta.Where(c => c.IdPropiedad == propiedad.Id);
            if (estado == "Pendiente")
                consulta = consulta.Where(c => c.Estado == "Pendiente" && c.FechaVencimiento.Date >= DateTime.Today);
            else if (estado == "Vencido")
                consulta = consulta.Where(c => c.Estado == "Vencido" ||
                    (c.Estado == "Pendiente" && c.FechaVencimiento.Date < DateTime.Today));
            else if (estado == "Pagado")
                consulta = consulta.Where(c => c.Estado == "Pagado");
            else if (estado == "Anulado")
                consulta = consulta.Where(c => c.Estado == "Anulado");

            List<CargoVista> resultado = consulta.OrderByDescending(c => c.FechaEmision)
                .Select(c => new CargoVista(c, ObtenerCodigoPropiedad(c.IdPropiedad))).ToList();
            dgvCargos.DataSource = resultado;
            dgvCargos.ClearSelection();
            _cargoSeleccionado = null;
            ActualizarBotones();
            lblResultados.Text = resultado.Count + " cargo(s) encontrado(s)";
            lblPendientesValor.Text = resultado.Count(x => x.Cargo.Estado == "Pendiente").ToString();
            lblVencidosValor.Text = resultado.Count(x => x.Estado == "Vencido").ToString();
            lblTotalValor.Text = resultado.Where(x => x.Cargo.Estado == "Pendiente").Sum(x => x.Total)
                .ToString("C2", CultureInfo.GetCultureInfo("es-CR"));
        }

        private string ObtenerCodigoPropiedad(int id)
        {
            List<PropiedadDTO> propiedades = cmbPropiedad.DataSource as List<PropiedadDTO>;
            PropiedadDTO p = propiedades == null ? null : propiedades.FirstOrDefault(x => x.IdPropiedad == id);
            return p == null ? id.ToString() : p.Codigo;
        }

        // ── NUEVO ──────────────────────────────────────────────────────

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _modoEdicion = false;
            lblModo.Text = "NUEVO CARGO";
            lblModo.BackColor = Color.FromArgb(22, 163, 74);
            btnGuardar.Text = "Guardar cargo";
            txtDescripcion.Focus();
        }

        // ── GUARDAR ───────────────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                CargoFacturableDTO cargo = ObtenerDatosFormulario();

                if (_modoEdicion && _cargoSeleccionado != null)
                {
                    cargo.IdCargo = _cargoSeleccionado.IdCargo;
                    _cargoBLL.Modificar(cargo);
                    MessageBox.Show("Cargo modificado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CargoFacturableDTO guardado = _cargoBLL.RegistrarManual(cargo);

                    // El cargo ya existe: mostrarlo inmediatamente. La generación
                    // de la factura es un proceso posterior y no debe impedir que
                    // la lista refleje el registro recién guardado.
                    CargarCargos();

                    // Preguntar si desea generar factura inmediatamente
                    DialogResult gen = MessageBox.Show(
                        "¿Desea generar la factura para este cargo ahora?",
                        "Generar factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (gen == DialogResult.Yes)
                    {
                        PropiedadDTO prop = (PropiedadDTO)cmbPropiedad.SelectedItem;
                        FacturaDTO factura = _facturaBLL.GenerarFacturaManual(guardado, prop.Codigo);
                        MessageBox.Show(
                            $"Factura #{factura.IdFactura} generada.\n" +
                            $"Total: ₡{factura.TotalColones:N2}  |  ${factura.TotalDolares:N2}",
                            "Factura emitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cargo registrado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LimpiarFormulario();
                CargarCargos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── EDITAR ────────────────────────────────────────────────────

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_cargoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cargo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cargoSeleccionado.Estado == "Pagado")
            {
                MessageBox.Show("No se puede editar un cargo ya pagado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarDatosEnFormulario(_cargoSeleccionado);
            _modoEdicion = true;
            lblModo.Text = "EDITANDO CARGO #" + _cargoSeleccionado.IdCargo;
            lblModo.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.Text = "Guardar cambios";
            txtDescripcion.Focus();
        }

        // ── ELIMINAR ──────────────────────────────────────────────────

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion("eliminar")) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar el cargo: {_cargoSeleccionado.Descripcion}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool eliminado = _cargoBLL.Eliminar(_cargoSeleccionado.IdCargo);
                if (!eliminado)
                    throw new Exception("No se modificó ningún cargo. Actualice la lista e inténtelo nuevamente.");

                MessageBox.Show(
                    "El cargo fue eliminado correctamente.\n\n" +
                    "Si ya estaba incluido en una factura, se conserva como Anulado para no perder el historial.",
                    "Operación realizada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarCargos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── MARCAR COMO PAGADO ────────────────────────────────────────

        private void btnMarcarPagado_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion("marcar como pagado")) return;

            if (MessageBox.Show("¿Confirma el pago del cargo #" + _cargoSeleccionado.IdCargo +
                " por " + _cargoSeleccionado.Total.ToString("C2", CultureInfo.GetCultureInfo("es-CR")) + "?",
                "Confirmar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _cargoBLL.MarcarComoPagado(_cargoSeleccionado.IdCargo);
                MessageBox.Show("Cargo marcado como pagado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCargos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            try
            {
                CargarCargos();
                lblSeleccion.Text = "Lista actualizada: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la lista: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion("cambiar el estado")) return;
            if (cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nuevo estado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoEstado = cmbNuevoEstado.SelectedItem.ToString();
            if (_cargoSeleccionado.Estado == "Pagado")
            {
                MessageBox.Show("Un cargo pagado no puede cambiarse manualmente.", "Operación no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nuevoEstado == _cargoSeleccionado.Estado)
            {
                MessageBox.Show("El cargo ya tiene ese estado.", "Sin cambios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nuevoEstado == "Pagado")
            {
                btnMarcarPagado_Click(sender, e);
                return;
            }

            if (MessageBox.Show("¿Cambiar el cargo #" + _cargoSeleccionado.IdCargo + " de " +
                _cargoSeleccionado.Estado + " a " + nuevoEstado + "?", "Confirmar cambio",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                CargoFacturableDTO actualizado = new CargoFacturableDTO
                {
                    IdCargo = _cargoSeleccionado.IdCargo,
                    Descripcion = _cargoSeleccionado.Descripcion,
                    Tipo = _cargoSeleccionado.Tipo,
                    MontoBase = _cargoSeleccionado.MontoBase,
                    FechaEmision = _cargoSeleccionado.FechaEmision,
                    FechaVencimiento = _cargoSeleccionado.FechaVencimiento,
                    IdPropiedad = _cargoSeleccionado.IdPropiedad,
                    Estado = nuevoEstado
                };

                if (!_cargoBLL.Modificar(actualizado))
                    throw new Exception("No se modificó ningún registro.");

                MessageBox.Show("Estado actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCargos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CANCELAR ─────────────────────────────────────────────────

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // ── SELECCIÓN EN GRID ─────────────────────────────────────────

        private void dgvCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            CargoVista vista = dgvCargos.Rows[e.RowIndex].DataBoundItem as CargoVista;
            _cargoSeleccionado = vista == null ? null : vista.Cargo;
            ActualizarBotones();
            lblSeleccion.Text = _cargoSeleccionado == null ? "Seleccione una fila para habilitar sus acciones." :
                "Seleccionado: cargo #" + _cargoSeleccionado.IdCargo + " · " + _cargoSeleccionado.Descripcion;
        }

        // ── HELPERS ──────────────────────────────────────────────────

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPropiedad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una propiedad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPropiedad.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontoBase.Text.Trim(), out decimal m) || m <= 0)
            {
                MessageBox.Show("Ingrese un monto base válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpVencimiento.Value <= dtpEmision.Value)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior a la de emisión.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private CargoFacturableDTO ObtenerDatosFormulario()
        {
            PropiedadDTO prop = (PropiedadDTO)cmbPropiedad.SelectedItem;

            return new CargoFacturableDTO
            {
                Descripcion      = txtDescripcion.Text.Trim(),
                Tipo             = cmbTipo.SelectedItem.ToString(),
                MontoBase        = decimal.Parse(txtMontoBase.Text.Trim()),
                FechaEmision     = dtpEmision.Value,
                FechaVencimiento = dtpVencimiento.Value,
                IdPropiedad      = prop.IdPropiedad,
                // En edición se conserva el estado actual. En un registro nuevo
                // la BLL lo inicializa como Pendiente.
                Estado = _modoEdicion && _cargoSeleccionado != null
                    ? _cargoSeleccionado.Estado
                    : "Pendiente"
            };
        }

        private void CargarDatosEnFormulario(CargoFacturableDTO c)
        {
            txtDescripcion.Text      = c.Descripcion;
            cmbTipo.SelectedItem     = c.Tipo;
            txtMontoBase.Text        = c.MontoBase.ToString("F2");
            dtpEmision.Value         = c.FechaEmision;
            dtpVencimiento.Value     = c.FechaVencimiento;

            // Seleccionar propiedad en combo
            foreach (PropiedadDTO p in (List<PropiedadDTO>)cmbPropiedad.DataSource)
            {
                if (p.IdPropiedad == c.IdPropiedad)
                {
                    cmbPropiedad.SelectedItem = p;
                    break;
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtDescripcion.Text   = "";
            txtMontoBase.Text     = "";
            cmbTipo.SelectedIndex = 0;
            dtpEmision.Value      = DateTime.Now;
            dtpVencimiento.Value  = DateTime.Now.AddDays(30);
            _cargoSeleccionado    = null;
            _modoEdicion          = false;
            btnEditar.Enabled = btnEliminar.Enabled = btnMarcarPagado.Enabled = false;
            btnCambiarEstado.Enabled = false;
            cmbNuevoEstado.Enabled = false;
            cmbNuevoEstado.SelectedIndex = 0;
            lblModo.Text = "NUEVO CARGO";
            lblModo.BackColor = Color.FromArgb(22, 163, 74);
            btnGuardar.Text = "Guardar cargo";
            lblSeleccion.Text = "Seleccione una fila para habilitar sus acciones.";
            ActualizarVistaPrevia();
        }

        private void ActualizarBotones()
        {
            bool editable = _cargoSeleccionado != null &&
                _cargoSeleccionado.Estado != "Pagado" && _cargoSeleccionado.Estado != "Anulado";
            btnEditar.Enabled = editable;
            btnEliminar.Enabled = editable;
            btnMarcarPagado.Enabled = editable;
            btnCambiarEstado.Enabled = editable;
            cmbNuevoEstado.Enabled = editable;

            if (_cargoSeleccionado != null)
            {
                string estadoVisible = _cargoSeleccionado.Estado == "Pendiente" &&
                    _cargoSeleccionado.FechaVencimiento.Date < DateTime.Today ? "Vencido" : _cargoSeleccionado.Estado;
                cmbNuevoEstado.SelectedItem = estadoVisible;
            }
        }

        private bool ValidarSeleccion(string accion)
        {
            if (_cargoSeleccionado != null) return true;
            MessageBox.Show("Seleccione una fila antes de " + accion + ".", "Seleccione un cargo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void FiltroCambiado(object sender, EventArgs e) { AplicarFiltros(); }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _cargandoFiltros = true;
            txtBuscar.Clear();
            cmbFiltroPropiedad.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;
            _cargandoFiltros = false;
            AplicarFiltros();
        }

        private void CampoCalculoCambiado(object sender, EventArgs e) { ActualizarVistaPrevia(); }

        private void ActualizarVistaPrevia()
        {
            decimal monto;
            if (!decimal.TryParse(txtMontoBase.Text.Trim(), out monto) || monto < 0) monto = 0;
            string tipo = cmbTipo.SelectedItem == null ? "" : cmbTipo.SelectedItem.ToString();
            decimal iva = tipo == TipoCargo.CuotaExtraordinaria.ToString() ? monto * 0.13m : 0m;
            lblBaseValor.Text = monto.ToString("C2", CultureInfo.GetCultureInfo("es-CR"));
            lblIvaValor.Text = iva.ToString("C2", CultureInfo.GetCultureInfo("es-CR"));
            lblVistaTotalValor.Text = (monto + iva).ToString("C2", CultureInfo.GetCultureInfo("es-CR"));
            lblNotaIva.Text = iva > 0 ? "Incluye IVA del 13 %." : "Este tipo de cargo no aplica IVA.";
        }

        private void FormatearGrid()
        {
            if (dgvCargos.Columns.Count == 0) return;

            dgvCargos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCargos.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvCargos.ReadOnly            = true;
            dgvCargos.MultiSelect         = false;

            if (dgvCargos.Columns["IdCargo"]          != null) dgvCargos.Columns["IdCargo"].HeaderText = "ID";
            if (dgvCargos.Columns["Descripcion"]      != null) dgvCargos.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvCargos.Columns["Tipo"]             != null) dgvCargos.Columns["Tipo"].HeaderText = "Tipo";
            if (dgvCargos.Columns["MontoBase"]        != null) { dgvCargos.Columns["MontoBase"].HeaderText = "Monto base"; dgvCargos.Columns["MontoBase"].DefaultCellStyle.Format = "N2"; }
            if (dgvCargos.Columns["IVA"]              != null) { dgvCargos.Columns["IVA"].HeaderText = "IVA"; dgvCargos.Columns["IVA"].DefaultCellStyle.Format = "N2"; }
            if (dgvCargos.Columns["Total"]            != null) { dgvCargos.Columns["Total"].HeaderText = "Total"; dgvCargos.Columns["Total"].DefaultCellStyle.Format = "N2"; }
            if (dgvCargos.Columns["FechaEmision"]     != null) { dgvCargos.Columns["FechaEmision"].HeaderText = "Emisión"; dgvCargos.Columns["FechaEmision"].DefaultCellStyle.Format = "dd/MM/yyyy"; }
            if (dgvCargos.Columns["FechaVencimiento"] != null) { dgvCargos.Columns["FechaVencimiento"].HeaderText = "Vencimiento"; dgvCargos.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy"; }
            if (dgvCargos.Columns["Estado"]           != null) dgvCargos.Columns["Estado"].HeaderText = "Estado";
            if (dgvCargos.Columns["Cargo"] != null) dgvCargos.Columns["Cargo"].Visible = false;
        }

        private void dgvCargos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCargos.Columns[e.ColumnIndex].DataPropertyName != "Estado" || e.Value == null) return;
            string estado = e.Value.ToString();
            e.CellStyle.Font = new Font(dgvCargos.Font, FontStyle.Bold);
            e.CellStyle.ForeColor = estado == "Pagado" ? Color.ForestGreen :
                estado == "Vencido" ? Color.Firebrick : Color.DarkGoldenrod;
        }

        private sealed class FiltroPropiedad
        {
            public int Id { get; private set; }
            private string Texto { get; set; }
            public FiltroPropiedad(int id, string texto) { Id = id; Texto = texto; }
            public override string ToString() { return Texto; }
        }

        private sealed class CargoVista
        {
            public CargoFacturableDTO Cargo { get; private set; }
            public int IdCargo { get { return Cargo.IdCargo; } }
            public string Descripcion { get { return Cargo.Descripcion; } }
            public string Tipo { get { return Cargo.Tipo; } }
            public string Propiedad { get; private set; }
            public decimal MontoBase { get { return Cargo.MontoBase; } }
            public decimal IVA { get { return Cargo.IVA; } }
            public decimal Total { get { return Cargo.Total; } }
            public DateTime FechaEmision { get { return Cargo.FechaEmision; } }
            public DateTime FechaVencimiento { get { return Cargo.FechaVencimiento; } }
            public string Estado { get { return Cargo.Estado == "Pendiente" && Cargo.FechaVencimiento.Date < DateTime.Today ? "Vencido" : Cargo.Estado; } }
            public CargoVista(CargoFacturableDTO cargo, string propiedad) { Cargo = cargo; Propiedad = propiedad; }
        }
    }
}
