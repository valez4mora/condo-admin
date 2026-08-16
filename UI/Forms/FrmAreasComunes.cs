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
    public partial class FrmAreasComunes : Form
    {
        private readonly AreaComunBLL _bll = new AreaComunBLL();
        private int _idSeleccionado = 0;
        private bool _limpiando = false;
        public FrmAreasComunes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FrmAreasComunes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarAreas();
            LimpiarFormulario();



        }

        //configurar columnas
        private void ConfigurarGrid()
        {
            dgvAreas.AutoGenerateColumns = false;
            dgvAreas.Columns.Clear();
            dgvAreas.ReadOnly = true;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.MultiSelect = false;

            dgvAreas.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdArea",
                    HeaderText       = "ID",
                    Width            = 45
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre",
                    HeaderText       = "Nombre",
                    Width            = 160
                },

                 new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "HorarioTexto",
                    HeaderText       = "Horario",
                    Width            = 170
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CapacidadMaxima",
                    HeaderText       = "Capacidad",
                    Width            = 80
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Tarifa",
                    HeaderText       = "Tarifa (₡)",
                    Width            = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                }
            });
        }


        //cargar areas en el grid
        private void CargarAreas()
        {
            try
            {
                List<AreaComunDTO> lista = _bll.ObtenerTodas();

                dgvAreas.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las áreas comunes:\n" + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //selecionar en el grid
        private void dgvAreas_SelectionChanged(object sender, EventArgs e)
        {
            if (_limpiando) return; // si estamos limpiando, ignoramos el evento
            if (dgvAreas.CurrentRow == null) return;

            AreaComunDTO area = dgvAreas.CurrentRow.DataBoundItem as AreaComunDTO;
            if (area == null) return;

            _idSeleccionado = area.IdArea;
            txtNombre.Text = area.Nombre;
            txtDescripcion.Text = area.Descripcion;
            numericUpDown1.Value = area.CapacidadMaxima;
            numericUpDown2.Value = area.Tarifa;
            dateTimePicker1.Value = DateTime.Today.Add(area.HoraApertura);
            dateTimePicker2.Value = DateTime.Today.Add(area.HoraCierre);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Construimos el DTO con los valores que el usuario ingresó
                AreaComunDTO area = new AreaComunDTO
                {
                    IdArea = _idSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    CapacidadMaxima = (int)numericUpDown1.Value,
                    Tarifa = numericUpDown2.Value,
                    HoraApertura = dateTimePicker1.Value.TimeOfDay,
                    HoraCierre = dateTimePicker2.Value.TimeOfDay
                };

                if (_idSeleccionado == 0)
                {
                    // nuevo
                    _bll.Registrar(area);
                    MessageBox.Show("Área común registrada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // modificar
                    _bll.Modificar(area);
                    MessageBox.Show("Área común actualizada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarFormulario();
                CargarAreas(); // Refrescar el grid
            }
            catch (Exception ex)
            {
           
                MessageBox.Show(ex.Message, "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un área del listado para eliminar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult r = MessageBox.Show(
                "¿Está seguro de que desea eliminar el área seleccionada?\n" +
                "No se podrá eliminar si tiene reservas o bloqueos asociados.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes) return;

            try
            {
                _bll.Eliminar(_idSeleccionado);
                MessageBox.Show("Área común eliminada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarAreas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }


        private void LimpiarFormulario()
        {
            _limpiando = true; 
            _idSeleccionado = 0;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 0;
            dateTimePicker1.Value = DateTime.Today.AddHours(8);
            dateTimePicker2.Value = DateTime.Today.AddHours(22);
            dgvAreas.ClearSelection();
            _limpiando = false; 
        }

        private void dgvAreas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
