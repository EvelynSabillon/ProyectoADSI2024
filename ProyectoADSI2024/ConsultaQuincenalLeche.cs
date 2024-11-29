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
            try
            {
                CargarDatos();
                //Obtener el mes actual para el textbox Mes
                string mesActual = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));

                //Asignar el mes al textbox
                tboxMes.Text = char.ToUpper(mesActual[0]) + mesActual.Substring(1);

                txtTexto.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BOTONES
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Limpiar errores anteriores
            errorProvider.Clear();
            bool esValido = true;

            // Validar si el campo QuincenaID está vacío o no es un número válido
            if (string.IsNullOrWhiteSpace(tboxQuincenaid.Text))
            {
                errorProvider.SetError(tboxQuincenaid, "El campo Quincena ID no puede estar vacío.");
                esValido = false;
            }
            else if (!int.TryParse(tboxQuincenaid.Text, out int quincenaID))
            {
                errorProvider.SetError(tboxQuincenaid, "El campo Quincena ID debe contener un número válido.");
                esValido = false;
            }

            // Validar si las fechas de los DateTimePickers están configuradas
            if (dtpFechaInicio.Value == DateTime.MinValue)
            {
                errorProvider.SetError(dtpFechaInicio, "Seleccione una fecha de inicio válida.");
                esValido = false;
            }

            if (dtpFechaFinal.Value == DateTime.MinValue)
            {
                errorProvider.SetError(dtpFechaFinal, "Seleccione una fecha final válida.");
                esValido = false;
            }
            else if (dtpFechaFinal.Value < dtpFechaInicio.Value)
            {
                errorProvider.SetError(dtpFechaFinal, "La fecha final no puede ser anterior a la fecha de inicio.");
                esValido = false;
            }

            // Si hay errores, mostrar mensaje y detener el proceso
            if (!esValido)
            {
                MessageBox.Show("Corrija los errores marcados antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Desea guardar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
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
                    MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Actualizar tabla
                    CargarDatos();
                }catch(Exception ex)
                {
                    MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ELIMINAR UN REGISTRO seleccionado en el DataGridView
                try
                {
                    if (dgConsultaLeche.SelectedRows.Count > 0)
                    {
                        int QuincenaID = Convert.ToInt32(dgConsultaLeche.SelectedRows[0].Cells["QuincenaID"].Value);
                        try
                        {
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
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                //Ajustar el tamanio de las columnas de datagrid
                dgConsultaLeche.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //Ocultar activo
                /*if (dgConsultaLeche.Columns.Contains("Activo"))
                {
                    dgConsultaLeche.Columns["Activo"].Visible = false;
                }
                */
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
            toolTips.IsBalloon = true;
            toolTips.ToolTipIcon = ToolTipIcon.Info;
            toolTips.ToolTipTitle = "Ayuda";
            toolTips.UseAnimation = true;
            toolTips.SetToolTip(tboxQuincenaid, "Ingrese un número de Quincena válido");
            toolTips.SetToolTip(tboxMes, "Mes");
            toolTips.SetToolTip(dtpFechaInicio, "Seleccione la fecha en la que iniciará la quincena.");
            toolTips.SetToolTip(dtpFechaFinal, "Seleccione la fecha en la que terminará la quincena.");
            toolTips.SetToolTip(btnGuardar,"Guarda un nuevo registro al hacer click.");
            toolTips.SetToolTip(btnAtras,"Regresará al menú.");
            toolTips.SetToolTip(btnEliminar, "Ocultará el registro");
            toolTips.SetToolTip(btnLimpiar,"Limpiar los cuadros de texto y fechas.");
            toolTips.SetToolTip(btnGenReporte,"Generar un reporte de la última quincena");

        }

        private void Limpiar()
        {
            errorProvider.Clear();
            txtTexto.Enabled = false;
            tboxQuincenaid.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
        }

        private void dgConsultaLeche_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgConsultaLeche.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgConsultaLeche.SelectedRows[0];
                    tboxQuincenaid.Text = row.Cells["QuincenaID"].Value.ToString();
                    
                    dtpFechaInicio.Value = Convert.ToDateTime(row.Cells["FechaInicio"].Value);
                    dtpFechaFinal.Value = Convert.ToDateTime(row.Cells["FechaFinal"].Value);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al seleccionar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabQuincena.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = tabQuincena.Columns[cmbCampo.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tabQuincena.DefaultView.RowFilter = cmbCampo.Text + " LIKE '%" + txtTexto.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTexto.Text, out int numero))
                        {
                            tabQuincena.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                        }
                        else
                        {
                            tabQuincena.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTexto.Text, out decimal numeroDecimal))
                        {
                            tabQuincena.DefaultView.RowFilter = cmbCampo.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            tabQuincena.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(DateTime)) // Filtro para fechas (día/mes/año)
                    {
                        string inputFecha = txtTexto.Text.Trim();
                        string[] formatosFecha = { "dd/MM/yyyy", "dd/MM" }; // Soportar "día/mes/año" y "día/mes"
                        DateTime dateValue;

                        if (DateTime.TryParseExact(inputFecha, formatosFecha, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                        {
                            // Si no se proporciona el año, agregar el año actual
                            if (inputFecha.Length <= 5) // Formato corto: "dd/MM"
                            {
                                dateValue = new DateTime(DateTime.Now.Year, dateValue.Month, dateValue.Day);
                            }

                            // Convertir la fecha al formato requerido por RowFilter: "MM/dd/yyyy"
                            tabQuincena.DefaultView.RowFilter = cmbCampo.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            tabQuincena.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        tabQuincena.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dgConsultaLeche.DataSource = tabQuincena.DefaultView.ToTable();
        }

        private void cmbCampo_Click(object sender, EventArgs e)
        {
            txtTexto.Enabled = true;
        }

        private void btnGenReporte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar un reporte de /*Nombre del Reporte*/ ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmReporteConsQuincenal frmConsulta = new FrmReporteConsQuincenal();

                Report_Manager reportManager = new Report_Manager();
                string tipoReporte = "04"; // Tipo de reporte (puedes adaptarlo según sea necesario)
                string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

                // Pasar el número de reporte al formulario
                frmConsulta.NumeroReporte = numeroReporte;

                frmConsulta.ShowDialog();
            }
        }
    }
}
