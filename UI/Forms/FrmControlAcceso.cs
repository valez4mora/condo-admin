using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using BLL;
using DTO;

// REQUIERE: instalar QRCoder via NuGet
// PM> Install-Package QRCoder
using QRCoder;

namespace UI.Forms
{
    public partial class FrmControlAcceso : Form
    {
        // ── Dependencias ──────────────────────────────────────────
        private readonly VisitaBLL visitaBLL = new VisitaBLL();
        private readonly PropiedadBLL propiedadBLL = new PropiedadBLL();

        // ── Estado interno ────────────────────────────────────────
        private int _idVisitaActual = 0;        // visita recién registrada o seleccionada en grid
        private Bitmap _qrActual = null;        // imagen QR generada

        public FrmControlAcceso()
        {
            InitializeComponent();
        }

        // ============================================================
        // CARGA DEL FORM
        // ============================================================

        private void FrmControlAcceso_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
            ConfigurarGrilla();
            CargarHistorial();

            // Placeholder manual para txtCodigoQR
            txtCodigoQR.Text = "Ej: VISITA-12-3-20260815";
            txtCodigoQR.ForeColor = System.Drawing.Color.Gray;
            txtCodigoQR.Enter += (s, ev) => {
                if (txtCodigoQR.ForeColor == System.Drawing.Color.Gray)
                {
                    txtCodigoQR.Text = "";
                    txtCodigoQR.ForeColor = System.Drawing.Color.Black;
                }
            };
            txtCodigoQR.Leave += (s, ev) => {
                if (string.IsNullOrWhiteSpace(txtCodigoQR.Text))
                {
                    txtCodigoQR.Text = "Ej: VISITA-12-3-20260815";
                    txtCodigoQR.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        /// <summary>Carga el combo de propiedades en ambas pestañas.</summary>
        private void CargarPropiedades()
        {
            try
            {
                var propiedades = propiedadBLL.ObtenerTodas();

                // Combo de registro
                cmbPropiedad.DataSource = null;
                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.SelectedIndex = -1;

                // Combo de filtro (agrega opción "Todas")
                var listaFiltro = new List<PropiedadDTO>();
                listaFiltro.Add(new PropiedadDTO { IdPropiedad = 0, Codigo = "— Todas —" });
                listaFiltro.AddRange(propiedades);

                cmbFiltroProp.DataSource = null;
                cmbFiltroProp.DataSource = listaFiltro;
                cmbFiltroProp.DisplayMember = "Codigo";
                cmbFiltroProp.ValueMember = "IdPropiedad";
                cmbFiltroProp.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar propiedades: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Define las columnas del DataGridView de historial.</summary>
        private void ConfigurarGrilla()
        {
            dgvHistorial.Columns.Clear();

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdVisita",
                HeaderText = "ID",
                DataPropertyName = "IdVisita",
                Width = 50
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreVisitante",
                HeaderText = "Visitante",
                DataPropertyName = "NombreVisitante"
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoPropiedad",
                HeaderText = "Propiedad",
                DataPropertyName = "CodigoPropiedad",
                Width = 100
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 90
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraEntrada",
                HeaderText = "Hora Entrada",
                DataPropertyName = "HoraEntrada",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" },
                Width = 100
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraSalida",
                HeaderText = "Hora Salida",
                DataPropertyName = "HoraSalida",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm", NullValue = "—" },
                Width = 100
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 75
            });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoQR",
                HeaderText = "Código QR",
                DataPropertyName = "CodigoQR"
            });

            // Color alternado de filas
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        }

