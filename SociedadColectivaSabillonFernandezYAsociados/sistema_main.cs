namespace SociedadColectivaSabillonFernandezYAsociados
{
    public partial class sistema_main : Form
    {
        private bool isMaximized = false;
        private string maxpath = @"C:\Users\coseg\Desktop\ProyectoAYDS\white_square_icon.png";
        private string minpath = @"C:\Users\coseg\Desktop\ProyectoAYDS\white_doublesquare_icon.png";
        public sistema_main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximize_Click(object sender, EventArgs e)
        {

            if (isMaximized)
            {
                this.WindowState = FormWindowState.Normal;
                isMaximized = false;
                maximize.Image = Image.FromFile(maxpath);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                isMaximized = true;
                maximize.Image = Image.FromFile(minpath);
            }
        }

        private void sistema_main_Load(object sender, EventArgs e)
        {

        }

        private void gpf_Click(object sender, EventArgs e)
        {
            
        }

        private void gi_Click(object sender, EventArgs e)
        {
           
        }

        private void mp_Click(object sender, EventArgs e)
        {
            
        }

        private void cil_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void rgds_Click(object sender, EventArgs e)
        {
            
        }

        private void center_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            socios_admin socios_Admin = new socios_admin();
            socios_Admin.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
