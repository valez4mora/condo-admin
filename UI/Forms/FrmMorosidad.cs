using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmMorosidad : Form
    {
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();
        private readonly IndicadorMorosidadBLL indicadorMorosidadBLL = new IndicadorMorosidadBLL();

        public FrmMorosidad()
        {
            InitializeComponent();
        }

        private void FrmMorosidad_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarPropiedades();
        }

        private void ConfigurarControles()
        {
            nudMesesMora.Minimum = 0;
            nudMesesMora.Maximum = 120;

            nudFacturasPendientes.Minimum = 0;
            nudFacturasPendientes.Maximum = 1000;

            nudMontoAdeudado.Minimum = 0;
            nudMontoAdeudado.Maximum = 1000000000;
            nudMontoAdeudado.DecimalPlaces = 2;
            nudMontoAdeudado.ThousandsSeparator = true;

            txtIndiceRiesgo.ReadOnly = true;
            txtClasificacion.ReadOnly = true;
            txtFechaCalculo.ReadOnly = true;
        }

        private void CargarPropiedades()
        {
            try
            {
                List<PropiedadDTO> propiedades = propiedadBLL.ObtenerTodas();

                cmbPropiedad.DataSource = null;
                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.SelectedIndex = -1;

                lblPropietarioValor.Text = "-";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las propiedades: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            PropiedadDTO propiedad = cmbPropiedad.SelectedItem as PropiedadDTO;

            if (propiedad == null)
            {
                lblPropietarioValor.Text = "-";
                return;
            }

            lblPropietarioValor.Text = string.IsNullOrWhiteSpace(propiedad.NombrePropietario)
                ? "No disponible"
                : propiedad.NombrePropietario;
        }

        private void btnCalcularRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPropiedad.SelectedIndex == -1 || cmbPropiedad.SelectedValue == null)
                    throw new Exception("Debe seleccionar una propiedad.");

                if (nudMesesMora.Value <= 0)
                    throw new Exception("Los meses de mora deben ser mayores a cero.");

                if (nudFacturasPendientes.Value <= 0)
                    throw new Exception("Debe existir al menos una factura pendiente.");

                if (nudMontoAdeudado.Value <= 0)
                    throw new Exception("El monto adeudado debe ser mayor a cero.");

                IndicadorMorosidadDTO indicador = new IndicadorMorosidadDTO
                {
                    IdPropiedad = Convert.ToInt32(cmbPropiedad.SelectedValue),
                    MesesMora = Convert.ToInt32(nudMesesMora.Value),
                    FacturasPendientes = Convert.ToInt32(nudFacturasPendientes.Value),
                    MontoAdeudado = nudMontoAdeudado.Value
                };

                IndicadorMorosidadDTO resultado = indicadorMorosidadBLL.CalcularIndicador(indicador);

                txtIndiceRiesgo.Text = resultado.IndiceRiesgo.ToString("N2");
                txtClasificacion.Text = resultado.Clasificacion;
                txtFechaCalculo.Text = resultado.FechaCalculo.ToString("dd/MM/yyyy HH:mm");

                MessageBox.Show(
                    "El indicador de morosidad se calculó y registró correctamente.",
                    "Proceso completado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbPropiedad.SelectedIndex = -1;
            nudMesesMora.Value = 0;
            nudFacturasPendientes.Value = 0;
            nudMontoAdeudado.Value = 0;

            txtIndiceRiesgo.Clear();
            txtClasificacion.Clear();
            txtFechaCalculo.Clear();

            lblPropietarioValor.Text = "-";
            cmbPropiedad.Focus();
        }
    }
}
