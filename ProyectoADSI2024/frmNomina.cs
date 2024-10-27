using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class frmNomina : Form
    {
        public frmNomina()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmNomina_Load(object sender, EventArgs e)
        {

        }

        private void timerMes_Tick(object sender, EventArgs e)
        {
            lblMes.Text = DateTime.Now.ToString("MMMM");
        }
    }
}
