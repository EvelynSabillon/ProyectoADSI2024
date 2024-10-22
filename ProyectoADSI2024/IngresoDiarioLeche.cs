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
    public partial class IngresoDiarioLeche : Form
    {
        public IngresoDiarioLeche()
        {
            InitializeComponent();
        }

        private void IngresoDiarioLeche_Load(object sender, EventArgs e)
        {
            CargarSocios(); // Llenar el ComboBox al abrir el formulario
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime diaIDDate = DateTime.Parse(tBoxDiaID.Text);
                string url = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";
                SqlConnection conexion = new SqlConnection(url);
                SqlCommand cmd = new SqlCommand("spProyectoIngLecheInsert", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DiaID", diaIDDate);
                cmd.Parameters.AddWithValue("@SocioID", Convert.ToInt32(cboxSocios.SelectedValue));
                cmd.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
                cmd.Parameters.AddWithValue("@LitrosAM", Convert.ToDecimal(tboxLAM.Text));
                cmd.Parameters.AddWithValue("@LitrosPM", Convert.ToDecimal(tboxLPM.Text));
                cmd.Parameters.AddWithValue("@Observaciones", tboxObs.Text);
                cmd.Parameters.AddWithValue("@Encargado", tboxEncargado.Text);
                cmd.Parameters.AddWithValue("@Activo", chboxActivo.Checked ? 1 : 0);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para cargar la lista de Socios en el combo box
        private void CargarSocios()
        {
            string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spProyectoIngLecheSocioInsert", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // Abre la conexión
                    conexion.Open();

                    // Llena el DataTable con los resultados del SP
                    da.Fill(dt);

                    cboxSocios.DataSource = dt;
                    cboxSocios.DisplayMember = "Nombre";   // Mostrar nombres en el ComboBox
                    cboxSocios.ValueMember = "SocioID";    // SocioID será el valor asociado a cada nombre
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de socios: " + ex.Message);
                }
                finally
                {
                    // Cierra la conexión
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }

        //Modificable
        private void cboxSocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSocios.SelectedValue != null)
            {
                // Muestra el SocioID en el TextBox
                tboxSocioID.Text = cboxSocios.SelectedValue.ToString();
            }
        }

    }
}
