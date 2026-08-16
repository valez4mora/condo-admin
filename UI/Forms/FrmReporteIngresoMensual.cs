using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI.Forms
{
    public partial class FrmReporteIngresoMensual : Form
    {
        private readonly ReporteBLL reporteBLL = new ReporteBLL();
        private List<IngresoMensualDTO> datos = new List<IngresoMensualDTO>();
        private Chart chartIngresos;

        public FrmReporteIngresoMensual() { InitializeComponent(); }

        private void FrmReporteIngresoMensual_Load(object sender, EventArgs e)
        {
            nudAnio.Minimum = 2000;
            nudAnio.Maximum = DateTime.Now.Year + 1;
            nudAnio.Value = DateTime.Now.Year;
            ConfigurarGrafico();
            cmbMoneda.SelectedIndex = 0;
            CargarReporte();
        }

        private void ConfigurarGrafico()
        {
            chartIngresos = new Chart();
            chartIngresos.Dock = DockStyle.Fill;
            chartIngresos.BackColor = Color.White;
            chartIngresos.ChartAreas.Add(new ChartArea("Principal"));
            chartIngresos.Legends.Add(new Legend("Leyenda"));
            pnlGrafico.Controls.Add(chartIngresos);
            ChartArea area = chartIngresos.ChartAreas[0];
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(229, 231, 235);
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisX.Title = "Meses del año";
            area.AxisY.Title = "Total facturado";
        }

        private void CargarReporte()
        {
            try
            {
                CambiarEstadoCarga(true);
                datos = reporteBLL.ObtenerIngresosMensuales((int)nudAnio.Value) ?? new List<IngresoMensualDTO>();
                MostrarReporte();
                lblActualizado.Text = "Actualizado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                datos.Clear();
                MostrarReporte();
                MessageBox.Show("No se pudo generar el reporte.\n\n" + ex.Message,
                    "Ingresos mensuales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { CambiarEstadoCarga(false); }
        }

        private void MostrarReporte()
        {
            bool colones = cmbMoneda.SelectedIndex != 1;
            List<IngresoMensualDTO> meses = CompletarMeses(datos);
            chartIngresos.Series.Clear();
            Series serie = new Series(colones ? "Facturación en colones" : "Facturación en dólares")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(37, 99, 235),
                IsValueShownAsLabel = true,
                LabelFormat = "N0"
            };
            foreach (IngresoMensualDTO item in meses)
            {
                decimal valor = colones ? item.TotalColones : item.TotalDolares;
                serie.Points.AddXY(item.Mes.Substring(0, Math.Min(3, item.Mes.Length)), valor);
            }
            chartIngresos.Series.Add(serie);

            decimal total = meses.Sum(x => colones ? x.TotalColones : x.TotalDolares);
            IngresoMensualDTO mejor = meses.OrderByDescending(x => colones ? x.TotalColones : x.TotalDolares).First();
            string simbolo = colones ? "₡" : "$";
            lblTotalValor.Text = simbolo + total.ToString("N2");
            lblPromedioValor.Text = simbolo + (total / 12m).ToString("N2");
            lblMejorMesValor.Text = mejor.Mes + " · " + simbolo +
                (colones ? mejor.TotalColones : mejor.TotalDolares).ToString("N2");
            lblResultado.Text = "Facturación mensual de " + nudAnio.Value + " en " + cmbMoneda.Text.ToLower();

            dgvIngresos.DataSource = meses;
            FormatearGrid();
            pnlSinDatos.Visible = datos.Count == 0 || datos.All(x => x.TotalColones == 0 && x.TotalDolares == 0);
            if (pnlSinDatos.Visible) pnlSinDatos.BringToFront();
        }

        private List<IngresoMensualDTO> CompletarMeses(List<IngresoMensualDTO> origen)
        {
            CultureInfo cultura = CultureInfo.GetCultureInfo("es-CR");
            List<IngresoMensualDTO> resultado = new List<IngresoMensualDTO>();
            for (int mes = 1; mes <= 12; mes++)
            {
                IngresoMensualDTO item = origen.FirstOrDefault(x => x.NumeroMes == mes);
                resultado.Add(item ?? new IngresoMensualDTO
                {
                    NumeroMes = mes,
                    Mes = cultura.DateTimeFormat.GetMonthName(mes),
                    TotalColones = 0,
                    TotalDolares = 0
                });
            }
            return resultado;
        }

        private void FormatearGrid()
        {
            if (dgvIngresos.Columns.Count == 0) return;
            if (dgvIngresos.Columns["NumeroMes"] != null) dgvIngresos.Columns["NumeroMes"].Visible = false;
            if (dgvIngresos.Columns["Mes"] != null) dgvIngresos.Columns["Mes"].HeaderText = "Mes";
            if (dgvIngresos.Columns["TotalColones"] != null)
            {
                dgvIngresos.Columns["TotalColones"].HeaderText = "Total facturado (₡)";
                dgvIngresos.Columns["TotalColones"].DefaultCellStyle.Format = "N2";
            }
            if (dgvIngresos.Columns["TotalDolares"] != null)
            {
                dgvIngresos.Columns["TotalDolares"].HeaderText = "Total facturado ($)";
                dgvIngresos.Columns["TotalDolares"].DefaultCellStyle.Format = "N2";
            }
            dgvIngresos.ClearSelection();
        }

        private void btnGenerar_Click(object sender, EventArgs e) { CargarReporte(); }
        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated && chartIngresos != null) MostrarReporte();
        }
        private void btnCerrar_Click(object sender, EventArgs e) { Close(); }
        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnGenerar.Enabled = !cargando;
            nudAnio.Enabled = !cargando;
            cmbMoneda.Enabled = !cargando;
            if (cargando) lblResultado.Text = "Generando reporte...";
        }

        private void lblSinDatosTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblSinDatosDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}
