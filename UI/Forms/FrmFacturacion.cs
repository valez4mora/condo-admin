using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI.Forms
{
    public partial class FrmFacturacion : Form
    {
        //Intancias
        PropiedadBLL propiedadBLL = new PropiedadBLL();
        CargoFacturableBILL cargoBLL = new CargoFacturableBILL();
        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
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

        private void btbGenerarCuota_Click(object sender, EventArgs e)
        {
            if (cmbPropiedades.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una propiedad.");
                return;
            }

            PropiedadDTO seleccionada = (PropiedadDTO)cmbPropiedades.SelectedItem; //casteo para poder usar todas sus propiedades
            try
            {
                CargoFacturableDTO cargoGenerado = cargoBLL.GenerarCuotaOrdinaria(seleccionada);
                
                    MessageBox.Show("Cuota generada correctamente."+seleccionada.Codigo);

                MostrarResultado(cargoGenerado);


            }
            catch(Exception ex)
            {
                //si el bll lanzo una excepcion , se muestra un mensaje en pantalla
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void MostrarResultado(CargoFacturableDTO cargo)
        {
            dvgResultado.DataSource = null;//se limpia
            List<CargoFacturableDTO> lista = new List<CargoFacturableDTO> { cargo };

            dvgResultado.DataSource = lista;

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
            dvgResultado.Columns["Estado"].HeaderText = "Estado";
            dvgResultado.Columns["Estado"].Visible = false;
            dvgResultado.Columns["Tipo"].Visible = false;
        }
    }
}
