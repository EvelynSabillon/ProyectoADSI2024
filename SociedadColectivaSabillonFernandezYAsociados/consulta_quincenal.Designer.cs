namespace SociedadColectivaSabillonFernandezYAsociados
{
    partial class consulta_quincenal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(consulta_quincenal));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox5 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tboxQuincenaID = new TextBox();
            tboxMes = new TextBox();
            label5 = new Label();
            cboxFechaInicio = new ComboBox();
            cboxFechaFinal = new ComboBox();
            label6 = new Label();
            dgConsQuincenal = new DataGridView();
            btnConsultar = new Button();
            btnLimpiar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgConsQuincenal).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(84, 142, 51);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1017, 46);
            panel1.TabIndex = 11;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = Properties.Resources.white_arrow_icon;
            pictureBox3.Location = new Point(933, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.white_arrow_icon;
            pictureBox2.Location = new Point(1521, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(2124, 10);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(36, 32);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 15;
            pictureBox5.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(123, 47);
            label1.TabIndex = 2;
            label1.Text = "SCSFA";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.white_cross_icon;
            pictureBox1.Location = new Point(975, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gadugi", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(84, 142, 51);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(154, 74);
            label2.Name = "label2";
            label2.Size = new Size(724, 38);
            label2.TabIndex = 12;
            label2.Text = "CONSULTA QUINCENAL DE LECHE INGRESADA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(52, 137);
            label3.Name = "label3";
            label3.Size = new Size(95, 21);
            label3.TabIndex = 13;
            label3.Text = "Quincena ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(424, 137);
            label4.Name = "label4";
            label4.Size = new Size(42, 21);
            label4.TabIndex = 14;
            label4.Text = "Mes:";
            // 
            // tboxQuincenaID
            // 
            tboxQuincenaID.Font = new Font("Segoe UI", 12F);
            tboxQuincenaID.Location = new Point(153, 137);
            tboxQuincenaID.Name = "tboxQuincenaID";
            tboxQuincenaID.Size = new Size(135, 29);
            tboxQuincenaID.TabIndex = 15;
            // 
            // tboxMes
            // 
            tboxMes.Font = new Font("Segoe UI", 12F);
            tboxMes.Location = new Point(472, 129);
            tboxMes.Name = "tboxMes";
            tboxMes.ReadOnly = true;
            tboxMes.Size = new Size(100, 29);
            tboxMes.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(52, 186);
            label5.Name = "label5";
            label5.Size = new Size(94, 21);
            label5.TabIndex = 17;
            label5.Text = "Fecha Inicio:";
            // 
            // cboxFechaInicio
            // 
            cboxFechaInicio.Font = new Font("Segoe UI", 10F);
            cboxFechaInicio.FormattingEnabled = true;
            cboxFechaInicio.Location = new Point(152, 186);
            cboxFechaInicio.Name = "cboxFechaInicio";
            cboxFechaInicio.Size = new Size(226, 25);
            cboxFechaInicio.TabIndex = 18;
            cboxFechaInicio.Text = "Seleccione la fecha de inicio...";
            // 
            // cboxFechaFinal
            // 
            cboxFechaFinal.Font = new Font("Segoe UI", 10F);
            cboxFechaFinal.FormattingEnabled = true;
            cboxFechaFinal.Location = new Point(520, 186);
            cboxFechaFinal.Name = "cboxFechaFinal";
            cboxFechaFinal.Size = new Size(226, 25);
            cboxFechaFinal.TabIndex = 19;
            cboxFechaFinal.Text = "Seleccione la fecha final...";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(424, 186);
            label6.Name = "label6";
            label6.Size = new Size(90, 21);
            label6.TabIndex = 20;
            label6.Text = "Fecha Final:";
            // 
            // dgConsQuincenal
            // 
            dgConsQuincenal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgConsQuincenal.Location = new Point(43, 230);
            dgConsQuincenal.Name = "dgConsQuincenal";
            dgConsQuincenal.Size = new Size(952, 355);
            dgConsQuincenal.TabIndex = 21;
            // 
            // btnConsultar
            // 
            btnConsultar.Font = new Font("Segoe UI", 15F);
            btnConsultar.Location = new Point(774, 129);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(140, 37);
            btnConsultar.TabIndex = 22;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 15F);
            btnLimpiar.Location = new Point(774, 172);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 39);
            btnLimpiar.TabIndex = 23;
            btnLimpiar.Text = "Limpiar Tabla";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // consulta_quincenal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 597);
            Controls.Add(btnLimpiar);
            Controls.Add(btnConsultar);
            Controls.Add(dgConsQuincenal);
            Controls.Add(label6);
            Controls.Add(cboxFechaFinal);
            Controls.Add(cboxFechaInicio);
            Controls.Add(label5);
            Controls.Add(tboxMes);
            Controls.Add(tboxQuincenaID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "consulta_quincenal";
            Text = "consulta_quincenal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgConsQuincenal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tboxQuincenaID;
        private TextBox tboxMes;
        private Label label5;
        private ComboBox cboxFechaInicio;
        private ComboBox cboxFechaFinal;
        private Label label6;
        private DataGridView dgConsQuincenal;
        private Button btnConsultar;
        private Button btnLimpiar;
    }
}