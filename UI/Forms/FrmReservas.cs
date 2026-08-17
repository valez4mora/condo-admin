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
using Microsoft.VisualBasic;
namespace UI.Forms
{
    public partial class FrmReservas : Form
    {
        private readonly ReservaBLL _bll = new ReservaBLL();
        private readonly PropiedadBLL _bllProp = new PropiedadBLL();
        private readonly AreaComunBLL _bllArea = new AreaComunBLL();
        private readonly ResidenteBLL _bllRes = new ResidenteBLL();

        private int _idSeleccionado = 0;
        private bool _limpiando = false;
        public FrmReservas()
        {
            InitializeComponent();
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {

            CargarComboPropiedades();
            CargarComboAreas();
            CargarComboEstados();
            CargarReservas();
            LimpiarFormulario();


        }

        private void CargarComboPropiedades()
        {
            try
            {
                List<PropiedadDTO> lista = _bllProp.ObtenerTodas();
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.DataSource = lista;
               
                cmbPropiedad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar propiedades:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboAreas()
        {
            try
            {
                List<AreaComunDTO> lista = _bllArea.ObtenerTodas();
               cmbArea.DisplayMember = "Nombre"; 
                 cmbArea.ValueMember = "IdArea";
                cmbArea.DataSource = lista;
                
               
                cmbArea.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar áreas:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = -1;
            cmbEstado.Enabled = false; // solo informativo
        }


       
       

       //cargar las reservas en el grid 
        private void CargarReservas()
        {
            try
            {
                dgvResultado.AutoGenerateColumns = false;
                dgvResultado.Columns.Clear();
                dgvResultado.ReadOnly = true;
                dgvResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvResultado.MultiSelect = false;

                dgvResultado.Columns.AddRange(new DataGridViewColumn[]
                {
                    new DataGridViewTextBoxColumn { DataPropertyName = "IdReserva",       HeaderText = "ID",        Width = 40  },
                    new DataGridViewTextBoxColumn { DataPropertyName = "FechaTexto",      HeaderText = "Fecha",     Width = 90  },
                    new DataGridViewTextBoxColumn { DataPropertyName = "AreaComun",       HeaderText = "Área",      Width = 130 },
                    new DataGridViewTextBoxColumn { DataPropertyName = "CodigoPropiedad", HeaderText = "Propiedad", Width = 90  },
                    new DataGridViewTextBoxColumn { DataPropertyName = "NombreResidente", HeaderText = "Residente", Width = 140 },
                    new DataGridViewTextBoxColumn { DataPropertyName = "HorarioTexto",    HeaderText = "Horario",   Width = 150 },
                    new DataGridViewTextBoxColumn { DataPropertyName = "Estado",          HeaderText = "Estado",    Width = 90  },
                });

                dgvResultado.DataSource = _bll.ObtenerTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_limpiando || cmbPropiedad.SelectedValue == null) return;

            try
            {
                int idPropiedad = (int)cmbPropiedad.SelectedValue;
                List<ResidenteDTO> residentes = _bllRes.ObtenerPorPropiedad(idPropiedad);
                cmbResidente.DataSource = residentes;
                cmbResidente.DisplayMember = "Nombre";
                cmbResidente.ValueMember = "IdPersona";

                if (residentes.Count == 0)
                    MessageBox.Show("Esta propiedad no tiene residentes registrados.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar residentes:\n" + ex.ToString(),
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbResidente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numCapacidadMaxima_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeApertura_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeCierre_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbPropiedad.SelectedValue == null)
                    throw new Exception("Debe seleccionar una propiedad.");
                if (cmbArea.SelectedValue == null)
                    throw new Exception("Debe seleccionar un área común.");
                if (cmbResidente.SelectedValue == null)
                    throw new Exception("Debe seleccionar un residente.");

                ReservaDTO reserva = new ReservaDTO
                {
                    IdPropiedad = (int)cmbPropiedad.SelectedValue,
                    IdArea = (int)cmbArea.SelectedValue,
                    IdResidente = (int)cmbResidente.SelectedValue,
                    Fecha = dateTimeApertura.Value.Date,
                    HoraInicio = dateTimeApertura.Value.TimeOfDay,
                    HoraFin = dateTimeCierre.Value.TimeOfDay,
                    CantidadPersonas = (int)numCapacidadMaxima.Value
                };

                _bll.CrearReserva(reserva);
                MessageBox.Show("Reserva creada correctamente. Estado: Pendiente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbPropiedad.SelectedValue == null)
                    throw new Exception("Debe seleccionar una propiedad.");
                if (cmbArea.SelectedValue == null)
                    throw new Exception("Debe seleccionar un área común.");
                if (cmbResidente.SelectedValue == null)
                    throw new Exception("Debe seleccionar un residente.");

                ReservaDTO reserva = new ReservaDTO
                {
                    IdPropiedad = (int)cmbPropiedad.SelectedValue,
                    IdArea = (int)cmbArea.SelectedValue,
                    IdResidente = (int)cmbResidente.SelectedValue,
                    Fecha = dateTimeApertura.Value.Date,
                    HoraInicio = dateTimeApertura.Value.TimeOfDay,
                    HoraFin = dateTimeCierre.Value.TimeOfDay,
                    CantidadPersonas = (int)numCapacidadMaxima.Value
                };

                _bll.CrearReserva(reserva);
                MessageBox.Show("Reserva creada correctamente. Estado: Pendiente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {

            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná una reserva del listado.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string motivo = Interaction.InputBox(
                "Ingresá el motivo del rechazo:",
                "Rechazar reserva", "");

            if (string.IsNullOrWhiteSpace(motivo)) return;

            try
            {
                _bll.Rechazar(_idSeleccionado, motivo);
                MessageBox.Show("Reserva rechazada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná una reserva del listado.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string motivo = Interaction.InputBox(
                "Ingresá el motivo de cancelación:",
                "Cancelar reserva", "");

            if (string.IsNullOrWhiteSpace(motivo)) return;

            DialogResult confirm = MessageBox.Show(
                "¿Confirmás la cancelación de esta reserva?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _bll.Cancelar(_idSeleccionado, motivo);
                MessageBox.Show("Reserva cancelada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        //limpiar
        private void LimpiarFormulario()
        {
            _limpiando = true;
            _idSeleccionado = 0;

            cmbPropiedad.SelectedIndex = -1;
            cmbArea.SelectedIndex = -1;
            cmbResidente.DataSource = null;
            cmbEstado.SelectedIndex = -1;
            numCapacidadMaxima.Value = 1;
            dateTimeApertura.Value = DateTime.Today.AddHours(8);
            dateTimeCierre.Value = DateTime.Today.AddHours(10);
            txtMotivo.Text = string.Empty;

            btnAprobar.Enabled = false;
            btnRechazar.Enabled = false;
            btnCancelar.Enabled = false;

            dgvResultado.ClearSelection();
            _limpiando = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            LimpiarFormulario();


        }

        private void dgvResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            ReservaDTO r = dgvResultado.Rows[e.RowIndex].DataBoundItem as ReservaDTO;
            if (r == null) return;

            _idSeleccionado = r.IdReserva;

            _limpiando = true;
            cmbPropiedad.SelectedValue = r.IdPropiedad;
            cmbArea.SelectedValue = r.IdArea;
            dateTimeApertura.Value = DateTime.Today.Add(r.HoraInicio);
            dateTimeCierre.Value = DateTime.Today.Add(r.HoraFin);
            numCapacidadMaxima.Value = r.CantidadPersonas;
            cmbEstado.SelectedItem = r.Estado;
            txtMotivo.Text = r.MotivoCancelacion ?? string.Empty;
            _limpiando = false;

            // Habilitar botones según estado
            btnAprobar.Enabled = r.Estado == "Pendiente";
            btnRechazar.Enabled = r.Estado == "Pendiente";
            btnCancelar.Enabled = r.Estado != "Cancelada";







        }
    }
}
