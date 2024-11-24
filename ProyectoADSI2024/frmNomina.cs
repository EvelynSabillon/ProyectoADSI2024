using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ProyectoADSI2024; //Mandar a llamar el form del reporte de la nomina

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

        private void btnGenReporte_Click_1(object sender, EventArgs e)
        {
            FrmReporteConsQuincenal frmNomina = new FrmReporteConsQuincenal();

            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "02"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
            frmNomina.NumeroReporte = numeroReporte;

            frmNomina.ShowDialog();
        }
    }
}
