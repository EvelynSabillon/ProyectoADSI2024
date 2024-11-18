using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class frmVistaDeSocioParaReporteConsumoInsumo : Form
    {
        SqlDataAdapter adpreporte;
        DataTable dtreporte = new DataTable();
        Conexion cnxreporteconsumoinsumo;

        public frmVistaDeSocioParaReporteConsumoInsumo()
        {
            InitializeComponent();
            adpreporte = new SqlDataAdapter();
            cnxreporteconsumoinsumo = new Conexion();
            dtreporte = new DataTable();

            adpreporte = new SqlDataAdapter("spversocios", cnxreporteconsumoinsumo.ObtenerConexion());
            adpreporte.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        private void frmVistaDeSocioParaReporteConsumoInsumo_Load(object sender, EventArgs e)
        {
            adpreporte.Fill(dtreporte);
            dgvistasociosreporte.DataSource = dtreporte;

        }

        private void dgvistasociosreporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmReporteConsumoMedCon objformReporte = new frmReporteConsumoMedCon();
            int idsocio = Convert.ToInt32(dgvistasociosreporte.CurrentRow.Cells[0].Value);

            objformReporte.idsocio = idsocio;
            objformReporte.ShowDialog();
        }
    }
}
