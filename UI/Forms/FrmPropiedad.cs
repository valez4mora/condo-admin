using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util.Enumeraciones;


namespace UI.Forms
{
    public partial class FrmPropiedad : Form
    {
        private PropiedadBLL propiedadBLL = new PropiedadBLL();
        public FrmPropiedad()
        {
            InitializeComponent();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {

        }

        private void FrmPropiedad_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(TipoPropiedad));
            cmbEstado.DataSource = Enum.GetValues(typeof(IndiceRiesgo));

            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblResidentes_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblCuota_Click(object sender, EventArgs e)
        {

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void lblPropietario_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void nudResidentes_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudArea_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudCuota_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarPorCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el propietario seleccionado
                // El ValueMember debe contener el ID de Hacienda
                int idPropietario = Convert.ToInt32(cmbPropietario.SelectedValue);

                // Obtener el estado seleccionado
                bool estado = Convert.ToBoolean(cmbEstado.SelectedValue);

                // Crear el objeto DTO con los datos de los controles
                PropiedadDTO propiedad = new PropiedadDTO
                {
                    Codigo = txtCodigo.Text.Trim(),

                    Tipo = cmbTipo.Text,

                    Area = nudArea.Value,

                    CantidadResidentes = Convert.ToInt32(nudResidentes.Value),

                    CuotaMantenimiento = nudCuota.Value,

                    IdPropietario = idPropietario,

                    Estado = estado
                };

                // Registrar mediante el BLL
                bool registrado = propiedadBLL.Registrar(propiedad);

                if (registrado)
                {
                    MessageBox.Show(
                        "La propiedad se registró correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtDireccion.Clear();


            nudResidentes.Value = 0;
            nudArea.Value = 0;
            nudCuota.Value = 0;

            cmbTipo.SelectedIndex = -1;
            cmbPropietario.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
