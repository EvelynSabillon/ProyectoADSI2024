namespace ProyectoADSI2024
{
    partial class frmGestionMedicamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionMedicamento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.PictureBox();
            this.dgIngresoLeche = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombeArticulo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEstadoCompra = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarCompraCon = new System.Windows.Forms.Button();
            this.btnEditarCompraCon = new System.Windows.Forms.Button();
            this.btnAgregarCompraCon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgIngresoLeche)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(317, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTIÓN DE MEDICAMENTOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(470, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "COMPRA";
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
            this.btnAtras.TabIndex = 37;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // dgIngresoLeche
            // 
            this.dgIngresoLeche.AllowUserToAddRows = false;
            this.dgIngresoLeche.AllowUserToDeleteRows = false;
            this.dgIngresoLeche.AllowUserToResizeColumns = false;
            this.dgIngresoLeche.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgIngresoLeche.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgIngresoLeche.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgIngresoLeche.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgIngresoLeche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgIngresoLeche.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgIngresoLeche.Location = new System.Drawing.Point(23, 360);
            this.dgIngresoLeche.MultiSelect = false;
            this.dgIngresoLeche.Name = "dgIngresoLeche";
            this.dgIngresoLeche.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgIngresoLeche.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgIngresoLeche.Size = new System.Drawing.Size(1023, 223);
            this.dgIngresoLeche.TabIndex = 105;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(203, 226);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(234, 25);
            this.dateTimePicker1.TabIndex = 104;
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCompra.Location = new System.Drawing.Point(569, 141);
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(200, 25);
            this.txtFechaCompra.TabIndex = 103;
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProveedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(203, 313);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(234, 25);
            this.cbxProveedor.TabIndex = 99;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(46, 313);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 21);
            this.label13.TabIndex = 98;
            this.label13.Text = "Proveedor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(46, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 21);
            this.label12.TabIndex = 97;
            this.label12.Text = "FechaVencimiento";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(316, 184);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(121, 25);
            this.txtPrecio.TabIndex = 96;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(252, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 95;
            this.label11.Text = "Precio";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(125, 182);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(121, 25);
            this.txtCodigo.TabIndex = 94;
            // 
            // txtNombeArticulo
            // 
            this.txtNombeArticulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombeArticulo.Location = new System.Drawing.Point(125, 141);
            this.txtNombeArticulo.Name = "txtNombeArticulo";
            this.txtNombeArticulo.Size = new System.Drawing.Size(312, 25);
            this.txtNombeArticulo.TabIndex = 93;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 21);
            this.label10.TabIndex = 92;
            this.label10.Text = "Codigo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 91;
            this.label9.Text = "Nombre";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(648, 313);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(121, 25);
            this.txtCosto.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(495, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 21);
            this.label7.TabIndex = 89;
            this.label7.Text = "Costo";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(203, 270);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 25);
            this.txtCantidad.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 21);
            this.label6.TabIndex = 87;
            this.label6.Text = "Cantidad";
            // 
            // cbxEstadoCompra
            // 
            this.cbxEstadoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstadoCompra.FormattingEnabled = true;
            this.cbxEstadoCompra.Items.AddRange(new object[] {
            "Pagada",
            "Por pagar"});
            this.cbxEstadoCompra.Location = new System.Drawing.Point(648, 270);
            this.cbxEstadoCompra.Name = "cbxEstadoCompra";
            this.cbxEstadoCompra.Size = new System.Drawing.Size(121, 25);
            this.cbxEstadoCompra.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(495, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 21);
            this.label5.TabIndex = 85;
            this.label5.Text = "Estado de Compra";
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Mantenimiento",
            "Lechera",
            "18% Lechera",
            "Churro"});
            this.cbxTipo.Location = new System.Drawing.Point(648, 226);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 25);
            this.cbxTipo.TabIndex = 84;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(494, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 21);
            this.label8.TabIndex = 83;
            this.label8.Text = "Tipo";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(648, 182);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(121, 25);
            this.txtDocumento.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 81;
            this.label4.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 80;
            this.label3.Text = "Fecha";
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
            this.btnEliminarCompraCon.Location = new System.Drawing.Point(851, 300);
            this.btnEliminarCompraCon.Name = "btnEliminarCompraCon";
            this.btnEliminarCompraCon.Size = new System.Drawing.Size(160, 38);
            this.btnEliminarCompraCon.TabIndex = 102;
            this.btnEliminarCompraCon.Text = "ELIMINAR";
            this.btnEliminarCompraCon.UseVisualStyleBackColor = false;
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
            this.btnEditarCompraCon.Location = new System.Drawing.Point(851, 194);
            this.btnEditarCompraCon.Name = "btnEditarCompraCon";
            this.btnEditarCompraCon.Size = new System.Drawing.Size(160, 38);
            this.btnEditarCompraCon.TabIndex = 101;
            this.btnEditarCompraCon.Text = "EDITAR";
            this.btnEditarCompraCon.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCompraCon
            // 
            this.btnAgregarCompraCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnAgregarCompraCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCompraCon.FlatAppearance.BorderSize = 0;
            this.btnAgregarCompraCon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnAgregarCompraCon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnAgregarCompraCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCompraCon.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCompraCon.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCompraCon.Location = new System.Drawing.Point(851, 141);
            this.btnAgregarCompraCon.Name = "btnAgregarCompraCon";
            this.btnAgregarCompraCon.Size = new System.Drawing.Size(160, 38);
            this.btnAgregarCompraCon.TabIndex = 100;
            this.btnAgregarCompraCon.Text = "AGREGAR";
            this.btnAgregarCompraCon.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(851, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 38);
            this.button1.TabIndex = 106;
            this.button1.Text = "LIMPIAR";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmGestionMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgIngresoLeche);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.btnEliminarCompraCon);
            this.Controls.Add(this.btnEditarCompraCon);
            this.Controls.Add(this.btnAgregarCompraCon);
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
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionMedicamento";
            this.Text = "frmGestionMedicamento";
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgIngresoLeche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnAtras;
        private System.Windows.Forms.DataGridView dgIngresoLeche;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker txtFechaCompra;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombeArticulo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEstadoCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarCompraCon;
        private System.Windows.Forms.Button btnEditarCompraCon;
        private System.Windows.Forms.Button btnAgregarCompraCon;
        private System.Windows.Forms.Button button1;
    }
}