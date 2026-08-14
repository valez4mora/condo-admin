namespace UI.Forms
{
    partial class FrmPropietario
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
            this.pnlAccent          = new System.Windows.Forms.Panel();
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.lblSubtitulo       = new System.Windows.Forms.Label();
            this.pnlSepHeader       = new System.Windows.Forms.Panel();
            this.pnlForm            = new System.Windows.Forms.Panel();
            this.lblTipoId          = new System.Windows.Forms.Label();
            this.rdoCedula          = new System.Windows.Forms.RadioButton();
            this.rdoPasaporte       = new System.Windows.Forms.RadioButton();
            this.lblIdentificacion  = new System.Windows.Forms.Label();
            this.txtIdentificacion  = new System.Windows.Forms.TextBox();
            this.btnBuscarHacienda  = new System.Windows.Forms.Button();
            this.lblNombre          = new System.Windows.Forms.Label();
            this.txtNombre          = new System.Windows.Forms.TextBox();
            this.lblApellidos       = new System.Windows.Forms.Label();
            this.txtApellidos       = new System.Windows.Forms.TextBox();
            this.lblSexo            = new System.Windows.Forms.Label();
            this.cmbSexo            = new System.Windows.Forms.ComboBox();
            this.chkMoroso          = new System.Windows.Forms.CheckBox();
            this.lblTelefono        = new System.Windows.Forms.Label();
            this.txtTelefono        = new System.Windows.Forms.TextBox();
            this.lblEmail           = new System.Windows.Forms.Label();
            this.txtEmail           = new System.Windows.Forms.TextBox();
            this.lblDireccion       = new System.Windows.Forms.Label();
            this.txtDireccion       = new System.Windows.Forms.TextBox();
            this.lblProvincia       = new System.Windows.Forms.Label();
            this.cmbProvincia       = new System.Windows.Forms.ComboBox();
            this.pnlSepFoto         = new System.Windows.Forms.Panel();
            this.lblFoto            = new System.Windows.Forms.Label();
            this.picFoto            = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto      = new System.Windows.Forms.Button();
            this.pnlSepVert         = new System.Windows.Forms.Panel();
            this.pnlDerecha         = new System.Windows.Forms.Panel();
            this.pnlBusqueda        = new System.Windows.Forms.Panel();
            this.txtBuscar          = new System.Windows.Forms.TextBox();
            this.btnFiltrar         = new System.Windows.Forms.Button();
            this.btnVerTodos        = new System.Windows.Forms.Button();
            this.pnlSepGrid         = new System.Windows.Forms.Panel();
            this.dgvPropietarios    = new System.Windows.Forms.DataGridView();
            this.pnlInfoGrid        = new System.Windows.Forms.Panel();
            this.lblInfoGrid        = new System.Windows.Forms.Label();
            this.pnlSepAcciones     = new System.Windows.Forms.Panel();
            this.pnlAcciones        = new System.Windows.Forms.Panel();
            this.btnGuardar         = new System.Windows.Forms.Button();
            this.btnActualizar      = new System.Windows.Forms.Button();
            this.btnEliminar        = new System.Windows.Forms.Button();
            this.btnLimpiar         = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlInfoGrid.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
            this.SuspendLayout();

            // ── ACCENT BAR ─────────────────────────────────
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Height    = 4;
            this.pnlAccent.Name      = "pnlAccent";
            this.pnlAccent.TabIndex  = 0;

            // ── HEADER ─────────────────────────────────────
            this.pnlHeader.BackColor  = System.Drawing.Color.White;
            this.pnlHeader.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height     = 58;
            this.pnlHeader.Name       = "pnlHeader";
            this.pnlHeader.TabIndex   = 1;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblTitulo.Location  = new System.Drawing.Point(20, 8);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Propietarios";

            this.lblSubtitulo.AutoSize  = true;
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubtitulo.Location  = new System.Drawing.Point(22, 37);
            this.lblSubtitulo.Name      = "lblSubtitulo";
            this.lblSubtitulo.TabIndex  = 1;
            this.lblSubtitulo.Text      = "Registro y gesti\u00f3n de propietarios del condominio";

            // Línea bajo header
            this.pnlSepHeader.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlSepHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSepHeader.Height    = 1;
            this.pnlSepHeader.Name      = "pnlSepHeader";
            this.pnlSepHeader.TabIndex  = 2;

            // ── PANEL IZQUIERDA ────────────────────────────
            this.pnlForm.BackColor  = System.Drawing.Color.White;
            this.pnlForm.Location   = new System.Drawing.Point(0, 63);
            this.pnlForm.Name       = "pnlForm";
            this.pnlForm.Size       = new System.Drawing.Size(460, 600);
            this.pnlForm.TabIndex   = 3;
            this.pnlForm.Anchor     = ((System.Windows.Forms.AnchorStyles)(
                                        System.Windows.Forms.AnchorStyles.Top    |
                                        System.Windows.Forms.AnchorStyles.Left   |
                                        System.Windows.Forms.AnchorStyles.Bottom));
            this.pnlForm.Controls.Add(this.lblTipoId);
            this.pnlForm.Controls.Add(this.rdoCedula);
            this.pnlForm.Controls.Add(this.rdoPasaporte);
            this.pnlForm.Controls.Add(this.lblIdentificacion);
            this.pnlForm.Controls.Add(this.txtIdentificacion);
            this.pnlForm.Controls.Add(this.btnBuscarHacienda);
            this.pnlForm.Controls.Add(this.lblNombre);
            this.pnlForm.Controls.Add(this.txtNombre);
            this.pnlForm.Controls.Add(this.lblApellidos);
            this.pnlForm.Controls.Add(this.txtApellidos);
            this.pnlForm.Controls.Add(this.lblSexo);
            this.pnlForm.Controls.Add(this.cmbSexo);
            this.pnlForm.Controls.Add(this.chkMoroso);
            this.pnlForm.Controls.Add(this.lblTelefono);
            this.pnlForm.Controls.Add(this.txtTelefono);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblDireccion);
            this.pnlForm.Controls.Add(this.txtDireccion);
            this.pnlForm.Controls.Add(this.lblProvincia);
            this.pnlForm.Controls.Add(this.cmbProvincia);
            this.pnlForm.Controls.Add(this.pnlSepFoto);
            this.pnlForm.Controls.Add(this.lblFoto);
            this.pnlForm.Controls.Add(this.picFoto);
            this.pnlForm.Controls.Add(this.btnSeleccionarFoto);
            this.pnlForm.Controls.Add(this.btnQuitarFoto);

            // ── Tipo ID ────────────────────────────────────
            this.lblTipoId.AutoSize  = true;
            this.lblTipoId.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoId.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblTipoId.Location  = new System.Drawing.Point(20, 18);
            this.lblTipoId.Name      = "lblTipoId";
            this.lblTipoId.TabIndex  = 0;
            this.lblTipoId.Text      = "Tipo de ID:";

            this.rdoCedula.AutoSize  = true;
            this.rdoCedula.Checked   = true;
            this.rdoCedula.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCedula.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.rdoCedula.Location  = new System.Drawing.Point(165, 15);
            this.rdoCedula.Name      = "rdoCedula";
            this.rdoCedula.TabIndex  = 1;
            this.rdoCedula.TabStop   = true;
            this.rdoCedula.Text      = "C\u00e9dula";
            this.rdoCedula.CheckedChanged += new System.EventHandler(this.rdoTipoId_CheckedChanged);

            this.rdoPasaporte.AutoSize  = true;
            this.rdoPasaporte.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPasaporte.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.rdoPasaporte.Location  = new System.Drawing.Point(255, 15);
            this.rdoPasaporte.Name      = "rdoPasaporte";
            this.rdoPasaporte.TabIndex  = 2;
            this.rdoPasaporte.Text      = "Pasaporte";
            this.rdoPasaporte.CheckedChanged += new System.EventHandler(this.rdoTipoId_CheckedChanged);

            // ── Identificación ─────────────────────────────
            this.lblIdentificacion.AutoSize  = true;
            this.lblIdentificacion.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificacion.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblIdentificacion.Location  = new System.Drawing.Point(20, 55);
            this.lblIdentificacion.Name      = "lblIdentificacion";
            this.lblIdentificacion.TabIndex  = 3;
            this.lblIdentificacion.Text      = "Identificaci\u00f3n:";

            this.txtIdentificacion.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location  = new System.Drawing.Point(165, 50);
            this.txtIdentificacion.MaxLength = 12;
            this.txtIdentificacion.Name      = "txtIdentificacion";
            this.txtIdentificacion.Size      = new System.Drawing.Size(148, 25);
            this.txtIdentificacion.TabIndex  = 4;

            this.btnBuscarHacienda.BackColor  = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnBuscarHacienda.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHacienda.FlatAppearance.BorderSize = 0;
            this.btnBuscarHacienda.Font       = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarHacienda.ForeColor  = System.Drawing.Color.White;
            this.btnBuscarHacienda.Location   = new System.Drawing.Point(318, 50);
            this.btnBuscarHacienda.Name       = "btnBuscarHacienda";
            this.btnBuscarHacienda.Size       = new System.Drawing.Size(120, 25);
            this.btnBuscarHacienda.TabIndex   = 5;
            this.btnBuscarHacienda.Text       = "Consultar Hacienda";
            this.btnBuscarHacienda.UseVisualStyleBackColor = false;
            this.btnBuscarHacienda.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarHacienda.Click     += new System.EventHandler(this.btnBuscarHacienda_Click);

            // ── Nombre ─────────────────────────────────────
            this.lblNombre.AutoSize  = true;
            this.lblNombre.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblNombre.Location  = new System.Drawing.Point(20, 92);
            this.lblNombre.Name      = "lblNombre";
            this.lblNombre.TabIndex  = 6;
            this.lblNombre.Text      = "Nombre(s):";

            this.txtNombre.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location  = new System.Drawing.Point(165, 87);
            this.txtNombre.Name      = "txtNombre";
            this.txtNombre.Size      = new System.Drawing.Size(273, 25);
            this.txtNombre.TabIndex  = 7;

            // ── Apellidos ──────────────────────────────────
            this.lblApellidos.AutoSize  = true;
            this.lblApellidos.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblApellidos.Location  = new System.Drawing.Point(20, 126);
            this.lblApellidos.Name      = "lblApellidos";
            this.lblApellidos.TabIndex  = 8;
            this.lblApellidos.Text      = "Apellidos:";

            this.txtApellidos.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location  = new System.Drawing.Point(165, 121);
            this.txtApellidos.Name      = "txtApellidos";
            this.txtApellidos.Size      = new System.Drawing.Size(273, 25);
            this.txtApellidos.TabIndex  = 9;

            // ── Sexo + Moroso ──────────────────────────────
            this.lblSexo.AutoSize  = true;
            this.lblSexo.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSexo.Location  = new System.Drawing.Point(20, 160);
            this.lblSexo.Name      = "lblSexo";
            this.lblSexo.TabIndex  = 10;
            this.lblSexo.Text      = "Sexo:";

            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Font          = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location      = new System.Drawing.Point(165, 155);
            this.cmbSexo.Name          = "cmbSexo";
            this.cmbSexo.Size          = new System.Drawing.Size(85, 25);
            this.cmbSexo.TabIndex      = 11;

            this.chkMoroso.AutoSize  = true;
            this.chkMoroso.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoroso.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.chkMoroso.Location  = new System.Drawing.Point(268, 158);
            this.chkMoroso.Name      = "chkMoroso";
            this.chkMoroso.Size      = new System.Drawing.Size(75, 19);
            this.chkMoroso.TabIndex  = 12;
            this.chkMoroso.Text      = "Moroso";

            // ── Teléfono ───────────────────────────────────
            this.lblTelefono.AutoSize  = true;
            this.lblTelefono.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblTelefono.Location  = new System.Drawing.Point(20, 194);
            this.lblTelefono.Name      = "lblTelefono";
            this.lblTelefono.TabIndex  = 13;
            this.lblTelefono.Text      = "Tel\u00e9fono:";

            this.txtTelefono.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location  = new System.Drawing.Point(165, 189);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name      = "txtTelefono";
            this.txtTelefono.Size      = new System.Drawing.Size(273, 25);
            this.txtTelefono.TabIndex  = 14;

            // ── Email ──────────────────────────────────────
            this.lblEmail.AutoSize  = true;
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblEmail.Location  = new System.Drawing.Point(20, 228);
            this.lblEmail.Name      = "lblEmail";
            this.lblEmail.TabIndex  = 15;
            this.lblEmail.Text      = "Correo electr\u00f3nico:";

            this.txtEmail.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location  = new System.Drawing.Point(165, 223);
            this.txtEmail.Name      = "txtEmail";
            this.txtEmail.Size      = new System.Drawing.Size(273, 25);
            this.txtEmail.TabIndex  = 16;

            // ── Dirección ──────────────────────────────────
            this.lblDireccion.AutoSize  = true;
            this.lblDireccion.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDireccion.Location  = new System.Drawing.Point(20, 262);
            this.lblDireccion.Name      = "lblDireccion";
            this.lblDireccion.TabIndex  = 17;
            this.lblDireccion.Text      = "Direcci\u00f3n:";

            this.txtDireccion.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location  = new System.Drawing.Point(165, 257);
            this.txtDireccion.Name      = "txtDireccion";
            this.txtDireccion.Size      = new System.Drawing.Size(273, 25);
            this.txtDireccion.TabIndex  = 18;

            // ── Provincia ──────────────────────────────────
            this.lblProvincia.AutoSize  = true;
            this.lblProvincia.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvincia.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblProvincia.Location  = new System.Drawing.Point(20, 297);
            this.lblProvincia.Name      = "lblProvincia";
            this.lblProvincia.TabIndex  = 19;
            this.lblProvincia.Text      = "Provincia:";

            this.cmbProvincia.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.Font             = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location         = new System.Drawing.Point(165, 292);
            this.cmbProvincia.Name             = "cmbProvincia";
            this.cmbProvincia.Size             = new System.Drawing.Size(273, 25);
            this.cmbProvincia.TabIndex         = 20;

            // ── Separador sección foto ─────────────────────
            this.pnlSepFoto.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlSepFoto.Location  = new System.Drawing.Point(20, 333);
            this.pnlSepFoto.Name      = "pnlSepFoto";
            this.pnlSepFoto.Size      = new System.Drawing.Size(418, 1);
            this.pnlSepFoto.TabIndex  = 21;

            // ── Fotografía ─────────────────────────────────
            this.lblFoto.AutoSize  = true;
            this.lblFoto.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblFoto.Location  = new System.Drawing.Point(20, 376);
            this.lblFoto.Name      = "lblFoto";
            this.lblFoto.TabIndex  = 22;
            this.lblFoto.Text      = "Fotograf\u00eda:";

            this.picFoto.BackColor   = System.Drawing.Color.FromArgb(243, 244, 246);
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location    = new System.Drawing.Point(165, 344);
            this.picFoto.Name        = "picFoto";
            this.picFoto.Size        = new System.Drawing.Size(88, 88);
            this.picFoto.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex    = 23;

            this.btnSeleccionarFoto.BackColor  = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnSeleccionarFoto.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFoto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnSeleccionarFoto.FlatAppearance.BorderSize  = 1;
            this.btnSeleccionarFoto.Font       = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarFoto.ForeColor  = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnSeleccionarFoto.Location   = new System.Drawing.Point(262, 344);
            this.btnSeleccionarFoto.Name       = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size       = new System.Drawing.Size(120, 30);
            this.btnSeleccionarFoto.TabIndex   = 24;
            this.btnSeleccionarFoto.Text       = "Seleccionar foto";
            this.btnSeleccionarFoto.UseVisualStyleBackColor = false;
            this.btnSeleccionarFoto.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarFoto.Click     += new System.EventHandler(this.btnSeleccionarFoto_Click);

            this.btnQuitarFoto.BackColor  = System.Drawing.Color.White;
            this.btnQuitarFoto.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnQuitarFoto.FlatAppearance.BorderSize  = 1;
            this.btnQuitarFoto.Font       = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarFoto.ForeColor  = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnQuitarFoto.Location   = new System.Drawing.Point(262, 381);
            this.btnQuitarFoto.Name       = "btnQuitarFoto";
            this.btnQuitarFoto.Size       = new System.Drawing.Size(120, 30);
            this.btnQuitarFoto.TabIndex   = 25;
            this.btnQuitarFoto.Text       = "Quitar foto";
            this.btnQuitarFoto.UseVisualStyleBackColor = false;
            this.btnQuitarFoto.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFoto.Click     += new System.EventHandler(this.btnQuitarFoto_Click);

            // ── SEPARADOR VERTICAL ─────────────────────────
            this.pnlSepVert.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlSepVert.Location  = new System.Drawing.Point(460, 63);
            this.pnlSepVert.Name      = "pnlSepVert";
            this.pnlSepVert.Size      = new System.Drawing.Size(1, 600);
            this.pnlSepVert.TabIndex  = 4;
            this.pnlSepVert.Anchor    = ((System.Windows.Forms.AnchorStyles)(
                                          System.Windows.Forms.AnchorStyles.Top  |
                                          System.Windows.Forms.AnchorStyles.Left |
                                          System.Windows.Forms.AnchorStyles.Bottom));

            // ── PANEL DERECHA ──────────────────────────────
            this.pnlDerecha.BackColor = System.Drawing.Color.White;
            this.pnlDerecha.Location  = new System.Drawing.Point(461, 63);
            this.pnlDerecha.Name      = "pnlDerecha";
            this.pnlDerecha.Size      = new System.Drawing.Size(739, 600);
            this.pnlDerecha.TabIndex  = 5;
            this.pnlDerecha.Anchor    = ((System.Windows.Forms.AnchorStyles)(
                                          System.Windows.Forms.AnchorStyles.Top    |
                                          System.Windows.Forms.AnchorStyles.Left   |
                                          System.Windows.Forms.AnchorStyles.Right  |
                                          System.Windows.Forms.AnchorStyles.Bottom));
            this.pnlDerecha.Controls.Add(this.pnlBusqueda);
            this.pnlDerecha.Controls.Add(this.pnlSepGrid);
            this.pnlDerecha.Controls.Add(this.dgvPropietarios);
            this.pnlDerecha.Controls.Add(this.pnlInfoGrid);

            // ── Barra búsqueda ─────────────────────────────
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.Location  = new System.Drawing.Point(0, 0);
            this.pnlBusqueda.Name      = "pnlBusqueda";
            this.pnlBusqueda.Size      = new System.Drawing.Size(739, 48);
            this.pnlBusqueda.TabIndex  = 0;
            this.pnlBusqueda.Anchor    = ((System.Windows.Forms.AnchorStyles)(
                                           System.Windows.Forms.AnchorStyles.Top  |
                                           System.Windows.Forms.AnchorStyles.Left |
                                           System.Windows.Forms.AnchorStyles.Right));
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.btnFiltrar);
            this.pnlBusqueda.Controls.Add(this.btnVerTodos);

            this.txtBuscar.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.txtBuscar.Location  = new System.Drawing.Point(12, 12);
            this.txtBuscar.Name      = "txtBuscar";
            this.txtBuscar.Size      = new System.Drawing.Size(320, 25);
            this.txtBuscar.TabIndex  = 0;
            this.txtBuscar.Text      = "Buscar por nombre, identificacion o correo...";
            this.txtBuscar.Enter    += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave    += new System.EventHandler(this.txtBuscar_Leave);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.btnFiltrar.BackColor  = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltrar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Font       = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor  = System.Drawing.Color.White;
            this.btnFiltrar.Location   = new System.Drawing.Point(340, 11);
            this.btnFiltrar.Name       = "btnFiltrar";
            this.btnFiltrar.Size       = new System.Drawing.Size(88, 26);
            this.btnFiltrar.TabIndex   = 1;
            this.btnFiltrar.Text       = "Buscar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click     += new System.EventHandler(this.btnFiltrar_Click);

            this.btnVerTodos.BackColor  = System.Drawing.Color.White;
            this.btnVerTodos.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnVerTodos.FlatAppearance.BorderSize  = 1;
            this.btnVerTodos.Font       = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTodos.ForeColor  = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnVerTodos.Location   = new System.Drawing.Point(436, 11);
            this.btnVerTodos.Name       = "btnVerTodos";
            this.btnVerTodos.Size       = new System.Drawing.Size(88, 26);
            this.btnVerTodos.TabIndex   = 2;
            this.btnVerTodos.Text       = "Ver todos";
            this.btnVerTodos.UseVisualStyleBackColor = false;
            this.btnVerTodos.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodos.Click     += new System.EventHandler(this.btnVerTodos_Click);

            this.pnlSepGrid.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlSepGrid.Location  = new System.Drawing.Point(0, 48);
            this.pnlSepGrid.Name      = "pnlSepGrid";
            this.pnlSepGrid.Size      = new System.Drawing.Size(739, 1);
            this.pnlSepGrid.TabIndex  = 1;
            this.pnlSepGrid.Anchor    = ((System.Windows.Forms.AnchorStyles)(
                                          System.Windows.Forms.AnchorStyles.Top  |
                                          System.Windows.Forms.AnchorStyles.Left |
                                          System.Windows.Forms.AnchorStyles.Right));

            // ── DataGridView ───────────────────────────────
            this.dgvPropietarios.AllowUserToAddRows    = false;
            this.dgvPropietarios.AllowUserToDeleteRows = false;
            this.dgvPropietarios.AllowUserToResizeRows = false;
            this.dgvPropietarios.BackgroundColor       = System.Drawing.Color.White;
            this.dgvPropietarios.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvPropietarios.ColumnHeadersHeight   = 34;
            this.dgvPropietarios.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPropietarios.GridColor       = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvPropietarios.Location        = new System.Drawing.Point(0, 49);
            this.dgvPropietarios.MultiSelect     = false;
            this.dgvPropietarios.Name            = "dgvPropietarios";
            this.dgvPropietarios.ReadOnly        = true;
            this.dgvPropietarios.RowHeadersVisible = false;
            this.dgvPropietarios.SelectionMode   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropietarios.Size            = new System.Drawing.Size(739, 514);
            this.dgvPropietarios.TabIndex        = 2;
            this.dgvPropietarios.Anchor          = ((System.Windows.Forms.AnchorStyles)(
                                                    System.Windows.Forms.AnchorStyles.Top    |
                                                    System.Windows.Forms.AnchorStyles.Left   |
                                                    System.Windows.Forms.AnchorStyles.Right  |
                                                    System.Windows.Forms.AnchorStyles.Bottom));
            this.dgvPropietarios.CellClick      += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPropietarios_CellClick);

            // Info strip
            this.pnlInfoGrid.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlInfoGrid.Location  = new System.Drawing.Point(0, 563);
            this.pnlInfoGrid.Name      = "pnlInfoGrid";
            this.pnlInfoGrid.Size      = new System.Drawing.Size(739, 37);
            this.pnlInfoGrid.TabIndex  = 3;
            this.pnlInfoGrid.Anchor    = ((System.Windows.Forms.AnchorStyles)(
                                           System.Windows.Forms.AnchorStyles.Bottom |
                                           System.Windows.Forms.AnchorStyles.Left   |
                                           System.Windows.Forms.AnchorStyles.Right));
            this.pnlInfoGrid.Controls.Add(this.lblInfoGrid);

            this.lblInfoGrid.AutoSize  = true;
            this.lblInfoGrid.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoGrid.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblInfoGrid.Location  = new System.Drawing.Point(10, 11);
            this.lblInfoGrid.Name      = "lblInfoGrid";
            this.lblInfoGrid.TabIndex  = 0;
            this.lblInfoGrid.Text      = "Haga clic en una fila para cargar los datos en el formulario";

            // ── BARRA ACCIONES ─────────────────────────────
            this.pnlSepAcciones.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlSepAcciones.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSepAcciones.Height    = 1;
            this.pnlSepAcciones.Name      = "pnlSepAcciones";
            this.pnlSepAcciones.TabIndex  = 6;

            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlAcciones.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Height    = 60;
            this.pnlAcciones.Name      = "pnlAcciones";
            this.pnlAcciones.TabIndex  = 7;
            this.pnlAcciones.Controls.Add(this.btnGuardar);
            this.pnlAcciones.Controls.Add(this.btnActualizar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);

            this.btnGuardar.BackColor  = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGuardar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor  = System.Drawing.Color.White;
            this.btnGuardar.Location   = new System.Drawing.Point(15, 11);
            this.btnGuardar.Name       = "btnGuardar";
            this.btnGuardar.Size       = new System.Drawing.Size(145, 38);
            this.btnGuardar.TabIndex   = 0;
            this.btnGuardar.Text       = "Registrar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click     += new System.EventHandler(this.btnGuardar_Click);

            this.btnActualizar.BackColor  = System.Drawing.Color.FromArgb(8, 145, 178);
            this.btnActualizar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor  = System.Drawing.Color.White;
            this.btnActualizar.Location   = new System.Drawing.Point(170, 11);
            this.btnActualizar.Name       = "btnActualizar";
            this.btnActualizar.Size       = new System.Drawing.Size(145, 38);
            this.btnActualizar.TabIndex   = 1;
            this.btnActualizar.Text       = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Click     += new System.EventHandler(this.btnActualizar_Click);

            this.btnEliminar.BackColor  = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnEliminar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor  = System.Drawing.Color.White;
            this.btnEliminar.Location   = new System.Drawing.Point(325, 11);
            this.btnEliminar.Name       = "btnEliminar";
            this.btnEliminar.Size       = new System.Drawing.Size(145, 38);
            this.btnEliminar.TabIndex   = 2;
            this.btnEliminar.Text       = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click     += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.BackColor  = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnLimpiar.FlatAppearance.BorderSize  = 1;
            this.btnLimpiar.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor  = System.Drawing.Color.FromArgb(107, 114, 128);
            this.btnLimpiar.Location   = new System.Drawing.Point(480, 11);
            this.btnLimpiar.Name       = "btnLimpiar";
            this.btnLimpiar.Size       = new System.Drawing.Size(120, 38);
            this.btnLimpiar.TabIndex   = 3;
            this.btnLimpiar.Text       = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click     += new System.EventHandler(this.btnLimpiar_Click);

            // ── FORM ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(1200, 725);
            this.MinimumSize         = new System.Drawing.Size(1000, 660);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlSepVert);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlSepAcciones);
            this.Controls.Add(this.pnlSepHeader);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAccent);
            this.Name          = "FrmPropietario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Propietarios";
            this.WindowState   = System.Windows.Forms.FormWindowState.Maximized;
            this.Load         += new System.EventHandler(this.FrmPropietario_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlInfoGrid.ResumeLayout(false);
            this.pnlInfoGrid.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel           pnlAccent;
        private System.Windows.Forms.Panel           pnlHeader;
        private System.Windows.Forms.Label           lblTitulo;
        private System.Windows.Forms.Label           lblSubtitulo;
        private System.Windows.Forms.Panel           pnlSepHeader;
        private System.Windows.Forms.Panel           pnlForm;
        private System.Windows.Forms.Label           lblTipoId;
        private System.Windows.Forms.RadioButton     rdoCedula;
        private System.Windows.Forms.RadioButton     rdoPasaporte;
        private System.Windows.Forms.Label           lblIdentificacion;
        private System.Windows.Forms.TextBox         txtIdentificacion;
        private System.Windows.Forms.Button          btnBuscarHacienda;
        private System.Windows.Forms.Label           lblNombre;
        private System.Windows.Forms.TextBox         txtNombre;
        private System.Windows.Forms.Label           lblApellidos;
        private System.Windows.Forms.TextBox         txtApellidos;
        private System.Windows.Forms.Label           lblSexo;
        private System.Windows.Forms.ComboBox        cmbSexo;
        private System.Windows.Forms.CheckBox        chkMoroso;
        private System.Windows.Forms.Label           lblTelefono;
        private System.Windows.Forms.TextBox         txtTelefono;
        private System.Windows.Forms.Label           lblEmail;
        private System.Windows.Forms.TextBox         txtEmail;
        private System.Windows.Forms.Label           lblDireccion;
        private System.Windows.Forms.TextBox         txtDireccion;
        private System.Windows.Forms.Label           lblProvincia;
        private System.Windows.Forms.ComboBox        cmbProvincia;
        private System.Windows.Forms.Panel           pnlSepFoto;
        private System.Windows.Forms.Label           lblFoto;
        private System.Windows.Forms.PictureBox      picFoto;
        private System.Windows.Forms.Button          btnSeleccionarFoto;
        private System.Windows.Forms.Button          btnQuitarFoto;
        private System.Windows.Forms.Panel           pnlSepVert;
        private System.Windows.Forms.Panel           pnlDerecha;
        private System.Windows.Forms.Panel           pnlBusqueda;
        private System.Windows.Forms.TextBox         txtBuscar;
        private System.Windows.Forms.Button          btnFiltrar;
        private System.Windows.Forms.Button          btnVerTodos;
        private System.Windows.Forms.Panel           pnlSepGrid;
        private System.Windows.Forms.DataGridView    dgvPropietarios;
        private System.Windows.Forms.Panel           pnlInfoGrid;
        private System.Windows.Forms.Label           lblInfoGrid;
        private System.Windows.Forms.Panel           pnlSepAcciones;
        private System.Windows.Forms.Panel           pnlAcciones;
        private System.Windows.Forms.Button          btnGuardar;
        private System.Windows.Forms.Button          btnActualizar;
        private System.Windows.Forms.Button          btnEliminar;
        private System.Windows.Forms.Button          btnLimpiar;
    }
}
