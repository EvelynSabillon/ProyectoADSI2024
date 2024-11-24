using ProyectoADSI2024.Reportes.ReporteGestionInventario;
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

namespace ProyectoADSI2024
{
    public partial class frmReporteKardexMedicamento : Form
    {
        public string NumeroReporte { get; set; }
        public frmReporteKardexMedicamento()
        {
            InitializeComponent();
        }

        public int articuloid;

        private void frmReporteKardexMedicamento_Load(object sender, EventArgs e)
        {
            rptKardexMedicamento objreporte = new rptKardexMedicamento();

            objreporte.SetParameterValue("@ArticuloMedID", articuloid);
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte); // Nuevo parámetro

            objreporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
        }
    }
}
