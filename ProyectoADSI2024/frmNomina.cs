using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
                txtTexto.Enabled = false;

                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Asignar la tabla al datagridview

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
                toolTip1.SetToolTip(txtPlanillaID, "ID de la planilla. Campo solo de lectura");
                toolTip1.SetToolTip(txtQuincenaID, "Seleccione el ID de la quincena");
                toolTip1.SetToolTip(dtpFechaInicio, "Seleccione una fecha de inicio de la quincena");
                toolTip1.SetToolTip(dtpFechaFinal, "Selecione una fecha de fin de la quincena");
                toolTip1.SetToolTip(txtPrecioLeche, "Ingrese el precio de la leche actual");
                toolTip1.SetToolTip(btnSeleccionar, "Haga click aquí para seleccionar el Id de quincena y fechas correspondientes.");
                toolTip1.SetToolTip(btnAyuda, "Haga click aquí para ver el modo de uso del formulario.");
                toolTip1.SetToolTip(cmbCampo, "Seleccione el campo por el cual desea filtrar los registros.");
                toolTip1.SetToolTip(txtTexto, "Ingrese el texto a buscar en el campo seleccionado.");
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
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    txtPlanillaID.Text = row.Cells["PlanillaID"].Value.ToString();
                    txtQuincenaID.Text = row.Cells["QuincenaID"].Value.ToString();
                    //Cuando aparezca el ID de Socio se debe autoseleccionar el valor en el cmbNombre Socio
                    dtpFechaInicio.Value = Convert.ToDateTime(row.Cells["PeriodoInicio"].Value);
                    dtpFechaFinal.Value = Convert.ToDateTime(row.Cells["PeriodoFinal"].Value);
                    txtPrecioLeche.Text = row.Cells["PrecioLeche"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al seleccionar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            { 
                Vista_Quincena_Planilla frm = new Vista_Quincena_Planilla(this);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Desea guardar los registros generados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = conexion.ObtenerConexion();
                        // Crear el comando y asociarlo con la conexión
                        using (SqlCommand cmdPlanilla = new SqlCommand("spInsertarPlanillaPorSocio", con))
                        {
                            cmdPlanilla.CommandType = CommandType.StoredProcedure;

                            // Agregar los parámetros necesarios
                            cmdPlanilla.Parameters.AddWithValue("@quincenaID", Convert.ToInt32(txtQuincenaID.Text));
                            cmdPlanilla.Parameters.AddWithValue("@periodoinicio", dtpFechaInicio.Value);
                            cmdPlanilla.Parameters.AddWithValue("@periodofinal", dtpFechaFinal.Value);
                            cmdPlanilla.Parameters.AddWithValue("@precioleche", Convert.ToDouble(txtPrecioLeche.Text));
                            cmdPlanilla.Parameters.AddWithValue("@activo", true);


                            // Ejecuta el procedimiento almacenado
                            cmdPlanilla.ExecuteNonQuery();
                            MessageBox.Show("Registros guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                            Limpiar();

                            //Actualizar la tabla
                            tabla.Clear();
                            adaptador.Fill(tabla);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
                    }

                }
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            errorProvider1.Clear();

            // Validar que la QuincenaId no sea null
            if (string.IsNullOrWhiteSpace(txtQuincenaID.Text) || !int.TryParse(txtQuincenaID.Text, out int quincenaID))
            {
                errorProvider1.SetError(txtQuincenaID, "Seleccione un ID de quincena. Este campo no puede ir vacio.");
                errorProvider1.SetError(dtpFechaInicio, "Seleccione un ID de quincena.La fecha de inicio debe estar asociada al ID de Quincena");
                errorProvider1.SetError(dtpFechaFinal, "Seleccione un ID de quincena. La fecha de fin debe estar asociada al ID de Quincena");
                esValido = false;
            }

            // Validar que el precio no sea negativo y sea un número válido
            if (string.IsNullOrWhiteSpace(txtPrecioLeche.Text) || !double.TryParse(txtPrecioLeche.Text, out double precioLeche))
            {
                errorProvider1.SetError(txtPrecioLeche, "Ingrese un precio válido.");
                esValido = false;
            }
            else if (precioLeche <= 0)
            {
                errorProvider1.SetError(txtPrecioLeche, "Ingrese un precio válido. Valores numéricos positivos.");
                esValido = false;
            }

            return esValido;
        }


        private void Limpiar()
        {
            //LIMPIAR TODOS LOS CAMPOS
            txtPlanillaID.Enabled = false;
            txtQuincenaID.Text = "";
            txtPrecioLeche.Text = "";  // Deseleccionar socio
            dtpFechaInicio.ResetText();
            dtpFechaFinal.ResetText();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //EDITAR UN REGISTRO, SELECCIONANDOLO EN EL DataGridView Y MODIFICANDO LOS CAMPOS EN LOS TEXTBOX
                    try
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            int PlanillaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PlanillaID"].Value);
                            int QuincenaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["QuincenaID"].Value);
                            int SocioID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SocioID"].Value);
                            SqlConnection con = conexion.ObtenerConexion();
                            using (SqlCommand cmdPlanilla = new SqlCommand("spPlanillaUpdate", con))
                            {
                                cmdPlanilla.CommandType = CommandType.StoredProcedure;
                                cmdPlanilla.Parameters.AddWithValue("@planillaid", PlanillaID);
                                cmdPlanilla.Parameters.AddWithValue("@precioleche", Convert.ToDouble(txtPrecioLeche.Text));
                                cmdPlanilla.Parameters.AddWithValue("@socioid", SocioID);
                                cmdPlanilla.Parameters.AddWithValue("@quincenaid", QuincenaID);
                                cmdPlanilla.ExecuteNonQuery();
                                MessageBox.Show("Registro actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Actualizar la tabla
                                tabla.Clear();
                                adaptador.Fill(tabla);

                                //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                                Limpiar();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
                    }
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
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int PlanillaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PlanillaID"].Value);
                        int QuincenaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["QuincenaID"].Value);
                        int SocioID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SocioID"].Value);
                        SqlConnection con = conexion.ObtenerConexion();
                        using (SqlCommand cmdPlanilla = new SqlCommand("spPlanillaDesactivar", con))
                        {
                            cmdPlanilla.CommandType = CommandType.StoredProcedure;
                            cmdPlanilla.Parameters.AddWithValue("@planillaid", PlanillaID);
                            cmdPlanilla.Parameters.AddWithValue("@socioid", SocioID);
                            cmdPlanilla.Parameters.AddWithValue("@quincenaid", QuincenaID);
                            cmdPlanilla.ExecuteNonQuery();
                            MessageBox.Show("Registro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Actualizar la tabla
                            tabla.Clear();
                            adaptador.Fill(tabla);

                            //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                            Limpiar();
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

        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampo.SelectedIndex != -1)
            {
                txtTexto.Enabled = true;
            }
            else
            {
                txtTexto.Enabled = false;
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabla.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = tabla.Columns[cmbCampo.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tabla.DefaultView.RowFilter = cmbCampo.Text + " LIKE '%" + txtTexto.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTexto.Text, out int numero))
                        {
                            tabla.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTexto.Text, out decimal numeroDecimal))
                        {
                            tabla.DefaultView.RowFilter = cmbCampo.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
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
                            tabla.DefaultView.RowFilter = cmbCampo.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        tabla.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dataGridView1.DataSource = tabla.DefaultView.ToTable();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Ingrese los valores adecuados para todos los campos solicitados en el formulario y al dar click al botón guardar se " +
            "generara los registros de planilla de todos los socios activos.", "Ayuda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
    }
}
