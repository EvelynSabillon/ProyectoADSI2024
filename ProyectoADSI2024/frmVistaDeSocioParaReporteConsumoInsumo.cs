using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class frmVistaDeSocioParaReporteConsumoInsumo : Form
    {
        SqlDataAdapter adpreporte;
        DataTable dtreporte = new DataTable();
        Conexion cnxreporteconsumoinsumo;
        public string NumeroReporte { get; set; }

        public frmVistaDeSocioParaReporteConsumoInsumo()
        {
            InitializeComponent();
            adpreporte = new SqlDataAdapter();
            cnxreporteconsumoinsumo = new Conexion();
            dtreporte = new DataTable();

            adpreporte = new SqlDataAdapter("spversocios", cnxreporteconsumoinsumo.ObtenerConexion());
            adpreporte.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void frmVistaDeSocioParaReporteConsumoInsumo_Load(object sender, EventArgs e)
        {
            adpreporte.Fill(dtreporte);
            dgvistasociosreporte.DataSource = dtreporte;

        }

        private void dgvistasociosreporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmContenedorConsumoInsumoReparado objformReportereparado = new frmContenedorConsumoInsumoReparado();
            int idsocio = Convert.ToInt32(dgvistasociosreporte.CurrentRow.Cells[0].Value);
            objformReportereparado.idsocio = idsocio;

            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "03"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
            objformReportereparado.NumeroReporte = numeroReporte;

            objformReportereparado.ShowDialog();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección del socio?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void frmVistaDeSocioParaReporteConsumoInsumo_MouseDown(object sender, MouseEventArgs e)
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
