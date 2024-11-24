namespace ProyectoADSI2024
{
    partial class frmplanillainforme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmplanillainforme));
            this.dgverplanilla = new System.Windows.Forms.DataGridView();
            this.btngenreporte = new System.Windows.Forms.Button();
            this.txtidplanilla = new System.Windows.Forms.TextBox();
            this.txtplanilla = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgverplanilla)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dgverplanilla
            // 
            this.dgverplanilla.AllowUserToAddRows = false;
            this.dgverplanilla.AllowUserToDeleteRows = false;
            this.dgverplanilla.AllowUserToResizeColumns = false;
            this.dgverplanilla.AllowUserToResizeRows = false;
            this.dgverplanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgverplanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgverplanilla.Location = new System.Drawing.Point(84, 106);
            this.dgverplanilla.Name = "dgverplanilla";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.dgverplanilla.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgverplanilla.Size = new System.Drawing.Size(471, 202);
            this.dgverplanilla.TabIndex = 0;
            this.dgverplanilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgverplanilla_CellDoubleClick);
            // 
            // btngenreporte
            // 
            this.btngenreporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.btngenreporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngenreporte.FlatAppearance.BorderSize = 0;
            this.btngenreporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btngenreporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.btngenreporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenreporte.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenreporte.ForeColor = System.Drawing.Color.White;
            this.btngenreporte.Location = new System.Drawing.Point(395, 330);
            this.btngenreporte.Name = "btngenreporte";
            this.btngenreporte.Size = new System.Drawing.Size(160, 60);
            this.btngenreporte.TabIndex = 129;
            this.btngenreporte.Text = "GENERAR INFORME";
            this.btngenreporte.UseVisualStyleBackColor = false;
            this.btngenreporte.Click += new System.EventHandler(this.btngenreporte_Click);
            // 
            // txtidplanilla
            // 
            this.txtidplanilla.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidplanilla.Location = new System.Drawing.Point(84, 330);
            this.txtidplanilla.Name = "txtidplanilla";
            this.txtidplanilla.ReadOnly = true;
            this.txtidplanilla.Size = new System.Drawing.Size(47, 25);
            this.txtidplanilla.TabIndex = 130;
            // 
            // txtplanilla
            // 
            this.txtplanilla.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtplanilla.Location = new System.Drawing.Point(137, 330);
            this.txtplanilla.Name = "txtplanilla";
            this.txtplanilla.ReadOnly = true;
            this.txtplanilla.Size = new System.Drawing.Size(147, 25);
            this.txtplanilla.TabIndex = 131;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(297, 332);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 134;
            this.label3.Text = "Planilla";
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.BarraTitulo.Controls.Add(this.label4);
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnClose);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(661, 55);
            this.BarraTitulo.TabIndex = 155;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(477, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "SELECCIÓN DE PLANILLA PARA INFORME DE PAGOS";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(566, 10);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(614, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmplanillainforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 426);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtplanilla);
            this.Controls.Add(this.txtidplanilla);
            this.Controls.Add(this.btngenreporte);
            this.Controls.Add(this.dgverplanilla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmplanillainforme";
            this.Text = "frmplanillainforme";
            this.Load += new System.EventHandler(this.frmplanillainforme_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmplanillainforme_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgverplanilla)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgverplanilla;
        private System.Windows.Forms.Button btngenreporte;
        private System.Windows.Forms.TextBox txtidplanilla;
        private System.Windows.Forms.TextBox txtplanilla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnClose;
    }
}