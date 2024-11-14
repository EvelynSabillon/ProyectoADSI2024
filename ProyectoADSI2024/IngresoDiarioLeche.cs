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
        //Variables globlales

        //Varibale de conexio a BD
        string url = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";
        SqlConnection conexion;
        SqlDataAdapter adp;

        //Objetos de la capa desconectada
        DataTable tabIngresoLeche;


        //ToolTips
        ToolTip toolTip;
        public IngresoDiarioLeche()
        {
            InitializeComponent();
            this.Load += new EventHandler(IngresoDiarioLeche_Load); //Con este evento me aseguro que la lista de socios me cargue en tiempo real
          
            conexion = new SqlConnection(url);

            adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            
            //Adapter para el insert a la base de datos
            adp.InsertCommand = new SqlCommand("spProyectoIngLecheInsert",conexion);
            adp.InsertCommand.CommandType = CommandType.StoredProcedure;

            //TootTips para los textBox
            toolTip = new ToolTip();
            toolTip.SetToolTip(tBoxDiaID, "Ingrese un número del 1 al 7 según el día de la semana en el que esté.");
            toolTip.SetToolTip(tboxLAM, "Se espera que ingrese un número.");
            toolTip.SetToolTip(tboxLPM, "Se espera que ingrese un número.");
            toolTip.SetToolTip(tboxObs, "Escriba observaciones detalladas para este registro.");
            toolTip.SetToolTip(tboxEncargado, "Ingrese el nombre del encargado.");
            toolTip.SetToolTip(btnGuardar, "Al hacer click se guardará la información previa.");
            toolTip.SetToolTip(btnEditar, "Al hacer click se mostrará toda la información, seleccione o busque lo que quiere editar y al hacer cambios se guardarán automáticamente.")
            toolTip.SetToolTip(btnLimpiar, "Al hacer click se vaciarán los cuadros de texto.");
            toolTip.SetToolTip(btnEliminar, "Algo hace");
            toolTip.SetToolTip(btnGenReporte, "Generará un reporte.");
        
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

                if (!DateTime.TryParse(tBoxDiaID.Text, out diaIDDate))
                {
                    MessageBox.Show("Por favor ingrese una fecha válida para DiaID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detener el proceso de guardado si la fecha no es válida
                }

                //cadena para conectarme a la bd
                SqlCommand cmd = new SqlCommand("spProyectoIngLecheInsert", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DiaID", diaIDDate);
                cmd.Parameters.AddWithValue("@SocioID", Convert.ToInt32(cboxSocios.SelectedValue));
                cmd.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
                cmd.Parameters.AddWithValue("@LitrosAM", Convert.ToDouble(tboxLAM.Text));
                cmd.Parameters.AddWithValue("@LitrosPM", Convert.ToDouble(tboxLPM.Text));
                cmd.Parameters.AddWithValue("@Observaciones", tboxObs.Text);
                cmd.Parameters.AddWithValue("@Encargado", tboxEncargado.Text);
                cmd.Parameters.AddWithValue("@Activo", Convert.ToInt32(checkBoxActivo.Checked));


                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();

                //Limpiamos text boxs al guardar y regresamos el combobox al index 0
                tBoxDiaID.Clear();
                tboxLAM.Clear();
                tboxLPM.Clear();
                tboxObs.Clear();
                tboxEncargado.Clear();
                checkBoxActivo.Checked = false;
                cboxSocios.SelectedIndex = 0;


                MessageBox.Show("Datos guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tboxSocioID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar los text box, regresar el combobox a index 0 y desmarcar el checkbox
            tBoxDiaID.Clear();
            tboxLAM.Clear();
            tboxLPM.Clear();
            tboxObs.Clear();
            tboxEncargado.Clear();
            checkBoxActivo.Checked = false;
            cboxSocios.SelectedIndex = 0;

            MessageBox.Show("Se limpió con éxito los cuadros de texto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarDatosDG();
            dgIngresoLeche.ReadOnly = false;
        }

        //OTROS METODOS
        private void IngresoDiarioLeche_Load(object sender, EventArgs e)
        {
            LlenarComboBoxSocios();
        }

        private void LlenarComboBoxSocios()
        {
            string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";
            string query = "SELECT SocioID, Nombre FROM proyecto.Socio";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var socios = new List<KeyValuePair<int, string>>();
                socios.Add(new KeyValuePair<int, string>(0, "Seleccione un Socio"));

                while (reader.Read())
                {
                    socios.Add(new KeyValuePair<int, string>((int)reader["SocioID"], reader["Nombre"].ToString()));
                }

                reader.Close();

                // Asignar la lista al ComboBox
                cboxSocios.DataSource = new BindingSource(socios, null);
                cboxSocios.DisplayMember = "Value"; // Mostrar el nombre del socio
                cboxSocios.ValueMember = "Key";     // Guardar el SocioID como valor
            }
        }

        private void cboxSocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSocios.SelectedItem != null)
            {
                tBoxSocioID.Text = ((KeyValuePair<int, string>)cboxSocios.SelectedItem).Key.ToString();
            }
        }


        //METODO PARA CARGAR DATOS DE LA BD EN EL DATAGRIDVIEW
        private void CargarDatosDG()
        {
            try
            {
                // Conexión a la base de datos
                using (SqlConnection conexion = new SqlConnection(url))
                {
                    string query = "SELECT * FROM proyecto.IngresoLeche"; 
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

                    tabIngresoLeche = new DataTable();
                    adapter.Fill(tabIngresoLeche);

                    // Asignar el DataTable al DataGridView
                    dgIngresoLeche.DataSource = tabIngresoLeche;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
