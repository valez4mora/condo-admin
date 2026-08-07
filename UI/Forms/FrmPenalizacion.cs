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
    {
        PropiedadBLL propiedadBLL = new PropiedadBLL();
        CargoFacturableBILL cargoBLL = new CargoFacturableBILL();
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
    }
}
