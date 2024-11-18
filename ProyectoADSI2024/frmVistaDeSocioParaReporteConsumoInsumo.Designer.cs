namespace ProyectoADSI2024
{
    partial class frmVistaDeSocioParaReporteConsumoInsumo
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
            this.dgvistasociosreporte = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tlAyida = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvistasociosreporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvistasociosreporte
            // 
            this.dgvistasociosreporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvistasociosreporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvistasociosreporte.Location = new System.Drawing.Point(104, 146);
            this.dgvistasociosreporte.Name = "dgvistasociosreporte";
            this.dgvistasociosreporte.Size = new System.Drawing.Size(709, 250);
            this.dgvistasociosreporte.TabIndex = 0;
            this.dgvistasociosreporte.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvistasociosreporte_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(256, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 38);
            this.label2.TabIndex = 49;
            this.label2.Text = "REPORTE CONSUMO DE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(232, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 38);
            this.label1.TabIndex = 48;
            this.label1.Text = "SELECCION DE SOCIO PARA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(311, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 38);
            this.label3.TabIndex = 50;
            this.label3.Text = "MEDICAMENTOS";
            // 
            // tlAyida
            // 
            this.tlAyida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(142)))), ((int)(((byte)(51)))));
            this.tlAyida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlAyida.FlatAppearance.BorderSize = 0;
            this.tlAyida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.tlAyida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.tlAyida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tlAyida.Font = new System.Drawing.Font("Nirmala UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.tlAyida.ForeColor = System.Drawing.Color.White;
            this.tlAyida.Location = new System.Drawing.Point(719, 111);
            this.tlAyida.Name = "tlAyida";
            this.tlAyida.Size = new System.Drawing.Size(94, 29);
            this.tlAyida.TabIndex = 153;
            this.tlAyida.Text = "AYUDA";
            this.toolTip1.SetToolTip(this.tlAyida, "Haga doble click en el id de el socio");
            this.tlAyida.UseVisualStyleBackColor = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Seleccion de socio ";
            // 
            // frmVistaDeSocioParaReporteConsumoInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 450);
            this.Controls.Add(this.tlAyida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvistasociosreporte);
            this.Name = "frmVistaDeSocioParaReporteConsumoInsumo";
            this.Text = "frmVistaDeSocioParaReporteConsumoInsumo";
            this.Load += new System.EventHandler(this.frmVistaDeSocioParaReporteConsumoInsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvistasociosreporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvistasociosreporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tlAyida;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}