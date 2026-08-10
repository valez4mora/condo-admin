using BLL;
using DTO;
using Integration.Hacienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmPropietario : Form
    {
        private readonly PropietarioBLL propietarioBLL = new PropietarioBLL();
        private readonly IHaciendaService haciendaService = new HaciendaService();
        private int idPropietarioSeleccionado = 0;

        public FrmPropietario()
        {
            InitializeComponent();
            this.Load += FrmPropietario_Load;
            dgvPropietarios.CellClick += dgvPropietarios_CellClick;
            btnActualizarLista.Click += btnActualizarLista_Click;
        }

        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();

            cmbSexo.Items.Clear();
            cmbSexo.Items.AddRange(new[] { "M", "F" });
            cmbSexo.SelectedIndex = -1;

            CargarListaPropietarios();
        }

        private void ConfigurarColumnas()
        {
            dgvPropietarios.AutoGenerateColumns = false;
            dgvPropietarios.Columns.Clear();

            dgvPropietarios.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Identificacion", HeaderText = "Identificación", Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nombre",         HeaderText = "Nombre",         Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Apellidos",      HeaderText = "Apellidos",      Width = 120 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefono",       HeaderText = "Teléfono",       Width = 90  },
                new DataGridViewTextBoxColumn { DataPropertyName = "Email",          HeaderText = "Correo",         Width = 150 },
                new DataGridViewCheckBoxColumn { DataPropertyName = "EstadoMorosidad", HeaderText = "Moroso",       Width = 60  }
            });
        }

        private void CargarListaPropietarios()
        {
            try
            {
                List<PropietarioDTO> propietarios = propietarioBLL.ObtenerTodos();
                dgvPropietarios.DataSource = new BindingList<PropietarioDTO>(propietarios);
                dgvPropietarios.ClearSelection();
                idPropietarioSeleccionado = 0;
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar la lista de propietarios.", ex);
            }
        }

        private void dgvPropietarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPropietarios.Rows[e.RowIndex].DataBoundItem is PropietarioDTO propietario)
            {
                idPropietarioSeleccionado = propietario.IdPersona;
                txtIdentificacion.Text = propietario.Identificacion;
                txtNombre.Text = propietario.Nombre;
                txtApellidos.Text = propietario.Apellidos;
                cmbSexo.Text = propietario.Sexo;
                txtTelefono.Text = propietario.Telefono;
                txtEmail.Text = propietario.Email;
                txtDireccion.Text = propietario.Direccion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposObligatorios();

                PropietarioDTO propietario = ConstruirPropietarioDesdeFormulario();
                bool registrado = propietarioBLL.Registrar(propietario);

                if (registrado)
                {
                    MessageBox.Show("El propietario se registró correctamente.",
                        "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarListaPropietarios();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPropietarioSeleccionado <= 0)
                    throw new Exception("Seleccione un propietario de la lista.");

                ValidarCamposObligatorios();

                PropietarioDTO propietario = ConstruirPropietarioDesdeFormulario();
                propietario.IdPersona = idPropietarioSeleccionado;

                bool actualizado = propietarioBLL.Modificar(propietario);

                if (actualizado)
                {
                    MessageBox.Show("Propietario actualizado correctamente.",
                        "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarListaPropietarios();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPropietarioSeleccionado <= 0)
                    throw new Exception("Seleccione un propietario de la lista.");

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este propietario?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No) return;

                bool eliminado = propietarioBLL.Eliminar(idPropietarioSeleccionado);

                if (eliminado)
                {
                    MessageBox.Show("Propietario eliminado correctamente.",
                        "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarListaPropietarios();
                }
                else
                {
                    MostrarError("No se pudo eliminar el propietario.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo eliminar el propietario.", ex);
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarListaPropietarios();
            MessageBox.Show("Lista actualizada correctamente.",
                "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscarHacienda_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                MessageBox.Show("Digite una identificación antes de buscar.",
                    "Identificación requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                HaciendaResponseDTO resultado = haciendaService.ConsultarIdentificacion(txtIdentificacion.Text.Trim());

                if (resultado == null || string.IsNullOrWhiteSpace(resultado.Nombre))
                {
                    MessageBox.Show("No se encontró información para esa identificación en Hacienda.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SepararNombreCompleto(resultado.Nombre, out string nombres, out string apellidos);
                txtNombre.Text = nombres;
                txtApellidos.Text = apellidos;
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo consultar el API de Hacienda.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnLimpiarFormulario_Click(object sender, EventArgs e) => LimpiarFormulario();

        // ── Helpers ──────────────────────────────────────────────────────────

        private PropietarioDTO ConstruirPropietarioDesdeFormulario()
        {
            return new PropietarioDTO
            {
                Identificacion = txtIdentificacion.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Sexo = cmbSexo.SelectedItem?.ToString(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EstadoMorosidad = false
            };
        }

        private void ValidarCamposObligatorios()
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                throw new Exception("La identificación es obligatoria.");
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                throw new Exception("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                throw new Exception("Los apellidos son obligatorios.");
        }

        private void LimpiarFormulario()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            cmbSexo.SelectedIndex = -1;
            idPropietarioSeleccionado = 0;
            dgvPropietarios.ClearSelection();
            txtIdentificacion.Focus();
        }

        private void SepararNombreCompleto(string nombreCompleto, out string nombres, out string apellidos)
        {
            nombres = apellidos = string.Empty;

            if (string.IsNullOrWhiteSpace(nombreCompleto)) return;

            string[] partes = nombreCompleto.Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (partes.Length)
            {
                case 1:
                    nombres = partes[0];
                    break;
                case 2:
                    nombres = partes[0];
                    apellidos = partes[1];
                    break;
                default:
                    apellidos = $"{partes[partes.Length - 2]} {partes[partes.Length - 1]}";
                    nombres = string.Join(" ", partes, 0, partes.Length - 2);
                    break;
            }
        }

        private static void MostrarError(string mensaje, Exception ex = null)
        {
            string texto = ex != null ? $"{mensaje}\n\n{ex.Message}" : mensaje;
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}