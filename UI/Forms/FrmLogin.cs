using BLL;
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
    public partial class FrmLogin : Form
    {
        private readonly UsuarioBLL _bll = new UsuarioBLL();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                _bll.Login(txtUsuario.Text.Trim(), txtContrasena.Text);

                FrmMenu menu = new FrmMenu();
                menu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de acceso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Clear();
                txtContrasena.Focus();
            }


        }

        // permite presionar enter desde el campo de contraseña para iniciar sesión
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnIngresar_Click(sender, e);
        }
    }
}
