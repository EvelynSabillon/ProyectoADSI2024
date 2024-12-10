namespace ProyectoADSI2024
{
    partial class frmGestionConcentrado
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionConcentrado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxEstadoCompra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombeArticulo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.btnEditarCompraCon = new System.Windows.Forms.Button();
            this.btnEliminarCompraCon = new System.Windows.Forms.Button();
            this.dtpFehcaCompra = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dgGestionConcentrado = new System.Windows.Forms.DataGridView();
            this.btnLimpiarConcentradoCompara = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.PictureBox();
            this.epAgregar = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEditar = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEliminar = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCompraID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgarticuloscompra = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarVarios = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtconID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgGestionConcentrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgarticuloscompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(188, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(652, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTIÓN DE COMPRA DE CONCENTRADO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(648, 178);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(121, 25);
            this.txtDocumento.TabIndex = 5;
            this.txtDocumento.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Documento";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(494, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "Tipo";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Credito",
            "Contado"});
            this.cbxTipo.Location = new System.Drawing.Point(648, 222);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 25);
            this.cbxTipo.TabIndex = 13;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(495, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Estado de Compra";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbxEstadoCompra
            // 
            this.cbxEstadoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstadoCompra.FormattingEnabled = true;
            this.cbxEstadoCompra.Items.AddRange(new object[] {
            "Pagada",
            "Pendiente"});
            this.cbxEstadoCompra.Location = new System.Drawing.Point(648, 266);
            this.cbxEstadoCompra.Name = "cbxEstadoCompra";
            this.cbxEstadoCompra.Size = new System.Drawing.Size(121, 25);
            this.cbxEstadoCompra.TabIndex = 15;
            this.cbxEstadoCompra.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cantidad";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(203, 266);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 25);
            this.txtCantidad.TabIndex = 17;
            this.txtCantidad.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(495, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "Costo";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(648, 309);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(121, 25);
            this.txtCosto.TabIndex = 19;
            this.txtCosto.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 21;
            this.label9.Text = "Nombre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Codigo";
            // 
            // txtNombeArticulo
            // 
            this.txtNombeArticulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombeArticulo.Location = new System.Drawing.Point(125, 137);
            this.txtNombeArticulo.Name = "txtNombeArticulo";
            this.txtNombeArticulo.Size = new System.Drawing.Size(312, 25);
            this.txtNombeArticulo.TabIndex = 24;
            this.txtNombeArticulo.TextChanged += new System.EventHandler(this.txtNombeArticulo_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(125, 178);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(121, 25);
            this.txtCodigo.TabIndex = 25;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(316, 180);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(121, 25);
            this.txtPrecio.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(252, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 26;
            this.label11.Text = "Precio";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(32, 223);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 21);
            this.label12.TabIndex = 28;
            this.label12.Text = "FechaVencimiento";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(32, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 21);
            this.label13.TabIndex = 30;
            this.label13.Text = "Proveedor";
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProveedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(203, 309);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(234, 25);
            this.cbxProveedor.TabIndex = 31;
            // 
            // btnEditarCompraCon
            // 
            this.btnEditarCompraCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnEditarCompraCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCompraCon.FlatAppearance.BorderSize = 0;
            this.btnEditarCompraCon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnEditarCompraCon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnEditarCompraCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCompraCon.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCompraCon.ForeColor = System.Drawing.Color.White;
            this.btnEditarCompraCon.Location = new System.Drawing.Point(851, 199);
            this.btnEditarCompraCon.Name = "btnEditarCompraCon";
            this.btnEditarCompraCon.Size = new System.Drawing.Size(160, 38);
            this.btnEditarCompraCon.TabIndex = 33;
            this.btnEditarCompraCon.Text = "EDITAR";
            this.btnEditarCompraCon.UseVisualStyleBackColor = false;
            this.btnEditarCompraCon.Click += new System.EventHandler(this.btnEditarCompraCon_Click);
            // 
            // btnEliminarCompraCon
            // 
            this.btnEliminarCompraCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnEliminarCompraCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCompraCon.FlatAppearance.BorderSize = 0;
            this.btnEliminarCompraCon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnEliminarCompraCon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnEliminarCompraCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCompraCon.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCompraCon.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCompraCon.Location = new System.Drawing.Point(851, 307);
            this.btnEliminarCompraCon.Name = "btnEliminarCompraCon";
            this.btnEliminarCompraCon.Size = new System.Drawing.Size(160, 38);
            this.btnEliminarCompraCon.TabIndex = 34;
            this.btnEliminarCompraCon.Text = "ELIMINAR";
            this.btnEliminarCompraCon.UseVisualStyleBackColor = false;
            this.btnEliminarCompraCon.Click += new System.EventHandler(this.btnEliminarCompraCon_Click);
            // 
            // dtpFehcaCompra
            // 
            this.dtpFehcaCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFehcaCompra.Location = new System.Drawing.Point(569, 137);
            this.dtpFehcaCompra.Name = "dtpFehcaCompra";
            this.dtpFehcaCompra.Size = new System.Drawing.Size(200, 25);
            this.dtpFehcaCompra.TabIndex = 35;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(203, 222);
            this.dtpFechaVencimiento.MinDate = new System.DateTime(2024, 12, 10, 0, 0, 0, 0);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(234, 25);
            this.dtpFechaVencimiento.TabIndex = 37;
            this.dtpFechaVencimiento.ValueChanged += new System.EventHandler(this.dtpFechaVencimiento_ValueChanged);
            // 
            // dgGestionConcentrado
            // 
            this.dgGestionConcentrado.AllowUserToAddRows = false;
            this.dgGestionConcentrado.AllowUserToDeleteRows = false;
            this.dgGestionConcentrado.AllowUserToResizeColumns = false;
            this.dgGestionConcentrado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgGestionConcentrado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgGestionConcentrado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGestionConcentrado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgGestionConcentrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGestionConcentrado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgGestionConcentrado.Location = new System.Drawing.Point(23, 356);
            this.dgGestionConcentrado.MultiSelect = false;
            this.dgGestionConcentrado.Name = "dgGestionConcentrado";
            this.dgGestionConcentrado.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgGestionConcentrado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgGestionConcentrado.Size = new System.Drawing.Size(487, 223);
            this.dgGestionConcentrado.TabIndex = 79;
            this.dgGestionConcentrado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGestionConcentrado_CellDoubleClick);
            // 
            // btnLimpiarConcentradoCompara
            // 
            this.btnLimpiarConcentradoCompara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnLimpiarConcentradoCompara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarConcentradoCompara.FlatAppearance.BorderSize = 0;
            this.btnLimpiarConcentradoCompara.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnLimpiarConcentradoCompara.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnLimpiarConcentradoCompara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarConcentradoCompara.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarConcentradoCompara.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarConcentradoCompara.Location = new System.Drawing.Point(851, 253);
            this.btnLimpiarConcentradoCompara.Name = "btnLimpiarConcentradoCompara";
            this.btnLimpiarConcentradoCompara.Size = new System.Drawing.Size(160, 38);
            this.btnLimpiarConcentradoCompara.TabIndex = 80;
            this.btnLimpiarConcentradoCompara.Text = "LIMPIAR";
            this.btnLimpiarConcentradoCompara.UseVisualStyleBackColor = false;
            this.btnLimpiarConcentradoCompara.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.Location = new System.Drawing.Point(991, 17);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(55, 55);
            this.btnAtras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnAtras.TabIndex = 36;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // epAgregar
            // 
            this.epAgregar.ContainerControl = this;
            // 
            // epEditar
            // 
            this.epEditar.ContainerControl = this;
            // 
            // epEliminar
            // 
            this.epEliminar.ContainerControl = this;
            // 
            // txtCompraID
            // 
            this.txtCompraID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompraID.Location = new System.Drawing.Point(125, 97);
            this.txtCompraID.Name = "txtCompraID";
            this.txtCompraID.ReadOnly = true;
            this.txtCompraID.Size = new System.Drawing.Size(121, 25);
            this.txtCompraID.TabIndex = 81;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(32, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 21);
            this.label14.TabIndex = 82;
            this.label14.Text = "CompraID";
            // 
            // dgarticuloscompra
            // 
            this.dgarticuloscompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgarticuloscompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Codigo,
            this.Precio,
            this.Cantidad,
            this.Proveedor,
            this.Documento,
            this.Tipo,
            this.EstadoCompra,
            this.Costo,
            this.FechaCompra,
            this.FechaVencimiento});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgarticuloscompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgarticuloscompra.Location = new System.Drawing.Point(529, 356);
            this.dgarticuloscompra.Name = "dgarticuloscompra";
            this.dgarticuloscompra.Size = new System.Drawing.Size(482, 223);
            this.dgarticuloscompra.TabIndex = 83;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // EstadoCompra
            // 
            this.EstadoCompra.HeaderText = "EstadoCompra";
            this.EstadoCompra.Name = "EstadoCompra";
            // 
            // Costo
            // 
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            // 
            // FechaCompra
            // 
            this.FechaCompra.HeaderText = "FechaCompra";
            this.FechaCompra.Name = "FechaCompra";
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "FechaVencimiento";
            this.FechaVencimiento.Name = "FechaVencimiento";
            // 
            // btnAgregarVarios
            // 
            this.btnAgregarVarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnAgregarVarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarVarios.FlatAppearance.BorderSize = 0;
            this.btnAgregarVarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnAgregarVarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnAgregarVarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVarios.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarVarios.ForeColor = System.Drawing.Color.White;
            this.btnAgregarVarios.Location = new System.Drawing.Point(851, 145);
            this.btnAgregarVarios.Name = "btnAgregarVarios";
            this.btnAgregarVarios.Size = new System.Drawing.Size(160, 38);
            this.btnAgregarVarios.TabIndex = 84;
            this.btnAgregarVarios.Text = "AGREGAR";
            this.btnAgregarVarios.UseVisualStyleBackColor = false;
            this.btnAgregarVarios.Click += new System.EventHandler(this.btnAgregarVarios_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnComprar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprar.FlatAppearance.BorderSize = 0;
            this.btnComprar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnComprar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprar.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.ForeColor = System.Drawing.Color.White;
            this.btnComprar.Location = new System.Drawing.Point(851, 93);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(160, 38);
            this.btnComprar.TabIndex = 85;
            this.btnComprar.Text = "COMPRAR";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(494, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 21);
            this.label15.TabIndex = 87;
            this.label15.Text = "Concen. ID";
            // 
            // txtconID
            // 
            this.txtconID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconID.Location = new System.Drawing.Point(648, 98);
            this.txtconID.Name = "txtconID";
            this.txtconID.ReadOnly = true;
            this.txtconID.Size = new System.Drawing.Size(121, 25);
            this.txtconID.TabIndex = 86;
            // 
            // frmGestionConcentrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 595);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtconID);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.btnAgregarVarios);
            this.Controls.Add(this.dgarticuloscompra);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCompraID);
            this.Controls.Add(this.btnLimpiarConcentradoCompara);
            this.Controls.Add(this.dgGestionConcentrado);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dtpFehcaCompra);
            this.Controls.Add(this.btnEliminarCompraCon);
            this.Controls.Add(this.btnEditarCompraCon);
            this.Controls.Add(this.cbxProveedor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtNombeArticulo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxEstadoCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionConcentrado";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmGestionConcentrado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGestionConcentrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgarticuloscompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxEstadoCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombeArticulo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.Button btnEditarCompraCon;
        private System.Windows.Forms.Button btnEliminarCompraCon;
        private System.Windows.Forms.DateTimePicker dtpFehcaCompra;
        private System.Windows.Forms.PictureBox btnAtras;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.DataGridView dgGestionConcentrado;
        private System.Windows.Forms.Button btnLimpiarConcentradoCompara;
        private System.Windows.Forms.ErrorProvider epAgregar;
        private System.Windows.Forms.ErrorProvider epEditar;
        private System.Windows.Forms.ErrorProvider epEliminar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCompraID;
        private System.Windows.Forms.DataGridView dgarticuloscompra;
        private System.Windows.Forms.Button btnAgregarVarios;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtconID;
    }
}