using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using BLL;
using DTO;
using QRCoder;

namespace UI.Forms
{
    public partial class FrmControlAcceso : Form
    {
        private readonly VisitaBLL _bll = new VisitaBLL();
        private readonly PropiedadBLL _bllProp = new PropiedadBLL();

        private int _idVisitaActual = 0;
        private Bitmap _qrActual = null;

        public FrmControlAcceso()
        {
            InitializeComponent();
        }

        private void FrmControlAcceso_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
            ConfigurarGrilla();
            CargarHistorial();

            btnRegistrarSalida.Enabled = false;
            btnGuardarQR.Enabled = false;
            dtpFiltroFecha.Enabled = false;

            // Placeholder manual para txtCodigoQR
            txtCodigoQR.Text = "Ej: VISITA-12-3-20260815";
            txtCodigoQR.ForeColor = Color.Gray;
            txtCodigoQR.Enter += (s, ev) =>
            {
                if (txtCodigoQR.ForeColor == Color.Gray)
                {
                    txtCodigoQR.Text = string.Empty;
                    txtCodigoQR.ForeColor = Color.Black;
                }
            };
            txtCodigoQR.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCodigoQR.Text))
                {
                    txtCodigoQR.Text = "Ej: VISITA-12-3-20260815";
                    txtCodigoQR.ForeColor = Color.Gray;
                }
            };
        }

        private void CargarPropiedades()
        {
            try
            {
                var propiedades = _bllProp.ObtenerTodas();

                cmbPropiedad.DataSource = null;
                cmbPropiedad.DataSource = propiedades;
                cmbPropiedad.DisplayMember = "Codigo";
                cmbPropiedad.ValueMember = "IdPropiedad";
                cmbPropiedad.SelectedIndex = -1;

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

        private void ConfigurarGrilla()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.Columns.Clear();
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            dgvHistorial.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "IdVisita",        HeaderText = "ID",          Width = 50  },
                new DataGridViewTextBoxColumn { DataPropertyName = "NombreVisitante", HeaderText = "Visitante",   Width = 160 },
                new DataGridViewTextBoxColumn { DataPropertyName = "CodigoPropiedad", HeaderText = "Propiedad",   Width = 100 },
                new DataGridViewTextBoxColumn { DataPropertyName = "FechaTexto",      HeaderText = "Fecha",       Width = 90  },
                new DataGridViewTextBoxColumn { DataPropertyName = "HoraEntradaTexto",HeaderText = "Entrada",     Width = 80  },
                new DataGridViewTextBoxColumn { DataPropertyName = "HoraSalidaTexto", HeaderText = "Salida",      Width = 80  },
                new DataGridViewTextBoxColumn { DataPropertyName = "Estado",          HeaderText = "Estado",      Width = 75  },
                new DataGridViewTextBoxColumn { DataPropertyName = "CodigoQR",        HeaderText = "Código QR",   Width = 200 },
            });
        }

        // registro

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPropiedad.SelectedIndex < 0 || (int)cmbPropiedad.SelectedValue == 0)
                    throw new Exception("Seleccioná la propiedad destino.");

                if (string.IsNullOrWhiteSpace(txtNombreVisitante.Text))
                    throw new Exception("Ingresá el nombre del visitante.");

                VisitaDTO visita = new VisitaDTO
                {
                    NombreVisitante = txtNombreVisitante.Text.Trim(),
                    Fecha = dtpFecha.Value.Date,
                    HoraEntrada = dtpHoraEntrada.Value.TimeOfDay,
                    IdPropiedad = (int)cmbPropiedad.SelectedValue
                };

                VisitaDTO registrada = _bll.RegistrarVisita(visita);
                _idVisitaActual = registrada.IdVisita;

                MostrarQR(registrada.CodigoQR);

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
                MessageBox.Show(ex.Message, "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (_idVisitaActual <= 0)
            {
                MessageBox.Show("No hay ninguna visita activa seleccionada.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bll.RegistrarSalida(_idVisitaActual);
                MessageBox.Show("Salida registrada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRegistrarSalida.Enabled = false;
                _idVisitaActual = 0;
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void MostrarQR(string contenido)
        {
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);

            _qrActual = qrCode.GetGraphic(pixelsPerModule: 10);

            picQR.Image = _qrActual;
            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            lblCodigoQR.Text = contenido;
            lblCodigoQR.ForeColor = Color.Black;
        }

        private void LimpiarFormularioRegistro()
        {
            cmbPropiedad.SelectedIndex = -1;
            txtNombreVisitante.Clear();
            dtpFecha.Value = DateTime.Today;
            dtpHoraEntrada.Value = DateTime.Now;
        }

        // historial

        private void CargarHistorial()
        {
            try
            {
                int? idPropiedad = cmbFiltroProp.SelectedIndex > 0
                                   ? (int?)cmbFiltroProp.SelectedValue : null;

                DateTime? fecha = chkUsarFecha.Checked
                                  ? (DateTime?)dtpFiltroFecha.Value.Date : null;

                string estado = cmbFiltroEstado.SelectedItem?.ToString();
                if (estado == "Todos") estado = null;

                List<VisitaDTO> lista = _bll.ObtenerHistorial(idPropiedad, fecha, estado);

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

        private void ColorearFilasPorEstado()
        {
            foreach (DataGridViewRow row in dgvHistorial.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString();
                row.DefaultCellStyle.ForeColor = estado == "Dentro"
                    ? Color.FromArgb(27, 94, 32) : Color.Gray;
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
            dtpFiltroFecha.Value = DateTime.Today;
            cmbFiltroEstado.SelectedIndex = 0;
            CargarHistorial();
        }

        private void chkUsarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFiltroFecha.Enabled = chkUsarFecha.Checked;
        }

        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            VisitaDTO v = dgvHistorial.Rows[e.RowIndex].DataBoundItem as VisitaDTO;
            if (v == null) return;

            _idVisitaActual = v.IdVisita;
            btnRegistrarSalida.Enabled = v.Estado == "Dentro";
        }

        // validacion QR

        private void btnValidarQR_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoQR.ForeColor == Color.Gray
                            ? string.Empty : txtCodigoQR.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                lblResultadoQR.Text = "Ingresá un código QR para validar.";
                lblResultadoQR.ForeColor = Color.OrangeRed;
                return;
            }

            try
            {
                // ValidarAccesoQR lanza excepción si el QR no es válido o ya fue usado
                VisitaDTO visita = _bll.ValidarAccesoQR(codigo);

                lblResultadoQR.Text =
                    $"✔  Visita #{visita.IdVisita}\n" +
                    $"Visitante: {visita.NombreVisitante}\n" +
                    $"Propiedad: {visita.CodigoPropiedad}   Estado: {visita.Estado}";
                lblResultadoQR.ForeColor = Color.FromArgb(27, 94, 32);

                // Ofrecer registrar salida inmediatamente
                DialogResult r = MessageBox.Show(
                    $"QR válido para {visita.NombreVisitante}.\n¿Registrar salida ahora?",
                    "Validación de acceso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    _bll.RegistrarSalida(visita.IdVisita);
                    MessageBox.Show("Salida registrada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigoQR.Text = string.Empty;
                    lblResultadoQR.Text = string.Empty;
                    CargarHistorial();
                }
            }
            catch (Exception ex)
            {
                lblResultadoQR.Text = "✘ " + ex.Message;
                lblResultadoQR.ForeColor = Color.Red;
            }
        }
    }
}