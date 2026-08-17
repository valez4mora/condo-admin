using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Util.Factura;

namespace UI.Forms
{
    public partial class FrmFacturas : Form
    {
        private readonly FacturaBLL facturaBLL = new FacturaBLL();
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();
        private List<FacturaDTO> facturas = new List<FacturaDTO>();
        private FacturaDTO facturaSeleccionada;
        private bool cargando;

        public FrmFacturas() { InitializeComponent(); }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid(dgvFacturas);
            ConfigurarGrid(dgvDetalle);
            cmbEstado.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today.AddMonths(-3);
            dtpHasta.Value = DateTime.Today;
            CargarPropiedades();
            CargarFacturas();
        }

        private static void ConfigurarGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = true;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 38;
            grid.RowTemplate.Height = 34;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void CargarPropiedades()
        {
            try
            {
                cargando = true;
                List<PropiedadDTO> lista = propiedadBLL.ObtenerTodas().OrderBy(x => x.Codigo).ToList();
                lista.Insert(0, new PropiedadDTO { IdPropiedad = 0, Codigo = "Todas las propiedades" });
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.DataSource = lista;
                cmbPropiedad.SelectedIndex = 0;
            }
            catch (Exception ex) { MostrarError("No se pudieron cargar las propiedades.", ex); }
            finally { cargando = false; }
        }

