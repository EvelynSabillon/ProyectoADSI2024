namespace ProyectoADSI2024
{
    partial class frmPrincipalEntregaQuincenal
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.dB20212030388DataSet = new ProyectoADSI2024.DB20212030388DataSet();
            this.quincenaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quincenaTableAdapter = new ProyectoADSI2024.DB20212030388DataSetTableAdapters.QuincenaTableAdapter();
            this.quincenaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB20212030388DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quincenaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quincenaIDDataGridViewTextBoxColumn,
            this.fechaInicioDataGridViewTextBoxColumn,
            this.fechaFinalDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.quincenaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(29, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(737, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(687, 12);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(101, 47);
            this.btnAyuda.TabIndex = 1;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // dB20212030388DataSet
            // 
            this.dB20212030388DataSet.DataSetName = "DB20212030388DataSet";
            this.dB20212030388DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quincenaBindingSource
            // 
            this.quincenaBindingSource.DataMember = "Quincena";
            this.quincenaBindingSource.DataSource = this.dB20212030388DataSet;
            // 
            // quincenaTableAdapter
            // 
            this.quincenaTableAdapter.ClearBeforeFill = true;
            // 
            // quincenaIDDataGridViewTextBoxColumn
            // 
            this.quincenaIDDataGridViewTextBoxColumn.DataPropertyName = "QuincenaID";
            this.quincenaIDDataGridViewTextBoxColumn.HeaderText = "QuincenaID";
            this.quincenaIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quincenaIDDataGridViewTextBoxColumn.Name = "quincenaIDDataGridViewTextBoxColumn";
            this.quincenaIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            this.fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "FechaInicio";
            this.fechaInicioDataGridViewTextBoxColumn.HeaderText = "FechaInicio";
            this.fechaInicioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            this.fechaInicioDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaFinalDataGridViewTextBoxColumn
            // 
            this.fechaFinalDataGridViewTextBoxColumn.DataPropertyName = "FechaFinal";
            this.fechaFinalDataGridViewTextBoxColumn.HeaderText = "FechaFinal";
            this.fechaFinalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaFinalDataGridViewTextBoxColumn.Name = "fechaFinalDataGridViewTextBoxColumn";
            this.fechaFinalDataGridViewTextBoxColumn.Width = 125;
            // 
            // frmPrincipalEntregaQuincenal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmPrincipalEntregaQuincenal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipalEntregaQuincenal";
            this.Load += new System.EventHandler(this.frmPrincipalEntregaQuincenal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB20212030388DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quincenaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAyuda;
        private DB20212030388DataSet dB20212030388DataSet;
        private System.Windows.Forms.BindingSource quincenaBindingSource;
        private DB20212030388DataSetTableAdapters.QuincenaTableAdapter quincenaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn quincenaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFinalDataGridViewTextBoxColumn;
    }
}