using BLL;
using DAL.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private PropietarioBLL propietarioBLL = new PropietarioBLL();

        // Guarda el Id de la propiedad actualmente cargada en el formulario
        // (se llena al buscar por código; lo usan Actualizar y Eliminar)
        private int idPropiedadSeleccionada = 0;

        // Valores de configuración del condominio (App.config), usados
        // para el cálculo automático de la cuota: Cuota = (Area * Tarifa) + CargoFijo
        private decimal tarifaPorM2 = Convert.ToDecimal(ConfigurationManager.AppSettings["TarifaPorM2"]);
        private decimal cargoFijo = Convert.ToDecimal(ConfigurationManager.AppSettings["CargoFijoMantenimiento"]);

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
            cmbTipo.SelectedIndex = -1;

            CargarPropietarios();

            // La cuota se calcula sola; el usuario no la digita
            nudCuota.Enabled = false;
        }

        private void CargarPropietarios()
        {
            try
            {
                List<PropietarioDTO> propietarios =
                    propietarioBLL.ObtenerTodos();

                cmbPropietario.DataSource = null;
                cmbPropietario.DataSource = propietarios;

                cmbPropietario.DisplayMember = "NombreCompleto";
                cmbPropietario.ValueMember = "IdPersona";

                cmbPropietario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la lista de propietarios: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        // Recalcula la cuota de mantenimiento cada vez que cambia el área.
        // Cuota = (Area * TarifaPorM2) + CargoFijo   (requerimiento 4.1-A)
        private void nudArea_ValueChanged(object sender, EventArgs e)
        {
            nudCuota.Value = (nudArea.Value * tarifaPorM2) + cargoFijo;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtBuscarPorCodigo.Text.Trim();

                PropiedadDTO propiedad = propiedadBLL.ObtenerPorCodigo(codigo);

                if (propiedad == null)
                {
                    MessageBox.Show(
                        "No se encontró ninguna propiedad con ese código.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Recuerda cuál propiedad quedó cargada, para Actualizar/Eliminar
                idPropiedadSeleccionada = propiedad.IdPropiedad;

                txtCodigo.Text = propiedad.Codigo;
                txtDireccion.Text = propiedad.NombrePropietario; // ver nota abajo sobre este campo
                nudResidentes.Value = propiedad.CantidadResidentes;
                nudArea.Value = propiedad.Area; // esto ya dispara el recálculo de la cuota
                cmbTipo.Text = propiedad.Tipo;
                cmbPropietario.SelectedValue = propiedad.IdPropietario;
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPropietario.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar un propietario.");

                int idPropietario = Convert.ToInt32(cmbPropietario.SelectedValue);

                PropiedadDTO propiedad = new PropiedadDTO
                {
                    Codigo = txtCodigo.Text.Trim(),
                    Tipo = cmbTipo.Text,
                    Area = nudArea.Value,
                    CantidadResidentes = Convert.ToInt32(nudResidentes.Value),
                    TarifaMetro = tarifaPorM2,
                    CargoFijo = cargoFijo,
                    CuotaMantenimiento = nudCuota.Value,
                    IdPropietario = idPropietario
                };

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
            try
            {
                if (idPropiedadSeleccionada <= 0)
                    throw new Exception("Primero busque una propiedad por código antes de actualizar.");

                if (cmbPropietario.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar un propietario.");

                PropiedadDTO propiedad = new PropiedadDTO
                {
                    IdPropiedad = idPropiedadSeleccionada,
                    Codigo = txtCodigo.Text.Trim(),
                    Tipo = cmbTipo.Text,
                    Area = nudArea.Value,
                    CantidadResidentes = Convert.ToInt32(nudResidentes.Value),
                    TarifaMetro = tarifaPorM2,
                    CargoFijo = cargoFijo,
                    CuotaMantenimiento = nudCuota.Value,
                    IdPropietario = Convert.ToInt32(cmbPropietario.SelectedValue),
                };

                bool actualizado = propiedadBLL.Modificar(propiedad);

                if (actualizado)
                {
                    MessageBox.Show(
                        "La propiedad se actualizó correctamente.",
                        "Actualización exitosa",
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPropiedadSeleccionada <= 0)
                    throw new Exception("Primero busque una propiedad por código antes de eliminar.");

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de eliminar la propiedad con código " + txtCodigo.Text + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                    return;

                bool eliminado = propiedadBLL.Eliminar(idPropiedadSeleccionada);

                if (eliminado)
                {
                    MessageBox.Show(
                        "La propiedad se eliminó correctamente.",
                        "Eliminación exitosa",
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            // El reporte de propiedades (con filtro por propietario) se resuelve
            // en su propio formulario/módulo de Reportes, no aquí.
            MessageBox.Show(
                "El reporte de propiedades se genera desde el módulo de Reportes.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void LimpiarFormulario()
        {
            idPropiedadSeleccionada = 0;

            txtCodigo.Clear();
            txtDireccion.Clear();
            txtBuscarPorCodigo.Clear();

            nudResidentes.Value = 0;
            nudArea.Value = 0;
            nudCuota.Value = 0;

            cmbTipo.SelectedIndex = -1;
            cmbPropietario.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}