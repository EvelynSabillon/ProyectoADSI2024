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
    public partial class frmContenedorConsumoInsumoReparado : Form
    {
        public string NumeroReporte { get; set; }
        public frmContenedorConsumoInsumoReparado()
        {
            InitializeComponent();
        }
        public int idsocio;
        private void frmContenedorConsumoInsumoReparado_Load(object sender, EventArgs e)
        {
            crReporteConsumoInsumoReparado objreporte = new crReporteConsumoInsumoReparado();

            objreporte.SetParameterValue("@socioid", idsocio);
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte);

            objreporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
        }
    }
}
