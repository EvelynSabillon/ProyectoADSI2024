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
        public int quincenaid1;
        public int quincenaid2;

        public subFrmNomina()
        {
            InitializeComponent();
        }

        public subFrmNomina(int quincenaid1,  int quincenaid2)
        {
            InitializeComponent();
            this.quincenaid1 = quincenaid1; // Recibir el ID de quincena
            this.quincenaid2 = quincenaid2; // Recibir el ID de quincena
        }

        public string NumeroReporte { get; set; }

        private void subFrmNomina_Load(object sender, EventArgs e)
        {
            crReporteConsQuincenal objReporte = new crReporteConsQuincenal();
            objReporte.SetParameterValue("@QuincenaID1", quincenaid1);
            objReporte.SetParameterValue("@QuincenaID2", quincenaid2);

            objReporte.SetParameterValue("NumeroReporte", NumeroReporte); // Nuevo parámetro

            objReporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objReporte;
            crystalReportViewer1.Refresh();
        }
    }
}




