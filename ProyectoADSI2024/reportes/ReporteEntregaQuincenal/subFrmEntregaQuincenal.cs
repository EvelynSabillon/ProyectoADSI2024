using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProyectoADSI2024.Reportes.ReporteEntregaQuincenal
{
    public partial class subFrmEntregaQuincenal : Form
    {
        public string NumeroReporte { get; set; }
        public subFrmEntregaQuincenal()
        {
            InitializeComponent();
        }
        public string QuincenaID;
        //public DateTime FechaInicio;
        //public DateTime FechaFinal;

        private void subFrmEntregaQuincenal_Load(object sender, EventArgs e)
        {
            ReporteEntregasQuincenal objReporte = new ReporteEntregasQuincenal();
            objReporte.SetParameterValue("@QuincenaID",QuincenaID);
            objReporte.SetParameterValue("NumeroReporte", NumeroReporte);
            //objReporte.SetParameterValue("@FechaInicio", FechaInicio);  // Pasar la fecha de inicio
            //objReporte.SetParameterValue("@FechaFinal", FechaFinal);
            objReporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objReporte;
        }
    }
}
