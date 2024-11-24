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
using ProyectoADSI2024.Reportes.ReporteGestionInventario;

namespace ProyectoADSI2024
{
    public partial class frmReporteKardexConcentrado : Form
    {
        public ReportDocument Reporte { get; set; }
        public string NumeroReporte { get; set; }
        public int articuloid;
        public frmReporteKardexConcentrado()
        {
            InitializeComponent();
        }


        private void frmReporteKardexConcentrado_Load(object sender, EventArgs e)
        {
            rptKardexConcentrado objreporte = new rptKardexConcentrado();
            
            objreporte.SetParameterValue("@ArticuloConID", articuloid);
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte); // Nuevo parámetro

            objreporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
        }
    }
}
