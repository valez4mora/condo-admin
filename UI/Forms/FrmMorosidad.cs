using BLL;
using DTO;
using Facade;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmMorosidad : Form
    {
        // Se conserva porque se utiliza para recalcular y consultar indicadores.
        private readonly IndicadorMorosidadBLL morosidadBLL =
            new IndicadorMorosidadBLL();

        // Facade para ejecutar operaciones financieras completas.
        private readonly GestionFinancieraFacade gestionFinanciera =
            new GestionFinancieraFacade();

        private List<IndicadorMorosidadDTO> indicadores =
            new List<IndicadorMorosidadDTO>();

        public FrmMorosidad()
        {
            InitializeComponent();
        }

        private void FrmMorosidad_Load(object sender, EventArgs e)
        {
            cmbRiesgo.Items.AddRange(new object[]
            {
                "Todos",
                "Bajo",
                "Medio",
                "Alto",
                "Critico"
            });

            cmbRiesgo.SelectedIndex = 0;
            nudTasa.Value = 2.00m;

            Recalcular();
        }

        private void Recalcular()
        {
            try
            {
                CambiarCarga(true);

                indicadores =
                    morosidadBLL.RecalcularTodos(nudTasa.Value);

                AplicarFiltros();

                lblActualizado.Text =
                    "Actualizado: " +
                    DateTime.Now.ToString(
                        "dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo recalcular la morosidad.\n\n" +
                    ex.Message,
                    "Control de morosidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CambiarCarga(false);
            }
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();

            string riesgo =
                cmbRiesgo.SelectedItem == null
                    ? "Todos"
                    : cmbRiesgo.SelectedItem.ToString();

            IEnumerable<IndicadorMorosidadDTO> consulta =
                indicadores;

            if (texto.Length > 0)
            {
                consulta = consulta.Where(x =>
                    (x.CodigoPropiedad ?? "")
                        .IndexOf(
                            texto,
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.NombrePropietario ?? "")
                        .IndexOf(
                            texto,
                            StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (riesgo != "Todos")
            {
                consulta = consulta.Where(
                    x => x.Clasificacion == riesgo);
            }

            if (chkSuspendidas.Checked)
            {
                consulta = consulta.Where(
                    x => x.ReservasSuspendidas);
            }

            List<IndicadorMorosidadDTO> resultado =
                consulta
                    .OrderByDescending(x => x.IndiceRiesgo)
                    .ThenByDescending(x => x.MontoAdeudado)
                    .ToList();

            dgvMorosidad.DataSource = null;
            dgvMorosidad.DataSource = resultado;

            FormatearGrid();

            CultureInfo cr =
                CultureInfo.GetCultureInfo("es-CR");

            lblPropiedadesValor.Text =
                resultado.Count.ToString("N0");

            lblDeudaValor.Text =
                resultado
                    .Sum(x => x.MontoAdeudado)
                    .ToString("C2", cr);

            lblInteresValor.Text =
                resultado
                    .Sum(x => x.InteresCalculado)
                    .ToString("C2", cr);

            lblCriticasValor.Text =
                resultado.Count(x =>
                    x.Clasificacion == "Alto" ||
                    x.Clasificacion == "Critico")
                .ToString("N0");

            lblResultado.Text =
                resultado.Count == 1
                    ? "1 propiedad morosa"
                    : resultado.Count +
                      " propiedades morosas";

            pnlSinDatos.Visible = resultado.Count == 0;

            if (pnlSinDatos.Visible)
            {
                pnlSinDatos.BringToFront();
            }
            else
            {
                dgvMorosidad.BringToFront();
            }
        }

        private void FormatearGrid()
        {
            if (dgvMorosidad.Columns.Count == 0)
            {
                return;
            }

            Ocultar("IdIndicador");
            Ocultar("IdPropiedad");
            Ocultar("MesesMora");
            Ocultar("TasaInteres");
            Ocultar("FechaCalculo");
            Ocultar("FechaVencimientoMasAntigua");

            Encabezado("CodigoPropiedad", "Propiedad");
            Encabezado("NombrePropietario", "Propietario");
            Encabezado("DiasMora", "Días mora");
            Encabezado("FacturasPendientes", "Pendientes");
            Encabezado("MontoAdeudado", "Saldo pendiente");
            Encabezado(
                "InteresCalculado",
                "Interés calculado");
            Encabezado("IndiceRiesgo", "Índice");
            Encabezado("Clasificacion", "Riesgo");
            Encabezado(
                "PorcentajePenalizacion",
                "Recargo");
            Encabezado(
                "ReservasSuspendidas",
                "Reservas suspendidas");

            Moneda("MontoAdeudado");
            Moneda("InteresCalculado");

            if (dgvMorosidad
                    .Columns["PorcentajePenalizacion"] != null)
            {
                dgvMorosidad
                    .Columns["PorcentajePenalizacion"]
                    .DefaultCellStyle.Format = "N2' %'";
            }

            dgvMorosidad.ClearSelection();
        }

        private void Ocultar(string nombre)
        {
            if (dgvMorosidad.Columns[nombre] != null)
            {
                dgvMorosidad.Columns[nombre].Visible = false;
            }
        }

        private void Encabezado(
            string nombre,
            string texto)
        {
            if (dgvMorosidad.Columns[nombre] != null)
            {
                dgvMorosidad.Columns[nombre].HeaderText =
                    texto;
            }
        }

        private void Moneda(string nombre)
        {
            if (dgvMorosidad.Columns[nombre] == null)
            {
                return;
            }

            dgvMorosidad.Columns[nombre]
                .DefaultCellStyle.Format = "C2";

            dgvMorosidad.Columns[nombre]
                .DefaultCellStyle.FormatProvider =
                    CultureInfo.GetCultureInfo("es-CR");
        }

        private void btnRecalcular_Click(
            object sender,
            EventArgs e)
        {
            Recalcular();
        }

        private void filtro_Cambio(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
            {
                AplicarFiltros();
            }
        }

        private void btnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            txtBuscar.Clear();
            cmbRiesgo.SelectedIndex = 0;
            chkSuspendidas.Checked = false;

            AplicarFiltros();
            txtBuscar.Focus();
        }

        private void btnPenalizaciones_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                CambiarCarga(true);

                // La operación masiva se ejecuta mediante el Facade.
                int cantidad =
                    gestionFinanciera
                        .AplicarPenalizacionesMorosas();

                MessageBox.Show(
                    cantidad == 0
                        ? "No había penalizaciones nuevas por registrar."
                        : "Se registraron " +
                          cantidad +
                          " penalizaciones.",
                    "Penalizaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Recalcular();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Penalizaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CambiarCarga(false);
            }
        }

        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void CambiarCarga(bool cargando)
        {
            UseWaitCursor = cargando;
            btnRecalcular.Enabled = !cargando;
            btnPenalizaciones.Enabled = !cargando;
            grpFiltros.Enabled = !cargando;

            if (cargando)
            {
                lblResultado.Text =
                    "Calculando saldos e indicadores...";
            }
        }
    }
}