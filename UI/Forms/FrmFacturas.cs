using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Util.Factura;

namespace UI.Forms
{
    /// <summary>
    /// Formulario para consultar facturas, verlas en detalle,
    /// anularlas, exportar XML y enviarlas por correo.
    /// </summary>
    public partial class FrmFacturas : Form
    {
        private readonly FacturaBLL    _facturaBLL    = new FacturaBLL();
        private readonly PropiedadBLL  _propiedadBLL  = new PropiedadBLL();
        private FacturaDTO             _facturaSeleccionada = null;

        public FrmFacturas()
        {
            InitializeComponent();
        }

        // ── CARGA ─────────────────────────────────────────────────────

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
            CargarFacturas();
        }

        private void CargarPropiedades()
        {
            List<PropiedadDTO> propiedades = _propiedadBLL.ObtenerTodas();
            cmbPropiedad.DataSource    = propiedades;
            cmbPropiedad.DisplayMember = "Codigo";
            cmbPropiedad.ValueMember   = "IdPropiedad";
            cmbPropiedad.SelectedIndex = -1;
        }

        private void CargarFacturas(int idPropiedad = 0)
        {
            List<FacturaDTO> lista = idPropiedad > 0
                ? _facturaBLL.ObtenerPorPropiedad(idPropiedad)
                : _facturaBLL.ObtenerTodas();

            dgvFacturas.DataSource = lista;
            FormatearGrid();
            _facturaSeleccionada = null;
            LimpiarDetalle();
        }

        // ── FILTRAR ───────────────────────────────────────────────────

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cmbPropiedad.SelectedItem == null)
            {
                CargarFacturas();
                return;
            }

            PropiedadDTO prop = (PropiedadDTO)cmbPropiedad.SelectedItem;
            CargarFacturas(prop.IdPropiedad);
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cmbPropiedad.SelectedIndex = -1;
            CargarFacturas();
        }

        // ── SELECCIÓN EN GRID ─────────────────────────────────────────

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null) return;

            _facturaSeleccionada = dgvFacturas.CurrentRow.DataBoundItem as FacturaDTO;
            if (_facturaSeleccionada == null) return;

            // Cargar detalle completo (con líneas)
            _facturaSeleccionada = _facturaBLL.ObtenerPorId(_facturaSeleccionada.IdFactura);
            MostrarDetalle(_facturaSeleccionada);
        }

        private void MostrarDetalle(FacturaDTO f)
        {
            lblIdFactura.Text    = f.IdFactura.ToString();
            lblFecha.Text        = f.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblPropiedad.Text    = f.CodigoPropiedad;
            lblColones.Text      = f.TotalColones.ToString("N2");
            lblDolares.Text      = f.TotalDolares.ToString("N2");
            lblEstado.Text       = f.Estado;

            dgvDetalle.DataSource = f.Detalles;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Habilitar / deshabilitar botones según el estado
            bool esEmitida = f.Estado == "Emitida";
            btnAnular.Enabled      = esEmitida;
            btnExportarXml.Enabled = true;
            btnEnviarCorreo.Enabled = true;
        }

        private void LimpiarDetalle()
        {
            lblIdFactura.Text = lblFecha.Text = lblPropiedad.Text =
            lblColones.Text   = lblDolares.Text = lblEstado.Text = "";
            dgvDetalle.DataSource = null;
            btnAnular.Enabled = btnExportarXml.Enabled = btnEnviarCorreo.Enabled = false;
        }

        // ── ANULAR ────────────────────────────────────────────────────

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Desea anular la factura #{_facturaSeleccionada.IdFactura}?",
                "Confirmar anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _facturaBLL.AnularFactura(_facturaSeleccionada.IdFactura);
                MessageBox.Show("Factura anulada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── EXPORTAR XML ──────────────────────────────────────────────

        private void btnExportarXml_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null) return;

            try
            {
                string ruta = XmlFacturaUtil.GuardarEnArchivo(_facturaSeleccionada);
                MessageBox.Show($"XML guardado en:\n{ruta}",
                    "XML Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar XML: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── ENVIAR POR CORREO ─────────────────────────────────────────

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null) return;

            string email = txtEmailDestinatario.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Ingrese el correo electrónico del destinatario.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _facturaBLL.EnviarPorCorreo(_facturaSeleccionada, email);
                MessageBox.Show("Factura enviada correctamente a: " + email,
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── FORMATO GRID ──────────────────────────────────────────────

        private void FormatearGrid()
        {
            if (dgvFacturas.Columns.Count == 0) return;

            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.ReadOnly            = true;

            if (dgvFacturas.Columns["IdFactura"]     != null) dgvFacturas.Columns["IdFactura"].HeaderText     = "N.° Factura";
            if (dgvFacturas.Columns["Fecha"]         != null)
            {
                dgvFacturas.Columns["Fecha"].HeaderText = "Fecha";
                dgvFacturas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvFacturas.Columns["CodigoPropiedad"] != null) dgvFacturas.Columns["CodigoPropiedad"].HeaderText = "Propiedad";
            if (dgvFacturas.Columns["TotalColones"]  != null)
            {
                dgvFacturas.Columns["TotalColones"].HeaderText = "Total (₡)";
                dgvFacturas.Columns["TotalColones"].DefaultCellStyle.Format = "N2";
            }
            if (dgvFacturas.Columns["TotalDolares"]  != null)
            {
                dgvFacturas.Columns["TotalDolares"].HeaderText = "Total ($)";
                dgvFacturas.Columns["TotalDolares"].DefaultCellStyle.Format = "N2";
            }
            if (dgvFacturas.Columns["Estado"]        != null) dgvFacturas.Columns["Estado"].HeaderText = "Estado";
            if (dgvFacturas.Columns["IdPropiedad"]   != null) dgvFacturas.Columns["IdPropiedad"].Visible = false;
            if (dgvFacturas.Columns["Detalles"]      != null) dgvFacturas.Columns["Detalles"].Visible = false;
        }
    }
}
