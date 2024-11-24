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
        public subFrmEntregaQuincenal()
        {
            InitializeComponent();
        }
        public string QuincenaID;
        private void subFrmEntregaQuincenal_Load(object sender, EventArgs e)
        {
            ReporteEntregasQuincenal objReporte = new ReporteEntregasQuincenal();
            objReporte.SetParameterValue("@QuincenaID",QuincenaID);
            crystalReportViewer1.ReportSource = objReporte;
        }
    }
}
