using BLL;
using DTO;
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
    public partial class FrmUsuarios : Form
    {

        private readonly UsuarioBLL _bll = new UsuarioBLL();
        private readonly RolBLL _rolBll = new RolBLL();
        private int _idSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

            ConfigurarGrid();
            CargarRoles();
            CargarEstados();
            CargarUsuarios();
            ModoNuevo();


        }

        // configurar columnas
        private void ConfigurarGrid()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdUsuario",
                    HeaderText       = "ID",
                    Width            = 40
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Usuario",
                    HeaderText       = "Usuario",
                    Width            = 150
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreRol",
                    HeaderText       = "Rol",
                    Width            = 130
                },
                new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Estado",
                    HeaderText       = "Activo",
                    Width            = 60
                }
            });
        }


        //cargar roles
        private void CargarRoles()
        {
            List<RolDTO> roles = _rolBll.ObtenerTodos();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "IdRol";
            cmbRoles.SelectedIndex = -1;
        }

        // cargar estados 
        private void CargarEstados()
        {
            cmbEstados.Items.Clear();
            cmbEstados.Items.Add("Activo");
            cmbEstados.Items.Add("Inactivo");
            cmbEstados.SelectedIndex = 0; 
        }
        // cargar usuarios 
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = _bll.ObtenerTodos();
        }

        // limpiar 
        private void ModoNuevo()
        {
            _idSeleccionado = 0;
            txtUsuario.Clear();
            txtContrasena.Clear();
            cmbRoles.SelectedIndex = -1;
            cmbEstados.SelectedIndex = 0;
            txtUsuario.Focus();
            btnEliminar.Enabled = false;
            // en modo nuevo la contraseña es obligatoria
            txtContrasena.Enabled = true;
        }


        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ModoNuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoles.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar un rol.");

                RolDTO rolSeleccionado = (RolDTO)cmbRoles.SelectedItem;

                UsuarioDTO usuario = new UsuarioDTO
                {
                    IdUsuario = _idSeleccionado,
                    Usuario = txtUsuario.Text.Trim(),
                    Contrasena = txtContrasena.Text,
                    IdRol = rolSeleccionado.IdRol,
                    Estado = cmbEstados.SelectedItem.ToString() == "Activo"
                };

                if (_idSeleccionado == 0)
                {
                    // modo nuevo 
                    if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                        throw new Exception("La contraseña es obligatoria al crear un usuario.");

                    _bll.Registrar(usuario);
                    MessageBox.Show("Usuario registrado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // actualiza
                    _bll.Modificar(usuario);

                    // si escribió una nueva contraseña, también la cambia
                    if (!string.IsNullOrWhiteSpace(txtContrasena.Text))
                        _bll.CambiarContrasena(_idSeleccionado, txtContrasena.Text);

                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarUsuarios();
                ModoNuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (_idSeleccionado == 0) return;

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(_idSeleccionado);
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    ModoNuevo();
                }
                catch (Exception ex)
                {
                    // el SP lanza error si es el último administrador
                    MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            UsuarioDTO usuario = (UsuarioDTO)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;

            _idSeleccionado = usuario.IdUsuario;
            txtUsuario.Text = usuario.Usuario;
            txtContrasena.Clear(); // nunca mostramos la contraseña
            cmbEstados.SelectedItem = usuario.Estado ? "Activo" : "Inactivo";

            // selecciona el rol correspondiente en el ComboBox
            foreach (RolDTO rol in cmbRoles.Items)
            {
                if (rol.IdRol == usuario.IdRol)
                {
                    cmbRoles.SelectedItem = rol;
                    break;
                }
            }

            btnEliminar.Enabled = true;
        }
    }








}
    