        private void CargarFacturas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                cargando = true;
                facturas = facturaBLL.ObtenerTodas() ?? new List<FacturaDTO>();
                AplicarFiltros();
            }
            catch (Exception ex) { MostrarError("No se pudieron cargar las facturas.", ex); }
            finally { cargando = false; Cursor = Cursors.Default; }
        }

        private void AplicarFiltros()
        {
            IEnumerable<FacturaDTO> consulta = facturas;
            int idPropiedad = cmbPropiedad.SelectedValue is int ? (int)cmbPropiedad.SelectedValue : 0;
            string estado = cmbEstado.SelectedItem == null ? "Todos" : cmbEstado.SelectedItem.ToString();
            string texto = txtBuscar.Text.Trim();

            if (idPropiedad > 0) consulta = consulta.Where(x => x.IdPropiedad == idPropiedad);
            if (estado != "Todos") consulta = consulta.Where(x => string.Equals(x.Estado, estado, StringComparison.OrdinalIgnoreCase));
            if (chkFechas.Checked)
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
                consulta = consulta.Where(x => x.Fecha >= desde && x.Fecha <= hasta);
            }
            if (texto.Length > 0)
                consulta = consulta.Where(x => x.IdFactura.ToString().Contains(texto) ||
                    (!string.IsNullOrWhiteSpace(x.CodigoPropiedad) && x.CodigoPropiedad.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0));

            List<FacturaDTO> resultado = consulta.OrderByDescending(x => x.Fecha).ToList();
            cargando = true;
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = resultado;
            FormatearFacturas();
            lblResultados.Text = resultado.Count == 1 ? "1 factura encontrada" : resultado.Count + " facturas encontradas";
            facturaSeleccionada = null;
            LimpiarDetalle();
            cargando = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e) { AplicarFiltros(); }
        private void btnActualizar_Click(object sender, EventArgs e) { CargarFacturas(); }
        private void chkFechas_CheckedChanged(object sender, EventArgs e) { dtpDesde.Enabled = dtpHasta.Enabled = chkFechas.Checked; }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            AplicarFiltros();
            e.SuppressKeyPress = true;
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbPropiedad.SelectedIndex = cmbEstado.SelectedIndex = 0;
            chkFechas.Checked = false;
            AplicarFiltros();
        }

        private void btnEmitirPendientes_Click(object sender, EventArgs e)
        {
            FrmCargosFacturables form = new FrmCargosFacturables();
            if (MdiParent != null) form.MdiParent = MdiParent;
            form.FormClosed += (s, args) => CargarFacturas();
            form.Show();
        }

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgvFacturas.CurrentRow == null) return;
            FacturaDTO resumen = dgvFacturas.CurrentRow.DataBoundItem as FacturaDTO;
            if (resumen == null) return;
            try
            {
                facturaSeleccionada = facturaBLL.ObtenerPorId(resumen.IdFactura);
                if (facturaSeleccionada == null) throw new InvalidOperationException("La factura ya no existe.");
                MostrarDetalle(facturaSeleccionada);
            }
            catch (Exception ex) { facturaSeleccionada = null; LimpiarDetalle(); MostrarError("No se pudo cargar el detalle.", ex); }
        }

        private void MostrarDetalle(FacturaDTO f)
        {
            lblIdFactura.Text = "#" + f.IdFactura;
            lblFecha.Text = f.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblPropiedad.Text = string.IsNullOrWhiteSpace(f.CodigoPropiedad) ? "—" : f.CodigoPropiedad;
            lblColones.Text = "₡ " + f.TotalColones.ToString("N2");
            lblDolares.Text = "$ " + f.TotalDolares.ToString("N2");
            lblEstado.Text = f.Estado ?? "—";
            PintarEstado(f.Estado);
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = f.Detalles;
            FormatearDetalle();
            btnAnular.Enabled = string.Equals(f.Estado, "Emitida", StringComparison.OrdinalIgnoreCase);
            btnExportarXml.Enabled = btnExportarPdf.Enabled = btnEnviarCorreo.Enabled = txtEmailDestinatario.Enabled = true;
        }

        private void PintarEstado(string estado)
        {
            bool anulada = string.Equals(estado, "Anulada", StringComparison.OrdinalIgnoreCase);
            bool pagada = string.Equals(estado, "Pagada", StringComparison.OrdinalIgnoreCase);
            lblEstado.BackColor = anulada ? Color.FromArgb(254, 226, 226) : pagada ? Color.FromArgb(220, 252, 231) : Color.FromArgb(219, 234, 254);
            lblEstado.ForeColor = anulada ? Color.FromArgb(185, 28, 28) : pagada ? Color.FromArgb(21, 128, 61) : Color.FromArgb(29, 78, 216);
        }

        private void LimpiarDetalle()
        {
            lblIdFactura.Text = lblFecha.Text = lblPropiedad.Text = lblColones.Text = lblDolares.Text = "—";
            lblEstado.Text = "Sin selección";
            lblEstado.BackColor = Color.FromArgb(241, 245, 249);
            lblEstado.ForeColor = Color.FromArgb(71, 85, 105);
            dgvDetalle.DataSource = null;
            btnAnular.Enabled = btnExportarXml.Enabled = btnExportarPdf.Enabled = btnEnviarCorreo.Enabled = txtEmailDestinatario.Enabled = false;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (!HaySeleccion()) return;
            if (MessageBox.Show("¿Desea anular la factura #" + facturaSeleccionada.IdFactura + "?\n\nPermanecerá visible en el historial.", "Confirmar anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try { facturaBLL.AnularFactura(facturaSeleccionada.IdFactura); MessageBox.Show("Factura anulada correctamente.", "Factura actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information); CargarFacturas(); }
            catch (Exception ex) { MostrarError("No se pudo anular la factura.", ex); }
        }

        private void btnExportarXml_Click(object sender, EventArgs e)
        {
            if (!HaySeleccion()) return;
            try { string ruta = XmlFacturaUtil.GuardarEnArchivo(facturaSeleccionada); MessageBox.Show("XML descargado en:\n" + ruta, "XML de factura", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MostrarError("No se pudo descargar el XML.", ex); }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (!HaySeleccion()) return;
            try { string ruta = PdfFacturaUtil.GuardarEnArchivo(facturaSeleccionada); MessageBox.Show("PDF descargado en:\n" + ruta, "PDF de factura", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MostrarError("No se pudo descargar el PDF.", ex); }
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (!HaySeleccion()) return;
            string email = txtEmailDestinatario.Text.Trim();
            try { new MailAddress(email); }
            catch { MessageBox.Show("Ingrese un correo electrónico válido.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtEmailDestinatario.Focus(); return; }
            try { facturaBLL.EnviarPorCorreo(facturaSeleccionada, email); MessageBox.Show("Factura enviada a " + email + ".", "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MostrarError("No se pudo enviar la factura.", ex); }
        }

        private bool HaySeleccion()
        {
            if (facturaSeleccionada != null) return true;
            MessageBox.Show("Seleccione una factura de la lista.", "Factura requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void FormatearFacturas()
        {
            Columna(dgvFacturas, "IdFactura", "N.°", null);
            Columna(dgvFacturas, "Fecha", "Fecha de emisión", "dd/MM/yyyy HH:mm");
            Columna(dgvFacturas, "CodigoPropiedad", "Propiedad", null);
            Columna(dgvFacturas, "TotalColones", "Total (₡)", "N2");
            Columna(dgvFacturas, "TotalDolares", "Total ($)", "N2");
            Columna(dgvFacturas, "Estado", "Estado", null);
            Ocultar(dgvFacturas, "IdPropiedad", "Detalles", "XMLFactura");
        }

        private void FormatearDetalle()
        {
            Ocultar(dgvDetalle, "IdDetalle", "IdFactura", "IdCargo");
            Columna(dgvDetalle, "Descripcion", "Concepto", null);
            Columna(dgvDetalle, "Cantidad", "Cantidad", "N2");
            Columna(dgvDetalle, "Precio", "Precio unitario", "N2");
            Columna(dgvDetalle, "Subtotal", "Subtotal", "N2");
        }

        private static void Columna(DataGridView grid, string nombre, string titulo, string formato)
        {
            if (grid.Columns[nombre] == null) return;
            grid.Columns[nombre].HeaderText = titulo;
            if (!string.IsNullOrEmpty(formato)) grid.Columns[nombre].DefaultCellStyle.Format = formato;
        }

        private static void Ocultar(DataGridView grid, params string[] nombres)
        {
            foreach (string nombre in nombres) if (grid.Columns[nombre] != null) grid.Columns[nombre].Visible = false;
        }

        private static void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show(mensaje + "\n\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
