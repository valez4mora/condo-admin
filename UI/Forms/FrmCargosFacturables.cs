using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Util.Enumeraciones;

namespace UI.Forms
{
    /// <summary>
    /// Formulario CRUD para Cargos Facturables manuales
    /// (Multas, Cuotas Extraordinarias, Reservas).
    /// La generación automática de cuotas de mantenimiento
    /// se maneja en FrmGenerarCuota.
    /// </summary>
    public partial class FrmCargosFacturables : Form
    {
        private readonly CargoFacturableBLL _cargoBLL     = new CargoFacturableBLL();
        private readonly PropiedadBLL       _propiedadBLL = new PropiedadBLL();
        private readonly FacturaBLL         _facturaBLL   = new FacturaBLL();

        private CargoFacturableDTO _cargoSeleccionado = null;
        private bool _modoEdicion = false;

        public FrmCargosFacturables()
        {
            InitializeComponent();
        }

        // ── CARGA ─────────────────────────────────────────────────────

        private void FrmCargosFacturables_Load(object sender, EventArgs e)
        {
            CargarTiposCargo();
            CargarPropiedades();
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
            List<CargoFacturableDTO> lista = _cargoBLL.ObtenerTodos();
            dgvCargos.DataSource = lista;
            FormatearGrid();
        }

        // ── NUEVO ──────────────────────────────────────────────────────

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _modoEdicion = false;
            HabilitarFormulario(true);
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
                HabilitarFormulario(false);
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
            HabilitarFormulario(true);
        }

        // ── ELIMINAR ──────────────────────────────────────────────────

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_cargoSeleccionado == null) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar el cargo: {_cargoSeleccionado.Descripcion}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _cargoBLL.Eliminar(_cargoSeleccionado.IdCargo);
                MessageBox.Show("Cargo eliminado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCargos();
                LimpiarFormulario();
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
            if (_cargoSeleccionado == null) return;

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

        // ── CANCELAR ─────────────────────────────────────────────────

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(false);
        }

        // ── SELECCIÓN EN GRID ─────────────────────────────────────────

        private void dgvCargos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCargos.CurrentRow == null) return;
            _cargoSeleccionado = dgvCargos.CurrentRow.DataBoundItem as CargoFacturableDTO;

            bool esPendiente = _cargoSeleccionado?.Estado == "Pendiente";
            btnEditar.Enabled       = esPendiente;
            btnEliminar.Enabled     = esPendiente;
            btnMarcarPagado.Enabled = esPendiente;
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
                IdPropiedad      = prop.IdPropiedad
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
        }

        private void HabilitarFormulario(bool habilitar)
        {
            grpFormulario.Enabled = habilitar;
            btnNuevo.Enabled  = !habilitar;
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
            if (dgvCargos.Columns["IdPropiedad"]      != null) dgvCargos.Columns["IdPropiedad"].Visible = false;
            if (dgvCargos.Columns["Penalizado"]       != null) dgvCargos.Columns["Penalizado"].Visible = false;
        }

        private void grpFormulario_Enter(object sender, EventArgs e)
        {

        }
    }
}
