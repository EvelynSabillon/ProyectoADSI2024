using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ProyectoADSI2024
{
    public partial class frmReporteProduccionGeneral : Form
    {
        public frmReporteProduccionGeneral()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmReporteProduccionGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia del reporte
                ReportDocument reporte = new ReportDocument();

                // Cargar el archivo .rpt con la plantilla
                string rutaReporte = @"C:\Users\coseg\Desktop\ProyectoADSI2024\ProyectoADSI2024\Reportes\ReporteProduccion\ReporteProduccionGeneral.rpt"; //ruta correspondiente
                reporte.Load(rutaReporte);

                // Conectar a la base de datos (opcional, según sea necesario)
                // Configura los datos de conexión
                reporte.SetDatabaseLogon("carlos.osegueda", "CO20212030669", "3.128.144.165", "DB20212030388");

                // Asignar el reporte al visor
                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
