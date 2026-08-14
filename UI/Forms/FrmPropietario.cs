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
using System.Windows.Forms;

namespace UI.Forms
{
    /// <summary>
    /// Gestión de Propietarios.
    /// CRUD completo con validación de cédula vía API Hacienda,
    /// soporte de pasaportes, carga de provincias desde API GitHub,
    /// fotografía, estado de morosidad y búsqueda en tiempo real.
    /// </summary>
    public partial class FrmPropietario : Form
    {
        // ── Servicios ─────────────────────────────────────────────────
        private readonly PropietarioBLL    _bll             = new PropietarioBLL();
        private readonly IHaciendaService  _haciendaService = new HaciendaService();
        private ProvinciaService _provinciaService;

        // ── Estado interno ────────────────────────────────────────────
        private int _idSeleccionado = 0;

        /// <summary>Lista completa cargada desde BD; se filtra localmente.</summary>
        private List<PropietarioDTO> _listaTodos = new List<PropietarioDTO>();

        // ─────────────────────────────────────────────────────────────
        public FrmPropietario()
        {
            InitializeComponent();
        }

        // ═════════════════════════════════════════════════════════════
        // CARGA INICIAL
        // ═════════════════════════════════════════════════════════════
        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            InicializarServicios();
            ConfigurarGrid();
            CargarSexo();
            CargarProvincias();
            CargarTodos();
            rdoCedula.Checked = true;
        }

