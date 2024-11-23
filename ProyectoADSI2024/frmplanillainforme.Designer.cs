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
            this.dgverplanilla = new System.Windows.Forms.DataGridView();
            this.btngenreporte = new System.Windows.Forms.Button();
            this.txtidplanilla = new System.Windows.Forms.TextBox();
            this.txtplanilla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgverplanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgverplanilla
            // 
            this.dgverplanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgverplanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgverplanilla.Location = new System.Drawing.Point(159, 99);
            this.dgverplanilla.Name = "dgverplanilla";
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
            this.btngenreporte.Location = new System.Drawing.Point(470, 323);
            this.btngenreporte.Name = "btngenreporte";
            this.btngenreporte.Size = new System.Drawing.Size(160, 60);
            this.btngenreporte.TabIndex = 129;
            this.btngenreporte.Text = "GENERAR INFORME";
            this.btngenreporte.UseVisualStyleBackColor = false;
            this.btngenreporte.Click += new System.EventHandler(this.btngenreporte_Click);
            // 
            // txtidplanilla
            // 
            this.txtidplanilla.Location = new System.Drawing.Point(159, 323);
            this.txtidplanilla.Name = "txtidplanilla";
            this.txtidplanilla.ReadOnly = true;
            this.txtidplanilla.Size = new System.Drawing.Size(47, 20);
            this.txtidplanilla.TabIndex = 130;
            // 
            // txtplanilla
            // 
            this.txtplanilla.Location = new System.Drawing.Point(212, 323);
            this.txtplanilla.Name = "txtplanilla";
            this.txtplanilla.ReadOnly = true;
            this.txtplanilla.Size = new System.Drawing.Size(147, 20);
            this.txtplanilla.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(134, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 38);
            this.label1.TabIndex = 132;
            this.label1.Text = "CONFIGURACION:PLANILLA PARA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(182, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 38);
            this.label2.TabIndex = 133;
            this.label2.Text = "INFORME PAGO DE SOCIOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(372, 324);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 134;
            this.label3.Text = "Planilla";
            // 
            // frmplanillainforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 482);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtplanilla);
            this.Controls.Add(this.txtidplanilla);
            this.Controls.Add(this.btngenreporte);
            this.Controls.Add(this.dgverplanilla);
            this.Name = "frmplanillainforme";
            this.Text = "frmplanillainforme";
            this.Load += new System.EventHandler(this.frmplanillainforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgverplanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgverplanilla;
        private System.Windows.Forms.Button btngenreporte;
        private System.Windows.Forms.TextBox txtidplanilla;
        private System.Windows.Forms.TextBox txtplanilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}