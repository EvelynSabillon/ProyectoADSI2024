namespace SociedadColectivaSabillonFernandezYAsociados
{
    partial class sistema_mainII
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
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btprestamos = new Button();
            pictureBox2 = new PictureBox();
            btleche = new Button();
            btinventario = new Button();
            btproveedores = new Button();
            btsocios = new Button();
            btinfo = new Button();
            btconsultaq = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(84, 142, 51);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(649, 46);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, -4);
            label1.Name = "label1";
            label1.Size = new Size(123, 47);
            label1.TabIndex = 1;
            label1.Text = "SCSFA";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.white_cross_icon;
            pictureBox1.Location = new Point(607, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btprestamos
            // 
            btprestamos.BackColor = Color.FromArgb(204, 185, 65);
            btprestamos.FlatStyle = FlatStyle.Popup;
            btprestamos.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btprestamos.ForeColor = Color.White;
            btprestamos.Location = new Point(215, 64);
            btprestamos.Name = "btprestamos";
            btprestamos.Size = new Size(195, 88);
            btprestamos.TabIndex = 1;
            btprestamos.Text = "GESTIÓN DE PRÉSTAMOS Y FINANZAS";
            btprestamos.UseVisualStyleBackColor = false;
            btprestamos.Click += btprestamos_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_png;
            pictureBox2.Location = new Point(8, 64);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(197, 191);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // btleche
            // 
            btleche.BackColor = Color.FromArgb(204, 185, 65);
            btleche.FlatStyle = FlatStyle.Popup;
            btleche.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btleche.ForeColor = Color.White;
            btleche.Location = new Point(438, 64);
            btleche.Name = "btleche";
            btleche.Size = new Size(195, 88);
            btleche.TabIndex = 8;
            btleche.Text = "CONTROL DE INGRESO DE LECHE";
            btleche.UseVisualStyleBackColor = false;
            btleche.Click += btleche_Click;
            // 
            // btinventario
            // 
            btinventario.BackColor = Color.FromArgb(204, 185, 65);
            btinventario.FlatStyle = FlatStyle.Popup;
            btinventario.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btinventario.ForeColor = Color.White;
            btinventario.Location = new Point(215, 167);
            btinventario.Name = "btinventario";
            btinventario.Size = new Size(195, 88);
            btinventario.TabIndex = 9;
            btinventario.Text = "GESTIÓN DE INVENTARIO";
            btinventario.UseVisualStyleBackColor = false;
            btinventario.Click += btinventario_Click;
            // 
            // btproveedores
            // 
            btproveedores.BackColor = Color.FromArgb(204, 185, 65);
            btproveedores.FlatStyle = FlatStyle.Popup;
            btproveedores.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btproveedores.ForeColor = Color.White;
            btproveedores.Location = new Point(438, 167);
            btproveedores.Name = "btproveedores";
            btproveedores.Size = new Size(195, 88);
            btproveedores.TabIndex = 10;
            btproveedores.Text = "MANEJO DE PROVEEDORES";
            btproveedores.UseVisualStyleBackColor = false;
            btproveedores.Click += btproveedores_Click;
            // 
            // btsocios
            // 
            btsocios.BackColor = Color.FromArgb(204, 185, 65);
            btsocios.FlatStyle = FlatStyle.Popup;
            btsocios.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btsocios.ForeColor = Color.White;
            btsocios.Location = new Point(215, 270);
            btsocios.Name = "btsocios";
            btsocios.Size = new Size(195, 88);
            btsocios.TabIndex = 11;
            btsocios.Text = "REGISTRO Y GESTIÓN DE SOCIOS";
            btsocios.UseVisualStyleBackColor = false;
            btsocios.Click += btsocios_Click;
            // 
            // btinfo
            // 
            btinfo.BackColor = Color.FromArgb(204, 185, 65);
            btinfo.FlatStyle = FlatStyle.Popup;
            btinfo.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btinfo.ForeColor = Color.White;
            btinfo.Location = new Point(438, 270);
            btinfo.Name = "btinfo";
            btinfo.Size = new Size(195, 88);
            btinfo.TabIndex = 12;
            btinfo.Text = "ADMINISTRACIÓN GENERAL";
            btinfo.UseVisualStyleBackColor = false;
            btinfo.Click += btinfo_Click;
            // 
            // btconsultaq
            // 
            btconsultaq.BackColor = Color.FromArgb(204, 185, 65);
            btconsultaq.FlatStyle = FlatStyle.Popup;
            btconsultaq.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            btconsultaq.ForeColor = Color.White;
            btconsultaq.Location = new Point(215, 379);
            btconsultaq.Name = "btconsultaq";
            btconsultaq.Size = new Size(195, 88);
            btconsultaq.TabIndex = 13;
            btconsultaq.Text = "CONSULTA QUINCENAL";
            btconsultaq.UseVisualStyleBackColor = false;
            btconsultaq.Click += btconsultaq_Click;
            // 
            // sistema_mainII
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(649, 479);
            ControlBox = false;
            Controls.Add(btconsultaq);
            Controls.Add(btinfo);
            Controls.Add(btsocios);
            Controls.Add(btproveedores);
            Controls.Add(btinventario);
            Controls.Add(btleche);
            Controls.Add(pictureBox2);
            Controls.Add(btprestamos);
            Controls.Add(panel1);
            Name = "sistema_mainII";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sociedad Colectiva Sabillon Fernandez y Asociados";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btprestamos;
        private PictureBox pictureBox2;
        private Button btleche;
        private Button btConsQuincenal;
        private Button btinventario;
        private Button btproveedores;
        private Button btsocios;
        private Button btinfo;
        private Button btconsultaq;
    }
}