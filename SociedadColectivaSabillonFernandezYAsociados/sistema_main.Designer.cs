namespace SociedadColectivaSabillonFernandezYAsociados
{
    partial class sistema_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sistema_main));
            panel1 = new Panel();
            close = new PictureBox();
            maximize = new PictureBox();
            label1 = new Label();
            minimize = new PictureBox();
            mp = new Button();
            gi = new Button();
            button2 = new Button();
            gpf = new Button();
            cil = new Button();
            button1 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maximize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimize).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.FromArgb(84, 142, 51);
            panel1.Controls.Add(close);
            panel1.Controls.Add(maximize);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(minimize);
            panel1.Name = "panel1";
            // 
            // close
            // 
            resources.ApplyResources(close, "close");
            close.Cursor = Cursors.Hand;
            close.Name = "close";
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // maximize
            // 
            resources.ApplyResources(maximize, "maximize");
            maximize.Cursor = Cursors.Hand;
            maximize.Name = "maximize";
            maximize.TabStop = false;
            maximize.Click += maximize_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // minimize
            // 
            resources.ApplyResources(minimize, "minimize");
            minimize.Cursor = Cursors.Hand;
            minimize.Name = "minimize";
            minimize.TabStop = false;
            minimize.Click += pictureBox1_Click;
            // 
            // mp
            // 
            resources.ApplyResources(mp, "mp");
            mp.BackColor = Color.FromArgb(204, 185, 65);
            mp.FlatAppearance.BorderSize = 0;
            mp.ForeColor = Color.White;
            mp.Name = "mp";
            mp.UseVisualStyleBackColor = false;
            mp.Click += mp_Click;
            // 
            // gi
            // 
            resources.ApplyResources(gi, "gi");
            gi.BackColor = Color.FromArgb(204, 185, 65);
            gi.FlatAppearance.BorderSize = 0;
            gi.ForeColor = Color.White;
            gi.Name = "gi";
            gi.UseVisualStyleBackColor = false;
            gi.Click += gi_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.BackColor = Color.FromArgb(204, 185, 65);
            button2.FlatAppearance.BorderSize = 0;
            button2.ForeColor = Color.White;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // gpf
            // 
            resources.ApplyResources(gpf, "gpf");
            gpf.BackColor = Color.FromArgb(204, 185, 65);
            gpf.FlatAppearance.BorderSize = 0;
            gpf.ForeColor = Color.White;
            gpf.Name = "gpf";
            gpf.UseVisualStyleBackColor = false;
            gpf.Click += gpf_Click;
            // 
            // cil
            // 
            resources.ApplyResources(cil, "cil");
            cil.BackColor = Color.FromArgb(204, 185, 65);
            cil.FlatAppearance.BorderSize = 0;
            cil.ForeColor = Color.White;
            cil.Name = "cil";
            cil.UseVisualStyleBackColor = false;
            cil.Click += cil_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.FromArgb(204, 185, 65);
            button1.ForeColor = Color.White;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = SystemColors.Desktop;
            panel2.Controls.Add(cil);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(gpf);
            panel2.Name = "panel2";
            // 
            // sistema_main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(mp);
            Controls.Add(gi);
            Name = "sistema_main";
            Load += sistema_main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ((System.ComponentModel.ISupportInitialize)maximize).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimize).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox close;
        private PictureBox maximize;
        private Label label1;
        private PictureBox minimize;
        private Button mp;
        private Button gi;
        private Button button2;
        private Button gpf;
        private Button cil;
        private Button cq;
        private Button button1;
        private Panel panel2;
    }
}