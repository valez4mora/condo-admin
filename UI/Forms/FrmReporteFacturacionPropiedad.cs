using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmReporteFacturacionPropiedad : Form
    {
        private readonly ReporteBLL _reporteBLL = new ReporteBLL();
        private readonly PropiedadBLL _propiedadBLL = new PropiedadBLL();
        private List<ReporteFacturacionPropiedadDTO> _datos =
            new List<ReporteFacturacionPropiedadDTO>();

        public FrmReporteFacturacionPropiedad()
        {
            InitializeComponent();
            ConfigurarTarjetasResumen();
        }

        private void FrmReporteFacturacionPropiedad_Load(
            object sender,
            EventArgs e)
        {
            ConfigurarGrid();
            ConfigurarFiltros();
            CargarPropiedades();
        }

        private void ConfigurarGrid()
        {
            dgvFacturacion.AutoGenerateColumns = false;
            dgvFacturacion.Columns.Clear();

            dgvFacturacion.Columns.Add(
                CrearColumna("TipoCargo", "Tipo de cargo", 145));

            DataGridViewTextBoxColumn descripcion = CrearColumna(
                "Descripcion", "Descripción", 220);
            descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descripcion.MinimumWidth = 190;
            dgvFacturacion.Columns.Add(descripcion);

            dgvFacturacion.Columns.Add(
                CrearColumnaMoneda("MontoBase", "Monto base", 115));
            dgvFacturacion.Columns.Add(
                CrearColumnaMoneda("Impuesto", "IVA", 100));
            dgvFacturacion.Columns.Add(
                CrearColumnaMoneda("Total", "Total", 120));

            DataGridViewTextBoxColumn estado =
                CrearColumna("Estado", "Estado", 105);
            estado.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvFacturacion.Columns.Add(estado);

            DataGridViewTextBoxColumn emision =
                CrearColumna("FechaEmision", "Emisión", 105);
            emision.DefaultCellStyle.Format = "dd/MM/yyyy";
            emision.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvFacturacion.Columns.Add(emision);

            DataGridViewTextBoxColumn vencimiento =
                CrearColumna("FechaVencimiento", "Vencimiento", 110);
            vencimiento.DefaultCellStyle.Format = "dd/MM/yyyy";
            vencimiento.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvFacturacion.Columns.Add(vencimiento);
        }

        private DataGridViewTextBoxColumn CrearColumna(
            string propiedad, string titulo, int ancho)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = propiedad,
                HeaderText = titulo,
                Name = "col" + propiedad,
                Width = ancho,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
        }

        private DataGridViewTextBoxColumn CrearColumnaMoneda(
            string propiedad, string titulo, int ancho)
        {
            DataGridViewTextBoxColumn columna =
                CrearColumna(propiedad, titulo, ancho);
            columna.DefaultCellStyle.Format = "C2";
            columna.DefaultCellStyle.FormatProvider =
                CultureInfo.GetCultureInfo("es-CR");
            columna.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            return columna;
        }

        private void ConfigurarFiltros()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[]
            {
                "Todos los estados",
                "Pendiente",
                "Vencido",
                "Pagado",
                "Anulado"
            });
            cmbEstado.SelectedIndex = 0;

            dtpDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            chkUsarFechas.Checked = false;
            ActualizarEstadoFechas();
        }

        private void CargarPropiedades()
        {
            try
            {
                List<PropiedadDTO> propiedades = _propiedadBLL.ObtenerTodas()
                    .OrderBy(p => p.Codigo)
                    .ToList();

                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.SelectedIndex = propiedades.Count > 0 ? 0 : -1;

                btnGenerar.Enabled = propiedades.Count > 0;

                if (propiedades.Count > 0)
                    CargarReporte();
                else
                    MostrarSinPropiedades();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar las propiedades.", ex);
            }
        }

        private void CargarReporte()
        {
            try
            {
                if (cmbPropiedad.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una propiedad.",
                        "Facturación por propiedad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (chkUsarFechas.Checked && dtpDesde.Value.Date > dtpHasta.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha inicial no puede ser posterior a la fecha final.",
                        "Rango de fechas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    dtpDesde.Focus();
                    return;
                }

                CambiarEstadoCarga(true);

                int idPropiedad = Convert.ToInt32(cmbPropiedad.SelectedValue);
                DateTime? desde = chkUsarFechas.Checked
                    ? (DateTime?)dtpDesde.Value.Date : null;
                DateTime? hasta = chkUsarFechas.Checked
                    ? (DateTime?)dtpHasta.Value.Date : null;

                _datos = _reporteBLL.ObtenerFacturacionPorPropiedad(
                    idPropiedad, desde, hasta)
                    ?? new List<ReporteFacturacionPropiedadDTO>();

                AplicarFiltrosLocales();

                lblPropiedadSeleccionada.Text =
                    "Propiedad: " + cmbPropiedad.Text;
                lblActualizado.Text = "Actualizado: " +
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                _datos = new List<ReporteFacturacionPropiedadDTO>();
                dgvFacturacion.DataSource = null;
                ActualizarResumen(_datos);
                MostrarError("No se pudo generar el reporte.", ex);
            }
            finally
            {
                CambiarEstadoCarga(false);
            }
        }

        private void AplicarFiltrosLocales()
        {
            string texto = txtBuscar.Text.Trim();
            string estado = cmbEstado.SelectedItem == null
                ? "Todos los estados"
                : cmbEstado.SelectedItem.ToString();

            IEnumerable<ReporteFacturacionPropiedadDTO> consulta = _datos;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(x =>
                    Contiene(x.TipoCargo, texto) ||
                    Contiene(x.Descripcion, texto) ||
                    Contiene(x.Estado, texto));
            }

            if (estado != "Todos los estados")
            {
                consulta = consulta.Where(x => string.Equals(
                    x.Estado, estado,
                    StringComparison.CurrentCultureIgnoreCase));
            }

            List<ReporteFacturacionPropiedadDTO> resultado = consulta
                .OrderByDescending(x => x.FechaEmision)
                .ThenByDescending(x => x.IdCargo)
                .ToList();

            dgvFacturacion.DataSource = null;
            dgvFacturacion.DataSource = resultado;
            dgvFacturacion.ClearSelection();
            ActualizarResumen(resultado);
        }

        private bool Contiene(string valor, string busqueda)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.IndexOf(busqueda,
                       StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void ActualizarResumen(
            List<ReporteFacturacionPropiedadDTO> datos)
        {
            lblCargosValor.Text = datos.Count.ToString("N0");
            lblBaseValor.Text = FormatearMoneda(datos.Sum(x => x.MontoBase));
            lblIvaValor.Text = FormatearMoneda(datos.Sum(x => x.Impuesto));
            lblTotalValor.Text = FormatearMoneda(datos.Sum(x => x.Total));
            lblResultado.Text = datos.Count == 1
                ? "1 cargo facturable mostrado"
                : datos.Count + " cargos facturables mostrados";
            pnlSinDatos.Visible = datos.Count == 0;
            pnlSinDatos.BringToFront();
        }

        private string FormatearMoneda(decimal monto)
        {
            return monto.ToString("C2", CultureInfo.GetCultureInfo("es-CR"));
        }

        private void MostrarSinPropiedades()
        {
            _datos.Clear();
            dgvFacturacion.DataSource = null;
            lblPropiedadSeleccionada.Text = "No hay propiedades registradas";
            ActualizarResumen(_datos);
        }

        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnGenerar.Enabled = !cargando && cmbPropiedad.Items.Count > 0;
            btnActualizar.Enabled = !cargando;
            cmbPropiedad.Enabled = !cargando;
            if (cargando) lblResultado.Text = "Cargando facturación...";
        }

        private void ActualizarEstadoFechas()
        {
            dtpDesde.Enabled = chkUsarFechas.Checked;
            dtpHasta.Enabled = chkUsarFechas.Checked;
        }

        private void ConfigurarTarjetasResumen()
        {
            ConfigurarTarjeta(pnlCargos, lblCargosTitulo, lblCargosValor,
                "CARGOS EMITIDOS", Color.FromArgb(37, 99, 235));
            ConfigurarTarjeta(pnlBase, lblBaseTitulo, lblBaseValor,
                "MONTO BASE", Color.FromArgb(75, 85, 99));
            ConfigurarTarjeta(pnlIva, lblIvaTitulo, lblIvaValor,
                "IVA TOTAL", Color.FromArgb(217, 119, 6));
            ConfigurarTarjeta(pnlTotal, lblTotalTitulo, lblTotalValor,
                "TOTAL FACTURADO", Color.FromArgb(5, 150, 105));
        }

        private void ConfigurarTarjeta(
            Panel panel, Label titulo, Label valor,
            string textoTitulo, Color color)
        {
            panel.BackColor = Color.White;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(0, 0, 12, 0);
            panel.Padding = new Padding(16, 10, 12, 8);
            titulo.Dock = DockStyle.Top;
            titulo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(107, 114, 128);
            titulo.Height = 24;
            titulo.Text = textoTitulo;
            valor.Dock = DockStyle.Fill;
            valor.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            valor.ForeColor = color;
            valor.Text = "0";
            valor.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void dgvFacturacion_CellFormatting(
            object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columna = dgvFacturacion.Columns[e.ColumnIndex].Name;
            if (columna == "colTotal" && e.Value != null)
            {
                e.CellStyle.Font = new Font(dgvFacturacion.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.FromArgb(5, 120, 87);
            }

            if (columna != "colEstado" || e.Value == null) return;
            e.CellStyle.Font = new Font(dgvFacturacion.Font, FontStyle.Bold);
            switch (e.Value.ToString())
            {
                case "Pagado":
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                    break;
                case "Vencido":
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                    break;
                case "Pendiente":
                    e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                    e.CellStyle.ForeColor = Color.FromArgb(161, 98, 7);
                    break;
                case "Anulado":
                    e.CellStyle.BackColor = Color.FromArgb(229, 231, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(75, 85, 99);
                    break;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e) { CargarReporte(); }
        private void btnActualizar_Click(object sender, EventArgs e) { CargarPropiedades(); }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { AplicarFiltrosLocales(); }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) { AplicarFiltrosLocales(); }
        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e) { ActualizarEstadoFechas(); }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbEstado.SelectedIndex = 0;
            chkUsarFechas.Checked = false;
            dtpDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            AplicarFiltrosLocales();
        }

        private void btnCerrar_Click(object sender, EventArgs e) { Close(); }

        private void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show(mensaje + "\n\n" + ex.Message,
                "Facturación por propiedad",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
