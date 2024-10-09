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
    public partial class sistema_mainII : Form
    {
        public sistema_mainII()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btprestamos_Click(object sender, EventArgs e)
        {
            this.Hide();
            finanzas_prestamos finanzas_Prestamos = new finanzas_prestamos();
            finanzas_Prestamos.Show();
        }


        private void btleche_Click(object sender, EventArgs e)
        {
            this.Hide();
            control_ingreso_leche control_ingreso_Leche = new control_ingreso_leche();
            control_ingreso_Leche.Show();
        }

        private void btinventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            gestion_inventario gestion_inventario = new gestion_inventario();
            gestion_inventario.Show();
        }

        private void btproveedores_Click(object sender, EventArgs e)
        {
            this.Hide();
            manejo_proveedores manejo_Proveedores = new manejo_proveedores();
            manejo_Proveedores.Show();
        }

        private void btsocios_Click(object sender, EventArgs e)
        {
            this.Hide();
            socios_admin socios_Admin = new socios_admin();
            socios_Admin.Show();
        }

        private void btinfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            about_us about_Us = new about_us();
            about_Us.Show();
        }

        private void btconsultaq_Click(object sender, EventArgs e)
        {
            this.Hide();
            consulta_quincenal consulta_Quincenal = new consulta_quincenal();
            consulta_Quincenal.Show();
        }
    }
}
