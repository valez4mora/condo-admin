using BLL;
using DTO;
using Integration.Hacienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmResidente : Form
    {
        private readonly ResidenteBLL residenteBLL = new ResidenteBLL();
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();
        private readonly IHaciendaService haciendaService = new HaciendaService();

        private int idResidenteSeleccionado = 0;
        private List<ResidenteDTO> residentes = new List<ResidenteDTO>();

        public FrmResidente()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void FrmResidente_Load(object sender, EventArgs e)
        {
            cmbSexo.Items.Clear();
            cmbSexo.Items.Add("M");
            cmbSexo.Items.Add("F");
            cmbSexo.SelectedIndex = -1;

            CargarPropiedades();
            CargarResidentes();
            LimpiarFormulario();
        }

        private void ConfigurarColumnas()
        {
            dgvResidentes.AutoGenerateColumns = false;
            dgvResidentes.Columns.Clear();

            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Identificacion",
                Name = "colIdentificacion",
                HeaderText = "Identificación",
                Width = 110
            });

            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                Name = "colNombre",
                HeaderText = "Nombre",
                Width = 110
            });

            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellidos",
                Name = "colApellidos",
                HeaderText = "Apellidos",
                Width = 130
            });

            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                Name = "colTelefono",
                HeaderText = "Teléfono",
                Width = 90
            });

            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                Name = "colEmail",
                HeaderText = "Correo",
                Width = 150
            });

            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdPropiedad",
                Name = "colIdPropiedad",
                HeaderText = "Id Propiedad",
                Width = 85
            });
        }

        private void CargarPropiedades()
        {
            try
            {
                List<PropiedadDTO> propiedades = propiedadBLL.ObtenerTodas();

                cmbPropiedad.DataSource = null;
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.SelectedIndex = -1;
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

        private void CargarResidentes()
        {
            try
            {
                residentes = residenteBLL.ObtenerTodos();
                dgvResidentes.DataSource = null;
                dgvResidentes.DataSource = new BindingList<ResidenteDTO>(residentes);
                dgvResidentes.ClearSelection();
                idResidenteSeleccionado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la lista de residentes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvResidentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ResidenteDTO residente = dgvResidentes.Rows[e.RowIndex].DataBoundItem as ResidenteDTO;

            if (residente == null)
                return;

            idResidenteSeleccionado = residente.IdPersona;

            txtIdentificacion.Text = residente.Identificacion;
            txtNombre.Text = residente.Nombre;
            txtApellidos.Text = residente.Apellidos;
            cmbSexo.Text = residente.Sexo;
            txtTelefono.Text = residente.Telefono;
            txtEmail.Text = residente.Email;
            txtDireccion.Text = residente.Direccion;
            cmbPropiedad.SelectedValue = residente.IdPropiedad;
        }

        private ResidenteDTO ObtenerDatosFormulario()
        {
            if (cmbPropiedad.SelectedValue == null)
                throw new Exception("Debe seleccionar una propiedad.");

            return new ResidenteDTO
            {
                IdPersona = idResidenteSeleccionado,
                Identificacion = txtIdentificacion.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Sexo = cmbSexo.SelectedItem == null ? null : cmbSexo.SelectedItem.ToString(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                IdPropiedad = Convert.ToInt32(cmbPropiedad.SelectedValue)
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ResidenteDTO residente = ObtenerDatosFormulario();

                if (residenteBLL.Registrar(residente))
                {
                    MessageBox.Show(
                        "Residente registrado correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarResidentes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idResidenteSeleccionado <= 0)
                    throw new Exception("Seleccione un residente de la lista.");

                ResidenteDTO residente = ObtenerDatosFormulario();

                if (residenteBLL.Modificar(residente))
                {
                    MessageBox.Show(
                        "Residente actualizado correctamente.",
                        "Actualización exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarResidentes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idResidenteSeleccionado <= 0)
                    throw new Exception("Seleccione un residente de la lista.");

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este residente?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                if (residenteBLL.Eliminar(idResidenteSeleccionado))
                {
                    MessageBox.Show(
                        "Residente eliminado correctamente.",
                        "Eliminación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarResidentes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el residente.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterio))
            {
                CargarResidentes();
                return;
            }

            List<ResidenteDTO> resultado = residentes
                .Where(r =>
                    (!string.IsNullOrEmpty(r.Identificacion) && r.Identificacion.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(r.Nombre) && r.Nombre.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(r.Apellidos) && r.Apellidos.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            dgvResidentes.DataSource = null;
            dgvResidentes.DataSource = new BindingList<ResidenteDTO>(resultado);
            dgvResidentes.ClearSelection();
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarPropiedades();
            CargarResidentes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idResidenteSeleccionado = 0;
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();
            cmbSexo.SelectedIndex = -1;
            cmbPropiedad.SelectedIndex = -1;
            dgvResidentes.ClearSelection();
            txtIdentificacion.Focus();
        }

        private void btnBuscarHacienda_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text.Trim();

            if (string.IsNullOrWhiteSpace(identificacion))
            {
                MessageBox.Show(
                    "Digite una identificación antes de consultar Hacienda.",
                    "Identificación requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                HaciendaResponseDTO resultado = haciendaService.ConsultarIdentificacion(identificacion);

                if (resultado == null || string.IsNullOrWhiteSpace(resultado.Nombre))
                {
                    MessageBox.Show(
                        "No se encontró información para esa identificación en Hacienda.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string nombres;
                string apellidos;
                SepararNombreCompleto(resultado.Nombre, out nombres, out apellidos);

                txtNombre.Text = nombres;
                txtApellidos.Text = apellidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo consultar el API de Hacienda: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SepararNombreCompleto(string nombreCompleto, out string nombres, out string apellidos)
        {
            nombres = "";
            apellidos = "";

            if (string.IsNullOrWhiteSpace(nombreCompleto))
                return;

            string[] partes = nombreCompleto
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 1)
            {
                nombres = partes[0];
                return;
            }

            if (partes.Length == 2)
            {
                nombres = partes[0];
                apellidos = partes[1];
                return;
            }

            apellidos = partes[partes.Length - 2] + " " + partes[partes.Length - 1];
            nombres = string.Join(" ", partes.Take(partes.Length - 2));
        }
    }
}
