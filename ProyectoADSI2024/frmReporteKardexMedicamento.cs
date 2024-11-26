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
        private int articuloId;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        public string NumeroReporte { get; set; }
        public frmReporteKardexMedicamento()
        {
            InitializeComponent();
        }

        public frmReporteKardexMedicamento(int articuloId, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            this.articuloId = articuloId;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;

        }

        private void frmReporteKardexMedicamento_Load(object sender, EventArgs e)
        {
            rptKardexMedicamento objreporte = new rptKardexMedicamento();

            objreporte.SetParameterValue("@ArticuloMedID", articuloId);
            objreporte.SetParameterValue("@FechaInicio", fechaInicio);
            objreporte.SetParameterValue("@FechaFin", fechaFin);
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte); // Nuevo parámetro

            objreporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
        }
    }
}
