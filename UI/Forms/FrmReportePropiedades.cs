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
    /// Reporte de propiedades exigido por el enunciado.
    /// Muestra código, tipo, área, residentes, cuota, propietario y estado,
    /// con filtro por propietario.
    /// </summary>
    public partial class FrmReportePropiedades : Form
    {
        private readonly ReporteBLL _reporteBLL = new ReporteBLL();
        private readonly PropietarioBLL _propietarioBLL = new PropietarioBLL();
        private List<ReportePropiedadDTO> _datos = new List<ReportePropiedadDTO>();

        public FrmReportePropiedades()
        {
            InitializeComponent();
            ConfigurarTarjetasResumen();
        }

        /// <summary>
        /// Se ejecuta fuera de InitializeComponent para que el diseñador de
        /// Windows Forms no intente serializar un método personalizado.
        /// </summary>
        private void ConfigurarTarjetasResumen()
        {
            ConfigurarTarjeta(
                pnlTotal,
                lblTotalTitulo,
                lblTotalValor,
                "TOTAL PROPIEDADES",
                Color.FromArgb(41, 128, 185));

            ConfigurarTarjeta(
                pnlAlDia,
                lblAlDiaTitulo,
                lblAlDiaValor,
                "PROPIEDADES AL DÍA",
                Color.FromArgb(22, 163, 74));

            ConfigurarTarjeta(
                pnlMorosas,
                lblMorosasTitulo,
                lblMorosasValor,
                "PROPIEDADES MOROSAS",
                Color.FromArgb(220, 38, 38));

            ConfigurarTarjeta(
                pnlCuotas,
                lblCuotasTitulo,
                lblCuotasValor,
                "TOTAL CUOTAS MENSUALES",
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

        private void FrmReportePropiedades_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarPropietarios();
            CargarReporte();
        }

        private void ConfigurarGrid()
        {
            dgvPropiedades.AutoGenerateColumns = false;
            dgvPropiedades.Columns.Clear();

            dgvPropiedades.Columns.Add(CrearColumna("Codigo", "Código", 90));
            dgvPropiedades.Columns.Add(CrearColumna("Tipo", "Tipo", 105));

            DataGridViewTextBoxColumn area = CrearColumna("Area", "Área (m²)", 95);
            area.DefaultCellStyle.Format = "N2";
            area.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPropiedades.Columns.Add(area);

            DataGridViewTextBoxColumn residentes =
                CrearColumna("CantidadResidentes", "Residentes", 90);
            residentes.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvPropiedades.Columns.Add(residentes);

            DataGridViewTextBoxColumn cuota =
                CrearColumna("CuotaMantenimiento", "Cuota mensual", 125);
            cuota.DefaultCellStyle.Format = "C2";
            cuota.DefaultCellStyle.FormatProvider =
                CultureInfo.GetCultureInfo("es-CR");
            cuota.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvPropiedades.Columns.Add(cuota);

            DataGridViewTextBoxColumn propietario =
                CrearColumna("NombrePropietario", "Propietario actual", 190);
            propietario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            propietario.MinimumWidth = 180;
            dgvPropiedades.Columns.Add(propietario);

            dgvPropiedades.Columns.Add(
                CrearColumna("CedulaPropietario", "Identificación", 115));

            DataGridViewTextBoxColumn estado =
                CrearColumna("EstadoFinanciero", "Estado", 105);
            estado.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvPropiedades.Columns.Add(estado);
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

        private void CargarPropietarios()
        {
            try
            {
                List<FiltroPropietario> opciones = new List<FiltroPropietario>
                {
                    new FiltroPropietario
                    {
                        IdPropietario = 0,
                        Descripcion = "Todos los propietarios"
                    }
                };

                opciones.AddRange(
                    _propietarioBLL.ObtenerTodos()
                        .OrderBy(p => p.Apellidos)
                        .ThenBy(p => p.Nombre)
                        .Select(p => new FiltroPropietario
                        {
                            IdPropietario = p.IdPersona,
                            Descripcion = string.Format(
                                "{0} {1} - {2}",
                                p.Nombre,
                                p.Apellidos,
                                p.Identificacion)
                        }));

                cmbPropietario.DataSource = opciones;
                cmbPropietario.DisplayMember = "Descripcion";
                cmbPropietario.ValueMember = "IdPropietario";
                cmbPropietario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los propietarios.\n\n" + ex.Message,
                    "Error de carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarReporte()
        {
            try
            {
                CambiarEstadoCarga(true);

                int idSeleccionado = cmbPropietario.SelectedValue == null
                    ? 0
                    : Convert.ToInt32(cmbPropietario.SelectedValue);

                int? idPropietario = idSeleccionado > 0
                    ? (int?)idSeleccionado
                    : null;

                _datos = _reporteBLL.ObtenerPropiedades(idPropietario)
                    ?? new List<ReportePropiedadDTO>();

                AplicarBusqueda();
                lblActualizado.Text = "Actualizado: " +
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                _datos = new List<ReportePropiedadDTO>();
                dgvPropiedades.DataSource = null;
                ActualizarResumen(_datos);

                MessageBox.Show(
                    "No se pudo generar el reporte de propiedades.\n\n" + ex.Message,
                    "Reportes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CambiarEstadoCarga(false);
            }
        }

        private void AplicarBusqueda()
        {
            string texto = txtBuscar.Text.Trim();
            IEnumerable<ReportePropiedadDTO> consulta = _datos;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(p =>
                    Contiene(p.Codigo, texto) ||
                    Contiene(p.Tipo, texto) ||
                    Contiene(p.NombrePropietario, texto) ||
                    Contiene(p.CedulaPropietario, texto) ||
                    Contiene(p.EstadoFinanciero, texto));
            }

            List<ReportePropiedadDTO> resultado = consulta
                .OrderBy(p => p.Codigo)
                .ToList();

            dgvPropiedades.DataSource = null;
            dgvPropiedades.DataSource = resultado;
            dgvPropiedades.ClearSelection();
            ActualizarResumen(resultado);
        }

        private bool Contiene(string valor, string busqueda)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.IndexOf(busqueda,
                       StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void ActualizarResumen(List<ReportePropiedadDTO> datos)
        {
            int total = datos.Count;
            int morosas = datos.Count(p => p.EsMorosa);
            int alDia = total - morosas;
            decimal cuotas = datos.Sum(p => p.CuotaMantenimiento);

            lblTotalValor.Text = total.ToString("N0");
            lblAlDiaValor.Text = alDia.ToString("N0");
            lblMorosasValor.Text = morosas.ToString("N0");
            lblCuotasValor.Text = cuotas.ToString(
                "C2",
                CultureInfo.GetCultureInfo("es-CR"));

            lblResultado.Text = total == 1
                ? "1 propiedad mostrada"
                : total + " propiedades mostradas";

            pnlSinDatos.Visible = total == 0;
            pnlSinDatos.BringToFront();
        }

        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnActualizar.Enabled = !cargando;
            btnFiltrar.Enabled = !cargando;
            cmbPropietario.Enabled = !cargando;
            lblResultado.Text = cargando
                ? "Cargando información..."
                : lblResultado.Text;
        }

        private void dgvPropiedades_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPropiedades.Columns[e.ColumnIndex].Name !=
                "colEstadoFinanciero" || e.Value == null)
                return;

            string estado = e.Value.ToString();
            e.CellStyle.Font = new Font(
                dgvPropiedades.Font,
                FontStyle.Bold);

            if (estado == "Morosa")
            {
                e.CellStyle.BackColor = Color.FromArgb(253, 232, 232);
                e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarPropietarios();
            CargarReporte();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbPropietario.SelectedIndex = 0;
            txtBuscar.Clear();
            CargarReporte();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarBusqueda();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private sealed class FiltroPropietario
        {
            public int IdPropietario { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
