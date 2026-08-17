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
    /// <summary>
    /// Formulario encargado de consultar, recalcular y visualizar
    /// los indicadores de morosidad de las propiedades.
    /// </summary>
    /// <remarks>
    /// Permite buscar propiedades morosas, filtrar los resultados por
    /// clasificación de riesgo y aplicar penalizaciones masivas mediante
    /// <see cref="GestionFinancieraFacade"/>.
    /// </remarks>
    public partial class FrmMorosidad : Form
    {
        /// <summary>
        /// Lógica de negocio utilizada para recalcular y consultar
        /// los indicadores de morosidad.
        /// </summary>
        private readonly IndicadorMorosidadBLL morosidadBLL =
            new IndicadorMorosidadBLL();

        /// <summary>
        /// Fachada utilizada para ejecutar operaciones financieras
        /// relacionadas con la morosidad.
        /// </summary>
        private readonly GestionFinancieraFacade gestionFinanciera =
            new GestionFinancieraFacade();

        /// <summary>
        /// Lista de indicadores de morosidad cargados en el formulario.
        /// </summary>
        private List<IndicadorMorosidadDTO> indicadores =
            new List<IndicadorMorosidadDTO>();

        /// <summary>
        /// Inicializa una nueva instancia del formulario de morosidad.
        /// </summary>
        public FrmMorosidad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configura los filtros iniciales y recalcula los indicadores
        /// cuando se carga el formulario.
        /// </summary>
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

        /// <summary>
        /// Recalcula los indicadores de morosidad utilizando la tasa
        /// mensual seleccionada y actualiza los datos mostrados.
        /// </summary>
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

        /// <summary>
        /// Filtra los indicadores por texto, clasificación de riesgo
        /// y estado de suspensión de reservas.
        /// </summary>
        /// <remarks>
        /// También actualiza los totales financieros, la cantidad de
        /// propiedades y los indicadores críticos mostrados en pantalla.
        /// </remarks>
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

        /// <summary>
        /// Configura los encabezados, formatos y visibilidad de las
        /// columnas del listado de morosidad.
        /// </summary>
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

        /// <summary>
        /// Oculta una columna del listado cuando se encuentra disponible.
        /// </summary>
        /// <param name="nombre">
        /// Nombre de la columna que se desea ocultar.
        /// </param>
        private void Ocultar(string nombre)
        {
            if (dgvMorosidad.Columns[nombre] != null)
            {
                dgvMorosidad.Columns[nombre].Visible = false;
            }
        }

        /// <summary>
        /// Asigna un texto descriptivo al encabezado de una columna.
        /// </summary>
        /// <param name="nombre">
        /// Nombre interno de la columna.
        /// </param>
        /// <param name="texto">
        /// Texto que se mostrará en el encabezado.
        /// </param>
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

        /// <summary>
        /// Aplica el formato monetario de Costa Rica a una columna.
        /// </summary>
        /// <param name="nombre">
        /// Nombre de la columna que contiene el valor monetario.
        /// </param>
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

        /// <summary>
        /// Recalcula los indicadores cuando el usuario presiona
        /// el botón correspondiente.
        /// </summary>
        private void btnRecalcular_Click(
            object sender,
            EventArgs e)
        {
            Recalcular();
        }

        /// <summary>
        /// Actualiza el listado cuando cambia alguno de los filtros.
        /// </summary>
        private void filtro_Cambio(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
            {
                AplicarFiltros();
            }
        }

        /// <summary>
        /// Restablece los filtros y vuelve a mostrar todos los resultados.
        /// </summary>
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

        /// <summary>
        /// Aplica las penalizaciones masivas mediante el patrón Facade
        /// y vuelve a calcular los indicadores de morosidad.
        /// </summary>
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

        /// <summary>
        /// Cierra el formulario de control de morosidad.
        /// </summary>
        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Activa o desactiva los controles del formulario mientras
        /// se ejecuta una operación.
        /// </summary>
        /// <param name="cargando">
        /// Indica si el formulario se encuentra procesando información.
        /// </param>
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