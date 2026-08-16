using BLL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmFondoReserva : Form
    {
        private readonly FondoReservaBLL fondoBLL =
            new FondoReservaBLL();

        private readonly PropiedadBLL propiedadBLL =
            new PropiedadBLL();

        private List<FondoReserva> movimientos =
            new List<FondoReserva>();

        // Evita consultar mientras el ComboBox está cargando.
        private bool cargandoPropiedades;

        public FrmFondoReserva()
        {
            InitializeComponent();
        }

        private void FrmFondoReserva_Load(
            object sender,
            EventArgs e)
        {
            dtpDesde.Value =
                new DateTime(DateTime.Today.Year, 1, 1);

            dtpHasta.Value = DateTime.Today;

            dtpDesde.Enabled = chkUsarFechas.Checked;
            dtpHasta.Enabled = chkUsarFechas.Checked;

            CargarPropiedades();
            CargarMovimientos();
        }

        private void CargarPropiedades()
        {
            try
            {
                cargandoPropiedades = true;

                List<PropiedadDTO> propiedades =
                    propiedadBLL.ObtenerTodas()
                        .OrderBy(x => x.Codigo)
                        .ToList();

                propiedades.Insert(
                    0,
                    new PropiedadDTO
                    {
                        IdPropiedad = 0,
                        Codigo = "Todas las propiedades"
                    });

                // Se configuran antes de asignar el DataSource.
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las propiedades.\n\n" +
                    ex.Message,
                    "Fondo de reserva",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargandoPropiedades = false;
            }
        }

        private void CargarMovimientos()
        {
            if (cargandoPropiedades)
                return;

            try
            {
                CambiarEstadoCarga(true);

                int idPropiedad = ObtenerIdPropiedadSeleccionada();

                if (idPropiedad > 0)
                {
                    movimientos =
                        fondoBLL.ObtenerPorPropiedad(idPropiedad);
                }
                else
                {
                    movimientos =
                        fondoBLL.ObtenerTodos();
                }

                AplicarFiltros();

                lblActualizado.Text =
                    "Actualizado: " +
                    DateTime.Now.ToString(
                        "dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                movimientos = new List<FondoReserva>();

                MessageBox.Show(
                    "No se pudo consultar el fondo de reserva.\n\n" +
                    ex.Message,
                    "Fondo de reserva",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CambiarEstadoCarga(false);
            }
        }

        private int ObtenerIdPropiedadSeleccionada()
        {
            PropiedadDTO propiedad =
                cmbPropiedad.SelectedItem as PropiedadDTO;

            if (propiedad == null)
                return 0;

            return propiedad.IdPropiedad;
        }

        private void AplicarFiltros()
        {
            if (movimientos == null)
            {
                movimientos = new List<FondoReserva>();
            }

            IEnumerable<FondoReserva> consulta = movimientos;

            if (chkUsarFechas.Checked)
            {
                if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha inicial no puede ser posterior " +
                        "a la fecha final.",
                        "Fechas no válidas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                consulta = consulta.Where(x =>
                    x.Fecha.Date >= dtpDesde.Value.Date &&
                    x.Fecha.Date <= dtpHasta.Value.Date);
            }

            List<FondoReserva> resultado =
                consulta
                    .OrderByDescending(x => x.Fecha)
                    .ToList();

            dgvFondos.DataSource = null;
            dgvFondos.DataSource = resultado;

            FormatearGrid();

            decimal total =
                resultado.Sum(x => x.Monto);

            decimal promedio =
                resultado.Count > 0
                    ? total / resultado.Count
                    : 0m;

            CultureInfo culturaCR =
                CultureInfo.GetCultureInfo("es-CR");

            lblTotalValor.Text =
                total.ToString("C2", culturaCR);

            lblAportesValor.Text =
                resultado.Count.ToString("N0");

            lblPromedioValor.Text =
                promedio.ToString("C2", culturaCR);

            lblResultado.Text =
                resultado.Count == 1
                    ? "1 aporte mostrado"
                    : resultado.Count + " aportes mostrados";

            pnlSinDatos.Visible =
                resultado.Count == 0;

            if (pnlSinDatos.Visible)
            {
                pnlSinDatos.BringToFront();
            }
            else
            {
                dgvFondos.BringToFront();
            }
        }

        private void FormatearGrid()
        {
            if (dgvFondos.Columns.Count == 0)
                return;

            if (dgvFondos.Columns["IdFondoReserva"] != null)
            {
                dgvFondos.Columns["IdFondoReserva"].Visible = false;
            }

            if (dgvFondos.Columns["IdPropiedad"] != null)
            {
                dgvFondos.Columns["IdPropiedad"].HeaderText =
                    "Id propiedad";
            }

            if (dgvFondos.Columns["Porcentaje"] != null)
            {
                dgvFondos.Columns["Porcentaje"].HeaderText =
                    "Porcentaje aplicado";

                dgvFondos.Columns["Porcentaje"]
                    .DefaultCellStyle.Format = "N2' %'";
            }

            if (dgvFondos.Columns["Monto"] != null)
            {
                dgvFondos.Columns["Monto"].HeaderText =
                    "Aporte al fondo";

                dgvFondos.Columns["Monto"]
                    .DefaultCellStyle.Format = "C2";

                dgvFondos.Columns["Monto"]
                    .DefaultCellStyle.FormatProvider =
                    CultureInfo.GetCultureInfo("es-CR");
            }

            if (dgvFondos.Columns["Fecha"] != null)
            {
                dgvFondos.Columns["Fecha"].HeaderText =
                    "Fecha del aporte";

                dgvFondos.Columns["Fecha"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            dgvFondos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvFondos.ClearSelection();
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            CargarMovimientos();
        }

        private void cmbPropiedad_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cargandoPropiedades || !IsHandleCreated)
                return;

            CargarMovimientos();
        }

        private void chkUsarFechas_CheckedChanged(
            object sender,
            EventArgs e)
        {
            dtpDesde.Enabled = chkUsarFechas.Checked;
            dtpHasta.Enabled = chkUsarFechas.Checked;

            AplicarFiltros();
        }

        private void dtpFecha_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (!chkUsarFechas.Checked)
                return;

            if (dtpDesde.Value.Date <= dtpHasta.Value.Date)
            {
                AplicarFiltros();
            }
        }

        private void btnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            chkUsarFechas.Checked = false;

            dtpDesde.Value =
                new DateTime(DateTime.Today.Year, 1, 1);

            dtpHasta.Value = DateTime.Today;

            if (cmbPropiedad.Items.Count == 0)
            {
                CargarMovimientos();
                return;
            }

            // Si cambia la selección, el evento del ComboBox recarga.
            if (cmbPropiedad.SelectedIndex != 0)
            {
                cmbPropiedad.SelectedIndex = 0;
            }
            else
            {
                // Si ya estaba en cero, se debe recargar manualmente.
                CargarMovimientos();
            }
        }

        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnActualizar.Enabled = !cargando;
            grpFiltros.Enabled = !cargando;

            if (cargando)
            {
                lblResultado.Text =
                    "Consultando movimientos...";
            }
        }
    }
}