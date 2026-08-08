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
    public partial class FrmPenalizacion : Form
    {//instancias 
        PropiedadBLL propiedadBLL = new PropiedadBLL();
        PenalizacionBLL PenalizacionBLL = new PenalizacionBLL();
        public FrmPenalizacion()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmPenalizacion_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
        }

        //metodo para llenar el combobox con las propiedades
        public void CargarPropiedades()
        {
            //se le pide al BLL la lista completa de propiedad que vienen del DAL
            List<PropiedadDTO> propiedades = propiedadBLL.ObtenerTodas();
            cmbPropiedades.DataSource = propiedades;// se llena con esos datos 
            cmbPropiedades.DisplayMember = "Codigo";//se va a ver el codigo de la propiedad
            cmbPropiedades.ValueMember = "IdPropiedad";
        }

        private void btnPenalizacion_Click(object sender, EventArgs e)
        {
            if (cmbPropiedades == null)
            {
                MessageBox.Show("Debe seleccionar una propiedad.");
                return;
            }

            PropiedadDTO seleccionada = (PropiedadDTO)cmbPropiedades.SelectedItem; //casteo para poder usar todas sus propiedades
            try
            {
                CargoFacturableDTO penalizacion = PenalizacionBLL.AplicarPenalizacion(seleccionada);
                MessageBox.Show("La penalización se genero correctamente.");

                MostrarResultado(penalizacion);

            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void MostrarResultado(CargoFacturableDTO penalizacion)
        {
            dvgResultado.DataSource = null;
            dvgResultado.DataSource = new List<CargoFacturableDTO> { penalizacion };

            // Formato de fecha corta
            dvgResultado.Columns["FechaEmision"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dvgResultado.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Que las columnas llenen todo el ancho disponible
            dvgResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Nombres de columnas
            dvgResultado.Columns["Descripcion"].HeaderText = "Descripción";
            dvgResultado.Columns["MontoBase"].HeaderText = "Monto base";
            dvgResultado.Columns["FechaEmision"].HeaderText = "Fecha emisión";
            dvgResultado.Columns["FechaVencimiento"].HeaderText = "Fecha vencimiento";

            // Columnas que no necesitás mostrar
            dvgResultado.Columns["IdCargo"].Visible = false;
            dvgResultado.Columns["IdPropiedad"].Visible = false;
            dvgResultado.Columns["Tipo"].Visible = false;
           




        }
    }
}
