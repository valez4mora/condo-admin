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
    public partial class FrmPropietario : Form
    {
        private PropietarioBLL propietarioBLL = new PropietarioBLL();

        public FrmPropietario()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        // Define explícitamente qué columnas mostrar (en vez de AutoGenerateColumns)
        // para no mostrar IdPersona ni Fotografia (byte[]) en la grilla.
        private void ConfigurarColumnas()
        {
            dgvPropietarios.Columns.Clear();

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Identificacion",
                Name = "colIdentificacion",
                HeaderText = "Identificación",
                Width = 130
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                Name = "colNombre",
                HeaderText = "Nombre",
                Width = 130
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellidos",
                Name = "colApellidos",
                HeaderText = "Apellidos",
                Width = 150
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Sexo",
                Name = "colSexo",
                HeaderText = "Sexo",
                Width = 60
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                Name = "colTelefono",
                HeaderText = "Teléfono",
                Width = 110
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                Name = "colEmail",
                HeaderText = "Correo",
                Width = 180
            });

            dgvPropietarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Direccion",
                Name = "colDireccion",
                HeaderText = "Dirección",
                Width = 200
            });

            dgvPropietarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "EstadoMorosidad",
                Name = "colMorosidad",
                HeaderText = "Moroso",
                Width = 70
            });
        }

        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            CargarListaPropietarios();
        }

        private void CargarListaPropietarios()
        {
            try
            {
                List<PropietarioDTO> propietarios = propietarioBLL.ObtenerTodos();

                // BindingList permite refrescar sin reasignar el DataSource cada vez
                dgvPropietarios.DataSource = new BindingList<PropietarioDTO>(propietarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la lista de propietarios: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarListaPropietarios();
        }
    }
}