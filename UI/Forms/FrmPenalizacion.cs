using BLL;
using DTO;
using Facade;
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
        // Se mantiene porque se utiliza para cargar las propiedades.
        private readonly PropiedadBLL propiedadBLL =
            new PropiedadBLL();

        // Facade utilizado para aplicar la operación financiera.
        private readonly GestionFinancieraFacade gestionFinanciera =
            new GestionFinancieraFacade();

        public FrmPenalizacion()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void FrmPenalizacion_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
        }

        // Método para llenar el ComboBox con las propiedades.
        public void CargarPropiedades()
        {
            try
            {
                List<PropiedadDTO> propiedades =
                    propiedadBLL.ObtenerTodas();

                cmbPropiedades.DataSource = null;
                cmbPropiedades.DisplayMember = "Codigo";
                cmbPropiedades.ValueMember = "IdPropiedad";
                cmbPropiedades.DataSource = propiedades;

                cmbPropiedades.SelectedIndex =
                    propiedades.Count > 0 ? 0 : -1;

                btnPenalizacion.Enabled =
                    propiedades.Count > 0;
            }
            catch (Exception ex)
            {
                cmbPropiedades.DataSource = null;
                btnPenalizacion.Enabled = false;

                MessageBox.Show(
                    "No se pudieron cargar las propiedades.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPenalizacion_Click(
            object sender,
            EventArgs e)
        {
            // Se valida el elemento seleccionado, no el ComboBox.
            PropiedadDTO seleccionada =
                cmbPropiedades.SelectedItem as PropiedadDTO;

            if (seleccionada == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una propiedad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                btnPenalizacion.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // La UI utiliza el Facade.
                CargoFacturableDTO penalizacion =
                    gestionFinanciera.AplicarPenalizacion(
                        seleccionada);

                if (penalizacion == null)
                {
                    throw new InvalidOperationException(
                        "No fue posible generar la penalización.");
                }

                MostrarResultado(penalizacion);

                MessageBox.Show(
                    "La penalización se generó correctamente.",
                    "Proceso completado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "No se pudo generar la penalización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnPenalizacion.Enabled =
                    cmbPropiedades.SelectedItem != null;
            }
        }

        public void MostrarResultado(
            CargoFacturableDTO penalizacion)
        {
            dvgResultado.DataSource = null;
            dvgResultado.DataSource =
                new List<CargoFacturableDTO>
                {
                    penalizacion
                };

            // Formato de fecha corta.
            if (dvgResultado.Columns["FechaEmision"] != null)
            {
                dvgResultado.Columns["FechaEmision"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dvgResultado.Columns["FechaVencimiento"] != null)
            {
                dvgResultado.Columns["FechaVencimiento"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            // Las columnas llenan el ancho disponible.
            dvgResultado.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Nombres de columnas.
            if (dvgResultado.Columns["Descripcion"] != null)
            {
                dvgResultado.Columns["Descripcion"].HeaderText =
                    "Descripción";
            }

            if (dvgResultado.Columns["MontoBase"] != null)
            {
                dvgResultado.Columns["MontoBase"].HeaderText =
                    "Monto base";

                dvgResultado.Columns["MontoBase"]
                    .DefaultCellStyle.Format = "N2";
            }

            if (dvgResultado.Columns["IVA"] != null)
            {
                dvgResultado.Columns["IVA"]
                    .DefaultCellStyle.Format = "N2";
            }

            if (dvgResultado.Columns["Total"] != null)
            {
                dvgResultado.Columns["Total"]
                    .DefaultCellStyle.Format = "N2";
            }

            if (dvgResultado.Columns["FechaEmision"] != null)
            {
                dvgResultado.Columns["FechaEmision"].HeaderText =
                    "Fecha emisión";
            }

            if (dvgResultado.Columns["FechaVencimiento"] != null)
            {
                dvgResultado.Columns["FechaVencimiento"].HeaderText =
                    "Fecha vencimiento";
            }

            // Columnas que no se necesitan mostrar.
            if (dvgResultado.Columns["IdCargo"] != null)
            {
                dvgResultado.Columns["IdCargo"].Visible = false;
            }

            if (dvgResultado.Columns["IdPropiedad"] != null)
            {
                dvgResultado.Columns["IdPropiedad"].Visible = false;
            }

            if (dvgResultado.Columns["Tipo"] != null)
            {
                dvgResultado.Columns["Tipo"].Visible = false;
            }

            dvgResultado.ReadOnly = true;
            dvgResultado.AllowUserToAddRows = false;
            dvgResultado.AllowUserToDeleteRows = false;
            dvgResultado.MultiSelect = false;
            dvgResultado.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}