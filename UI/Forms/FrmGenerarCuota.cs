using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmGenerarCuota : Form
    {
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();
        private readonly CargoFacturableBLL cargoBLL = new CargoFacturableBLL();
        private readonly FacturaBLL facturaBLL = new FacturaBLL();
        private CargoFacturableDTO cargoGenerado;
        private bool cargando;

        public FrmGenerarCuota() { InitializeComponent(); }

        private void FrmGenerarCuota_Load(object sender, EventArgs e)
        {
            ConfigurarGrid(dgvCuota);
            ConfigurarGrid(dgvFactura);
            CargarPropiedades();
        }

        private static void ConfigurarGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarPropiedades()
        {
            try
            {
                cargando = true;
                List<PropiedadDTO> propiedades = propiedadBLL.ObtenerTodas()
                    .OrderBy(p => p.Codigo).ToList();
                cmbPropiedades.DataSource = null;
                cmbPropiedades.DisplayMember = "Codigo";
                cmbPropiedades.ValueMember = "IdPropiedad";
                cmbPropiedades.DataSource = propiedades;
                cmbPropiedades.SelectedIndex = propiedades.Count > 0 ? 0 : -1;
                lblSinDatos.Visible = propiedades.Count == 0;
                cmbPropiedades.Enabled = propiedades.Count > 0;
            }
            catch (Exception ex)
            {
                cmbPropiedades.DataSource = null;
                cmbPropiedades.Enabled = false;
                lblSinDatos.Text = "No fue posible cargar las propiedades.";
                lblSinDatos.Visible = true;
                MessageBox.Show("No se pudieron cargar las propiedades.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
                ReiniciarProceso();
                MostrarVistaPrevia();
            }
        }

        private void cmbPropiedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            ReiniciarProceso();
            MostrarVistaPrevia();
        }

        private void MostrarVistaPrevia()
        {
            PropiedadDTO p = cmbPropiedades.SelectedItem as PropiedadDTO;
            btnGenerarCuota.Enabled = p != null;
            if (p == null)
            {
                lblDatosPropiedad.Text = "Seleccione una propiedad para consultar sus datos.";
                lblCalculo.Text = "Cuota base: ₡0,00\nIVA (13 %): ₡0,00\nTotal: ₡0,00\nFondo de reserva (10 %): ₡0,00";
                return;
            }

            decimal baseCuota = decimal.Round((p.Area * p.TarifaMetro) + p.CargoFijo, 2,
                MidpointRounding.AwayFromZero);
            decimal iva = decimal.Round(baseCuota * 0.13m, 2, MidpointRounding.AwayFromZero);
            decimal fondo = decimal.Round(baseCuota * 0.10m, 2, MidpointRounding.AwayFromZero);

            lblDatosPropiedad.Text = "Código: " + p.Codigo + "\nTipo: " + p.Tipo +
                "\nÁrea: " + p.Area.ToString("N2") + " m²\nTarifa por m²: ₡" +
                p.TarifaMetro.ToString("N2") + "\nCargo fijo: ₡" + p.CargoFijo.ToString("N2");
            lblFormula.Text = "Fórmula: (" + p.Area.ToString("N2") + " m² × ₡" +
                p.TarifaMetro.ToString("N2") + ") + ₡" + p.CargoFijo.ToString("N2");
            lblCalculo.Text = "Cuota base: ₡" + baseCuota.ToString("N2") +
                "\nIVA (13 %): ₡" + iva.ToString("N2") +
                "\nTotal: ₡" + (baseCuota + iva).ToString("N2") +
                "\nFondo de reserva (10 %): ₡" + fondo.ToString("N2") +
                "\nVencimiento estimado: " + DateTime.Today.AddDays(30).ToString("dd/MM/yyyy");
            lblEstado.Text = "Lista para generar";
            lblEstado.ForeColor = Color.FromArgb(39, 108, 174);
        }

        private void btnGenerarCuota_Click(object sender, EventArgs e)
        {
            PropiedadDTO propiedad = cmbPropiedades.SelectedItem as PropiedadDTO;
            if (propiedad == null) { Aviso("Debe seleccionar una propiedad."); return; }
            try
            {
                Cursor = Cursors.WaitCursor;
                btnGenerarCuota.Enabled = false;
                cargoGenerado = cargoBLL.GenerarCuotaOrdinaria(propiedad);
                dgvCuota.DataSource = new List<CargoFacturableDTO> { cargoGenerado };
                btnGenerarFactura.Enabled = true;
                lblEstado.Text = "Cuota guardada; pendiente de facturar";
                lblEstado.ForeColor = Color.FromArgb(214, 137, 16);
                MessageBox.Show("Cuota generada correctamente. Ahora puede emitir la factura.",
                    "Cuota generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                btnGenerarCuota.Enabled = true;
                MessageBox.Show(ex.Message, "No se pudo generar la cuota",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            PropiedadDTO propiedad = cmbPropiedades.SelectedItem as PropiedadDTO;
            if (cargoGenerado == null || propiedad == null)
            { Aviso("Primero debe generar la cuota de la propiedad seleccionada."); return; }
            try
            {
                Cursor = Cursors.WaitCursor;
                btnGenerarFactura.Enabled = false;
                FacturaDTO factura = facturaBLL.GenerarFacturaManual(cargoGenerado, propiedad.Codigo);
                dgvFactura.DataSource = new List<FacturaDTO> { factura };
                cargoGenerado = null;
                lblEstado.Text = "Factura emitida correctamente";
                lblEstado.ForeColor = Color.FromArgb(39, 174, 96);
                MessageBox.Show("Factura N.° " + factura.IdFactura + " emitida correctamente.",
                    "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                btnGenerarFactura.Enabled = true;
                MessageBox.Show(ex.Message, "No se pudo emitir la factura",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnActualizar_Click(object sender, EventArgs e) { CargarPropiedades(); }
        private void btnLimpiar_Click(object sender, EventArgs e) { ReiniciarProceso(); MostrarVistaPrevia(); }

        private void ReiniciarProceso()
        {
            cargoGenerado = null;
            dgvCuota.DataSource = null;
            dgvFactura.DataSource = null;
            btnGenerarFactura.Enabled = false;
            btnGenerarCuota.Enabled = cmbPropiedades.SelectedItem != null;
            lblEstado.Text = cmbPropiedades.SelectedItem == null ? "Seleccione una propiedad" : "Lista para generar";
            lblEstado.ForeColor = Color.FromArgb(90, 100, 110);
        }

        private static void Aviso(string texto)
        {
            MessageBox.Show(texto, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
