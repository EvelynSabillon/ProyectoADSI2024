using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SociedadColectivaSabillonFernandezYAsociados
{
    public partial class manejo_proveedores : Form
    {
        public manejo_proveedores()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            sistema_mainII sistema_MainII = new sistema_mainII();
            sistema_MainII.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
