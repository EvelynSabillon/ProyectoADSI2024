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
        DateTime diaIDDate;
        
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
            
            // Validación de campos
            
            double litrosAM = 0;
            double litrosPM = 0;
            bool esValido = true;
            errorProvider.Clear(); 
            if (string.IsNullOrWhiteSpace(tBoxDiaID.Text))
            {
                errorProvider.SetError(tBoxDiaID, "El campo DiaID no puede estar vacío.");
                esValido = false;
            }
            else if (!DateTime.TryParse(tBoxDiaID.Text, out diaIDDate))
            {
                errorProvider.SetError(tBoxDiaID, "El campo DiaID debe tener un formato de fecha válido (dd/MM/yyyy).");
                esValido = false;
            }

            // Validar el formato numérico de Litros AM y Litros PM
            if (string.IsNullOrWhiteSpace(tboxLAM.Text) || !double.TryParse(tboxLAM.Text, out litrosAM) || litrosAM < 0)
            {
                errorProvider.SetError(tboxLAM, "El valor de Litros AM debe ser numérico y mayor o igual a 0.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tboxLPM.Text) || !double.TryParse(tboxLPM.Text, out litrosPM) || litrosPM < 0)
            {
                errorProvider.SetError(tboxLPM, "El valor de Litros PM debe ser numérico y mayor o igual a 0.");
                esValido = false;
            }

            // Validar selección del ComboBox de socios
            if (cboxSocios.SelectedIndex <= 0)
            {
                errorProvider.SetError(cboxSocios, "Debe seleccionar un socio válido.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tboxEncargado.Text))
            {
                errorProvider.SetError(tboxEncargado, "El campo Encargado no puede estar vacío.");
                esValido = false;
            }

            if (!esValido)
            {
                MessageBox.Show("Corrija los errores marcados antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            
            try
            {
                if (MessageBox.Show("¿Desea guardar la Salida?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
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

                    MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Restaurar estado
                    LimpiarTxtBox();
                    // Actualizar el DataGridView
                    CargarDatosActualizados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
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
            // Limpiar errores previos del ErrorProvider
            errorProvider.Clear();
            double litroAM = 0;
            double litroPM = 0;
            // Variable para controlar si hay errores
            bool esValido = true;

            // Validar si se seleccionó una fila
            if (dgIngresoLeche.CurrentRow == null)
            {
                errorProvider.SetError(dgIngresoLeche, "Seleccione un registro para editar.");
                esValido = false;
            }

            // Validar campos vacíos y valores incorrectos
            if (string.IsNullOrWhiteSpace(tBoxDiaID.Text))
            {
                errorProvider.SetError(tBoxDiaID, "El campo Día ID no puede estar vacío.");
                esValido = false;
            }
            else if (!DateTime.TryParse(tBoxDiaID.Text, out DateTime diaIDDate))
            {
                errorProvider.SetError(tBoxDiaID, "El campo Día ID debe tener un formato de fecha válido (dd/MM/yyyy).");
                esValido = false;
            }

            if (cboxSocios.SelectedIndex <= 0)
            {
                errorProvider.SetError(cboxSocios, "Debe seleccionar un socio válido.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tboxLAM.Text) || !double.TryParse(tboxLAM.Text, out double litrosAM) || litrosAM < 0)
            {
                errorProvider.SetError(tboxLAM, "El campo Litro AM debe contener un valor numérico mayor o igual a cero.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tboxLPM.Text) || !double.TryParse(tboxLPM.Text, out double litrosPM) || litrosPM < 0)
            {
                errorProvider.SetError(tboxLPM, "El campo Litro PM debe contener un valor numérico mayor o igual a cero.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tboxObs.Text))
            {
                errorProvider.SetError(tboxObs, "El campo Observaciones no puede estar vacío.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tboxEncargado.Text))
            {
                errorProvider.SetError(tboxEncargado, "El campo Encargado no puede estar vacío.");
                esValido = false;
            }

            if (dateTimePickerFecha.Value.Date > DateTime.Now.Date)
            {
                errorProvider.SetError(dateTimePickerFecha, "La fecha no puede ser una fecha futura.");
                esValido = false;
            }

            // Si hay errores, mostrar mensaje y detener el proceso
            if (!esValido)
            {
                MessageBox.Show("Corrija los errores marcados antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todas las validaciones son exitosas, proceder a la actualización
            try
            {
                if (MessageBox.Show("¿Desea editar el registro actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = conexion.ObtenerConexion();
                    SqlCommand cmd = new SqlCommand("spProyectoIngLecheUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado para actualizar
                    cmd.Parameters.AddWithValue("@DiaID", DateTime.Parse(tBoxDiaID.Text));
                    cmd.Parameters.AddWithValue("@SocioID", Convert.ToInt32(cboxSocios.SelectedValue));
                    cmd.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
                    cmd.Parameters.AddWithValue("@LitroAM", litroAM);
                    cmd.Parameters.AddWithValue("@LitroPM", litroPM);
                    cmd.Parameters.AddWithValue("@Observaciones", tboxObs.Text);
                    cmd.Parameters.AddWithValue("@Encargado", tboxEncargado.Text);
                    cmd.Parameters.AddWithValue("@Activo", checkBoxActivo.Checked);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar datos en el DataGridView
                    CargarDatosActualizados();

                    LimpiarTxtBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrese de que los datos están en el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgIngresoLeche.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Obtener el valor de DiaID como DateTime
                    if (!DateTime.TryParse(dgIngresoLeche.CurrentRow.Cells["DiaID"].Value?.ToString(), out DateTime diaid))
                    {
                        MessageBox.Show("El valor de DiaID no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            { 
                return;
            }

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

                tBoxDiaID.ReadOnly = true;  // Bloquear edición del TextBox
                cboxSocios.Enabled = false; // Bloquear selección en el ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Funcion para limpiar textboxs
        private void LimpiarTxtBox()
        {
            errorProvider.Clear();
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
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseAnimation = true;
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
            if (MessageBox.Show("¿Desea generar un reporte de Ingreso de Leche Diario ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
}

    

