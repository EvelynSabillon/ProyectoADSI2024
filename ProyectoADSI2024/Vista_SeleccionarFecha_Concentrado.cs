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
    public partial class Vista_SeleccionarFecha_Concentrado : Form
    {
        private int articuloId; // Almacena el ID del artículo seleccionado
        public Vista_SeleccionarFecha_Concentrado()
        {
            InitializeComponent();
        }

        public Vista_SeleccionarFecha_Concentrado(int articuloId)
        {
            InitializeComponent();
            this.articuloId = articuloId; // Recibir el ID del artículo
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección de la fecha?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void Vista_SeleccionarFecha_Concentrado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtp1.Value;
            DateTime fechaFin = dtp2.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Abrir el formulario del reporte y pasarle los parámetros
            frmReporteKardexConcentrado objformReporte = new frmReporteKardexConcentrado(articuloId, fechaInicio, fechaFin);

            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "04"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
            objformReporte.NumeroReporte = numeroReporte;

            objformReporte.ShowDialog();
        }
    }
}
