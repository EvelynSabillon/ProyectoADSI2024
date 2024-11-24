using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

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

        private void frmSeleccionFechaIL_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }
    }
}
