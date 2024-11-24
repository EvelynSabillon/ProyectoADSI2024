using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024.Reportes
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        // Método para cargar un reporte.
        public void LoadReport(ReportDocument report)
        {
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();

            report.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
