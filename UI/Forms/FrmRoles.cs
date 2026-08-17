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
    public partial class FrmRoles : Form
    {
        private readonly RolBLL _bll = new RolBLL();
        private int _idSeleccionado = 0;
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                RolDTO rol = new RolDTO
                {
                    IdRol = _idSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                if (_idSeleccionado == 0)
                {
                    // es nuevo, entonces se inserta
                    _bll.Registrar(rol);
                    MessageBox.Show("Rol registrado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // existe ,se actualiza
                    _bll.Modificar(rol);
                    MessageBox.Show("Rol actualizado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarRoles(); // refresca el grid
                ModoNuevo();   // limpia los campos
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ModoNuevo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (_idSeleccionado == 0) return;

            // confirmación antes de eliminar
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar este rol?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(_idSeleccionado);
                    MessageBox.Show("Rol eliminado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarRoles();
                    ModoNuevo();
                }
                catch (Exception ex)
                {
                    // el SP lanza error si el rol tiene usuarios asignados
                    MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void dgvResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clic en el encabezado, ignorar

            // obtiene el rol de la fila seleccionada
            RolDTO rol = (RolDTO)dgvResultado.Rows[e.RowIndex].DataBoundItem;

            // carga los datos en los campos para editar
            _idSeleccionado = rol.IdRol;
            txtNombre.Text = rol.Nombre;
            txtDescripcion.Text = rol.Descripcion;

            // habilita el botón eliminar solo cuando hay algo seleccionado
            btnEliminar.Enabled = true;
        }
        

        private void FrmRoles_Load(object sender, EventArgs e)
        {

            ConfigurarGrid();
            CargarRoles();
            ModoNuevo(); // arranca en modo nuevo
        }


        // columnas del grid
        private void ConfigurarGrid()
        {
            dgvResultado.AutoGenerateColumns = false;
            dgvResultado.Columns.Clear();
            dgvResultado.ReadOnly = true;
            dgvResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvResultado.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdRol",
                    HeaderText       = "ID",
                    Width            = 50
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre",
                    HeaderText       = "Nombre",
                    Width            = 150
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText       = "Descripción",
                    AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill
                }
            });

        }


        // cargar roles
        private void CargarRoles()
        {
            // va a la BD, trae todos los roles y los muestra en el grid
            dgvResultado.DataSource = _bll.ObtenerTodos();
        }

        //  limpia campos y prepara para ingresar datos 
        private void ModoNuevo()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtNombre.Focus();
            btnEliminar.Enabled = false; // no se puede eliminar si no hay nada seleccionado
        }


    }
}
