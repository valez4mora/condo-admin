using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms
{
    /// <summary>
    /// Formulario para registrar pagos contra facturas emitidas.
    /// Permite seleccionar la propiedad, ver las facturas pendientes
    /// y registrar el pago con método y referencia.
    /// </summary>
    public partial class FrmPagos : Form
    {
        private readonly PagoBLL          _pagoBLL         = new PagoBLL();
        private readonly FacturaBLL       _facturaBLL      = new FacturaBLL();
        private readonly PropiedadBLL     _propiedadBLL    = new PropiedadBLL();
        private readonly CargoFacturableBLL _cargoBLL      = new CargoFacturableBLL();

        private FacturaDTO _facturaSeleccionada = null;

        public FrmPagos()
        {
            InitializeComponent();
        }

        // ── CARGA ─────────────────────────────────────────────────────

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
            CargarMetodosPago();
            LimpiarFormulario();
        }

        private void CargarPropiedades()
        {
            List<PropiedadDTO> lista = _propiedadBLL.ObtenerTodas();
            cmbPropiedad.DataSource    = lista;
            cmbPropiedad.DisplayMember = "Codigo";
            cmbPropiedad.ValueMember   = "IdPropiedad";
            cmbPropiedad.SelectedIndex = -1;
        }

        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.Items.Add("Tarjeta de débito");
            cmbMetodoPago.Items.Add("Tarjeta de crédito");
            cmbMetodoPago.Items.Add("SINPE Móvil");
            cmbMetodoPago.SelectedIndex = 0;
        }

        // ── BUSCAR FACTURAS PENDIENTES ────────────────────────────────

        private void btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            if (cmbPropiedad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una propiedad.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PropiedadDTO prop = (PropiedadDTO)cmbPropiedad.SelectedItem;

            try
            {
                List<FacturaDTO> facturas = _facturaBLL.ObtenerPorPropiedad(prop.IdPropiedad);
                // Mostrar solo las Emitidas (pendientes de pago)
                List<FacturaDTO> pendientes = facturas.FindAll(f => f.Estado == "Emitida");

                dgvFacturasPendientes.DataSource = pendientes;
                FormatearGridFacturas();

                _facturaSeleccionada = null;
                LimpiarSeccionPago();

                if (pendientes.Count == 0)
                    MessageBox.Show("La propiedad no tiene facturas pendientes.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── SELECCIONAR FACTURA ───────────────────────────────────────

        private void dgvFacturasPendientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFacturasPendientes.CurrentRow == null) return;

            _facturaSeleccionada = dgvFacturasPendientes.CurrentRow.DataBoundItem as FacturaDTO;
            if (_facturaSeleccionada == null) return;

            // Prellenar el monto con el total de la factura
            txtMonto.Text = _facturaSeleccionada.TotalColones.ToString("F2");
            lblInfoFactura.Text =
                $"Factura #{_facturaSeleccionada.IdFactura}  |  " +
                $"Propiedad: {_facturaSeleccionada.CodigoPropiedad}  |  " +
                $"Total: ₡{_facturaSeleccionada.TotalColones:N2}";

            grpPago.Enabled = true;
        }

        // ── REGISTRAR PAGO ────────────────────────────────────────────

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una factura.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PagoDTO pago = new PagoDTO
            {
                IdFactura  = _facturaSeleccionada.IdFactura,
                Monto      = monto,
                FechaPago  = dtpFechaPago.Value,
                MetodoPago = cmbMetodoPago.SelectedItem.ToString(),
                Referencia = txtReferencia.Text.Trim()
            };

            try
            {
                bool ok = _pagoBLL.Registrar(pago);
                if (!ok)
                {
                    MessageBox.Show("No se pudo registrar el pago.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si el monto cubre el total, marcar la factura como pagada en los cargos
                // (la lógica de estado de factura puede extenderse aquí)
                MessageBox.Show("Pago registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar facturas pendientes
                btnBuscarFacturas_Click(sender, e);
                LimpiarSeccionPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── HISTORIAL DE PAGOS ────────────────────────────────────────

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null) return;

            try
            {
                List<PagoDTO> pagos = _pagoBLL.ObtenerPorFactura(_facturaSeleccionada.IdFactura);
                dgvHistorialPagos.DataSource = pagos;
                dgvHistorialPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── LIMPIAR ───────────────────────────────────────────────────

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbPropiedad.SelectedIndex    = -1;
            dgvFacturasPendientes.DataSource = null;
            _facturaSeleccionada          = null;
            LimpiarSeccionPago();
        }

        private void LimpiarSeccionPago()
        {
            txtMonto.Text         = "";
            txtReferencia.Text    = "";
            dtpFechaPago.Value    = DateTime.Now;
            cmbMetodoPago.SelectedIndex = 0;
            lblInfoFactura.Text   = "";
            grpPago.Enabled       = false;
            dgvHistorialPagos.DataSource = null;
        }

        // ── FORMATO GRID ──────────────────────────────────────────────

        private void FormatearGridFacturas()
        {
            if (dgvFacturasPendientes.Columns.Count == 0) return;

            dgvFacturasPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturasPendientes.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturasPendientes.ReadOnly            = true;
            dgvFacturasPendientes.MultiSelect         = false;

            if (dgvFacturasPendientes.Columns["IdFactura"]     != null) dgvFacturasPendientes.Columns["IdFactura"].HeaderText     = "N.° Factura";
            if (dgvFacturasPendientes.Columns["Fecha"]         != null)
            {
                dgvFacturasPendientes.Columns["Fecha"].HeaderText = "Fecha";
                dgvFacturasPendientes.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvFacturasPendientes.Columns["CodigoPropiedad"] != null) dgvFacturasPendientes.Columns["CodigoPropiedad"].HeaderText = "Propiedad";
            if (dgvFacturasPendientes.Columns["TotalColones"]  != null)
            {
                dgvFacturasPendientes.Columns["TotalColones"].HeaderText = "Total (₡)";
                dgvFacturasPendientes.Columns["TotalColones"].DefaultCellStyle.Format = "N2";
            }
            if (dgvFacturasPendientes.Columns["TotalDolares"]  != null)
            {
                dgvFacturasPendientes.Columns["TotalDolares"].HeaderText = "Total ($)";
                dgvFacturasPendientes.Columns["TotalDolares"].DefaultCellStyle.Format = "N2";
            }
            if (dgvFacturasPendientes.Columns["Estado"]        != null) dgvFacturasPendientes.Columns["Estado"].Visible = false;
            if (dgvFacturasPendientes.Columns["IdPropiedad"]   != null) dgvFacturasPendientes.Columns["IdPropiedad"].Visible = false;
            if (dgvFacturasPendientes.Columns["Detalles"]      != null) dgvFacturasPendientes.Columns["Detalles"].Visible = false;
        }
    }
}
