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
    public partial class consulta_quincenal : Form
    {
        public consulta_quincenal()
        {
            InitializeComponent();
        }

        //Boton de regresar (<-)
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            sistema_mainII sistema_MainII = new sistema_mainII();
            sistema_MainII.Show();
        }

        //Boton Cerrarr (x)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
