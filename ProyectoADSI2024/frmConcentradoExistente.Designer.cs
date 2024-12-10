namespace ProyectoADSI2024
{
    partial class frmConcentradoExistente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConcentradoExistente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAtras = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgConcentradoExist = new System.Windows.Forms.DataGridView();
            this.dtpFechaConExistVen = new System.Windows.Forms.DateTimePicker();
            this.btnEditarCompraCon = new System.Windows.Forms.Button();
            this.cbxProvComEx = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCantidadMed = new System.Windows.Forms.TextBox();
            this.txtConIdCompraEx = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoCompra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEstadoCompraEx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxTipoComEx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDocumentoComEx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreArticuloMed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaCompraConExist = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.epAgregar = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConcentradoExist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAgregar)).BeginInit();
            this.SuspendLayout();
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
            this.btnAtras.TabIndex = 49;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(80, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(841, 38);
            this.label1.TabIndex = 48;
            this.label1.Text = "REGISTRO DE COMPRA DE CONCENTRADO EXISTENTE";
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
            this.button1.Location = new System.Drawing.Point(854, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 38);
            this.button1.TabIndex = 133;
            this.button1.Text = "LIMPIAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgConcentradoExist
            // 
            this.dgConcentradoExist.AllowUserToAddRows = false;
            this.dgConcentradoExist.AllowUserToDeleteRows = false;
            this.dgConcentradoExist.AllowUserToResizeColumns = false;
            this.dgConcentradoExist.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgConcentradoExist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConcentradoExist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgConcentradoExist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgConcentradoExist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConcentradoExist.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgConcentradoExist.Location = new System.Drawing.Point(33, 95);
            this.dgConcentradoExist.MultiSelect = false;
            this.dgConcentradoExist.Name = "dgConcentradoExist";
            this.dgConcentradoExist.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgConcentradoExist.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgConcentradoExist.Size = new System.Drawing.Size(1004, 206);
            this.dgConcentradoExist.TabIndex = 132;
            this.dgConcentradoExist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConcentradoExist_CellClick);
            // 
            // dtpFechaConExistVen
            // 
            this.dtpFechaConExistVen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaConExistVen.Location = new System.Drawing.Point(541, 328);
            this.dtpFechaConExistVen.Name = "dtpFechaConExistVen";
            this.dtpFechaConExistVen.Size = new System.Drawing.Size(234, 25);
            this.dtpFechaConExistVen.TabIndex = 131;
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
            this.btnEditarCompraCon.Location = new System.Drawing.Point(854, 328);
            this.btnEditarCompraCon.Name = "btnEditarCompraCon";
            this.btnEditarCompraCon.Size = new System.Drawing.Size(160, 38);
            this.btnEditarCompraCon.TabIndex = 128;
            this.btnEditarCompraCon.Text = "AGREGAR";
            this.btnEditarCompraCon.UseVisualStyleBackColor = false;
            this.btnEditarCompraCon.Click += new System.EventHandler(this.btnEditarCompraCon_Click);
            // 
            // cbxProvComEx
            // 
            this.cbxProvComEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProvComEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProvComEx.FormattingEnabled = true;
            this.cbxProvComEx.Location = new System.Drawing.Point(177, 492);
            this.cbxProvComEx.Name = "cbxProvComEx";
            this.cbxProvComEx.Size = new System.Drawing.Size(242, 25);
            this.cbxProvComEx.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(46, 494);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 21);
            this.label13.TabIndex = 125;
            this.label13.Text = "Proveedor";
            // 
            // txtCantidadMed
            // 
            this.txtCantidadMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadMed.Location = new System.Drawing.Point(177, 451);
            this.txtCantidadMed.Name = "txtCantidadMed";
            this.txtCantidadMed.Size = new System.Drawing.Size(121, 25);
            this.txtCantidadMed.TabIndex = 121;
            // 
            // txtConIdCompraEx
            // 
            this.txtConIdCompraEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConIdCompraEx.Location = new System.Drawing.Point(177, 328);
            this.txtConIdCompraEx.Name = "txtConIdCompraEx";
            this.txtConIdCompraEx.ReadOnly = true;
            this.txtConIdCompraEx.Size = new System.Drawing.Size(120, 25);
            this.txtConIdCompraEx.TabIndex = 120;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 21);
            this.label10.TabIndex = 119;
            this.label10.Text = "Código";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 21);
            this.label9.TabIndex = 118;
            this.label9.Text = "ConcentradoID";
            // 
            // txtCodigoCompra
            // 
            this.txtCodigoCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCompra.Location = new System.Drawing.Point(177, 369);
            this.txtCodigoCompra.Name = "txtCodigoCompra";
            this.txtCodigoCompra.ReadOnly = true;
            this.txtCodigoCompra.Size = new System.Drawing.Size(121, 25);
            this.txtCodigoCompra.TabIndex = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 21);
            this.label6.TabIndex = 114;
            this.label6.Text = "Cantidad";
            // 
            // cbxEstadoCompraEx
            // 
            this.cbxEstadoCompraEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCompraEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstadoCompraEx.FormattingEnabled = true;
            this.cbxEstadoCompraEx.Items.AddRange(new object[] {
            "Pagada",
            "Por pagar"});
            this.cbxEstadoCompraEx.Location = new System.Drawing.Point(654, 451);
            this.cbxEstadoCompraEx.Name = "cbxEstadoCompraEx";
            this.cbxEstadoCompraEx.Size = new System.Drawing.Size(121, 25);
            this.cbxEstadoCompraEx.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 21);
            this.label5.TabIndex = 112;
            this.label5.Text = "Estado de Compra";
            // 
            // cbxTipoComEx
            // 
            this.cbxTipoComEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoComEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoComEx.FormattingEnabled = true;
            this.cbxTipoComEx.Items.AddRange(new object[] {
            "Mantenimiento",
            "Lechera",
            "18% Lechera",
            "Churro"});
            this.cbxTipoComEx.Location = new System.Drawing.Point(654, 410);
            this.cbxTipoComEx.Name = "cbxTipoComEx";
            this.cbxTipoComEx.Size = new System.Drawing.Size(121, 25);
            this.cbxTipoComEx.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(467, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 21);
            this.label8.TabIndex = 110;
            this.label8.Text = "Tipo";
            // 
            // txtDocumentoComEx
            // 
            this.txtDocumentoComEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentoComEx.Location = new System.Drawing.Point(654, 369);
            this.txtDocumentoComEx.Name = "txtDocumentoComEx";
            this.txtDocumentoComEx.Size = new System.Drawing.Size(121, 25);
            this.txtDocumentoComEx.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(467, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 108;
            this.label4.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(467, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 107;
            this.label3.Text = "Fecha";
            // 
            // txtNombreArticuloMed
            // 
            this.txtNombreArticuloMed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArticuloMed.Location = new System.Drawing.Point(177, 410);
            this.txtNombreArticuloMed.Name = "txtNombreArticuloMed";
            this.txtNombreArticuloMed.ReadOnly = true;
            this.txtNombreArticuloMed.Size = new System.Drawing.Size(224, 25);
            this.txtNombreArticuloMed.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 135;
            this.label2.Text = "Nombre";
            // 
            // dtpFechaCompraConExist
            // 
            this.dtpFechaCompraConExist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCompraConExist.Location = new System.Drawing.Point(584, 494);
            this.dtpFechaCompraConExist.Name = "dtpFechaCompraConExist";
            this.dtpFechaCompraConExist.Size = new System.Drawing.Size(191, 25);
            this.dtpFechaCompraConExist.TabIndex = 138;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(467, 494);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 21);
            this.label7.TabIndex = 137;
            this.label7.Text = "Fecha Compra";
            // 
            // epAgregar
            // 
            this.epAgregar.ContainerControl = this;
            // 
            // frmConcentradoExistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 595);
            this.Controls.Add(this.dtpFechaCompraConExist);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreArticuloMed);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgConcentradoExist);
            this.Controls.Add(this.dtpFechaConExistVen);
            this.Controls.Add(this.btnEditarCompraCon);
            this.Controls.Add(this.cbxProvComEx);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCantidadMed);
            this.Controls.Add(this.txtConIdCompraEx);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCodigoCompra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxEstadoCompraEx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxTipoComEx);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDocumentoComEx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConcentradoExistente";
            this.Text = "frmNuevoConcentrado";
            this.Load += new System.EventHandler(this.frmConcentradoExistente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConcentradoExist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAgregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btnAtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgConcentradoExist;
        private System.Windows.Forms.DateTimePicker dtpFechaConExistVen;
        private System.Windows.Forms.Button btnEditarCompraCon;
        private System.Windows.Forms.ComboBox cbxProvComEx;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCantidadMed;
        private System.Windows.Forms.TextBox txtConIdCompraEx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigoCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEstadoCompraEx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxTipoComEx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDocumentoComEx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreArticuloMed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaCompraConExist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider epAgregar;
    }
}