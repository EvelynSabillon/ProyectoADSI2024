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
    public partial class frmReporteEntregaQuincenal : Form
    {
        public frmReporteEntregaQuincenal()
        {
            InitializeComponent();
        }

        private void frmReporteEntregaQuincenal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB20212030388DataSet.Quincena' table. You can move, or remove it, as needed.
            this.quincenaTableAdapter.Fill(this.dB20212030388DataSet.Quincena);

        }
    }
}
