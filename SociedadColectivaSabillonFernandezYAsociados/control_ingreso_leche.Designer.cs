namespace SociedadColectivaSabillonFernandezYAsociados
{
    partial class control_ingreso_leche
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(control_ingreso_leche));
            label2 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox5 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            labelDiaID = new Label();
            tBoxDiaID = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gadugi", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(84, 142, 51);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(218, 71);
            label2.Name = "label2";
            label2.Size = new Size(638, 38);
            label2.TabIndex = 9;
            label2.Text = "CONTROL DE INGRESO DE LECHE DIARIO";
            label2.Click += label2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(84, 142, 51);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1003, 46);
            panel1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.white_arrow_icon;
            pictureBox2.Location = new Point(892, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1510, 10);
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
            pictureBox1.Location = new Point(944, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // labelDiaID
            // 
            labelDiaID.AutoSize = true;
            labelDiaID.Font = new Font("Segoe UI", 12F);
            labelDiaID.Location = new Point(83, 140);
            labelDiaID.Name = "labelDiaID";
            labelDiaID.Size = new Size(48, 21);
            labelDiaID.TabIndex = 11;
            labelDiaID.Text = "DiaID";
            // 
            // tBoxDiaID
            // 
            tBoxDiaID.Location = new Point(156, 138);
            tBoxDiaID.Name = "tBoxDiaID";
            tBoxDiaID.Size = new Size(111, 23);
            tBoxDiaID.TabIndex = 12;
            // 
            // control_ingreso_leche
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 585);
            ControlBox = false;
            Controls.Add(tBoxDiaID);
            Controls.Add(labelDiaID);
            Controls.Add(panel1);
            Controls.Add(label2);
            Name = "control_ingreso_leche";
            Text = "control_ingreso_leche";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Panel panel1;
        private PictureBox pictureBox5;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label labelDiaID;
        private TextBox tBoxDiaID;
    }
}