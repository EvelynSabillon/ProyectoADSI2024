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
            int quincenaID = int.Parse(tboxQuincenaid.Text);
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFinal = dtpFechaFinal.Value;
            
            // Determinar si es un INSERT o UPDATE
            if (EsNuevoRegistro(quincenaID)) // Función para verificar si el registro ya existe
            {
                // Llamar a procedimiento almacenado para INSERT
                InsertarQuincena(quincenaID, fechaInicio, fechaFinal);
            }
            else
            {
                // Llamar a procedimiento almacenado para UPDATE
                ActualizarQuincena(quincenaID, fechaInicio, fechaFinal);
            }
        }

        //FUNCIONES

        //SELECT
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

        //INSERT
        private void InsertarQuincena(int quincenaID, DateTime fechaInicio, DateTime fechaFinal)
        {
            
                using (SqlCommand cmd = new SqlCommand("spConsultaQuincenalInsert", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@QuincenaID", quincenaID);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinal", fechaFinal);

                    
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Datos guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                }
            
        }

        //UPDATE
        private void ActualizarQuincena(int quincenaID, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("spConsultaLecheUpdate", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@QuincenaID", quincenaID);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinal", fechaFinal);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Quincena actualizada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la quincena: " + ex.Message);
            }
        }


        private bool EsNuevoRegistro(int quincenaID)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM proyecto.Quincena WHERE QuincenaID = @QuincenaID", conexion))
            {
                cmd.Parameters.AddWithValue("@QuincenaID", quincenaID);

                try
                {
                    conexion.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0; // Si no existe, es un nuevo registro
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el registro: " + ex.Message);
                    return false; // Considerar que no es nuevo en caso de error
                }
            }
        }
    }
}
