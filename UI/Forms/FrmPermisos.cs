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
    public partial class FrmPermisos : Form
          
    {
        private readonly RolBLL _bll = new RolBLL();
        public FrmPermisos()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmPermisos_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }




        //  guarda un permiso individual ──────────────────────
        private void GuardarPermiso(int idRol, string modulo, bool puedeVer)
        {
            PermisoDTO permiso = new PermisoDTO
            {
                IdRol = idRol,
                Modulo = modulo,
                PuedeVer = puedeVer,
                // si puede ver también puede crear, editar
                // si no puede ver, no puede hacer nada
                PuedeCrear = puedeVer,
                PuedeEditar = puedeVer,
                PuedeEliminar = puedeVer
            };

            _bll.GuardarPermiso(permiso);
        }
    

        // limpiar los checkboxes
        private void LimpiarCheckboxes()
        {
            chePropiedad.Checked = false;
            cheResidente.Checked = false;
            cheFacturacion.Checked = false;
            cheReserva.Checked = false;
            cheAcceso.Checked = false;
            cheReporte.Checked = false;
            cheSeguridad.Checked = false;
        }


        // cargar roles en el combobox
        private void CargarRoles()
        {
            // trae todos los roles de la BD y los pone en el ComboBox
            List<RolDTO> roles = _bll.ObtenerTodos();

            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Nombre";  // lo que ve el usuario
            cmbRoles.ValueMember = "IdRol";   // el valor que usamos en código
            cmbRoles.SelectedIndex = -1;        // arranca sin nada seleccionado
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbRoles.SelectedIndex == -1) return;

            // obtiene el IdRol seleccionado
            RolDTO rolSeleccionado = (RolDTO)cmbRoles.SelectedItem;
            int idRol = rolSeleccionado.IdRol;

            // trae los permisos de ese rol desde la BD
            List<PermisoDTO> permisos = _bll.ObtenerPermisos(idRol);

            // primero desmarca todos los checkboxes
            LimpiarCheckboxes();

            // luego marca los que corresponden según lo que está en la BD
            foreach (PermisoDTO p in permisos)
            {
                switch (p.Modulo)
                {
                    case "Propiedades": chePropiedad.Checked = p.PuedeVer; break;
                    case "Residentes": cheResidente.Checked = p.PuedeVer; break;
                    case "Facturacion": cheFacturacion.Checked = p.PuedeVer; break;
                    case "Reservas": cheReserva.Checked = p.PuedeVer; break;
                    case "Acceso": cheAcceso.Checked = p.PuedeVer; break;
                    case "Reportes": cheReporte.Checked = p.PuedeVer; break;
                    case "Seguridad": cheSeguridad.Checked = p.PuedeVer; break;
                }
            }
        }



        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol primero.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idRol = Convert.ToInt32(cmbRoles.SelectedValue);

                // guarda cada módulo como un permiso independiente en la BD
                // el SP hace UPSERT (si existe actualiza, si no inserta)
                GuardarPermiso(idRol, "Propiedades", chePropiedad.Checked);
                GuardarPermiso(idRol, "Residentes", cheResidente.Checked);
                GuardarPermiso(idRol, "Facturacion", cheFacturacion.Checked);
                GuardarPermiso(idRol, "Reservas", cheReserva.Checked);
                GuardarPermiso(idRol, "Acceso", cheAcceso.Checked);
                GuardarPermiso(idRol, "Reportes", cheReporte.Checked);
                GuardarPermiso(idRol, "Seguridad", cheSeguridad.Checked);

                MessageBox.Show("Permisos guardados correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
    }

