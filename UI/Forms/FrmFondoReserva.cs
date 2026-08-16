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

        public FrmFondoReserva() { InitializeComponent(); }

        private void FrmFondoReserva_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            List<PropiedadDTO> propiedades = propiedadBLL.ObtenerTodas().OrderBy(x => x.Codigo).ToList();
            propiedades.Insert(0, new PropiedadDTO { IdPropiedad = 0, Codigo = "Todas las propiedades" });
            cmbPropiedad.DataSource = propiedades;
            cmbPropiedad.DisplayMember = "Codigo";
            cmbPropiedad.ValueMember = "IdPropiedad";
            CargarMovimientos();
        }

        private void CargarMovimientos()
        {
            try
            {
                CambiarEstadoCarga(true);
                int id = cmbPropiedad.SelectedValue == null ? 0 : Convert.ToInt32(cmbPropiedad.SelectedValue);
                movimientos = id > 0 ? fondoBLL.ObtenerPorPropiedad(id) : fondoBLL.ObtenerTodos();
                AplicarFiltros();
                lblActualizado.Text = "Actualizado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar el fondo de reserva.\n\n" + ex.Message,
                    "Fondo de reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { CambiarEstadoCarga(false); }
        }

        private void AplicarFiltros()
        {
            IEnumerable<FondoReserva> consulta = movimientos;
            if (chkUsarFechas.Checked)
                consulta = consulta.Where(x => x.Fecha.Date >= dtpDesde.Value.Date && x.Fecha.Date <= dtpHasta.Value.Date);
            List<FondoReserva> resultado = consulta.OrderByDescending(x => x.Fecha).ToList();
            dgvFondos.DataSource = null;
            dgvFondos.DataSource = resultado;
            FormatearGrid();
            decimal total = resultado.Sum(x => x.Monto);
            CultureInfo cr = CultureInfo.GetCultureInfo("es-CR");
            lblTotalValor.Text = total.ToString("C2", cr);
            lblAportesValor.Text = resultado.Count.ToString("N0");
            lblPromedioValor.Text = (resultado.Count == 0 ? 0 : total / resultado.Count).ToString("C2", cr);
            lblResultado.Text = resultado.Count == 1 ? "1 aporte mostrado" : resultado.Count + " aportes mostrados";
            pnlSinDatos.Visible = resultado.Count == 0;
            if (pnlSinDatos.Visible) pnlSinDatos.BringToFront();
        }

        private void FormatearGrid()
        {
            if (dgvFondos.Columns.Count == 0) return;
            if (dgvFondos.Columns["IdFondoReserva"] != null) dgvFondos.Columns["IdFondoReserva"].Visible = false;
            if (dgvFondos.Columns["IdPropiedad"] != null) dgvFondos.Columns["IdPropiedad"].HeaderText = "Id propiedad";
            if (dgvFondos.Columns["Porcentaje"] != null)
            {
                dgvFondos.Columns["Porcentaje"].HeaderText = "Porcentaje aplicado";
                dgvFondos.Columns["Porcentaje"].DefaultCellStyle.Format = "N2' %'";
            }
            if (dgvFondos.Columns["Monto"] != null)
            {
                dgvFondos.Columns["Monto"].HeaderText = "Aporte al fondo";
                dgvFondos.Columns["Monto"].DefaultCellStyle.Format = "C2";
                dgvFondos.Columns["Monto"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("es-CR");
            }
            if (dgvFondos.Columns["Fecha"] != null)
            {
                dgvFondos.Columns["Fecha"].HeaderText = "Fecha del aporte";
                dgvFondos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            dgvFondos.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e) { CargarMovimientos(); }
        private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e) { if (IsHandleCreated) CargarMovimientos(); }
        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = dtpHasta.Enabled = chkUsarFechas.Checked;
            AplicarFiltros();
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (chkUsarFechas.Checked && dtpDesde.Value.Date <= dtpHasta.Value.Date) AplicarFiltros();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbPropiedad.SelectedIndex = 0;
            chkUsarFechas.Checked = false;
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            CargarMovimientos();
        }
        private void btnCerrar_Click(object sender, EventArgs e) { Close(); }
        private void CambiarEstadoCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnActualizar.Enabled = !cargando;
            grpFiltros.Enabled = !cargando;
            if (cargando) lblResultado.Text = "Consultando movimientos...";
        }
    }
}
