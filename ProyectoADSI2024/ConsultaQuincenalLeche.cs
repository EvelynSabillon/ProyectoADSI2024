using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoADSI2024
{
    public partial class ConsultaQuincenalLeche : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adapter;
        DataTable tabQuincena;
        
        public ConsultaQuincenalLeche()
        
        {
            InitializeComponent();
            string connectionString = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
            conexion = new SqlConnection(connectionString); 
        }


        private void ConsultaQuincenalLeche_Load(object sender, EventArgs e)
        {
            
        }

        //BOTONES
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand("spConsultaQuincenalInsert", conexion);
                insertCmd.CommandType = CommandType.StoredProcedure;

                // Asignar parámetros desde los controles
                insertCmd.Parameters.AddWithValue("@QuincenaID", int.Parse(tboxQuincenaid.Text));
                insertCmd.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Value);
                insertCmd.Parameters.AddWithValue("@FechaFinal", dtpFechaFinal.Value);
                insertCmd.Parameters.AddWithValue("@Activo", 1);

                int filasAfectadas = insertCmd.ExecuteNonQuery();
                MessageBox.Show($"Registros insertados: {filasAfectadas}");

                conexion.Open();
                insertCmd.ExecuteNonQuery();
                conexion.Close();
                // Refrescar los datos
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
            }
        }

        //FUNCIONES

        private void CargarDatos()
        {
            try
            {
                 conexion.Open();

                // Adaptador para el SELECT
                adapter = new SqlDataAdapter("spMostrarIngresoLecheDiario", conexion);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Llenar el DataTable
                tabQuincena = new DataTable();
                adapter.Fill(tabQuincena);

                // Asignar al DataGridView
                dgConsultaLeche.DataSource = tabQuincena;
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        
    }
}
