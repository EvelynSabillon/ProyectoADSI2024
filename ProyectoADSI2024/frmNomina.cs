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
//using ProyectoADSI2024; //Mandar a llamar el form del reporte de la nomina

namespace ProyectoADSI2024
{
    public partial class frmNomina : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server
        public frmNomina()
        {
            InitializeComponent();

            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spPlanillaSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged; // Suscribirse al evento

            // Configurar ToolTips
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(btnGenReporte, "Generar reporte de nomina");
            toolTip1.SetToolTip(btnAtras, "Volver al menu principal");
            toolTip1.SetToolTip(btnEditar, "Editar registro seleccionado");
            toolTip1.SetToolTip(btnEliminar, "Eliminar registro seleccionado");
            toolTip1.SetToolTip(btnGuardar, "Agregar nuevo registro");
            toolTip1.SetToolTip(dataGridView1, "Seleccionar registro para editar o eliminar");
            toolTip1.SetToolTip(lblMes, "Mes actual");
            toolTip1.SetToolTip(txtPlanillaID, "ID de la planilla");
            toolTip1.SetToolTip(txtQuincenaID, "ID de la quincena");
            toolTip1.SetToolTip(dtpFechaInicio, "Seleccione una fecha de inicio de la quincena");
            toolTip1.SetToolTip(dtpFechaFinal, "Selecione una fecha de fin de la quincena");
            toolTip1.SetToolTip(txtPrecioLeche, "Precio de la leche actual");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmNomina_Load(object sender, EventArgs e)
        {
            try
            {
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Asignar la tabla al datagridview

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerMes_Tick(object sender, EventArgs e)
        {
            lblMes.Text = DateTime.Now.ToString("MMMM");
        }

        private void btnGenReporte_Click_1(object sender, EventArgs e)
        {
            frmDialogNomina frmNomina = new frmDialogNomina();
            frmNomina.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
