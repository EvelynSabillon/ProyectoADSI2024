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
    public partial class frmSeleccionFechaIL : Form
    {

        public DateTime FechaSeleccionada { get; private set; } = DateTime.Now;
        public bool EsConfirmado { get; private set; } = false;

        public frmSeleccionFechaIL()
        {
            InitializeComponent();
            dtpfechaIL.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección de la fecha?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            FechaSeleccionada = dtpfechaIL.Value.Date;
            //this.DialogResult = DialogResult.OK; // Confirmar selección
            EsConfirmado = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
