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
    public partial class FrmGenerarCuota : Form
    {
        //Intancias
        PropiedadBLL propiedadBLL = new PropiedadBLL();
        CargoFacturableBILL cargoBLL = new CargoFacturableBILL();
        FacturaBLL facturaBLL = new FacturaBLL();

            private CargoFacturableDTO cargoGenerado=null;
        public FrmGenerarCuota()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
            btnGenerarFactura.Enabled = false;//desactivado hasta que se genere el cargoFacturable
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
                MessageBox.Show("Debe seleccionar una propiedad.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PropiedadDTO seleccionada = (PropiedadDTO)cmbPropiedades.SelectedItem; //casteo para poder usar todas sus propiedades
            try
            {
                // genera y guarda el cargo en BD
                cargoGenerado = cargoBLL.GenerarCuotaOrdinaria(seleccionada);

                // muestra el cargo en el grid superior
                MostrarResultado(cargoGenerado);

                // habilita el boton de generar factura
                btnGenerarFactura.Enabled = true;

                MessageBox.Show("Cuota generada correctamente para: " + seleccionada.Codigo,
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch(Exception ex)
            {
                //si el bll lanzo una excepcion , se muestra un mensaje en pantalla
                MessageBox.Show("Error: " + ex.Message,
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dvgResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cargoGenerado == null)
            {
                MessageBox.Show("Primero debe generar una cuota ordinaria.",
                   "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PropiedadDTO seleccionada = (PropiedadDTO)cmbPropiedades.SelectedItem;

            try
            {
                FacturaDTO factura = facturaBLL.GenerarFacturaCuotaOrdinaria(seleccionada);//calcula y genera la factura en BD
                //muestra la factura en el datagrid
                MostrarFactura(factura);

                //limpiar datos 
                cargoGenerado = null;
                btnGenerarFactura.Enabled = false;

                MessageBox.Show("Factura emitida correctamente.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }

        private void MostrarFactura(FacturaDTO factura)
        {
            dvgFactura.DataSource = null;
            dvgFactura.DataSource = new List<FacturaDTO> { factura };

            dvgFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgFactura.Columns["IdFactura"].HeaderText = "N.° Factura";
            dvgFactura.Columns["Fecha"].HeaderText = "Fecha";
            dvgFactura.Columns["CodigoPropiedad"].HeaderText = "Propiedad";
            dvgFactura.Columns["TotalColones"].HeaderText = "Total (₡)";
            dvgFactura.Columns["TotalDolares"].HeaderText = "Total ($)";
            dvgFactura.Columns["Estado"].HeaderText = "Estado";
            dvgFactura.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dvgFactura.Columns["TotalColones"].DefaultCellStyle.Format = "N2";
            dvgFactura.Columns["TotalDolares"].DefaultCellStyle.Format = "N2";
            dvgFactura.Columns["IdPropiedad"].Visible = false;

        }
    }
}
