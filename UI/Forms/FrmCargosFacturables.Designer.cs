namespace UI.Forms
{
    partial class FrmCargosFacturables
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvCargos          = new System.Windows.Forms.DataGridView();
            this.grpFormulario      = new System.Windows.Forms.GroupBox();
            this.lblDescripcion     = new System.Windows.Forms.Label();
            this.txtDescripcion     = new System.Windows.Forms.TextBox();
            this.lblTipo            = new System.Windows.Forms.Label();
            this.cmbTipo            = new System.Windows.Forms.ComboBox();
            this.lblPropiedad       = new System.Windows.Forms.Label();
            this.cmbPropiedad       = new System.Windows.Forms.ComboBox();
            this.lblMontoBase       = new System.Windows.Forms.Label();
            this.txtMontoBase       = new System.Windows.Forms.TextBox();
            this.lblEmision         = new System.Windows.Forms.Label();
            this.dtpEmision         = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento     = new System.Windows.Forms.Label();
            this.dtpVencimiento     = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar         = new System.Windows.Forms.Button();
            this.btnCancelar        = new System.Windows.Forms.Button();
            this.btnNuevo           = new System.Windows.Forms.Button();
            this.btnEditar          = new System.Windows.Forms.Button();
            this.btnEliminar        = new System.Windows.Forms.Button();
            this.btnMarcarPagado    = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.grpFormulario.SuspendLayout();
            this.SuspendLayout();

            // dgvCargos
            this.dgvCargos.Location = new System.Drawing.Point(12, 12);
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.Size = new System.Drawing.Size(960, 240);
            this.dgvCargos.ReadOnly = true;
            this.dgvCargos.AllowUserToAddRows = false;
            this.dgvCargos.MultiSelect = false;
            this.dgvCargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargos.SelectionChanged += new System.EventHandler(this.dgvCargos_SelectionChanged);

            // Botones de acción (encima del formulario)
            this.btnNuevo.Location  = new System.Drawing.Point(12, 260);  this.btnNuevo.Size  = new System.Drawing.Size(90, 28); this.btnNuevo.Text  = "Nuevo";  this.btnNuevo.BackColor  = System.Drawing.Color.SeaGreen; this.btnNuevo.ForeColor = System.Drawing.Color.White; this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnEditar.Location = new System.Drawing.Point(110, 260); this.btnEditar.Size = new System.Drawing.Size(90, 28); this.btnEditar.Text = "Editar";  this.btnEditar.BackColor = System.Drawing.Color.SteelBlue; this.btnEditar.ForeColor = System.Drawing.Color.White; this.btnEditar.Enabled = false; this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEliminar.Location = new System.Drawing.Point(208, 260); this.btnEliminar.Size = new System.Drawing.Size(90, 28); this.btnEliminar.Text = "Eliminar"; this.btnEliminar.BackColor = System.Drawing.Color.Tomato; this.btnEliminar.ForeColor = System.Drawing.Color.White; this.btnEliminar.Enabled = false; this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnMarcarPagado.Location = new System.Drawing.Point(306, 260); this.btnMarcarPagado.Size = new System.Drawing.Size(110, 28); this.btnMarcarPagado.Text = "Marcar Pagado"; this.btnMarcarPagado.BackColor = System.Drawing.Color.DarkOrange; this.btnMarcarPagado.ForeColor = System.Drawing.Color.White; this.btnMarcarPagado.Enabled = false; this.btnMarcarPagado.Click += new System.EventHandler(this.btnMarcarPagado_Click);

            // grpFormulario
            this.grpFormulario.Controls.Add(this.lblDescripcion);
            this.grpFormulario.Controls.Add(this.txtDescripcion);
            this.grpFormulario.Controls.Add(this.lblTipo);
            this.grpFormulario.Controls.Add(this.cmbTipo);
            this.grpFormulario.Controls.Add(this.lblPropiedad);
            this.grpFormulario.Controls.Add(this.cmbPropiedad);
            this.grpFormulario.Controls.Add(this.lblMontoBase);
            this.grpFormulario.Controls.Add(this.txtMontoBase);
            this.grpFormulario.Controls.Add(this.lblEmision);
            this.grpFormulario.Controls.Add(this.dtpEmision);
            this.grpFormulario.Controls.Add(this.lblVencimiento);
            this.grpFormulario.Controls.Add(this.dtpVencimiento);
            this.grpFormulario.Controls.Add(this.btnGuardar);
            this.grpFormulario.Controls.Add(this.btnCancelar);
            this.grpFormulario.Location = new System.Drawing.Point(12, 297);
            this.grpFormulario.Size = new System.Drawing.Size(960, 200);
            this.grpFormulario.Text = "Datos del cargo";
            this.grpFormulario.Enabled = false;

            // Fila 1
            this.lblDescripcion.Location = new System.Drawing.Point(10, 30);  this.lblDescripcion.Text = "Descripción:"; this.lblDescripcion.Size = new System.Drawing.Size(75, 20);
            this.txtDescripcion.Location = new System.Drawing.Point(90, 27);  this.txtDescripcion.Size = new System.Drawing.Size(350, 22);

            this.lblTipo.Location = new System.Drawing.Point(455, 30); this.lblTipo.Text = "Tipo:"; this.lblTipo.Size = new System.Drawing.Size(40, 20);
            this.cmbTipo.Location = new System.Drawing.Point(500, 27); this.cmbTipo.Size = new System.Drawing.Size(200, 22); this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Fila 2
            this.lblPropiedad.Location = new System.Drawing.Point(10, 65);  this.lblPropiedad.Text = "Propiedad:"; this.lblPropiedad.Size = new System.Drawing.Size(75, 20);
            this.cmbPropiedad.Location = new System.Drawing.Point(90, 62);  this.cmbPropiedad.Size = new System.Drawing.Size(200, 22); this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblMontoBase.Location = new System.Drawing.Point(305, 65); this.lblMontoBase.Text = "Monto base (₡):"; this.lblMontoBase.Size = new System.Drawing.Size(100, 20);
            this.txtMontoBase.Location = new System.Drawing.Point(410, 62);  this.txtMontoBase.Size = new System.Drawing.Size(120, 22);

            // Fila 3
            this.lblEmision.Location = new System.Drawing.Point(10, 100);    this.lblEmision.Text = "Fecha emisión:"; this.lblEmision.Size = new System.Drawing.Size(90, 20);
            this.dtpEmision.Location = new System.Drawing.Point(105, 97);    this.dtpEmision.Size = new System.Drawing.Size(140, 22); this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblVencimiento.Location = new System.Drawing.Point(260, 100); this.lblVencimiento.Text = "Fecha vencimiento:"; this.lblVencimiento.Size = new System.Drawing.Size(115, 20);
            this.dtpVencimiento.Location = new System.Drawing.Point(380, 97); this.dtpVencimiento.Size = new System.Drawing.Size(140, 22); this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Botones formulario
            this.btnGuardar.Location  = new System.Drawing.Point(10,  155); this.btnGuardar.Size = new System.Drawing.Size(100, 30); this.btnGuardar.Text = "Guardar";  this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen; this.btnGuardar.ForeColor = System.Drawing.Color.White; this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Location = new System.Drawing.Point(120, 155); this.btnCancelar.Size = new System.Drawing.Size(100, 30); this.btnCancelar.Text = "Cancelar"; this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FrmCargosFacturables
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 510);
            this.Controls.Add(this.dgvCargos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnMarcarPagado);
            this.Controls.Add(this.grpFormulario);
            this.Name = "FrmCargosFacturables";
            this.Text = "Cargos Facturables — Multas / Cuotas Extraordinarias / Reservas";
            this.Load += new System.EventHandler(this.FrmCargosFacturables_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.grpFormulario.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView   dgvCargos;
        private System.Windows.Forms.GroupBox       grpFormulario;
        private System.Windows.Forms.Label          lblDescripcion;
        private System.Windows.Forms.TextBox        txtDescripcion;
        private System.Windows.Forms.Label          lblTipo;
        private System.Windows.Forms.ComboBox       cmbTipo;
        private System.Windows.Forms.Label          lblPropiedad;
        private System.Windows.Forms.ComboBox       cmbPropiedad;
        private System.Windows.Forms.Label          lblMontoBase;
        private System.Windows.Forms.TextBox        txtMontoBase;
        private System.Windows.Forms.Label          lblEmision;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label          lblVencimiento;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Button         btnGuardar;
        private System.Windows.Forms.Button         btnCancelar;
        private System.Windows.Forms.Button         btnNuevo;
        private System.Windows.Forms.Button         btnEditar;
        private System.Windows.Forms.Button         btnEliminar;
        private System.Windows.Forms.Button         btnMarcarPagado;
    }
}
