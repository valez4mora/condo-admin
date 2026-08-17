using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        // ============================================================
        // PROPIEDADES
        // ============================================================

        private void gestionDePropiedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropiedad frm = new FrmPropiedad();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // PERSONAS
        // ============================================================

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Este es solamente el menú principal "Personas".
            // No necesita abrir un formulario.
        }

        private void gestionDePropietariosResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropietario frm = new FrmPropietario();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void gestiónDeResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResidente frm = new FrmResidente();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // FACTURACIÓN
        // ============================================================

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Este es solamente el menú principal "Facturación".
            // No necesita abrir ningún formulario.
        }

        private void cargosFacturablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCargosFacturables frm = new FrmCargosFacturables();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cargosFacturablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCargosFacturables frm = new FrmCargosFacturables();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void generarCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenerarCuota frm = new FrmGenerarCuota();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturas frm = new FrmFacturas();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void registroDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagos frm = new FrmPagos();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // FINANCIERO
        // ============================================================

        private void morosidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void controlDeMorosidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMorosidad frm = new FrmMorosidad();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void controlDeMorosidadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmMorosidad frm = new FrmMorosidad();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void penalizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPenalizacion frm = new FrmPenalizacion();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void fondoDeReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFondoReserva frm = new FrmFondoReserva();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // ÁREAS Y RESERVAS
        // ============================================================

        private void áreasComunesReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAreasComunes frm = new FrmAreasComunes();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void reservasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReservas frm = new FrmReservas();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // ACCESO
        // ============================================================

        private void controlDeVisitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControlAcceso frm = new FrmControlAcceso();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // SEGURIDAD
        // ============================================================

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRoles frm = new FrmRoles();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPermisos frm = new FrmPermisos();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora frm = new FrmBitacora();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        // ============================================================
        // REPORTES
        // ============================================================

        private void reportepropiedadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReportePropiedades frm = new FrmReportePropiedades();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void facturaciónPorPropiedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteFacturacionPropiedad frm = new FrmReporteFacturacionPropiedad();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void propiedadesMorosasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportePropiedadesMorosas frm = new FrmReportePropiedadesMorosas();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void ingresosMensualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteIngresoMensual frm = new FrmReporteIngresoMensual();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void financieroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}