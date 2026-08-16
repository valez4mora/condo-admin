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
    /// <summary>
    /// Reporte de propiedades con al menos un cargo vencido y no pagado.
    /// </summary>
    public partial class FrmReportePropiedadesMorosas : Form
    {
        private readonly ReporteBLL _reporteBLL = new ReporteBLL();
        private List<ReporteMorosidadDTO> _datos =
            new List<ReporteMorosidadDTO>();

        public FrmReportePropiedadesMorosas()
        {
            InitializeComponent();
            ConfigurarTarjetasResumen();
        }

        private void FrmReportePropiedadesMorosas_Load(
            object sender,
            EventArgs e)
        {
            ConfigurarGrid();
            CargarFiltroRiesgo();
            CargarReporte();
        }

        private void ConfigurarGrid()
        {
            dgvMorosas.AutoGenerateColumns = false;
            dgvMorosas.Columns.Clear();

            dgvMorosas.Columns.Add(
                CrearColumna("CodigoPropiedad", "Propiedad", 105));

            DataGridViewTextBoxColumn propietario = CrearColumna(
                "NombrePropietario",
                "Propietario actual",
                220);
            propietario.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            propietario.MinimumWidth = 190;
            dgvMorosas.Columns.Add(propietario);

            DataGridViewTextBoxColumn deuda = CrearColumna(
                "MontoTotalAdeudado",
                "Total adeudado",
                145);
            deuda.DefaultCellStyle.Format = "C2";
            deuda.DefaultCellStyle.FormatProvider =
                CultureInfo.GetCultureInfo("es-CR");
            deuda.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvMorosas.Columns.Add(deuda);

            DataGridViewTextBoxColumn cargos = CrearColumna(
                "CantidadCargosPendientes",
                "Cargos vencidos",
                120);
            cargos.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvMorosas.Columns.Add(cargos);

            DataGridViewTextBoxColumn ultimoPago = CrearColumna(
                "UltimoPagoTexto",
                "Último pago",
                145);
            ultimoPago.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvMorosas.Columns.Add(ultimoPago);

            DataGridViewTextBoxColumn dias = CrearColumna(
                "DiasMaximosMora",
                "Días máximos de mora",
                145);
            dias.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvMorosas.Columns.Add(dias);

            DataGridViewTextBoxColumn riesgo = CrearColumna(
                "ClasificacionRiesgo",
                "Riesgo financiero",
                135);
            riesgo.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvMorosas.Columns.Add(riesgo);
        }

        private DataGridViewTextBoxColumn CrearColumna(
            string propiedad,
            string titulo,
            int ancho)
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

        private void CargarFiltroRiesgo()
        {
            cmbRiesgo.Items.Clear();
            cmbRiesgo.Items.AddRange(new object[]
            {
                "Todos los niveles",
                "Bajo",
                "Medio",
                "Alto",
                "Critico"
            });
            cmbRiesgo.SelectedIndex = 0;
        }

        private void CargarReporte()
        {
            try
            {
                CambiarEstadoCarga(true);

                _datos = _reporteBLL.ObtenerPropiedadesMorosas()
                    ?? new List<ReporteMorosidadDTO>();

                AplicarFiltros();

                lblActualizado.Text = "Actualizado: " +
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                _datos = new List<ReporteMorosidadDTO>();
                dgvMorosas.DataSource = null;
                ActualizarResumen(_datos);

                MessageBox.Show(
                    "No se pudo generar el reporte de propiedades morosas.\n\n" +
                    ex.Message,
                    "Reporte de morosidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CambiarEstadoCarga(false);
            }
        }

        private void AplicarFiltros()
        {
            string busqueda = txtBuscar.Text.Trim();
            string riesgo = cmbRiesgo.SelectedItem == null
                ? "Todos los niveles"
                : cmbRiesgo.SelectedItem.ToString();

            IEnumerable<ReporteMorosidadDTO> consulta = _datos;

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                consulta = consulta.Where(x =>
                    Contiene(x.CodigoPropiedad, busqueda) ||
                    Contiene(x.NombrePropietario, busqueda) ||
                    Contiene(x.ClasificacionRiesgo, busqueda));
            }

            if (riesgo != "Todos los niveles")
            {
                consulta = consulta.Where(x =>
                    string.Equals(
                        x.ClasificacionRiesgo,
                        riesgo,
                        StringComparison.CurrentCultureIgnoreCase));
            }

            List<ReporteMorosidadDTO> resultado = consulta
                .OrderByDescending(x => x.MontoTotalAdeudado)
                .ThenBy(x => x.CodigoPropiedad)
                .ToList();

            dgvMorosas.DataSource = null;
            dgvMorosas.DataSource = resultado;
            dgvMorosas.ClearSelection();

            ActualizarResumen(resultado);
        }

        private bool Contiene(string valor, string busqueda)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.IndexOf(
                       busqueda,
                       StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void ActualizarResumen(List<ReporteMorosidadDTO> datos)
        {
            decimal totalAdeudado = datos.Sum(x => x.MontoTotalAdeudado);
            int cargosPendientes = datos.Sum(x => x.CantidadCargosPendientes);
            int riesgoCritico = datos.Count(x =>
                string.Equals(
                    x.ClasificacionRiesgo,
                    "Critico",
                    StringComparison.CurrentCultureIgnoreCase));

            lblMorosasValor.Text = datos.Count.ToString("N0");
            lblDeudaValor.Text = totalAdeudado.ToString(
                "C2",
                CultureInfo.GetCultureInfo("es-CR"));
            lblCargosValor.Text = cargosPendientes.ToString("N0");
            lblCriticoValor.Text = riesgoCritico.ToString("N0");

            lblResultado.Text = datos.Count == 1
                ? "1 propiedad morosa mostrada"
                : datos.Count + " propiedades morosas mostradas";

            pnlSinDatos.Visible = datos.Count == 0;
            pnlSinDatos.BringToFront();
        }

        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnActualizar.Enabled = !cargando;
            btnLimpiar.Enabled = !cargando;
            cmbRiesgo.Enabled = !cargando;
            txtBuscar.Enabled = !cargando;

            if (cargando)
                lblResultado.Text = "Cargando información financiera...";
        }

        private void ConfigurarTarjetasResumen()
        {
            ConfigurarTarjeta(
                pnlMorosas,
                lblMorosasTitulo,
                lblMorosasValor,
                "PROPIEDADES MOROSAS",
                Color.FromArgb(220, 38, 38));

            ConfigurarTarjeta(
                pnlDeuda,
                lblDeudaTitulo,
                lblDeudaValor,
                "TOTAL ADEUDADO",
                Color.FromArgb(185, 28, 28));

            ConfigurarTarjeta(
                pnlCargos,
                lblCargosTitulo,
                lblCargosValor,
                "CARGOS VENCIDOS",
                Color.FromArgb(217, 119, 6));

            ConfigurarTarjeta(
                pnlCritico,
                lblCriticoTitulo,
                lblCriticoValor,
                "RIESGO CRÍTICO",
                Color.FromArgb(124, 58, 237));
        }

        private void ConfigurarTarjeta(
            Panel panel,
            Label titulo,
            Label valor,
            string textoTitulo,
            Color color)
        {
            panel.BackColor = Color.White;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(0, 0, 12, 0);
            panel.Padding = new Padding(16, 10, 12, 8);

            titulo.Dock = DockStyle.Top;
            titulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(107, 114, 128);
            titulo.Height = 24;
            titulo.Text = textoTitulo;

            valor.Dock = DockStyle.Fill;
            valor.Font = new Font(
                "Segoe UI Semibold",
                18F,
                FontStyle.Bold);
            valor.ForeColor = color;
            valor.Text = "0";
            valor.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void dgvMorosas_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            string nombreColumna = dgvMorosas.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colMontoTotalAdeudado" && e.Value != null)
            {
                e.CellStyle.Font = new Font(
                    dgvMorosas.Font,
                    FontStyle.Bold);
                e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            }

            if (nombreColumna != "colClasificacionRiesgo" || e.Value == null)
                return;

            e.CellStyle.Font = new Font(
                dgvMorosas.Font,
                FontStyle.Bold);

            switch (e.Value.ToString())
            {
                case "Bajo":
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                    break;
                case "Medio":
                    e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                    e.CellStyle.ForeColor = Color.FromArgb(161, 98, 7);
                    break;
                case "Alto":
                    e.CellStyle.BackColor = Color.FromArgb(255, 237, 213);
                    e.CellStyle.ForeColor = Color.FromArgb(194, 65, 12);
                    break;
                case "Critico":
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                    break;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbRiesgo.SelectedIndex = 0;
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
