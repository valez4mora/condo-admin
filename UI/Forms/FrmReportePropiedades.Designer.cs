namespace UI.Forms
{
    partial class FrmReportePropiedades
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.ComboBox cmbPropietario;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Panel pnlAlDia;
        private System.Windows.Forms.Label lblAlDiaTitulo;
        private System.Windows.Forms.Label lblAlDiaValor;
        private System.Windows.Forms.Panel pnlMorosas;
        private System.Windows.Forms.Label lblMorosasTitulo;
        private System.Windows.Forms.Label lblMorosasValor;
        private System.Windows.Forms.Panel pnlCuotas;
        private System.Windows.Forms.Label lblCuotasTitulo;
        private System.Windows.Forms.Label lblCuotasValor;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvPropiedades;
        private System.Windows.Forms.Panel pnlSinDatos;
        private System.Windows.Forms.Label lblSinDatosTitulo;
        private System.Windows.Forms.Label lblSinDatosDetalle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle encabezado = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle celda = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alterna = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatosTitulo = new System.Windows.Forms.Label();
            this.lblSinDatosDetalle = new System.Windows.Forms.Label();
            this.dgvPropiedades = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.pnlAlDia = new System.Windows.Forms.Panel();
            this.lblAlDiaTitulo = new System.Windows.Forms.Label();
            this.lblAlDiaValor = new System.Windows.Forms.Label();
            this.pnlMorosas = new System.Windows.Forms.Panel();
            this.lblMorosasTitulo = new System.Windows.Forms.Label();
            this.lblMorosasValor = new System.Windows.Forms.Label();
            this.pnlCuotas = new System.Windows.Forms.Panel();
            this.lblCuotasTitulo = new System.Windows.Forms.Label();
            this.lblCuotasValor = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.cmbPropietario = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            this.tlpResumen.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlAlDia.SuspendLayout();
            this.pnlMorosas.SuspendLayout();
            this.pnlCuotas.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();

            // pnlEncabezado
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.btnCerrar);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1220, 106);
            this.pnlEncabezado.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(355, 41);
            this.lblTitulo.Text = "Reporte de propiedades";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(205, 221, 238);
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 63);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(574, 19);
            this.lblSubtitulo.Text = "Consulta de propiedades, propietarios, cuotas de mantenimiento y estado financiero";

            // lblActualizado
            this.lblActualizado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblActualizado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(205, 221, 238);
            this.lblActualizado.Location = new System.Drawing.Point(850, 67);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(305, 20);
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnCerrar
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1165, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.Text = "×";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // pnlContenido
            this.pnlContenido.AutoScroll = true;
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.pnlContenido.Controls.Add(this.pnlTabla);
            this.pnlContenido.Controls.Add(this.tlpResumen);
            this.pnlContenido.Controls.Add(this.grpFiltros);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 106);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContenido.Size = new System.Drawing.Size(1220, 614);
            this.pnlContenido.TabIndex = 1;

            // grpFiltros
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.lblPropietario);
            this.grpFiltros.Controls.Add(this.cmbPropietario);
            this.grpFiltros.Controls.Add(this.lblBuscar);
            this.grpFiltros.Controls.Add(this.txtBuscar);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnActualizar);
            this.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.grpFiltros.Location = new System.Drawing.Point(24, 24);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.grpFiltros.Size = new System.Drawing.Size(1172, 103);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros del reporte";

            // lblPropietario
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropietario.Location = new System.Drawing.Point(20, 29);
            this.lblPropietario.Text = "Propietario";

            // cmbPropietario
            this.cmbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropietario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPropietario.FormattingEnabled = true;
            this.cmbPropietario.Location = new System.Drawing.Point(23, 52);
            this.cmbPropietario.Name = "cmbPropietario";
            this.cmbPropietario.Size = new System.Drawing.Size(300, 25);
            this.cmbPropietario.TabIndex = 0;

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(345, 29);
            this.lblBuscar.Text = "Búsqueda rápida";

            // txtBuscar
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(348, 52);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(270, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // btnFiltrar
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(642, 45);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(120, 35);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Aplicar filtro";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // btnLimpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(773, 45);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 35);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // btnActualizar
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnActualizar.Location = new System.Drawing.Point(1027, 45);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 35);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // tlpResumen
            this.tlpResumen.ColumnCount = 4;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.Controls.Add(this.pnlTotal, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlAlDia, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlMorosas, 2, 0);
            this.tlpResumen.Controls.Add(this.pnlCuotas, 3, 0);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpResumen.Location = new System.Drawing.Point(24, 127);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1172, 108);

            // pnlTabla
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Controls.Add(this.pnlSinDatos);
            this.pnlTabla.Controls.Add(this.dgvPropiedades);
            this.pnlTabla.Controls.Add(this.lblResultado);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(24, 235);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(14);
            this.pnlTabla.Size = new System.Drawing.Size(1172, 355);

            // lblResultado
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblResultado.Location = new System.Drawing.Point(14, 14);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Padding = new System.Windows.Forms.Padding(2, 0, 0, 8);
            this.lblResultado.Size = new System.Drawing.Size(1144, 32);
            this.lblResultado.Text = "Cargando información...";

            // dgvPropiedades
            this.dgvPropiedades.AllowUserToAddRows = false;
            this.dgvPropiedades.AllowUserToDeleteRows = false;
            this.dgvPropiedades.AllowUserToResizeRows = false;
            this.dgvPropiedades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvPropiedades.BackgroundColor = System.Drawing.Color.White;
            this.dgvPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            encabezado.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            encabezado.BackColor = System.Drawing.Color.FromArgb(31, 73, 113);
            encabezado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            encabezado.ForeColor = System.Drawing.Color.White;
            encabezado.Padding = new System.Windows.Forms.Padding(4);
            encabezado.SelectionBackColor = System.Drawing.Color.FromArgb(31, 73, 113);
            encabezado.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPropiedades.ColumnHeadersDefaultCellStyle = encabezado;
            this.dgvPropiedades.ColumnHeadersHeight = 42;
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            celda.BackColor = System.Drawing.Color.White;
            celda.Font = new System.Drawing.Font("Segoe UI", 9F);
            celda.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            celda.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            celda.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            celda.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.dgvPropiedades.DefaultCellStyle = celda;
            alterna.BackColor = System.Drawing.Color.FromArgb(247, 250, 252);
            this.dgvPropiedades.AlternatingRowsDefaultCellStyle = alterna;
            this.dgvPropiedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPropiedades.EnableHeadersVisualStyles = false;
            this.dgvPropiedades.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvPropiedades.Location = new System.Drawing.Point(14, 46);
            this.dgvPropiedades.MultiSelect = false;
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.ReadOnly = true;
            this.dgvPropiedades.RowHeadersVisible = false;
            this.dgvPropiedades.RowTemplate.Height = 34;
            this.dgvPropiedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropiedades.Size = new System.Drawing.Size(1144, 295);
            this.dgvPropiedades.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPropiedades_CellFormatting);

            // pnlSinDatos
            this.pnlSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Location = new System.Drawing.Point(376, 140);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(420, 105);
            this.pnlSinDatos.Visible = false;

            this.lblSinDatosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblSinDatosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(420, 45);
            this.lblSinDatosTitulo.Text = "No se encontraron propiedades";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;

            this.lblSinDatosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatosDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSinDatosDetalle.Location = new System.Drawing.Point(0, 45);
            this.lblSinDatosDetalle.Size = new System.Drawing.Size(420, 60);
            this.lblSinDatosDetalle.Text = "Cambie los filtros o verifique que existan registros.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // FrmReportePropiedades
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.ClientSize = new System.Drawing.Size(1220, 720);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1050, 650);
            this.Name = "FrmReportePropiedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de propiedades";
            this.Load += new System.EventHandler(this.FrmReportePropiedades_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
            this.tlpResumen.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlAlDia.ResumeLayout(false);
            this.pnlMorosas.ResumeLayout(false);
            this.pnlCuotas.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
        }

    }
}
