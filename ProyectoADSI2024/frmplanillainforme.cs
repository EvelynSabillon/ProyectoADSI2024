using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class frmplanillainforme : Form
    {

        private Conexion cnx;
        SqlDataAdapter adp;
        DataTable dt;
        public frmplanillainforme()
        {
            InitializeComponent();

            cnx = new Conexion();
            dt = new DataTable();

            adp = new SqlDataAdapter("select planillaid, periodoinicio,periodofinal, precioleche from proyecto.planilla", cnx.ObtenerConexion());
         


        }

        private void frmplanillainforme_Load(object sender, EventArgs e)
        {
            adp.Fill(dt);
            dgverplanilla.DataSource = dt;

        }

        private void dgverplanilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = dgverplanilla.Rows[e.RowIndex];

                // Asigno los valores de las celdas a los TextBox
                txtidplanilla.Text = filaSeleccionada.Cells["planillaid"].Value?.ToString();
                txtplanilla.Text = filaSeleccionada.Cells["periodoinicio"].Value?.ToString();
                

            }
        }

        private void btngenreporte_Click(object sender, EventArgs e)
        {
            frmInformePago informeparametro = new frmInformePago();
            informeparametro.idplanilla = Convert.ToInt32(txtidplanilla.Text);
            informeparametro.ShowDialog();
        }
    }
}
