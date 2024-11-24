using ProyectoADSI2024.Reportes.ReporteEntregaQuincenal;
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
    public partial class frmPrincipalEntregaQuincenal : Form
    {
        public frmPrincipalEntregaQuincenal()
        {
            InitializeComponent();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Seleccione una QuincenaID para consultar o imprimir un reporte.","Ayuda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }


        private void frmPrincipalEntregaQuincenal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB20212030388DataSet.Quincena' table. You can move, or remove it, as needed.
            this.quincenaTableAdapter.Fill(this.dB20212030388DataSet.Quincena);

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            subFrmEntregaQuincenal objForm = new subFrmEntregaQuincenal();
            string idQuin = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            objForm.QuincenaID = idQuin;
            objForm.ShowDialog();
        }
    }
}
