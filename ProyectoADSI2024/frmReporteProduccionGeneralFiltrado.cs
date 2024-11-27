using CrystalDecisions.ReportAppServer;
using ProyectoADSI2024.Reportes.ReportePrestamosFinanzas;
using ProyectoADSI2024.Reportes.ReporteProduccion;
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
    public partial class frmReporteProduccionGeneralFiltrado : Form
    {
        public int quincenaid;
        public frmReporteProduccionGeneralFiltrado()
        {
            InitializeComponent();
        }

        public frmReporteProduccionGeneralFiltrado(int quincenaid)
        {
            InitializeComponent();
            this.quincenaid = quincenaid; // Asigna el valor recibido
        }
        public string NumeroReporte { get; set; }

        private void frmReporteProduccionGeneralFiltrado_Load(object sender, EventArgs e)
        {
            rptProduccion objReporte = new rptProduccion();
            objReporte.SetParameterValue("@QuincenaID", quincenaid);


            // Obtener el número de reporte generado desde el procedimiento almacenado
           /* Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "06"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);*/

            /*objReporte.SetParameterValue("NumeroReporte", numeroReporte);*/ // Nuevo parámetro

            objReporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objReporte;
            crystalReportViewer1.Refresh();
        }
    }
}
