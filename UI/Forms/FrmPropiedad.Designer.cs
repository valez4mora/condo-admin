namespace UI.Forms
{
    partial class FrmPropiedad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblBuscarPorCodigo = new System.Windows.Forms.Label();
            this.txtBuscarPorCodigo = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.nudCuota = new System.Windows.Forms.NumericUpDown();
            this.lblCuota = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.nudResidentes = new System.Windows.Forms.NumericUpDown();
            this.lblResidentes = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPropietario = new System.Windows.Forms.ComboBox();
            this.nudArea = new System.Windows.Forms.NumericUpDown();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResidentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(57, 39);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(137, 21);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código de la Propiedad:";
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropietario.Location = new System.Drawing.Point(496, 39);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(68, 16);
            this.lblPropietario.TabIndex = 4;
            this.lblPropietario.Text = "Propietario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(541, 909);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Área (m²):";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(219, 37);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(209, 23);
            this.txtCodigo.TabIndex = 10;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.OliveDrab;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistrar.Location = new System.Drawing.Point(40, 518);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(151, 40);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.Location = new System.Drawing.Point(495, 92);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(66, 20);
            this.lblFoto.TabIndex = 17;
            this.lblFoto.Text = "Fotografía:";
            // 
            // lblBuscarPorCodigo
            // 
            this.lblBuscarPorCodigo.AutoSize = true;
            this.lblBuscarPorCodigo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPorCodigo.Location = new System.Drawing.Point(121, 28);
            this.lblBuscarPorCodigo.Name = "lblBuscarPorCodigo";
            this.lblBuscarPorCodigo.Size = new System.Drawing.Size(109, 16);
            this.lblBuscarPorCodigo.TabIndex = 22;
            this.lblBuscarPorCodigo.Text = "Buscar por código:";
            this.lblBuscarPorCodigo.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtBuscarPorCodigo
            // 
            this.txtBuscarPorCodigo.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscarPorCodigo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarPorCodigo.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscarPorCodigo.Location = new System.Drawing.Point(274, 26);
            this.txtBuscarPorCodigo.Name = "txtBuscarPorCodigo";
            this.txtBuscarPorCodigo.Size = new System.Drawing.Size(290, 22);
            this.txtBuscarPorCodigo.TabIndex = 23;
            this.txtBuscarPorCodigo.Text = "Ingrese el código de la propiedad";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1009, 113);
            this.pnlHeader.TabIndex = 26;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSubtitulo.Location = new System.Drawing.Point(390, 69);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(199, 17);
            this.lblSubtitulo.TabIndex = 27;
            this.lblSubtitulo.Text = "Registro y Búsqueda de Propiedades";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(376, 33);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(223, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Propiedades";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlContenedor.Controls.Add(this.btnReporte);
            this.pnlContenedor.Controls.Add(this.btnEliminar);
            this.pnlContenedor.Controls.Add(this.btnLimpiar);
            this.pnlContenedor.Controls.Add(this.btnActualizar);
            this.pnlContenedor.Controls.Add(this.pnlMenu);
            this.pnlContenedor.Controls.Add(this.btnBuscar);
            this.pnlContenedor.Controls.Add(this.lblBuscarPorCodigo);
            this.pnlContenedor.Controls.Add(this.btnRegistrar);
            this.pnlContenedor.Controls.Add(this.txtBuscarPorCodigo);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 113);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1009, 599);
            this.pnlContenedor.TabIndex = 27;
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Gray;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReporte.Location = new System.Drawing.Point(807, 518);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(151, 40);
            this.btnReporte.TabIndex = 29;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(413, 518);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(151, 40);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Chocolate;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpiar.Location = new System.Drawing.Point(601, 518);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(151, 40);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Teal;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizar.Location = new System.Drawing.Point(219, 518);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(151, 40);
            this.btnActualizar.TabIndex = 26;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlMenu.Controls.Add(this.nudCuota);
            this.pnlMenu.Controls.Add(this.lblCuota);
            this.pnlMenu.Controls.Add(this.cmbTipo);
            this.pnlMenu.Controls.Add(this.cmbEstado);
            this.pnlMenu.Controls.Add(this.lblEstado);
            this.pnlMenu.Controls.Add(this.nudResidentes);
            this.pnlMenu.Controls.Add(this.lblResidentes);
            this.pnlMenu.Controls.Add(this.txtDireccion);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Controls.Add(this.cmbPropietario);
            this.pnlMenu.Controls.Add(this.nudArea);
            this.pnlMenu.Controls.Add(this.lblTipo);
            this.pnlMenu.Controls.Add(this.lblCodigo);
            this.pnlMenu.Controls.Add(this.lblPropietario);
            this.pnlMenu.Controls.Add(this.lblFoto);
            this.pnlMenu.Controls.Add(this.txtCodigo);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Location = new System.Drawing.Point(0, 73);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1009, 395);
            this.pnlMenu.TabIndex = 25;
            // 
            // nudCuota
            // 
            this.nudCuota.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCuota.Location = new System.Drawing.Point(219, 263);
            this.nudCuota.Name = "nudCuota";
            this.nudCuota.Size = new System.Drawing.Size(209, 23);
            this.nudCuota.TabIndex = 27;
            // 
            // lblCuota
            // 
            this.lblCuota.AutoSize = true;
            this.lblCuota.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuota.Location = new System.Drawing.Point(58, 265);
            this.lblCuota.Name = "lblCuota";
            this.lblCuota.Size = new System.Drawing.Size(143, 16);
            this.lblCuota.TabIndex = 26;
            this.lblCuota.Text = "Cuota de Mantenimiento:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(219, 324);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(209, 24);
            this.cmbTipo.TabIndex = 24;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(219, 363);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(209, 24);
            this.cmbEstado.TabIndex = 31;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(60, 366);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(107, 16);
            this.lblEstado.TabIndex = 32;
            this.lblEstado.Text = "Estado de Pago:";
            // 
            // nudResidentes
            // 
            this.nudResidentes.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudResidentes.Location = new System.Drawing.Point(219, 145);
            this.nudResidentes.Name = "nudResidentes";
            this.nudResidentes.Size = new System.Drawing.Size(209, 23);
            this.nudResidentes.TabIndex = 23;
            // 
            // lblResidentes
            // 
            this.lblResidentes.AutoSize = true;
            this.lblResidentes.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResidentes.Location = new System.Drawing.Point(58, 147);
            this.lblResidentes.Name = "lblResidentes";
            this.lblResidentes.Size = new System.Drawing.Size(133, 16);
            this.lblResidentes.TabIndex = 22;
            this.lblResidentes.Text = "Cantidad de Residentes:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(219, 89);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(209, 23);
            this.txtDireccion.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Dirección Exacta:";
            // 
            // cmbPropietario
            // 
            this.cmbPropietario.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPropietario.FormattingEnabled = true;
            this.cmbPropietario.Location = new System.Drawing.Point(625, 36);
            this.cmbPropietario.Name = "cmbPropietario";
            this.cmbPropietario.Size = new System.Drawing.Size(209, 24);
            this.cmbPropietario.TabIndex = 19;
            // 
            // nudArea
            // 
            this.nudArea.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudArea.Location = new System.Drawing.Point(219, 202);
            this.nudArea.Name = "nudArea";
            this.nudArea.Size = new System.Drawing.Size(209, 23);
            this.nudArea.TabIndex = 18;
            this.nudArea.ValueChanged += new System.EventHandler(this.nudArea_ValueChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(60, 327);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(107, 16);
            this.lblTipo.TabIndex = 11;
            this.lblTipo.Text = "Tipo de Propiedad:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(601, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(151, 35);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1009, 712);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.label4);
            this.Name = "FrmPropiedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPropiedad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPropiedad_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResidentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Label lblBuscarPorCodigo;
        private System.Windows.Forms.TextBox txtBuscarPorCodigo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbPropietario;
        private System.Windows.Forms.NumericUpDown nudArea;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.NumericUpDown nudResidentes;
        private System.Windows.Forms.Label lblResidentes;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCuota;
        private System.Windows.Forms.Label lblCuota;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnReporte;
    }
}