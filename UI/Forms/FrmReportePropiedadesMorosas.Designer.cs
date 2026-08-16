namespace UI.Forms
{
    partial class FrmReportePropiedadesMorosas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblRiesgo;
        private System.Windows.Forms.ComboBox cmbRiesgo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Panel pnlMorosas;
        private System.Windows.Forms.Label lblMorosasTitulo;
        private System.Windows.Forms.Label lblMorosasValor;
        private System.Windows.Forms.Panel pnlDeuda;
        private System.Windows.Forms.Label lblDeudaTitulo;
        private System.Windows.Forms.Label lblDeudaValor;
        private System.Windows.Forms.Panel pnlCargos;
        private System.Windows.Forms.Label lblCargosTitulo;
        private System.Windows.Forms.Label lblCargosValor;
        private System.Windows.Forms.Panel pnlCritico;
        private System.Windows.Forms.Label lblCriticoTitulo;
        private System.Windows.Forms.Label lblCriticoValor;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvMorosas;
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvMorosas = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMorosas = new System.Windows.Forms.Panel();
            this.lblMorosasTitulo = new System.Windows.Forms.Label();
            this.lblMorosasValor = new System.Windows.Forms.Label();
            this.pnlDeuda = new System.Windows.Forms.Panel();
            this.lblDeudaTitulo = new System.Windows.Forms.Label();
            this.lblDeudaValor = new System.Windows.Forms.Label();
            this.pnlCargos = new System.Windows.Forms.Panel();
            this.lblCargosTitulo = new System.Windows.Forms.Label();
            this.lblCargosValor = new System.Windows.Forms.Label();
            this.pnlCritico = new System.Windows.Forms.Panel();
            this.lblCriticoTitulo = new System.Windows.Forms.Label();
            this.lblCriticoValor = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblRiesgo = new System.Windows.Forms.Label();
            this.cmbRiesgo = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorosas)).BeginInit();
            this.tlpResumen.SuspendLayout();
            this.pnlMorosas.SuspendLayout();
            this.pnlDeuda.SuspendLayout();
            this.pnlCargos.SuspendLayout();
            this.pnlCritico.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();

            // Encabezado
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(109, 40, 40);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.btnCerrar);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Size = new System.Drawing.Size(1240, 106);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 16);
            this.lblTitulo.Text = "Propiedades morosas";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(254, 226, 226);
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 63);
            this.lblSubtitulo.Text = "Cargos vencidos, deuda acumulada, último pago y nivel de riesgo financiero";

            this.lblActualizado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblActualizado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(254, 226, 226);
            this.lblActualizado.Location = new System.Drawing.Point(875, 67);
            this.lblActualizado.Size = new System.Drawing.Size(305, 20);
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(109, 40, 40);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1185, 12);
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.Text = "×";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // Contenido
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(248, 247, 247);
            this.pnlContenido.Controls.Add(this.pnlTabla);
            this.pnlContenido.Controls.Add(this.tlpResumen);
            this.pnlContenido.Controls.Add(this.grpFiltros);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(24);

            // Filtros
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.lblBuscar);
            this.grpFiltros.Controls.Add(this.txtBuscar);
            this.grpFiltros.Controls.Add(this.lblRiesgo);
            this.grpFiltros.Controls.Add(this.cmbRiesgo);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnActualizar);
            this.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.grpFiltros.Size = new System.Drawing.Size(1192, 103);
            this.grpFiltros.Text = "Consulta y filtros";

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 29);
            this.lblBuscar.Text = "Buscar propiedad o propietario";

            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(23, 52);
            this.txtBuscar.Size = new System.Drawing.Size(330, 24);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.lblRiesgo.AutoSize = true;
            this.lblRiesgo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRiesgo.Location = new System.Drawing.Point(378, 29);
            this.lblRiesgo.Text = "Nivel de riesgo";

            this.cmbRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRiesgo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRiesgo.Location = new System.Drawing.Point(381, 52);
            this.cmbRiesgo.Size = new System.Drawing.Size(205, 25);
            this.cmbRiesgo.TabIndex = 1;
            this.cmbRiesgo.SelectedIndexChanged += new System.EventHandler(this.cmbRiesgo_SelectedIndexChanged);

            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(610, 45);
            this.btnLimpiar.Size = new System.Drawing.Size(110, 35);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(1047, 45);
            this.btnActualizar.Size = new System.Drawing.Size(120, 35);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // Tarjetas
            this.tlpResumen.ColumnCount = 4;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.Controls.Add(this.pnlMorosas, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlDeuda, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlCargos, 2, 0);
            this.tlpResumen.Controls.Add(this.pnlCritico, 3, 0);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpResumen.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1192, 108);

            this.pnlMorosas.Controls.Add(this.lblMorosasValor);
            this.pnlMorosas.Controls.Add(this.lblMorosasTitulo);
            this.pnlDeuda.Controls.Add(this.lblDeudaValor);
            this.pnlDeuda.Controls.Add(this.lblDeudaTitulo);
            this.pnlCargos.Controls.Add(this.lblCargosValor);
            this.pnlCargos.Controls.Add(this.lblCargosTitulo);
            this.pnlCritico.Controls.Add(this.lblCriticoValor);
            this.pnlCritico.Controls.Add(this.lblCriticoTitulo);

            // Tabla
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Controls.Add(this.pnlSinDatos);
            this.pnlTabla.Controls.Add(this.dgvMorosas);
            this.pnlTabla.Controls.Add(this.lblResultado);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(14);

            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblResultado.Padding = new System.Windows.Forms.Padding(2, 0, 0, 8);
            this.lblResultado.Size = new System.Drawing.Size(1164, 32);
            this.lblResultado.Text = "Cargando información financiera...";

            this.dgvMorosas.AllowUserToAddRows = false;
            this.dgvMorosas.AllowUserToDeleteRows = false;
            this.dgvMorosas.AllowUserToResizeRows = false;
            this.dgvMorosas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMorosas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(127, 29, 29);
            headerStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(4);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(127, 29, 29);
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMorosas.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvMorosas.ColumnHeadersHeight = 44;
            this.dgvMorosas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            cellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(69, 10, 10);
            this.dgvMorosas.DefaultCellStyle = cellStyle;
            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(254, 250, 250);
            this.dgvMorosas.AlternatingRowsDefaultCellStyle = alternatingStyle;
            this.dgvMorosas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMorosas.EnableHeadersVisualStyles = false;
            this.dgvMorosas.GridColor = System.Drawing.Color.FromArgb(231, 229, 228);
            this.dgvMorosas.MultiSelect = false;
            this.dgvMorosas.ReadOnly = true;
            this.dgvMorosas.RowHeadersVisible = false;
            this.dgvMorosas.RowTemplate.Height = 35;
            this.dgvMorosas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMorosas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMorosas_CellFormatting);

            // Sin datos
            this.pnlSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Location = new System.Drawing.Point(386, 145);
            this.pnlSinDatos.Size = new System.Drawing.Size(420, 105);
            this.pnlSinDatos.Visible = false;

            this.lblSinDatosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(420, 45);
            this.lblSinDatosTitulo.Text = "No hay propiedades morosas";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;

            this.lblSinDatosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatosDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSinDatosDetalle.Text = "No existen cargos vencidos para los filtros seleccionados.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 247, 247);
            this.ClientSize = new System.Drawing.Size(1240, 730);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1080, 660);
            this.Name = "FrmReportePropiedadesMorosas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de propiedades morosas";
            this.Load += new System.EventHandler(this.FrmReportePropiedadesMorosas_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorosas)).EndInit();
            this.tlpResumen.ResumeLayout(false);
            this.pnlMorosas.ResumeLayout(false);
            this.pnlDeuda.ResumeLayout(false);
            this.pnlCargos.ResumeLayout(false);
            this.pnlCritico.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
