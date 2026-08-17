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
        private readonly FondoReservaBLL fondoBLL = new FondoReservaBLL();
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();

        private List<FondoReserva> movimientos = new List<FondoReserva>();
        private readonly Dictionary<int, string> codigosPropiedad =
            new Dictionary<int, string>();

        private bool cargandoPropiedades;

        public FrmFondoReserva()
        {
            InitializeComponent();
        }

        private void FrmFondoReserva_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            HabilitarFiltroFechas();

            CargarPropiedades();
            CargarMovimientos();
        }

        private void CargarPropiedades()
        {
            try
            {
                cargandoPropiedades = true;

                List<PropiedadDTO> propiedades = propiedadBLL.ObtenerTodas()
                    .OrderBy(p => p.Codigo)
                    .ToList();

                codigosPropiedad.Clear();
                foreach (PropiedadDTO propiedad in propiedades)
                {
                    codigosPropiedad[propiedad.IdPropiedad] = propiedad.Codigo;
                }

                propiedades.Insert(0, new PropiedadDTO
                {
                    IdPropiedad = 0,
                    Codigo = "Todas las propiedades"
                });

                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las propiedades.\n\n" + ex.Message,
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
                movimientos = idPropiedad > 0
                    ? fondoBLL.ObtenerPorPropiedad(idPropiedad)
                    : fondoBLL.ObtenerTodos();

                if (movimientos == null)
                    movimientos = new List<FondoReserva>();

                AplicarFiltros();
                lblActualizado.Text = "Actualizado: " +
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                movimientos = new List<FondoReserva>();
                MostrarResultados(new List<FondoReserva>());

                MessageBox.Show(
                    "No se pudo consultar el fondo de reserva.\n\n" + ex.Message,
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
            PropiedadDTO propiedad = cmbPropiedad.SelectedItem as PropiedadDTO;
            return propiedad == null ? 0 : propiedad.IdPropiedad;
        }

        private void AplicarFiltros()
        {
            if (chkUsarFechas.Checked &&
                dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser posterior a la fecha final.",
                    "Rango de fechas no válido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            IEnumerable<FondoReserva> consulta = movimientos;

            if (chkUsarFechas.Checked)
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;

                consulta = consulta.Where(m =>
                    m.Fecha.Date >= desde && m.Fecha.Date <= hasta);
            }

            MostrarResultados(consulta
                .OrderByDescending(m => m.Fecha)
                .ThenByDescending(m => m.IdFondoReserva)
                .ToList());
        }

        private void MostrarResultados(List<FondoReserva> resultado)
        {
            dgvFondos.Rows.Clear();

            foreach (FondoReserva movimiento in resultado)
            {
                string codigo;
                if (!codigosPropiedad.TryGetValue(movimiento.IdPropiedad, out codigo))
                    codigo = "Propiedad " + movimiento.IdPropiedad;

                dgvFondos.Rows.Add(
                    movimiento.IdFondoReserva,
                    codigo,
                    movimiento.Porcentaje,
                    movimiento.Monto,
                    movimiento.Fecha);
            }

            decimal total = resultado.Sum(m => m.Monto);
            decimal promedio = resultado.Count == 0
                ? 0m
                : total / resultado.Count;

            CultureInfo culturaCR = CultureInfo.GetCultureInfo("es-CR");
            lblTotalValor.Text = total.ToString("C2", culturaCR);
            lblAportesValor.Text = resultado.Count.ToString("N0");
            lblPromedioValor.Text = promedio.ToString("C2", culturaCR);

            lblResultado.Text = resultado.Count == 1
                ? "1 aporte mostrado"
                : resultado.Count + " aportes mostrados";

            pnlSinDatos.Visible = resultado.Count == 0;
            dgvFondos.Visible = resultado.Count > 0;
            dgvFondos.ClearSelection();
        }

        private void HabilitarFiltroFechas()
        {
            dtpDesde.Enabled = chkUsarFechas.Checked;
            dtpHasta.Enabled = chkUsarFechas.Checked;
        }

        private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoPropiedades && IsHandleCreated)
                CargarMovimientos();
        }

        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarFiltroFechas();

            if (IsHandleCreated)
                AplicarFiltros();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (chkUsarFechas.Checked &&
                dtpDesde.Value.Date <= dtpHasta.Value.Date)
            {
                AplicarFiltros();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargandoPropiedades = true;

            chkUsarFechas.Checked = false;
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;

            if (cmbPropiedad.Items.Count > 0)
                cmbPropiedad.SelectedIndex = 0;

            cargandoPropiedades = false;
            HabilitarFiltroFechas();
            CargarMovimientos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnActualizar.Enabled = !cargando;
            btnLimpiar.Enabled = !cargando;
            grpFiltros.Enabled = !cargando;

            if (cargando)
                lblResultado.Text = "Consultando aportes...";
        }
    }
}
