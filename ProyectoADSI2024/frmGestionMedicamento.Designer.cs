﻿namespace ProyectoADSI2024
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.PictureBox();
            this.dgGestionMedCompra = new System.Windows.Forms.DataGridView();
            this.dtpFechaVenMed = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaCompraMed = new System.Windows.Forms.DateTimePicker();
            this.cbxProveedorMed = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecioMed = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigoMed = new System.Windows.Forms.TextBox();
            this.txtNombeArticuloMed = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCostoMed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidadMed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEstadoCompraMed = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxTipoMed = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDocumentoMed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarCompraMed = new System.Windows.Forms.Button();
            this.btnEditarCompraCon = new System.Windows.Forms.Button();
            this.btnAgregarCompraMed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGestionMedCompra)).BeginInit();
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
            // dgGestionMedCompra
            // 
            this.dgGestionMedCompra.AllowUserToAddRows = false;
            this.dgGestionMedCompra.AllowUserToDeleteRows = false;
            this.dgGestionMedCompra.AllowUserToResizeColumns = false;
            this.dgGestionMedCompra.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgGestionMedCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgGestionMedCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgGestionMedCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgGestionMedCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGestionMedCompra.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgGestionMedCompra.Location = new System.Drawing.Point(23, 360);
            this.dgGestionMedCompra.MultiSelect = false;
            this.dgGestionMedCompra.Name = "dgGestionMedCompra";
            this.dgGestionMedCompra.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgGestionMedCompra.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgGestionMedCompra.Size = new System.Drawing.Size(1023, 223);
            this.dgGestionMedCompra.TabIndex = 105;
            // 
            // dtpFechaVenMed
            // 
            this.dtpFechaVenMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVenMed.Location = new System.Drawing.Point(203, 226);
            this.dtpFechaVenMed.Name = "dtpFechaVenMed";
            this.dtpFechaVenMed.Size = new System.Drawing.Size(234, 25);
            this.dtpFechaVenMed.TabIndex = 104;
            // 
            // dtpFechaCompraMed
            // 
            this.dtpFechaCompraMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCompraMed.Location = new System.Drawing.Point(569, 141);
            this.dtpFechaCompraMed.Name = "dtpFechaCompraMed";
            this.dtpFechaCompraMed.Size = new System.Drawing.Size(200, 25);
            this.dtpFechaCompraMed.TabIndex = 103;
            // 
            // cbxProveedorMed
            // 
            this.cbxProveedorMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProveedorMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProveedorMed.FormattingEnabled = true;
            this.cbxProveedorMed.Location = new System.Drawing.Point(203, 313);
            this.cbxProveedorMed.Name = "cbxProveedorMed";
            this.cbxProveedorMed.Size = new System.Drawing.Size(234, 25);
            this.cbxProveedorMed.TabIndex = 99;
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
            // txtPrecioMed
            // 
            this.txtPrecioMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMed.Location = new System.Drawing.Point(316, 184);
            this.txtPrecioMed.Name = "txtPrecioMed";
            this.txtPrecioMed.Size = new System.Drawing.Size(121, 25);
            this.txtPrecioMed.TabIndex = 96;
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
            // txtCodigoMed
            // 
            this.txtCodigoMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoMed.Location = new System.Drawing.Point(125, 182);
            this.txtCodigoMed.Name = "txtCodigoMed";
            this.txtCodigoMed.Size = new System.Drawing.Size(121, 25);
            this.txtCodigoMed.TabIndex = 94;
            // 
            // txtNombeArticuloMed
            // 
            this.txtNombeArticuloMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombeArticuloMed.Location = new System.Drawing.Point(125, 141);
            this.txtNombeArticuloMed.Name = "txtNombeArticuloMed";
            this.txtNombeArticuloMed.Size = new System.Drawing.Size(312, 25);
            this.txtNombeArticuloMed.TabIndex = 93;
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
            // txtCostoMed
            // 
            this.txtCostoMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoMed.Location = new System.Drawing.Point(648, 313);
            this.txtCostoMed.Name = "txtCostoMed";
            this.txtCostoMed.Size = new System.Drawing.Size(121, 25);
            this.txtCostoMed.TabIndex = 90;
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
            // txtCantidadMed
            // 
            this.txtCantidadMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadMed.Location = new System.Drawing.Point(203, 270);
            this.txtCantidadMed.Name = "txtCantidadMed";
            this.txtCantidadMed.Size = new System.Drawing.Size(121, 25);
            this.txtCantidadMed.TabIndex = 88;
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
            // cbxEstadoCompraMed
            // 
            this.cbxEstadoCompraMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCompraMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstadoCompraMed.FormattingEnabled = true;
            this.cbxEstadoCompraMed.Items.AddRange(new object[] {
            "Pagada",
            "Por pagar"});
            this.cbxEstadoCompraMed.Location = new System.Drawing.Point(648, 270);
            this.cbxEstadoCompraMed.Name = "cbxEstadoCompraMed";
            this.cbxEstadoCompraMed.Size = new System.Drawing.Size(121, 25);
            this.cbxEstadoCompraMed.TabIndex = 86;
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
            // cbxTipoMed
            // 
            this.cbxTipoMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoMed.FormattingEnabled = true;
            this.cbxTipoMed.Items.AddRange(new object[] {
            "Mantenimiento",
            "Lechera",
            "18% Lechera",
            "Churro"});
            this.cbxTipoMed.Location = new System.Drawing.Point(648, 226);
            this.cbxTipoMed.Name = "cbxTipoMed";
            this.cbxTipoMed.Size = new System.Drawing.Size(121, 25);
            this.cbxTipoMed.TabIndex = 84;
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
            // txtDocumentoMed
            // 
            this.txtDocumentoMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentoMed.Location = new System.Drawing.Point(648, 182);
            this.txtDocumentoMed.Name = "txtDocumentoMed";
            this.txtDocumentoMed.Size = new System.Drawing.Size(121, 25);
            this.txtDocumentoMed.TabIndex = 82;
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
            // btnEliminarCompraMed
            // 
            this.btnEliminarCompraMed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnEliminarCompraMed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCompraMed.FlatAppearance.BorderSize = 0;
            this.btnEliminarCompraMed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnEliminarCompraMed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnEliminarCompraMed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCompraMed.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCompraMed.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCompraMed.Location = new System.Drawing.Point(851, 300);
            this.btnEliminarCompraMed.Name = "btnEliminarCompraMed";
            this.btnEliminarCompraMed.Size = new System.Drawing.Size(160, 38);
            this.btnEliminarCompraMed.TabIndex = 102;
            this.btnEliminarCompraMed.Text = "ELIMINAR";
            this.btnEliminarCompraMed.UseVisualStyleBackColor = false;
            this.btnEliminarCompraMed.Click += new System.EventHandler(this.btnEliminarCompraMed_Click);
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
            // btnAgregarCompraMed
            // 
            this.btnAgregarCompraMed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btnAgregarCompraMed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCompraMed.FlatAppearance.BorderSize = 0;
            this.btnAgregarCompraMed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnAgregarCompraMed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btnAgregarCompraMed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCompraMed.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCompraMed.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCompraMed.Location = new System.Drawing.Point(851, 141);
            this.btnAgregarCompraMed.Name = "btnAgregarCompraMed";
            this.btnAgregarCompraMed.Size = new System.Drawing.Size(160, 38);
            this.btnAgregarCompraMed.TabIndex = 100;
            this.btnAgregarCompraMed.Text = "AGREGAR";
            this.btnAgregarCompraMed.UseVisualStyleBackColor = false;
            this.btnAgregarCompraMed.Click += new System.EventHandler(this.btnAgregarCompraCon_Click);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGestionMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgGestionMedCompra);
            this.Controls.Add(this.dtpFechaVenMed);
            this.Controls.Add(this.dtpFechaCompraMed);
            this.Controls.Add(this.btnEliminarCompraMed);
            this.Controls.Add(this.btnEditarCompraCon);
            this.Controls.Add(this.btnAgregarCompraMed);
            this.Controls.Add(this.cbxProveedorMed);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrecioMed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodigoMed);
            this.Controls.Add(this.txtNombeArticuloMed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCostoMed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCantidadMed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxEstadoCompraMed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxTipoMed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDocumentoMed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionMedicamento";
            this.Text = "frmGestionMedicamento";
            this.Load += new System.EventHandler(this.frmGestionMedicamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGestionMedCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnAtras;
        private System.Windows.Forms.DataGridView dgGestionMedCompra;
        private System.Windows.Forms.DateTimePicker dtpFechaVenMed;
        private System.Windows.Forms.DateTimePicker dtpFechaCompraMed;
        private System.Windows.Forms.ComboBox cbxProveedorMed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrecioMed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigoMed;
        private System.Windows.Forms.TextBox txtNombeArticuloMed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCostoMed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidadMed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEstadoCompraMed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxTipoMed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDocumentoMed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarCompraMed;
        private System.Windows.Forms.Button btnEditarCompraCon;
        private System.Windows.Forms.Button btnAgregarCompraMed;
        private System.Windows.Forms.Button button1;
    }
}