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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;

namespace ProyectoADSI2024
{
    public partial class ConsultaQuincenalLeche : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adapter;
        DataTable tabQuincena;

        System.Windows.Forms.ToolTip toolTips;

        public ConsultaQuincenalLeche()
        
        {
            InitializeComponent();
            string connectionString = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
            conexion = new SqlConnection(connectionString);
            toolTipsTxts();
        }


        private void ConsultaQuincenalLeche_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        //BOTONES
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tboxQuincenaid.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand cmd = new SqlCommand("spConsultaQuincenalInsert", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            int quincenaID = int.Parse(tboxQuincenaid.Text);

            cmd.Parameters.AddWithValue("@QuincenaID", quincenaID);
            cmd.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Value); //datetimepicker
            cmd.Parameters.AddWithValue("@FechaFinal", dtpFechaFinal.Value); //datetimepicker

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

            //Limpiar txbos y dtp
            Limpiar();

            //Actualizar tabla
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el préstamo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ELIMINAR UN REGISTRO seleccionado en el DataGridView
                try
                {
                    if (dgConsultaLeche.SelectedRows.Count > 0)
                    {
                        int QuincenaID = Convert.ToInt32(dgConsultaLeche.SelectedRows[0].Cells["QuincenaID"].Value);
                        using (SqlConnection con = new SqlConnection("Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;"))
                        {
                            // Procedimiento almacenado para eliminar el registro
                            using (SqlCommand cmdEliminar = new SqlCommand("spEliminarConsultaQuincenal", con))
                            {
                                cmdEliminar.CommandType = CommandType.StoredProcedure;

                                // Pasar el parámetro QuincenaID
                                cmdEliminar.Parameters.AddWithValue("@QuincenaID", QuincenaID);

                                // Abrir la conexión
                                con.Open();

                                // Ejecutar la eliminación
                                cmdEliminar.ExecuteNonQuery();

                                // Mostrar mensaje de éxito
                                MessageBox.Show("Quincena eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Actualizar la tabla 
                                tabQuincena.Clear(); // Limpiar datos antiguos
                                adapter.Fill(tabQuincena); // Llenar con los nuevos datos

                                // Limpiar los campos del formulario
                                tboxQuincenaid.Text = "";
                                dtpFechaInicio.ResetText();
                                dtpFechaFinal.ResetText();

                                // Actualizar la lista de socios
                                CargarDatos();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un registro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            MessageBox.Show("Se limpió correctamente.","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //FUNCIONES

        //SELECT
        private void CargarDatos()
        {
            try
            {
                 conexion.Open();

                // Adaptador para el SELECT
                adapter = new SqlDataAdapter("spMostrarQuincena", conexion);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Llenar el DataTable
                tabQuincena = new DataTable();
                adapter.Fill(tabQuincena);

                // Asignar al DataGridView
                dgConsultaLeche.DataSource = tabQuincena;

                //Dar formato a las columnas
                if (dgConsultaLeche.Columns["FechaInicio"] != null)
                    dgConsultaLeche.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgConsultaLeche.Columns["FechaFinal"] != null)
                    dgConsultaLeche.Columns["FechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";

                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void toolTipsTxts()
        {
            toolTips = new System.Windows.Forms.ToolTip();
            toolTips.SetToolTip(tboxQuincenaid, "Ingrese un número de Quincena válido");
            toolTips.SetToolTip(tboxMes, "Mes");
            toolTips.SetToolTip(dtpFechaInicio, "Seleccione la fecha en la que iniciará la quincena.");
            toolTips.SetToolTip(dtpFechaFinal, "Seleccione la fecha en la que terminará la quincena.");

        }

        private void Limpiar()
        {
            tboxQuincenaid.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
        }

        
    }
}
