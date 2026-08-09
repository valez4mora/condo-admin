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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void áreasComunesReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAreasComunes frm = new FrmAreasComunes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void penalizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          FrmPenalizacion frm = new FrmPenalizacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gestiónDeResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResidente frm = new FrmResidente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gestionDePropietariosResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropietario frm = new FrmPropietario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gestionDePropiedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropiedad frm = new FrmPropiedad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cargosFacturablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenerarCuota frm = new FrmGenerarCuota();
            frm.MdiParent = this;
            frm.Show();
        }

        private void fondoDeReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFondoReserva frm = new FrmFondoReserva();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reservasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAreasComunes frm = new FrmAreasComunes();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
