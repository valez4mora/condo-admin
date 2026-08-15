namespace UI.Forms
{
    partial class FrmControlAcceso
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRegistro = new System.Windows.Forms.TabPage();
            this.tabHistorial = new System.Windows.Forms.TabPage();

            // ── Tab Registro ──────────────────────────────────────
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblVisitante = new System.Windows.Forms.Label();
            this.txtNombreVisitante = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();

            this.grpQR = new System.Windows.Forms.GroupBox();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.lblCodigoQR = new System.Windows.Forms.Label();
            this.btnGuardarQR = new System.Windows.Forms.Button();

            // ── Tab Historial ─────────────────────────────────────
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblFiltroProp = new System.Windows.Forms.Label();
            this.cmbFiltroProp = new System.Windows.Forms.ComboBox();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.chkUsarFecha = new System.Windows.Forms.CheckBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();

            // ── Validación QR (panel inferior del historial) ──────
            this.grpValidarQR = new System.Windows.Forms.GroupBox();
            this.lblValidarQR = new System.Windows.Forms.Label();
            this.txtCodigoQR = new System.Windows.Forms.TextBox();
            this.btnValidarQR = new System.Windows.Forms.Button();
            this.lblResultadoQR = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.tabRegistro.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.grpValidarQR.SuspendLayout();
            this.SuspendLayout();

            // ─────────────────────────────────────────────────────
            // tabControl
            // ─────────────────────────────────────────────────────
            this.tabControl.Controls.Add(this.tabRegistro);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;

            // ─────────────────────────────────────────────────────
            // tabRegistro
            // ─────────────────────────────────────────────────────
            this.tabRegistro.Controls.Add(this.grpDatos);
            this.tabRegistro.Controls.Add(this.grpQR);
            this.tabRegistro.Location = new System.Drawing.Point(4, 26);
            this.tabRegistro.Name = "tabRegistro";
            this.tabRegistro.Padding = new System.Windows.Forms.Padding(10);
            this.tabRegistro.Size = new System.Drawing.Size(976, 580);
            this.tabRegistro.Text = "  Registrar Visita  ";

            // ─────────────────────────────────────────────────────
            // grpDatos
            // ─────────────────────────────────────────────────────
            this.grpDatos.Controls.Add(this.lblPropiedad);
            this.grpDatos.Controls.Add(this.cmbPropiedad);
            this.grpDatos.Controls.Add(this.lblVisitante);
            this.grpDatos.Controls.Add(this.txtNombreVisitante);
            this.grpDatos.Controls.Add(this.lblFecha);
            this.grpDatos.Controls.Add(this.dtpFecha);
            this.grpDatos.Controls.Add(this.lblHoraEntrada);
            this.grpDatos.Controls.Add(this.dtpHoraEntrada);
            this.grpDatos.Controls.Add(this.btnRegistrar);
            this.grpDatos.Controls.Add(this.btnRegistrarSalida);
            this.grpDatos.Location = new System.Drawing.Point(15, 15);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(560, 540);
            this.grpDatos.Text = "Datos de la Visita";
            this.grpDatos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // lblPropiedad
            this.lblPropiedad.Location = new System.Drawing.Point(20, 40);
            this.lblPropiedad.Size = new System.Drawing.Size(160, 23);
            this.lblPropiedad.Text = "Propiedad destino:";
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // cmbPropiedad
            this.cmbPropiedad.Location = new System.Drawing.Point(20, 63);
            this.cmbPropiedad.Size = new System.Drawing.Size(510, 25);
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPropiedad.Name = "cmbPropiedad";

            // lblVisitante
            this.lblVisitante.Location = new System.Drawing.Point(20, 105);
            this.lblVisitante.Size = new System.Drawing.Size(160, 23);
            this.lblVisitante.Text = "Nombre del visitante:";
            this.lblVisitante.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // txtNombreVisitante
            this.txtNombreVisitante.Location = new System.Drawing.Point(20, 128);
            this.txtNombreVisitante.Size = new System.Drawing.Size(510, 25);
            this.txtNombreVisitante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreVisitante.Name = "txtNombreVisitante";
            this.txtNombreVisitante.MaxLength = 100;

            // lblFecha
            this.lblFecha.Location = new System.Drawing.Point(20, 170);
            this.lblFecha.Size = new System.Drawing.Size(160, 23);
            this.lblFecha.Text = "Fecha de visita:";
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // dtpFecha
            this.dtpFecha.Location = new System.Drawing.Point(20, 193);
            this.dtpFecha.Size = new System.Drawing.Size(240, 25);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Name = "dtpFecha";

            // lblHoraEntrada
            this.lblHoraEntrada.Location = new System.Drawing.Point(20, 235);
            this.lblHoraEntrada.Size = new System.Drawing.Size(160, 23);
            this.lblHoraEntrada.Text = "Hora de entrada:";
            this.lblHoraEntrada.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // dtpHoraEntrada
            this.dtpHoraEntrada.Location = new System.Drawing.Point(20, 258);
            this.dtpHoraEntrada.Size = new System.Drawing.Size(240, 25);
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntrada.ShowUpDown = true;
            this.dtpHoraEntrada.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";

            // btnRegistrar
            this.btnRegistrar.Location = new System.Drawing.Point(20, 320);
            this.btnRegistrar.Size = new System.Drawing.Size(230, 42);
            this.btnRegistrar.Text = "✔  Registrar Visita y Generar QR";
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // btnRegistrarSalida
            this.btnRegistrarSalida.Location = new System.Drawing.Point(270, 320);
            this.btnRegistrarSalida.Size = new System.Drawing.Size(200, 42);
            this.btnRegistrarSalida.Text = "🚪  Registrar Salida";
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSalida.Enabled = false;
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);

            // ─────────────────────────────────────────────────────
            // grpQR
            // ─────────────────────────────────────────────────────
            this.grpQR.Controls.Add(this.picQR);
            this.grpQR.Controls.Add(this.lblCodigoQR);
            this.grpQR.Controls.Add(this.btnGuardarQR);
            this.grpQR.Location = new System.Drawing.Point(590, 15);
            this.grpQR.Name = "grpQR";
            this.grpQR.Size = new System.Drawing.Size(370, 540);
            this.grpQR.Text = "Código QR de Acceso";
            this.grpQR.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // picQR
            this.picQR.Location = new System.Drawing.Point(60, 40);
            this.picQR.Size = new System.Drawing.Size(250, 250);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.BackColor = System.Drawing.Color.White;
            this.picQR.Name = "picQR";

            // lblCodigoQR
            this.lblCodigoQR.Location = new System.Drawing.Point(15, 305);
            this.lblCodigoQR.Size = new System.Drawing.Size(340, 60);
            this.lblCodigoQR.Text = "El código QR aparecerá\ndespués de registrar la visita.";
            this.lblCodigoQR.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCodigoQR.ForeColor = System.Drawing.Color.Gray;
            this.lblCodigoQR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCodigoQR.Name = "lblCodigoQR";

            // btnGuardarQR
            this.btnGuardarQR.Location = new System.Drawing.Point(75, 380);
            this.btnGuardarQR.Size = new System.Drawing.Size(210, 38);
            this.btnGuardarQR.Text = "💾  Guardar QR como imagen";
            this.btnGuardarQR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardarQR.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnGuardarQR.ForeColor = System.Drawing.Color.White;
            this.btnGuardarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarQR.Enabled = false;
            this.btnGuardarQR.Name = "btnGuardarQR";
            this.btnGuardarQR.Click += new System.EventHandler(this.btnGuardarQR_Click);

            // ─────────────────────────────────────────────────────
            // tabHistorial
            // ─────────────────────────────────────────────────────
            this.tabHistorial.Controls.Add(this.pnlFiltros);
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.grpValidarQR);
            this.tabHistorial.Location = new System.Drawing.Point(4, 26);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(10);
            this.tabHistorial.Size = new System.Drawing.Size(976, 580);
            this.tabHistorial.Text = "  Historial de Visitas  ";

            // ─────────────────────────────────────────────────────
            // pnlFiltros
            // ─────────────────────────────────────────────────────
            this.pnlFiltros.Controls.Add(this.lblFiltroProp);
            this.pnlFiltros.Controls.Add(this.cmbFiltroProp);
            this.pnlFiltros.Controls.Add(this.chkUsarFecha);
            this.pnlFiltros.Controls.Add(this.lblFiltroFecha);
            this.pnlFiltros.Controls.Add(this.dtpFiltroFecha);
            this.pnlFiltros.Controls.Add(this.lblFiltroEstado);
            this.pnlFiltros.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.pnlFiltros.Location = new System.Drawing.Point(10, 10);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(956, 70);
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblFiltroProp
            this.lblFiltroProp.Location = new System.Drawing.Point(8, 8);
            this.lblFiltroProp.Size = new System.Drawing.Size(80, 20);
            this.lblFiltroProp.Text = "Propiedad:";
            this.lblFiltroProp.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            // cmbFiltroProp
            this.cmbFiltroProp.Location = new System.Drawing.Point(8, 30);
            this.cmbFiltroProp.Size = new System.Drawing.Size(200, 25);
            this.cmbFiltroProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroProp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmbFiltroProp.Name = "cmbFiltroProp";

            // chkUsarFecha
            this.chkUsarFecha.Location = new System.Drawing.Point(222, 8);
            this.chkUsarFecha.Size = new System.Drawing.Size(90, 20);
            this.chkUsarFecha.Text = "Filtrar fecha";
            this.chkUsarFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkUsarFecha.Name = "chkUsarFecha";
            this.chkUsarFecha.CheckedChanged += new System.EventHandler(this.chkUsarFecha_CheckedChanged);

            // lblFiltroFecha
            this.lblFiltroFecha.Location = new System.Drawing.Point(222, 8);
            this.lblFiltroFecha.Size = new System.Drawing.Size(50, 20);
            this.lblFiltroFecha.Text = "Fecha:";
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltroFecha.Visible = false;

            // dtpFiltroFecha
            this.dtpFiltroFecha.Location = new System.Drawing.Point(222, 30);
            this.dtpFiltroFecha.Size = new System.Drawing.Size(170, 25);
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dtpFiltroFecha.Enabled = false;
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";

            // lblFiltroEstado
            this.lblFiltroEstado.Location = new System.Drawing.Point(408, 8);
            this.lblFiltroEstado.Size = new System.Drawing.Size(55, 20);
            this.lblFiltroEstado.Text = "Estado:";
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            // cmbFiltroEstado
            this.cmbFiltroEstado.Location = new System.Drawing.Point(408, 30);
            this.cmbFiltroEstado.Size = new System.Drawing.Size(130, 25);
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Dentro", "Fuera" });
            this.cmbFiltroEstado.SelectedIndex = 0;
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";

            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(560, 25);
            this.btnBuscar.Size = new System.Drawing.Size(110, 32);
            this.btnBuscar.Text = "🔍  Buscar";
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // btnLimpiarFiltros
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(685, 25);
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(110, 32);
            this.btnLimpiarFiltros.Text = "✖  Limpiar";
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);

            // ─────────────────────────────────────────────────────
            // dgvHistorial
            // ─────────────────────────────────────────────────────
            this.dgvHistorial.Location = new System.Drawing.Point(10, 90);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(956, 360);
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvHistorial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellClick);

            // ─────────────────────────────────────────────────────
            // grpValidarQR (panel inferior del historial)
            // ─────────────────────────────────────────────────────
            this.grpValidarQR.Controls.Add(this.lblValidarQR);
            this.grpValidarQR.Controls.Add(this.txtCodigoQR);
            this.grpValidarQR.Controls.Add(this.btnValidarQR);
            this.grpValidarQR.Controls.Add(this.lblResultadoQR);
            this.grpValidarQR.Location = new System.Drawing.Point(10, 462);
            this.grpValidarQR.Name = "grpValidarQR";
            this.grpValidarQR.Size = new System.Drawing.Size(956, 100);
            this.grpValidarQR.Text = "Validar Código QR";
            this.grpValidarQR.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // lblValidarQR
            this.lblValidarQR.Location = new System.Drawing.Point(15, 30);
            this.lblValidarQR.Size = new System.Drawing.Size(120, 23);
            this.lblValidarQR.Text = "Código escaneado:";
            this.lblValidarQR.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtCodigoQR
            // txtCodigoQR
            this.txtCodigoQR.Location = new System.Drawing.Point(140, 27);
            this.txtCodigoQR.Size = new System.Drawing.Size(300, 25);
            this.txtCodigoQR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoQR.Name = "txtCodigoQR";

            // btnValidarQR
            this.btnValidarQR.Location = new System.Drawing.Point(455, 24);
            this.btnValidarQR.Size = new System.Drawing.Size(130, 32);
            this.btnValidarQR.Text = "✔  Validar QR";
            this.btnValidarQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidarQR.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnValidarQR.ForeColor = System.Drawing.Color.White;
            this.btnValidarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidarQR.Name = "btnValidarQR";
            this.btnValidarQR.Click += new System.EventHandler(this.btnValidarQR_Click);

            // lblResultadoQR
            this.lblResultadoQR.Location = new System.Drawing.Point(600, 20);
            this.lblResultadoQR.Size = new System.Drawing.Size(340, 60);
            this.lblResultadoQR.Text = "";
            this.lblResultadoQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultadoQR.Name = "lblResultadoQR";

            // ─────────────────────────────────────────────────────
            // FrmControlAcceso
            // ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 610);
            this.Controls.Add(this.tabControl);
            this.Name = "FrmControlAcceso";
            this.Text = "Control de Acceso y Visitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmControlAcceso_Load);

            this.tabControl.ResumeLayout(false);
            this.tabRegistro.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpQR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.grpValidarQR.ResumeLayout(false);
            this.grpValidarQR.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Tab control
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRegistro;
        private System.Windows.Forms.TabPage tabHistorial;

        // Tab registro
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.Label lblVisitante;
        private System.Windows.Forms.TextBox txtNombreVisitante;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.GroupBox grpQR;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.Button btnGuardarQR;

        // Tab historial
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFiltroProp;
        private System.Windows.Forms.ComboBox cmbFiltroProp;
        private System.Windows.Forms.CheckBox chkUsarFecha;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvHistorial;

        // Validacion QR
        private System.Windows.Forms.GroupBox grpValidarQR;
        private System.Windows.Forms.Label lblValidarQR;
        private System.Windows.Forms.TextBox txtCodigoQR;
        private System.Windows.Forms.Button btnValidarQR;
        private System.Windows.Forms.Label lblResultadoQR;
    }
}