        // ============================================================
        // TAB 1 — REGISTRO DE VISITA
        // ============================================================

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección de propiedad
                if (cmbPropiedad.SelectedIndex < 0 || (int)cmbPropiedad.SelectedValue == 0)
                {
                    MessageBox.Show("Seleccione la propiedad destino.",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPropiedad.Focus();
                    return;
                }

                // Validar nombre
                if (string.IsNullOrWhiteSpace(txtNombreVisitante.Text))
                {
                    MessageBox.Show("Ingrese el nombre del visitante.",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreVisitante.Focus();
                    return;
                }

                // Construir DTO
                VisitaDTO visita = new VisitaDTO
                {
                    NombreVisitante = txtNombreVisitante.Text.Trim(),
                    Fecha           = dtpFecha.Value.Date,
                    HoraEntrada     = dtpHoraEntrada.Value,
                    IdPropiedad     = (int)cmbPropiedad.SelectedValue
                };

                // Registrar en BLL (devuelve el DTO con IdVisita y CodigoQR asignados)
                VisitaDTO registrada = visitaBLL.RegistrarVisita(visita);

                _idVisitaActual = registrada.IdVisita;

                // Generar y mostrar imagen QR
                MostrarQR(registrada.CodigoQR);

                // Habilitar botones relacionados
                btnRegistrarSalida.Enabled = true;
                btnGuardarQR.Enabled = true;

                MessageBox.Show(
                    $"Visita registrada correctamente.\nCódigo QR: {registrada.CodigoQR}",
                    "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioRegistro();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar visita: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (_idVisitaActual <= 0)
            {
                MessageBox.Show("No hay ninguna visita activa seleccionada.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                visitaBLL.RegistrarSalida(_idVisitaActual);

                MessageBox.Show("Salida registrada correctamente.",
                    "Salida registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRegistrarSalida.Enabled = false;
                _idVisitaActual = 0;
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar salida: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarQR_Click(object sender, EventArgs e)
        {
            if (_qrActual == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Imagen PNG|*.png";
                sfd.FileName = $"QR_Visita_{_idVisitaActual}";
                sfd.Title = "Guardar código QR";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _qrActual.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Imagen QR guardada correctamente.",
                        "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Genera la imagen QR a partir del texto del código
        /// usando la librería QRCoder (NuGet).
        /// </summary>
        private void MostrarQR(string contenido)
        {
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);

            // pixelsPerModule = 10 produce una imagen de ~250px, adecuada para la PictureBox
            _qrActual = qrCode.GetGraphic(pixelsPerModule: 10);

            picQR.Image = _qrActual;
            lblCodigoQR.Text = contenido;
            lblCodigoQR.ForeColor = Color.Black;
        }

        private void LimpiarFormularioRegistro()
        {
            cmbPropiedad.SelectedIndex = -1;
            txtNombreVisitante.Clear();
            dtpFecha.Value = DateTime.Now;
            dtpHoraEntrada.Value = DateTime.Now;
        }

        // ============================================================
        // TAB 2 — HISTORIAL
        // ============================================================

        private void CargarHistorial()
        {
            try
            {
                int? idPropiedad = null;
                if (cmbFiltroProp.SelectedIndex > 0)
                    idPropiedad = (int)cmbFiltroProp.SelectedValue;

                DateTime? fecha = null;
                if (chkUsarFecha.Checked)
                    fecha = dtpFiltroFecha.Value.Date;

                string estado = cmbFiltroEstado.SelectedItem?.ToString();

                List<VisitaDTO> lista = visitaBLL.ObtenerPorFiltros(idPropiedad, fecha, estado);

                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = lista;

                ColorearFilasPorEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Pinta en verde las visitas "Dentro" y en gris las "Fuera".</summary>
        private void ColorearFilasPorEstado()
        {
            foreach (DataGridViewRow row in dgvHistorial.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString();
                if (estado == "Dentro")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(27, 94, 32);
                else
                    row.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroProp.SelectedIndex = 0;
            chkUsarFecha.Checked = false;
            dtpFiltroFecha.Value = DateTime.Now;
            cmbFiltroEstado.SelectedIndex = 0;
            CargarHistorial();
        }

        private void chkUsarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFiltroFecha.Enabled = chkUsarFecha.Checked;
        }

        /// <summary>
        /// Al hacer clic en el grid: carga el idVisita seleccionado
        /// y habilita el botón Registrar Salida si la visita sigue activa.
        /// </summary>
        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvHistorial.Rows[e.RowIndex];
            string estado = fila.Cells["Estado"].Value?.ToString();

            _idVisitaActual = Convert.ToInt32(fila.Cells["IdVisita"].Value);
            btnRegistrarSalida.Enabled = estado == "Dentro";
        }

        // ============================================================
        // VALIDACIÓN DE QR
        // ============================================================

        private void btnValidarQR_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoQR.ForeColor == System.Drawing.Color.Gray ? "" : txtCodigoQR.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                lblResultadoQR.Text = "Ingrese un código QR para validar.";
                lblResultadoQR.ForeColor = Color.OrangeRed;
                return;
            }

            try
            {
                VisitaDTO visita = visitaBLL.ValidarQR(codigo);

                if (visita == null)
                {
                    lblResultadoQR.Text = "❌  Código QR no encontrado.";
                    lblResultadoQR.ForeColor = Color.Red;
                }
                else
                {
                    string estado = visita.Estado;
                    string horaSalida = visita.HoraSalida.HasValue
                        ? visita.HoraSalida.Value.ToString("HH:mm")
                        : "—";

                    lblResultadoQR.Text =
                        $"✔  Visita #{visita.IdVisita}\n" +
                        $"Visitante: {visita.NombreVisitante}\n" +
                        $"Propiedad: {visita.CodigoPropiedad}   Estado: {estado}";

                    lblResultadoQR.ForeColor = estado == "Dentro"
                        ? Color.FromArgb(27, 94, 32)
                        : Color.Gray;
                }
            }
            catch (Exception ex)
            {
                lblResultadoQR.Text = "Error: " + ex.Message;
                lblResultadoQR.ForeColor = Color.Red;
            }
        }
    }
}
