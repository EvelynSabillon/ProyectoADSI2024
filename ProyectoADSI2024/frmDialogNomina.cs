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
    public partial class frmDialogNomina : Form
    {
        public frmDialogNomina()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void frmDialogNomina_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB20212030388DataSet1.Quincena' Puede moverla o quitarla según sea necesario.
            this.quincenaTableAdapter.Fill(this.dB20212030388DataSet1.Quincena);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección de la nomina?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Seleccione una QuincenaID para consultar o imprimir un reporte.", "Ayuda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void frmDialogNomina_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {



            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "02"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
           // frmNomina.NumeroReporte = numeroReporte;
        }
    }
}
