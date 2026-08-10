using BLL;
using DTO;
using Integration.Hacienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmPropietario : Form
    {
        private PropietarioBLL propietarioBLL = new PropietarioBLL();
        private IHaciendaService haciendaService = new HaciendaService();
        private int idPropietarioSeleccionado = 0;

        public FrmPropietario()
        {
            InitializeComponent();
            ConfigurarColumnas();
            dgvPropietarios.CellClick += dgvPropietarios_CellClick;
            btnActualizarLista.Click += btnActualizarLista_Click;
        }

        private void ConfigurarColumnas()
        {
            dgvPropietarios.AutoGenerateColumns = false; // ← esta línea faltaba
            dgvPropietarios.Columns.Clear();

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Identificacion",
                Name = "colIdentificacion",
                HeaderText = "Identificación",
                Width = 110
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                Name = "colNombre",
                HeaderText = "Nombre",
                Width = 110
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellidos",
                Name = "colApellidos",
                HeaderText = "Apellidos",
                Width = 120
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                Name = "colTelefono",
                HeaderText = "Teléfono",
                Width = 90
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                Name = "colEmail",
                HeaderText = "Correo",
                Width = 150
            });

            dgvPropietarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "EstadoMorosidad",
                Name = "colMorosidad",
                HeaderText = "Moroso",
                Width = 60
            });
        }

        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            cmbSexo.Items.Clear();
            cmbSexo.Items.Add("M");
            cmbSexo.Items.Add("F");
            cmbSexo.SelectedIndex = -1;

            CargarListaPropietarios();
        }

        private void dgvPropietarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            PropietarioDTO propietario =
                dgvPropietarios.Rows[e.RowIndex]
                .DataBoundItem as PropietarioDTO;

            if (propietario == null)
                return;

            idPropietarioSeleccionado = propietario.IdPersona;

            txtIdentificacion.Text = propietario.Identificacion;
            txtNombre.Text = propietario.Nombre;
            txtApellidos.Text = propietario.Apellidos;
            cmbSexo.Text = propietario.Sexo;
            txtTelefono.Text = propietario.Telefono;
            txtEmail.Text = propietario.Email;
            txtDireccion.Text = propietario.Direccion;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPropietarioSeleccionado <= 0)
                    throw new Exception(
                        "Seleccione un propietario de la lista.");

                PropietarioDTO propietario =
                    new PropietarioDTO
                    {
                        IdPersona = idPropietarioSeleccionado,
                        Identificacion =
                            txtIdentificacion.Text.Trim(),
                        Nombre =
                            txtNombre.Text.Trim(),
                        Apellidos =
                            txtApellidos.Text.Trim(),
                        Sexo =
                            cmbSexo.SelectedItem?.ToString(),
                        Telefono =
                            txtTelefono.Text.Trim(),
                        Email =
                            txtEmail.Text.Trim(),
                        Direccion =
                            txtDireccion.Text.Trim(),

                        EstadoMorosidad = false
                    };

                bool actualizado =
                    propietarioBLL.Modificar(propietario);

                if (actualizado)
                {
                    MessageBox.Show(
                        "Propietario actualizado correctamente.");

                    LimpiarFormulario();
                    CargarListaPropietarios();
                }
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

        private void CargarListaPropietarios()
        {
            try
            {
                dgvPropietarios.DataSource = null;

                List<PropietarioDTO> propietarios =
                    propietarioBLL.ObtenerTodos();

                dgvPropietarios.DataSource =
                    new BindingList<PropietarioDTO>(propietarios);

                dgvPropietarios.ClearSelection();

                idPropietarioSeleccionado = 0;
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

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarListaPropietarios();

            MessageBox.Show(
                "Lista actualizada correctamente.",
                "Actualización",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Consulta el API de Hacienda con la identificación digitada
        // y autocompleta el campo Nombre con la razón social/nombre que devuelve.
        // La API solo entrega un campo "nombre" completo; Apellidos lo ajusta el usuario.
        private void btnBuscarHacienda_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text.Trim();

            if (string.IsNullOrWhiteSpace(identificacion))
            {
                MessageBox.Show(
                    "Digite una identificación antes de buscar.",
                    "Identificación requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                string nombres;
                string apellidos;

                SepararNombreCompleto(
                    resultado.Nombre,
                    out nombres,
                    out apellidos
                );

                txtNombre.Text = nombres;
                txtApellidos.Text = apellidos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo consultar el API de Hacienda: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
                .Split(new[] { ' ' },
                       StringSplitOptions.RemoveEmptyEntries);

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

            apellidos =
                partes[partes.Length - 2] + " " +
                partes[partes.Length - 1];

            nombres = string.Join(
                " ",
                partes.Take(partes.Length - 2)
            );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                    throw new Exception("La identificación es obligatoria.");

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("El nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                    throw new Exception("Los apellidos son obligatorios.");

                PropietarioDTO propietario = new PropietarioDTO
                {
                    Identificacion = txtIdentificacion.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Sexo = cmbSexo.SelectedItem != null ? cmbSexo.SelectedItem.ToString() : null,
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    EstadoMorosidad = false // un propietario nuevo inicia al día
                };

                bool registrado = propietarioBLL.Registrar(propietario);

                if (registrado)
                {
                    MessageBox.Show(
                        "El propietario se registró correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimpiarFormulario();
                    CargarListaPropietarios();
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

        private void btnLimpiarFormulario_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un propietario
                if (idPropietarioSeleccionado <= 0)
                {
                    MessageBox.Show(
                        "Seleccione un propietario de la lista.",
                        "Propietario no seleccionado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Pedir confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este propietario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                    return;

                // Eliminar mediante la BLL
                bool eliminado =
                    propietarioBLL.Eliminar(idPropietarioSeleccionado);

                if (eliminado)
                {
                    MessageBox.Show(
                        "Propietario eliminado correctamente.",
                        "Eliminación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimpiarFormulario();

                    // Quitar la selección actual
                    idPropietarioSeleccionado = 0;

                    // Actualizar DataGridView
                    CargarListaPropietarios();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo eliminar el propietario.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el propietario.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}