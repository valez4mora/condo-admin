using BLL;
using DTO;
using Integration.Hacienda;
using Integration.Provincias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmResidente : Form
    {
        private readonly ResidenteBLL residenteBLL = new ResidenteBLL();
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();
        private readonly IHaciendaService haciendaService = new HaciendaService();
        private IProvinciaService provinciaService;
        private List<ResidenteDTO> residentes = new List<ResidenteDTO>();
        private int idSeleccionado;

        public FrmResidente()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void FrmResidente_Load(object sender, EventArgs e)
        {
            cmbSexo.Items.AddRange(new object[] { "M", "F" });
            try { provinciaService = new ProvinciaService(); } catch { provinciaService = null; }
            CargarProvincias();
            CargarPropiedades();
            CargarResidentes();
            LimpiarFormulario(false);
        }

        private void ConfigurarColumnas()
        {
            dgvResidentes.AutoGenerateColumns = false;
            dgvResidentes.Columns.Clear();
            AgregarColumna("Identificacion", "Identificación", 105);
            AgregarColumna("Nombre", "Nombre", 105);
            AgregarColumna("Apellidos", "Apellidos", 130);
            AgregarColumna("Sexo", "Sexo", 45);
            AgregarColumna("Telefono", "Teléfono", 90);
            AgregarColumna("Email", "Correo electrónico", 150);
            AgregarColumna("CodigoPropiedad", "Propiedad", 85);
        }

        private void AgregarColumna(string propiedad, string titulo, int ancho)
        {
            dgvResidentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = propiedad,
                Name = "col" + propiedad,
                HeaderText = titulo,
                Width = ancho,
                MinimumWidth = 45
            });
        }

        private void CargarProvincias()
        {
            try
            {
                cmbProvincia.DataSource = provinciaService == null ? null : provinciaService.ObtenerProvincias();
                cmbProvincia.DisplayMember = "Nombre";
                cmbProvincia.ValueMember = "Id";
                cmbProvincia.SelectedIndex = -1;
            }
            catch
            {
                cmbProvincia.DataSource = null;
                cmbProvincia.Items.Clear();
                cmbProvincia.Items.Add("San José"); cmbProvincia.Items.Add("Alajuela");
                cmbProvincia.Items.Add("Cartago"); cmbProvincia.Items.Add("Heredia");
                cmbProvincia.Items.Add("Guanacaste"); cmbProvincia.Items.Add("Puntarenas"); cmbProvincia.Items.Add("Limón");
                cmbProvincia.SelectedIndex = -1;
            }
        }

        private void CargarPropiedades()
        {
            try
            {
                cmbPropiedad.DataSource = propiedadBLL.ObtenerTodas().OrderBy(p => p.Codigo).ToList();
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.SelectedIndex = -1;
            }
            catch (Exception ex) { MostrarError("No se pudieron cargar las propiedades: " + ex.Message); }
        }

        private void CargarResidentes()
        {
            try
            {
                residentes = residenteBLL.ObtenerTodos();
                MostrarLista(residentes);
                lblTotal.Text = "Total: " + residentes.Count + " residente(s)";
            }
            catch (Exception ex) { MostrarError("No se pudo cargar la lista: " + ex.Message); }
        }

        private void MostrarLista(List<ResidenteDTO> lista)
        {
            dgvResidentes.DataSource = null;
            dgvResidentes.DataSource = new BindingList<ResidenteDTO>(lista);
            dgvResidentes.ClearSelection();
        }

        private void dgvResidentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ResidenteDTO r = dgvResidentes.Rows[e.RowIndex].DataBoundItem as ResidenteDTO;
            if (r == null) return;

            idSeleccionado = r.IdPersona;
            txtIdentificacion.Text = r.Identificacion;
            txtNombre.Text = r.Nombre;
            txtApellidos.Text = r.Apellidos;
            cmbSexo.SelectedItem = r.Sexo;
            txtTelefono.Text = r.Telefono;
            txtEmail.Text = r.Email;
            cmbPropiedad.SelectedValue = r.IdPropiedad;

            string provincia, direccion;
            SepararDireccion(r.Direccion, out provincia, out direccion);
            txtDireccion.Text = direccion;
            SeleccionarProvincia(provincia);
            MostrarFotografia(r.Fotografia);

            bool pasaporte = Regex.IsMatch(r.Identificacion ?? string.Empty, "^[A-Za-z]");
            rdoPasaporte.Checked = pasaporte;
            rdoCedula.Checked = !pasaporte;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            lblEstado.Text = "Editando residente: " + r.Nombre + " " + r.Apellidos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarGuardado(false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0) { MostrarAviso("Seleccione un residente de la lista."); return; }
            EjecutarGuardado(true);
        }

        private void EjecutarGuardado(bool modificar)
        {
            try
            {
                ResidenteDTO residente = ConstruirDTO();
                bool ok = modificar ? residenteBLL.Modificar(residente) : residenteBLL.Registrar(residente);
                if (!ok) { MostrarAviso("No se pudo guardar el residente."); return; }
                MessageBox.Show(modificar ? "Residente actualizado correctamente." : "Residente registrado correctamente.",
                    "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarResidentes();
                LimpiarFormulario(false);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private ResidenteDTO ConstruirDTO()
        {
            string identificacion = txtIdentificacion.Text.Trim().ToUpperInvariant();
            ValidarIdentificacion(identificacion);
            if (cmbProvincia.SelectedItem == null) throw new Exception("Debe seleccionar una provincia.");
            if (cmbPropiedad.SelectedValue == null) throw new Exception("Debe seleccionar la propiedad asignada.");

            string provincia = cmbProvincia.SelectedItem is ProvinciaDTO
                ? ((ProvinciaDTO)cmbProvincia.SelectedItem).Nombre : cmbProvincia.SelectedItem.ToString();

            return new ResidenteDTO
            {
                IdPersona = idSeleccionado,
                Identificacion = identificacion,
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Sexo = cmbSexo.SelectedItem == null ? null : cmbSexo.SelectedItem.ToString(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = provincia + "|" + txtDireccion.Text.Trim(),
                Fotografia = ImagenABytes(),
                IdPropiedad = Convert.ToInt32(cmbPropiedad.SelectedValue)
            };
        }

        private void ValidarIdentificacion(string identificacion)
        {
            if (rdoPasaporte.Checked)
            {
                if (!Regex.IsMatch(identificacion, "^[A-Za-z][0-9]{6}$"))
                    throw new Exception("El pasaporte debe contener una letra seguida de 6 dígitos. Ejemplo: A123456.");
            }
            else if (!Regex.IsMatch(identificacion, "^[0-9]{9,12}$"))
                throw new Exception("La cédula debe contener únicamente entre 9 y 12 dígitos.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0) { MostrarAviso("Seleccione un residente de la lista."); return; }
            if (MessageBox.Show("¿Desea eliminar al residente seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            try
            {
                residenteBLL.Eliminar(idSeleccionado);
                CargarResidentes(); LimpiarFormulario(false);
                MessageBox.Show("Residente eliminado correctamente.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e) { FiltrarLista(); }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { FiltrarLista(); }

        private void FiltrarLista()
        {
            string texto = txtBuscar.Text.Trim();
            List<ResidenteDTO> resultado = residentes.Where(r =>
                Contiene(r.Identificacion, texto) || Contiene(r.Nombre, texto) || Contiene(r.Apellidos, texto) ||
                Contiene(r.Email, texto) || Contiene(r.CodigoPropiedad, texto)).ToList();
            MostrarLista(resultado);
            lblTotal.Text = "Mostrando: " + resultado.Count + " de " + residentes.Count;
        }

        private static bool Contiene(string valor, string texto)
        {
            return string.IsNullOrEmpty(texto) || (!string.IsNullOrEmpty(valor) && valor.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void btnActualizarLista_Click(object sender, EventArgs e) { CargarPropiedades(); CargarResidentes(); LimpiarFormulario(false); }
        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarFormulario(true); }

        private void btnBuscarHacienda_Click(object sender, EventArgs e)
        {
            string id = txtIdentificacion.Text.Trim();
            if (!rdoCedula.Checked) { MostrarAviso("La consulta de Hacienda solo aplica para cédulas nacionales."); return; }
            try
            {
                ValidarIdentificacion(id);
                Cursor = Cursors.WaitCursor;
                HaciendaResponseDTO respuesta = haciendaService.ConsultarIdentificacion(id);
                if (respuesta == null || string.IsNullOrWhiteSpace(respuesta.Nombre)) { MostrarAviso("Hacienda no devolvió datos para esa cédula."); return; }
                SepararNombre(respuesta.Nombre, out string nombres, out string apellidos);
                txtNombre.Text = nombres; txtApellidos.Text = apellidos;
            }
            catch (Exception ex) { MostrarError("No se pudo consultar Hacienda: " + ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private void rdoTipoId_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscarHacienda.Visible = rdoCedula.Checked;
            lblAyudaId.Text = rdoCedula.Checked ? "9 a 12 dígitos" : "1 letra + 6 dígitos";
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar fotografía del residente";
                dialogo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                FileInfo archivo = new FileInfo(dialogo.FileName);
                if (archivo.Length > 5 * 1024 * 1024) { MostrarAviso("La imagen no puede superar 5 MB."); return; }
                using (Image temporal = Image.FromFile(dialogo.FileName))
                    MostrarImagen(new Bitmap(temporal));
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e) { MostrarImagen(null); }

        private void MostrarFotografia(byte[] fotografia)
        {
            if (fotografia == null || fotografia.Length == 0) { MostrarImagen(null); return; }
            try { using (MemoryStream ms = new MemoryStream(fotografia)) using (Image img = Image.FromStream(ms)) MostrarImagen(new Bitmap(img)); }
            catch { MostrarImagen(null); }
        }

        private void MostrarImagen(Image imagen)
        {
            Image anterior = picFoto.Image;
            picFoto.Image = imagen;
            if (anterior != null) anterior.Dispose();
            lblSinFoto.Visible = imagen == null;
            btnQuitarFoto.Enabled = imagen != null;
        }

        private byte[] ImagenABytes()
        {
            if (picFoto.Image == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                picFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void SepararDireccion(string valor, out string provincia, out string direccion)
        {
            provincia = string.Empty; direccion = valor ?? string.Empty;
            int indice = direccion.IndexOf('|');
            if (indice < 0) return;
            provincia = direccion.Substring(0, indice).Trim(); direccion = direccion.Substring(indice + 1).Trim();
        }

        private void SeleccionarProvincia(string nombre)
        {
            cmbProvincia.SelectedIndex = -1;
            for (int i = 0; i < cmbProvincia.Items.Count; i++)
            {
                string actual = cmbProvincia.Items[i] is ProvinciaDTO ? ((ProvinciaDTO)cmbProvincia.Items[i]).Nombre : cmbProvincia.Items[i].ToString();
                if (string.Equals(actual, nombre, StringComparison.OrdinalIgnoreCase)) { cmbProvincia.SelectedIndex = i; break; }
            }
        }

        private static void SepararNombre(string completo, out string nombres, out string apellidos)
        {
            string[] partes = (completo ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length <= 1) { nombres = partes.Length == 1 ? partes[0] : string.Empty; apellidos = string.Empty; return; }
            int inicioApellidos = Math.Max(1, partes.Length - 2);
            nombres = string.Join(" ", partes.Take(inicioApellidos)); apellidos = string.Join(" ", partes.Skip(inicioApellidos));
        }

        private void LimpiarFormulario(bool enfocar)
        {
            idSeleccionado = 0;
            txtIdentificacion.Clear(); txtNombre.Clear(); txtApellidos.Clear(); txtTelefono.Clear(); txtEmail.Clear(); txtDireccion.Clear();
            cmbSexo.SelectedIndex = -1; cmbProvincia.SelectedIndex = -1; cmbPropiedad.SelectedIndex = -1;
            rdoCedula.Checked = true; MostrarImagen(null); dgvResidentes.ClearSelection();
            btnGuardar.Enabled = true; btnActualizar.Enabled = false; btnEliminar.Enabled = false;
            lblEstado.Text = "Complete los datos para registrar un residente";
            if (enfocar) txtIdentificacion.Focus();
        }

        private static void MostrarAviso(string mensaje) { MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private static void MostrarError(string mensaje) { MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