        // ── Grid ──────────────────────────────────────────────────────
        private void ConfigurarGrid()
        {
            dgvPropietarios.AutoGenerateColumns = false;
            dgvPropietarios.Columns.Clear();

            dgvPropietarios.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Identificacion",
                    HeaderText       = "Identificación",
                    Width            = 110
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nombre",
                    HeaderText       = "Nombre",
                    Width            = 120
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Apellidos",
                    HeaderText       = "Apellidos",
                    Width            = 140
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Sexo",
                    HeaderText       = "Sexo",
                    Width            = 50,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Telefono",
                    HeaderText       = "Teléfono",
                    Width            = 95
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Email",
                    HeaderText       = "Correo",
                    Width            = 180,
                    AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill
                },
                new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "EstadoMorosidad",
                    HeaderText       = "Moroso",
                    Width            = 65,
                    DefaultCellStyle = new DataGridViewCellStyle
                                       { Alignment = DataGridViewContentAlignment.MiddleCenter }
                }
            });

            // Estilos
            dgvPropietarios.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(243, 244, 246);
            dgvPropietarios.ColumnHeadersDefaultCellStyle.ForeColor  = Color.FromArgb(55, 65, 81);
            dgvPropietarios.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvPropietarios.EnableHeadersVisualStyles               = false;
            dgvPropietarios.DefaultCellStyle.Font                   = new Font("Segoe UI", 9F);
            dgvPropietarios.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(219, 234, 254);
            dgvPropietarios.DefaultCellStyle.SelectionForeColor     = Color.FromArgb(30, 64, 175);
            dgvPropietarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvPropietarios.RowTemplate.Height                      = 28;
        }

        // ── ComboBox Sexo ─────────────────────────────────────────────

        /// <summary>
        /// Inicializa los servicios que pueden fallar (configuración faltante).
        /// Se llama desde Load para que el designer no falle al renderizar.
        /// </summary>
        private void InicializarServicios()
        {
            try { _provinciaService = new ProvinciaService(); }
            catch { _provinciaService = null; }
        }

        private void CargarSexo()
        {
            cmbSexo.Items.Clear();
            cmbSexo.Items.AddRange(new object[] { "M", "F" });
            cmbSexo.SelectedIndex = -1;
        }

        // ── ComboBox Provincias (API GitHub) ──────────────────────────
        private void CargarProvincias()
        {
            try
            {
                if (_provinciaService == null) { cmbProvincia.Items.Add("(Sin configurar)"); return; }
                List<ProvinciaDTO> provincias = _provinciaService.ObtenerProvincias();
                cmbProvincia.DataSource    = provincias;
                cmbProvincia.DisplayMember = "Nombre";
                cmbProvincia.ValueMember   = "Id";
                cmbProvincia.SelectedIndex = -1;
            }
            catch
            {
                // Si el servicio no está disponible, la provincia queda vacía.
                // No es crítico para el formulario.
                cmbProvincia.Items.Add("(Sin conexión)");
                cmbProvincia.SelectedIndex = 0;
            }
        }

        // ── Cargar grid ───────────────────────────────────────────────
        private void CargarTodos()
        {
            try
            {
                _listaTodos = _bll.ObtenerTodos();
                MostrarEnGrid(_listaTodos);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar la lista: " + ex.Message);
            }
        }

        private void MostrarEnGrid(List<PropietarioDTO> lista)
        {
            dgvPropietarios.DataSource = new BindingList<PropietarioDTO>(lista);
            dgvPropietarios.ClearSelection();
            lblInfoGrid.Text = lista.Count > 0
                ? $"  {lista.Count} propietario(s).  Haga clic en una fila para editar."
                : "  No se encontraron resultados.";
        }

        // ═════════════════════════════════════════════════════════════
        // TIPO DE IDENTIFICACIÓN
        // ═════════════════════════════════════════════════════════════
        private void rdoTipoId_CheckedChanged(object sender, EventArgs e)
        {
            bool esCedula = rdoCedula.Checked;

            // Solo las cédulas nacionales se consultan vía Hacienda
            btnBuscarHacienda.Visible = esCedula;
            txtIdentificacion.MaxLength = esCedula ? 12 : 10;
            txtIdentificacion.Clear();
        }

        // ═════════════════════════════════════════════════════════════
        // CONSULTA HACIENDA
        // ═════════════════════════════════════════════════════════════
        private void btnBuscarHacienda_Click(object sender, EventArgs e)
        {
            string id = txtIdentificacion.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MostrarAviso("Ingrese una cédula antes de consultar.");
                txtIdentificacion.Focus();
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                btnBuscarHacienda.Enabled = false;
                btnBuscarHacienda.Text    = "Consultando…";

                HaciendaResponseDTO resp = _haciendaService.ConsultarIdentificacion(id);

                if (resp == null || string.IsNullOrWhiteSpace(resp.Nombre))
                {
                    MostrarAviso("No se encontró información para esa cédula en Hacienda.");
                    return;
                }

                SepararNombre(resp.Nombre, out string nombres, out string apellidos);
                txtNombre.Text    = nombres;
                txtApellidos.Text = apellidos;
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MostrarError("Error al consultar Hacienda: " + ex.Message);
            }
            finally
            {
                Cursor                    = Cursors.Default;
                btnBuscarHacienda.Enabled = true;
                btnBuscarHacienda.Text    = "↗ Consultar Hacienda";
            }
        }

        // ═════════════════════════════════════════════════════════════
        // FOTOGRAFÍA
        // ═════════════════════════════════════════════════════════════
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title  = "Seleccionar fotografía";
                dlg.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Image img = Image.FromFile(dlg.FileName);
                    picFoto.Image = img;
                }
                catch
                {
                    MostrarError("No se pudo cargar la imagen seleccionada.");
                }
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            picFoto.Image?.Dispose();
            picFoto.Image = null;
        }

        // ═════════════════════════════════════════════════════════════
        // BÚSQUEDA / FILTRO EN TIEMPO REAL
        // ═════════════════════════════════════════════════════════════

        private const string PLACEHOLDER_BUSCAR = "Buscar por nombre, identificacion o correo...";

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER_BUSCAR)
            {
                txtBuscar.Text      = string.Empty;
                txtBuscar.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text      = PLACEHOLDER_BUSCAR;
                txtBuscar.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(termino))
            {
                MostrarEnGrid(_listaTodos);
                return;
            }

            var filtrado = _listaTodos.Where(p =>
                (p.Identificacion ?? "").ToLower().Contains(termino) ||
                (p.Nombre         ?? "").ToLower().Contains(termino) ||
                (p.Apellidos      ?? "").ToLower().Contains(termino) ||
                (p.Email          ?? "").ToLower().Contains(termino)
            ).ToList();

            MostrarEnGrid(filtrado);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // El filtrado ya ocurre en TextChanged; este botón también lo dispara.
            txtBuscar_TextChanged(sender, e);
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarTodos();
        }

        // ═════════════════════════════════════════════════════════════
        // SELECCIÓN EN GRID → CARGA EN FORMULARIO
        // ═════════════════════════════════════════════════════════════
        private void dgvPropietarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPropietarios.Rows[e.RowIndex].DataBoundItem is PropietarioDTO p)
                CargarEnFormulario(p);
        }

        private void CargarEnFormulario(PropietarioDTO p)
        {
            _idSeleccionado = p.IdPersona;

            txtIdentificacion.Text    = p.Identificacion;
            txtNombre.Text            = p.Nombre;
            txtApellidos.Text         = p.Apellidos;
            cmbSexo.SelectedItem      = p.Sexo;
            txtTelefono.Text          = p.Telefono;
            txtEmail.Text             = p.Email;
            chkMoroso.Checked         = p.EstadoMorosidad;

            // Separar provincia de dirección si fue combinada al guardar
            SepararProvinciaYDireccion(p.Direccion,
                out string provincia, out string direccion);

            txtDireccion.Text = direccion;

            // Seleccionar provincia en el combo
            if (!string.IsNullOrEmpty(provincia))
            {
                foreach (ProvinciaDTO prov in cmbProvincia.Items)
                {
                    if (prov.Nombre.Equals(provincia, StringComparison.OrdinalIgnoreCase))
                    {
                        cmbProvincia.SelectedItem = prov;
                        break;
                    }
                }
            }

            // Foto
            picFoto.Image?.Dispose();
            picFoto.Image = null;

            if (p.Fotografia != null && p.Fotografia.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(p.Fotografia))
                        picFoto.Image = Image.FromStream(ms);
                }
                catch { /* imagen corrupta: ignorar */ }
            }

            // Tipo de ID (heurística: pasaporte empieza con letra)
            bool esPasaporte = !string.IsNullOrEmpty(p.Identificacion) &&
                               char.IsLetter(p.Identificacion[0]);

            rdoPasaporte.Checked = esPasaporte;
            rdoCedula.Checked    = !esPasaporte;
        }

        // ═════════════════════════════════════════════════════════════
        // CRUD
        // ═════════════════════════════════════════════════════════════
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PropietarioDTO dto = ConstruirDTO();
                bool ok = _bll.Registrar(dto);

                if (ok)
                {
                    MostrarExito("Propietario registrado correctamente.");
                    LimpiarFormulario();
                    CargarTodos();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado <= 0)
                    throw new Exception("Seleccione un propietario de la lista antes de actualizar.");

                PropietarioDTO dto = ConstruirDTO();
                dto.IdPersona = _idSeleccionado;

                bool ok = _bll.Modificar(dto);

                if (ok)
                {
                    MostrarExito("Propietario actualizado correctamente.");
                    LimpiarFormulario();
                    CargarTodos();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado <= 0)
                    throw new Exception("Seleccione un propietario de la lista antes de eliminar.");

                string nombre = $"{txtNombre.Text} {txtApellidos.Text}".Trim();

                DialogResult confirm = MessageBox.Show(
                    $"¿Eliminar a {nombre}?\n\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (confirm != DialogResult.Yes) return;

                bool ok = _bll.Eliminar(_idSeleccionado);

                if (ok)
                {
                    MostrarExito("Propietario eliminado correctamente.");
                    LimpiarFormulario();
                    CargarTodos();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        // ═════════════════════════════════════════════════════════════
        // HELPERS PRIVADOS
        // ═════════════════════════════════════════════════════════════

        /// <summary>Construye el DTO con los datos actuales del formulario.</summary>
        private PropietarioDTO ConstruirDTO()
        {
            // Validar tipo de identificación
            string id = txtIdentificacion.Text.Trim();
            ValidarIdentificacion(id);

            // Combinar provincia + dirección en el campo Direccion del DTO
            // (el DTO/entidad no tiene campo Provincia separado)
            string provincia = (cmbProvincia.SelectedItem as ProvinciaDTO)?.Nombre ?? "";
            string dir       = txtDireccion.Text.Trim();
            string dirFinal  = string.IsNullOrEmpty(provincia)
                               ? dir
                               : $"{provincia}|{dir}";

            return new PropietarioDTO
            {
                Identificacion  = id,
                Nombre          = txtNombre.Text.Trim(),
                Apellidos       = txtApellidos.Text.Trim(),
                Sexo            = cmbSexo.SelectedItem?.ToString(),
                Telefono        = txtTelefono.Text.Trim(),
                Email           = txtEmail.Text.Trim(),
                Direccion       = dirFinal,
                EstadoMorosidad = chkMoroso.Checked,
                Fotografia      = ImagenABytes()
            };
        }

        /// <summary>
        /// Valida el formato de identificación:
        /// Cédula  → solo dígitos, hasta 12 chars
        /// Pasaporte → letra inicial + exactamente 6 dígitos
        /// </summary>
        private void ValidarIdentificacion(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("La identificación es obligatoria.");

            if (rdoPasaporte.Checked)
            {
                if (id.Length < 2 || !char.IsLetter(id[0]) || !id.Substring(1).All(char.IsDigit))
                    throw new Exception(
                        "El pasaporte debe iniciar con una letra seguida de dígitos (ej. A123456).");
            }
            else
            {
                if (!id.All(char.IsDigit))
                    throw new Exception("La cédula solo debe contener dígitos.");
            }
        }

        /// <summary>Convierte la imagen del PictureBox a byte[].</summary>
        private byte[] ImagenABytes()
        {
            if (picFoto.Image == null) return null;

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch { return null; }
        }

        /// <summary>
        /// Separa el nombre completo devuelto por Hacienda en Nombre y Apellidos.
        /// La convención en CR: últimas dos palabras = dos apellidos.
        /// </summary>
        private void SepararNombre(string completo, out string nombres, out string apellidos)
        {
            nombres = apellidos = string.Empty;
            if (string.IsNullOrWhiteSpace(completo)) return;

            string[] partes = completo.Trim()
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (partes.Length)
            {
                case 1:
                    nombres = partes[0];
                    break;
                case 2:
                    nombres   = partes[0];
                    apellidos = partes[1];
                    break;
                default:
                    apellidos = $"{partes[partes.Length - 2]} {partes[partes.Length - 1]}";
                    nombres   = string.Join(" ", partes, 0, partes.Length - 2);
                    break;
            }
        }

        /// <summary>Separa provincia y dirección almacenadas con separador '|'.</summary>
        private void SepararProvinciaYDireccion(
            string campo, out string provincia, out string direccion)
        {
            provincia = string.Empty;
            direccion = campo ?? string.Empty;

            if (string.IsNullOrEmpty(campo)) return;

            int sep = campo.IndexOf('|');
            if (sep < 0) return;

            provincia = campo.Substring(0, sep).Trim();
            direccion = campo.Substring(sep + 1).Trim();
        }

        /// <summary>Restablece el formulario a su estado inicial.</summary>
        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;

            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();

            cmbSexo.SelectedIndex      = -1;
            cmbProvincia.SelectedIndex = -1;
            chkMoroso.Checked          = false;
            rdoCedula.Checked          = true;

            picFoto.Image?.Dispose();
            picFoto.Image = null;

            dgvPropietarios.ClearSelection();
            txtIdentificacion.Focus();

            CargarTodos();
        }

        // ── Mensajes ──────────────────────────────────────────────────
        private void MostrarExito(string msg) =>
            MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void MostrarAviso(string msg) =>
            MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarError(string msg) =>
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
