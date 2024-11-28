using ProyectoADSI2024.Utils;
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
        private Conexion conexion;
        SqlDataAdapter adp;
        //Lista global de los socios que estan en la bd
        private List<KeyValuePair<int, string>> socios;
        DataTable tabIngresoLeche;
        //ToolTips
        System.Windows.Forms.ToolTip toolTip1;
        //private DataGridViewRow filaSeleccionada = null;
        public IngresoDiarioLeche()
        {
            InitializeComponent();
            conexion = new Conexion();
            tabIngresoLeche = new DataTable();
            dgIngresoLeche.SelectionChanged += dgIngresoLeche_SelectionChanged;

            adp = new SqlDataAdapter("spMostrarIngresoLecheDiario", conexion.ObtenerConexion());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //TootTips para los textBox
            toolTips();

            //Cambiar el tamaño de fuente del datagridview
            dgIngresoLeche.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); //Los titulos de columna
            dgIngresoLeche.DefaultCellStyle.Font = new Font("Arial", 12); //Letra global del grid para filas

            //Impedir Resize de columnas y filas
            dgIngresoLeche.AllowUserToResizeColumns = false;
            dgIngresoLeche.AllowUserToResizeRows = false;
            // Cargar los datos al DataGridView desde la base de datos
        }


        private void IngresoDiarioLeche_Load(object sender, EventArgs e)
        {
            LlenarComboBoxSocios();
            txtTexto.Enabled = false;
            CargarDatosActualizados();// Cargar datos al DataGridView
            adp.Fill(tabIngresoLeche);
            dgIngresoLeche.DataSource = tabIngresoLeche;
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
                // Validación de campos
                if (string.IsNullOrWhiteSpace(tBoxDiaID.Text) ||
                    string.IsNullOrWhiteSpace(tboxLAM.Text) ||
                    string.IsNullOrWhiteSpace(tboxLPM.Text) ||
                    cboxSocios.SelectedIndex <= 0 ||
                    string.IsNullOrWhiteSpace(tboxEncargado.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar el formato del campo DiaID (fecha)
                DateTime diaIDDate;
                if (!DateTime.TryParse(tBoxDiaID.Text, out diaIDDate))
                {
                    MessageBox.Show("El campo DiaID debe tener un formato de fecha válido tal como dd/MM/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar el formato numérico de Litros AM y Litros PM
                double litrosAM, litrosPM;
                if (!double.TryParse(tboxLAM.Text, out litrosAM) || litrosAM < 0)
                {
                    MessageBox.Show("El valor de Litros AM debe ser numérico y mayor o igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(tboxLPM.Text, out litrosPM) || litrosPM < 0)
                {
                    MessageBox.Show("El valor de Litros PM debe ser numérico y mayor o igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar selección del ComboBox de socios
                if (cboxSocios.SelectedIndex <= 0)
                {
                    MessageBox.Show("Por favor, seleccione un socio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlConnection con = conexion.ObtenerConexion();
                // Insertar datos en la base de datos
                SqlCommand cmd = new SqlCommand("spProyectoIngLecheInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DiaID", diaIDDate);
                cmd.Parameters.AddWithValue("@SocioID", Convert.ToInt32(cboxSocios.SelectedValue));
                cmd.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
                cmd.Parameters.AddWithValue("@LitroAM", litrosAM);
                cmd.Parameters.AddWithValue("@LitroPM", litrosPM);
                cmd.Parameters.AddWithValue("@Observaciones", tboxObs.Text);
                cmd.Parameters.AddWithValue("@Encargado", tboxEncargado.Text);
                cmd.Parameters.AddWithValue("@Activo", checkBoxActivo.Checked);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                // Restaurar estado
                LimpiarTxtBox();
                // Actualizar el DataGridView
                CargarDatosActualizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                 SqlConnection con = conexion.ObtenerConexion();
                 // Modo de edición: Actualizar la fila seleccionada
                 SqlCommand cmd = new SqlCommand("spProyectoIngLecheUpdate", con);
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
                    
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registro actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar datos en el DataGridView
                CargarDatosActualizados();

                LimpiarTxtBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgIngresoLeche.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Obtener el valor de DiaID como DateTime
                if (!DateTime.TryParse(dgIngresoLeche.CurrentRow.Cells["DiaID"].Value?.ToString(), out DateTime diaid))
                {
                    MessageBox.Show("El valor de DiaID no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Confirmación antes de eliminar
                if (MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                SqlConnection con = conexion.ObtenerConexion();
                // Eliminar registro usando un bloque `using` para liberar recursos
                using (SqlCommand cmdEliminar = new SqlCommand("spEliminarIngresoLecheDiario", con))
                {
                    cmdEliminar.CommandType = CommandType.StoredProcedure;
                    cmdEliminar.Parameters.AddWithValue("@DiaID", diaid);

                    
                    cmdEliminar.ExecuteNonQuery();
                    
                }

                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar datos actualizados
                CargarDatosActualizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //OTROS METODOS
        //Esta funcion es para llenar el comboBox con la lista de socios
        private void LlenarComboBoxSocios()
        {
            string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";
            string query = "SELECT SocioID, Nombre FROM proyecto.Socio";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    BindingList<KeyValuePair<int, string>> socios = new BindingList<KeyValuePair<int, string>>();
                    socios.Add(new KeyValuePair<int, string>(0, "Seleccione un Socio"));

                    while (reader.Read())
                    {
                        int socioId = reader["SocioID"] as int? ?? 0;
                        string nombre = reader["Nombre"] as string ?? "Desconocido";
                        socios.Add(new KeyValuePair<int, string>(socioId, nombre));
                    }

                    reader.Close();

                    // Asignar la lista al ComboBox
                    cboxSocios.DataSource = new BindingSource(socios, null);
                    cboxSocios.DisplayMember = "Value"; // Mostrar el nombre del socio
                    cboxSocios.ValueMember = "Key";     // Guardar el SocioID como valor
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los socios: " + ex.Message);
            }
        }

        //Evento para seleccionar la fila que se quiera editar y mandarlo a los textbox
        private void dgIngresoLeche_SelectionChanged(object sender, EventArgs e)
        {
            if (dgIngresoLeche.SelectedRows.Count == 0 || dgIngresoLeche.CurrentRow == null)
                return;

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
                SqlConnection con = conexion.ObtenerConexion();
                con = conexion.ObtenerConexion(); // Obtener la conexión
                                                  // Configurar el comando para ejecutar el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("spMostrarIngresoLecheDiario", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Crear el adaptador SQL y llenar el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                tabIngresoLeche = new DataTable();
                adapter.Fill(tabIngresoLeche);

                // Asignar el DataTable al DataGridView
                dgIngresoLeche.DataSource = tabIngresoLeche;

                // Ajustar visibilidad de columnas si es necesario
                if (dgIngresoLeche.Columns.Contains("Activo"))
                {
                    dgIngresoLeche.Columns["Activo"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolTips()
        {
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
        }
        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el campo de búsqueda está vacío
            if (txtTexto.Text.Length == 0)
            {
                tabIngresoLeche.DefaultView.RowFilter = ""; // Mostrar todos los datos si no hay texto
            }
            else
            {
                try
                {
                    // Obtener el tipo de la columna seleccionada
                    var columnType = tabIngresoLeche.Columns[cmbCampo.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tabIngresoLeche.DefaultView.RowFilter = $"{cmbCampo.Text} LIKE '%{txtTexto.Text}%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTexto.Text, out int numero))
                        {
                            tabIngresoLeche.DefaultView.RowFilter = $"{cmbCampo.Text} = {numero}";
                        }
                        else
                        {
                            tabIngresoLeche.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTexto.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal numeroDecimal))
                        {
                            tabIngresoLeche.DefaultView.RowFilter = $"{cmbCampo.Text} = {numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                        }
                        else
                        {
                            tabIngresoLeche.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(DateTime)) // Filtro para fechas (día/mes/año)
                    {
                        string inputFecha = txtTexto.Text.Trim();
                        string[] formatosFecha = { "dd/MM/yyyy", "dd/MM" }; // Formatos soportados
                        if (DateTime.TryParseExact(inputFecha, formatosFecha, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                        {
                            // Si el formato es corto (dd/MM), asumir el año actual
                            if (inputFecha.Length <= 5)
                            {
                                dateValue = new DateTime(DateTime.Now.Year, dateValue.Month, dateValue.Day);
                            }

                            // Aplicar filtro con formato MM/dd/yyyy
                            tabIngresoLeche.DefaultView.RowFilter = $"{cmbCampo.Text} = #{dateValue.ToString("MM/dd/yyyy")}#";
                        }
                        else
                        {
                            tabIngresoLeche.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        tabIngresoLeche.DefaultView.RowFilter = "1 = 0"; // Tipo de columna no soportado
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en el filtrado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Actualizar el DataGridView con los datos filtrados
            dgIngresoLeche.DataSource = tabIngresoLeche.DefaultView.ToTable();
        }

        private void cmbCampo_Click(object sender, EventArgs e)
        {
            txtTexto.Enabled = true;
        }

        private void btnGenReporte_Click(object sender, EventArgs e)
        {
            //ReportManager.ShowReport(@"ReporteModuloControlIngresoLeche\rptLecheDiaria.rpt");

            using (frmSeleccionFechaIL FechaSeleccion = new frmSeleccionFechaIL())
            {
                if (FechaSeleccion.ShowDialog() == DialogResult.OK && FechaSeleccion.EsConfirmado)
                {
                    DateTime FechaSeleccionada = FechaSeleccion.FechaSeleccionada;

                    //verificar si hay datos en la base de datos

                    if (DatabaseHelper.HasDataForDate(FechaSeleccionada))
                    {
                        // Si no hay datos, mostrar el reporte
                        
                        //Correlativo No. Reporte, el cual sera seteado en el reporte
                        Report_Manager reportManager = new Report_Manager();
                        string tipoReporte = "01";
                        string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

                        var parametros = new Dictionary<string, object>
                        {
                            {"FechaSeleccionada",FechaSeleccionada },
                            {"numeroReporte", numeroReporte }
                        };

                        //parametros.Add("FechaSeleccionada", FechaSeleccionada.Date);
                        //Mostrar el reporte
                        ReportManager.ShowReport(@"ReporteModuloControlIngresoLeche\rptLechediaria.rpt", parametros);
                    }
                    else
                    {
                        // Si no hay datos, mostrar mensaje
                        MessageBox.Show(
                            "No hay datos disponibles para la fecha seleccionada.",
                            "Datos no encontrados",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                         );
                    }
                }

            }

        }

    }
}

    

