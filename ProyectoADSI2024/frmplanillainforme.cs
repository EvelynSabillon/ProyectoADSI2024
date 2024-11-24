using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class frmplanillainforme : Form
    {

        private Conexion cnx;
        SqlDataAdapter adp;
        DataTable dt;
        public frmplanillainforme()
        {
            InitializeComponent();

            cnx = new Conexion();
            dt = new DataTable();

            adp = new SqlDataAdapter("select planillaid, periodoinicio,periodofinal, precioleche from proyecto.planilla", cnx.ObtenerConexion());
         


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana


        private void frmplanillainforme_Load(object sender, EventArgs e)
        {
            adp.Fill(dt);
            dgverplanilla.DataSource = dt;

        }

        private void dgverplanilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = dgverplanilla.Rows[e.RowIndex];

                // Asigno los valores de las celdas a los TextBox
                txtidplanilla.Text = filaSeleccionada.Cells["planillaid"].Value?.ToString();
                txtplanilla.Text = filaSeleccionada.Cells["periodoinicio"].Value?.ToString();
                

            }
        }

        private void btngenreporte_Click(object sender, EventArgs e)
        {
            try
            {
                frmInformePago informeparametro = new frmInformePago();
                informeparametro.idplanilla = Convert.ToInt32(txtidplanilla.Text);

                // Obtener el número de reporte generado desde el procedimiento almacenado
                Report_Manager reportManager = new Report_Manager();
                string tipoReporte = "07"; // Tipo de reporte (puedes adaptarlo según sea necesario)
                string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

                // Pasar el número de reporte al formulario
                informeparametro.NumeroReporte = numeroReporte;

                informeparametro.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmplanillainforme_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección de planilla?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
