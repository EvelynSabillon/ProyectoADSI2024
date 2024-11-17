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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoADSI2024
{
    public partial class IngresoDiarioLeche : Form
    {
        //Variables globlales

        //Varibale de conexion a BD
        string url = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";
        SqlConnection conexion;
        SqlDataAdapter adp;

        private DataGridViewRow filaSeleccionada = null;
        DataTable tabIngresoLeche;

        //ToolTips
        System.Windows.Forms.ToolTip toolTip1;

        //Lista global de los socios que estan en la bd
        private List<KeyValuePair<int, string>> socios;

        public IngresoDiarioLeche()
        {
            InitializeComponent();
            this.Load += new EventHandler(IngresoDiarioLeche_Load); //Con este evento me aseguro que la lista de socios me cargue en tiempo real

            conexion = new SqlConnection(url);

            adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();

            //Adapter para el insert a la base de datos
            adp.InsertCommand = new SqlCommand("spProyectoIngLecheInsert", conexion);
            adp.InsertCommand.CommandType = CommandType.StoredProcedure;

            //TootTips para los textBox
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(tBoxDiaID, "Ingrese la fecha de hoy");
            toolTip1.SetToolTip(tboxLAM, "Se espera que ingrese un número.");
            toolTip1.SetToolTip(tboxLPM, "Se espera que ingrese un número.");
            toolTip1.SetToolTip(tboxObs, "Escriba observaciones detalladas para este registro.");
            toolTip1.SetToolTip(tboxEncargado, "Ingrese el nombre del encargado.");
            toolTip1.SetToolTip(btnGuardar, "Al hacer click se guardará la información previa.");
            toolTip1.SetToolTip(btnEditar, "Seleccione una fila de la tabla para editar. Hacer click en el botón de Editar para guardar los cam");
            toolTip1.SetToolTip(btnLimpiar, "Al hacer click se vaciarán los cuadros de texto.");
            toolTip1.SetToolTip(btnEliminar, "Se eliminará un registro al hacer click");
            toolTip1.SetToolTip(btnGenReporte, "Generará un reporte de ingreso diario.");
            toolTip1.SetToolTip(checkBoxActivo, "Al desmarcarlo se ocultará el registro actual.");

            //Cambiar el tamaño de fuente del datagridview
            dgIngresoLeche.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); //Los titulos de columna
            dgIngresoLeche.DefaultCellStyle.Font = new Font("Arial", 12); //Letra global del grid para filas

            //Impedir Resize de columnas y filas
            dgIngresoLeche.AllowUserToResizeColumns = false;
            dgIngresoLeche.AllowUserToResizeRows = false;
            // Cargar los datos al DataGridView desde la base de datos
            CargarDatosActualizados();

            //MODIFICABLE O BORRABLE
            dgIngresoLeche.DataBindingComplete += DgIngresoLeche_Load;
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
                //Convertir a formato DateTime 
                DateTime diaIDDate = DateTime.Parse(tBoxDiaID.Text);

                // Convertir y validar datos numéricos
                double litrosAM;
                if (!double.TryParse(tboxLAM.Text, out litrosAM))
                {
                    MessageBox.Show("El valor de LitrosAM debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double litrosPM;
                if (!double.TryParse(tboxLPM.Text, out litrosPM))
                {
                    MessageBox.Show("El valor de LitrosPM debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Modo de insert: Guardar un nuevo registro
                SqlCommand cmd = new SqlCommand("spProyectoIngLecheInsert", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DiaID", DateTime.Parse(tBoxDiaID.Text));
                cmd.Parameters.AddWithValue("@SocioID", Convert.ToInt32(cboxSocios.SelectedValue));
                cmd.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
                cmd.Parameters.AddWithValue("@LitroAM", Convert.ToDouble(tboxLAM.Text));
                cmd.Parameters.AddWithValue("@LitroPM", Convert.ToDouble(tboxLPM.Text));
                cmd.Parameters.AddWithValue("@Observaciones", tboxObs.Text);
                cmd.Parameters.AddWithValue("@Encargado", tboxEncargado.Text);
                cmd.Parameters.AddWithValue("@Activo", checkBoxActivo.Checked);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();


                LimpiarTxtBox();

                MessageBox.Show("Datos guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar los text box, regresar el combobox a index 0 y desmarcar el checkbox
            LimpiarTxtBox();

            MessageBox.Show("Se limpió con éxito los cuadros de texto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {

                    // Modo de edición: Actualizar la fila seleccionada
                    SqlCommand cmd = new SqlCommand("spProyectoIngLecheUpdate", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado para actualizar
                    cmd.Parameters.AddWithValue("@DiaID", DateTime.Parse(tBoxDiaID.Text));
                    cmd.Parameters.AddWithValue("@SocioID", Convert.ToInt32(cboxSocios.SelectedValue));
                    cmd.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
                    cmd.Parameters.AddWithValue("@LitroAM", Convert.ToDouble(tboxLAM.Text));
                    cmd.Parameters.AddWithValue("@LitroPM", Convert.ToDouble(tboxLPM.Text));
                    cmd.Parameters.AddWithValue("@Observaciones", tboxObs.Text);
                    cmd.Parameters.AddWithValue("@Encargado", tboxEncargado.Text);
                    cmd.Parameters.AddWithValue("@Activo", checkBoxActivo.Checked);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Registro actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar datos en el DataGridView
                CargarDatosActualizados();

                LimpiarTxtBox();

                // Habilitar selección de fila y edición
                dgIngresoLeche.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgIngresoLeche.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Obtener el valor de la celda DiaID como DateTime
                DateTime diaid = Convert.ToDateTime(dgIngresoLeche.CurrentRow.Cells["DiaID"].Value);
                SqlCommand cmdEliminar = new SqlCommand("spEliminarIngresoLecheDiario", conexion);
                cmdEliminar.CommandType = CommandType.StoredProcedure;
                cmdEliminar.Parameters.AddWithValue("DiaID", diaid);

                conexion.Open();
                cmdEliminar .ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los datos del DataGridView
                CargarDatosActualizados();
            }
            catch (Exception ex) {

                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        //OTROS METODOS
        private void IngresoDiarioLeche_Load(object sender, EventArgs e)
        {
            LlenarComboBoxSocios();
        }


        //Esta funcion es para llenar el comboBox con la lista de socios
        private void LlenarComboBoxSocios()
        {
            string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";
            string query = "SELECT SocioID, Nombre FROM proyecto.Socio";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                socios = new List<KeyValuePair<int, string>>();
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


        //METODO PARA CARGAR DATOS DE LA BD EN EL DATAGRIDVIEW
        private void CargarDatosDG()
        {
            try
            {
                // Conexión a la base de datos
                using (SqlConnection conexion = new SqlConnection(url))
                {
                    string query = "SELECT * FROM proyecto.IngresoLeche ORDER BY DiaID desc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

                    //Instancia del datatable
                    tabIngresoLeche = new DataTable();
                    //LLenamos con la informacion la tablaa
                    adapter.Fill(tabIngresoLeche);

                    // Asignar el DataTable al DataGridView
                    dgIngresoLeche.DataSource = tabIngresoLeche;
                    dgIngresoLeche.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Evento para seleccionar la fila que se quiera editar y mandarlo a los textbox
        private void dgIngresoLeche_SelectionChanged(object sender, EventArgs e)
        {
            if ( dgIngresoLeche.CurrentRow == null) return; // No hacer nada si está cargando

            try
            {
                // Pasar datos al formulario desde la fila seleccionada
                DataGridViewRow filaSeleccionada = dgIngresoLeche.CurrentRow;

                tBoxDiaID.Text = filaSeleccionada.Cells["DiaID"].Value.ToString();
                dateTimePickerFecha.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value);
                tboxLAM.Text = filaSeleccionada.Cells["LitroAM"].Value.ToString();
                tboxLPM.Text = filaSeleccionada.Cells["LitroPM"].Value.ToString();
                tboxObs.Text = filaSeleccionada.Cells["Observaciones"].Value.ToString();
                tboxEncargado.Text = filaSeleccionada.Cells["Encargado"].Value.ToString();
                checkBoxActivo.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                cboxSocios.SelectedValue = Convert.ToInt32(filaSeleccionada.Cells["SocioID"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void IngresoDiarioLeche_Load(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            LlenarComboBoxSocios(); // Llenar el ComboBox de socios
            CargarDatosActualizados();        // Cargar datos al DataGridView

            dgIngresoLeche.ClearSelection();
        }

        private void DgIngresoLeche_Load(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Validar si el DataGridView tiene datos
            if (dgIngresoLeche.Rows.Count > 0)
            {
                dgIngresoLeche.ClearSelection(); // Deseleccionar cualquier fila inicial
            }
           
        }

        //Funcion para limpiar textboxs
        private void LimpiarTxtBox()
        {
            tBoxDiaID.Clear();
            tboxLAM.Clear();
            tboxLPM.Clear();
            tboxObs.Clear();
            tboxEncargado.Clear();
            checkBoxActivo.Checked = false;
            cboxSocios.SelectedIndex = 0;
            dateTimePickerFecha.Value = DateTime.Now;
        }


        private void CargarDatosActualizados()
        {
            try
            {
                // Conexión a la base de datos
                using (SqlConnection conexion = new SqlConnection(url))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Configurar el comando para ejecutar el procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("spMostrarIngresoLecheDiario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Crear el adaptador SQL y llenar el DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    tabIngresoLeche = new DataTable();
                    adapter.Fill(tabIngresoLeche);

                    // Asignar el DataTable al DataGridView
                    dgIngresoLeche.DataSource = tabIngresoLeche;
                    dgIngresoLeche.ClearSelection(); // Limpiar selección inicial
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

    

