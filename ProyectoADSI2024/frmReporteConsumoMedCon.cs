using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ProyectoADSI2024
{
    public partial class frmReporteConsumoMedCon : Form
    {

        public string NumeroReporte { get; set; }
        public frmReporteConsumoMedCon()
        {
            InitializeComponent();

            


        }

        public int idsocio;

        

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           


        }

        private void frmReporteConsumoMedCon_Load(object sender, EventArgs e)
        {
            crReporteConsumoMedCon objreporte = new crReporteConsumoMedCon();

            objreporte.SetParameterValue("@socioid", idsocio);
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte);
            
            objreporte.SetDatabaseLogon("eugene.wu","EW20212030388","3.128.144.165","DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
        }
    }
}
