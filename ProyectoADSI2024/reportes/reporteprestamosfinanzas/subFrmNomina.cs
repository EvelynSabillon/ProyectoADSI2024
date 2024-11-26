using ProyectoADSI2024.Reportes.ReporteEntregaQuincenal;
using ProyectoADSI2024.Reportes.ReportePrestamosFinanzas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024.Reportes.ReportePrestamosFinanzas
{
    public partial class subFrmNomina : Form
    {
        public subFrmNomina()
        {
            InitializeComponent();
        }

        public string NumeroReporte { get; set; }

        public int quincenaid1;
        public int quincenaid2;

        private void subFrmNomina_Load(object sender, EventArgs e)
        {
            crReporteConsQuincenal objReporte = new crReporteConsQuincenal();
            objReporte.SetParameterValue("@QuincenaID1", quincenaid1);
            objReporte.SetParameterValue("@QuincenaID2", quincenaid2);


            crReporteConsQuincenal objreporte = new crReporteConsQuincenal();
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte); // Nuevo parámetro

            objreporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
            crystalReportViewer1.Refresh();
        }
    }
}




