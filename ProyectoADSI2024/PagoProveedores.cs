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
using System.Data.SqlClient;

namespace ProyectoADSI2024
{
    public partial class PagoProveedores : Form
    {
        private string connectionString2 = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";
        SqlConnection conexion;
        SqlDataAdapter adp;
        //Tooltip
        System.Windows.Forms.ToolTip toolTips;
        public PagoProveedores()
        {
            InitializeComponent();
            toolTipsTxts();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void PagoProveedores_Load(object sender, EventArgs e)
        {
            LimpiarTxtBox();
            CargarDatos();
            CargarComboProveedores();

            //cargar combos
            comboBusca.Items.Add("ProveedorID");
            comboBusca.Items.Add("CompraConID");
            comboBusca.Items.Add("CompraMedID");
            comboBusca.Items.Add("MontoPago");
            comboBusca.Items.Add("MetodoPago");
            comboBusca.SelectedIndex = -1;

            comboMetodo.Items.Add("Crédito");
            comboMetodo.Items.Add("Efectivo");

            comboEstado.Items.Add("Pagado");
            comboEstado.Items.Add("Pendiente");



        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString2))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM proyecto.PagoCompraCredito ORDER BY PagoID desc", conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgPagoProv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }


        

        private void CargarComboProveedores()
        {
           
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString2))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Nombre FROM proyecto.Proveedor";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            comboName.Items.Add(reader["Nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ComboBox: " + ex.Message);
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarTxtBox();
        }

        private void comboName_SelectedIndexChanged(object sender, EventArgs e)
        {
             string selectedName = comboName.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString2))
                {
                    conn.Open();
                    string query = "SELECT ProveedorID FROM proyecto.Proveedor WHERE Nombre = @Nombre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", selectedName);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Mostrar el ProveedorID en el TextBox
                            provId.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el ProveedorID para el nombre seleccionado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ProveedorID: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Limpiar errores previos
            errorProvider1.Clear();

            bool tieneErrores = false;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(pagoId.Text))
            {
                errorProvider1.SetError(pagoId, "El campo PagoID no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(provId.Text))
            {
                errorProvider1.SetError(provId, "El campo ProveedorID no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(compraId.Text))
            {
                errorProvider1.SetError(compraId, "El campo CompraID no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(datePago.Text))
            {
                errorProvider1.SetError(datePago, "El campo FechaPago no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(pagoMonto.Text))
            {
                errorProvider1.SetError(pagoMonto, "El campo MontoPago no puede estar vacío.");
                tieneErrores = true;
            }

            if (comboMetodo.SelectedItem == null)
            {
                errorProvider1.SetError(comboMetodo, "Debe seleccionar un método de pago.");
                tieneErrores = true;
            }

            if (comboEstado.SelectedItem == null)
            {
                errorProvider1.SetError(comboEstado, "Debe seleccionar un estado de pago.");
                tieneErrores = true;
            }

            // Validar que uno de los dos RadioButton esté seleccionado
            if (!rdCon.Checked && !rdMed.Checked)
            {
                MessageBox.Show("Debe seleccionar una opción entre CompraConID y CompraMedID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tieneErrores = true;
            }

            // Validar valores numéricos y positivos
            if (!int.TryParse(pagoId.Text, out int pagoIdValue) || pagoIdValue <= 0)
            {
                errorProvider1.SetError(pagoId, "PagoID debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!int.TryParse(provId.Text, out int provIdValue) || provIdValue <= 0)
            {
                errorProvider1.SetError(provId, "ProveedorID debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!int.TryParse(compraId.Text, out int compraIdValue) || compraIdValue <= 0)
            {
                errorProvider1.SetError(compraId, "CompraID debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!decimal.TryParse(pagoMonto.Text, out decimal pagoMontoValue) || pagoMontoValue <= 0)
            {
                errorProvider1.SetError(pagoMonto, "MontoPago debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!DateTime.TryParse(datePago.Text, out DateTime fechaPagoValue))
            {
                errorProvider1.SetError(datePago, "FechaPago debe tener un formato válido de fecha.");
                tieneErrores = true;
            }

            // Si hay errores, mostrar mensaje y no continuar
            if (tieneErrores)
            {
                MessageBox.Show("Corrija los errores marcados antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de guardado
            if (MessageBox.Show("¿Desea guardar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString2))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("spPagoProvInsert", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Agregar parámetros
                            cmd.Parameters.AddWithValue("@PagoID", pagoIdValue);
                            cmd.Parameters.AddWithValue("@ProveedorID", provIdValue);

                            if (rdCon.Checked)
                            {
                                cmd.Parameters.AddWithValue("@CompraConID", compraIdValue);
                                cmd.Parameters.AddWithValue("@CompraMedID", DBNull.Value);
                            }
                            else if (rdMed.Checked)
                            {
                                cmd.Parameters.AddWithValue("@CompraConID", DBNull.Value);
                                cmd.Parameters.AddWithValue("@CompraMedID", compraIdValue);
                            }

                            cmd.Parameters.AddWithValue("@FechaPago", fechaPagoValue);
                            cmd.Parameters.AddWithValue("@MontoPago", pagoMontoValue);
                            cmd.Parameters.AddWithValue("@MetodoPago", comboMetodo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@EstadoPago", comboEstado.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Activo", true);

                            // Ejecutar comando
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarTxtBox();
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void LimpiarTxtBox()
        {
            try
            {
                // Limpiar TextBoxes
                pagoId.Clear();
                provId.Clear();
                pagoMonto.Clear();
                compraId.Clear();
                datePago.Value = DateTime.Now; // Establecer la fecha actual como valor por defecto

                // Limpiar ComboBoxes
                comboMetodo.SelectedIndex = -1; // Establecer el índice a -1, lo que significa que no hay selección

                // Limpiar CheckBoxes
                comboEstado.SelectedIndex = -1;
                rdCon.Checked = false;
                rdMed.Checked = false;

                // Verificar si hay un elemento seleccionado en el ComboBox `comboName`
                if (comboName.SelectedItem != null)
                {
                    string selectedName = comboName.SelectedItem.ToString(); // Obtiene el valor seleccionado
                                                                             // Puedes usar `selectedName` si es necesario, pero ahora estás seguro de que no es null
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar el formulario: " + ex.Message);
            }

        
        }

        private void rdCon_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdMed_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Limpiar errores previos
            errorProvider2.Clear();

            bool tieneErrores = false;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(pagoId.Text))
            {
                errorProvider2.SetError(pagoId, "El campo PagoID no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(provId.Text))
            {
                errorProvider2.SetError(provId, "El campo ProveedorID no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(compraId.Text))
            {
                errorProvider2.SetError(compraId, "El campo CompraID no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(datePago.Text))
            {
                errorProvider2.SetError(datePago, "El campo FechaPago no puede estar vacío.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(pagoMonto.Text))
            {
                errorProvider2.SetError(pagoMonto, "El campo MontoPago no puede estar vacío.");
                tieneErrores = true;
            }

            if (comboMetodo.SelectedItem == null)
            {
                errorProvider2.SetError(comboMetodo, "Debe seleccionar un método de pago.");
                tieneErrores = true;
            }

            if (comboEstado.SelectedItem == null)
            {
                errorProvider2.SetError(comboEstado, "Debe seleccionar un estado de pago.");
                tieneErrores = true;
            }

            // Validar que uno de los dos RadioButton esté seleccionado
            if (!rdCon.Checked && !rdMed.Checked)
            {
                MessageBox.Show("Debe seleccionar una opción entre CompraConID y CompraMedID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tieneErrores = true;
            }

            // Validar valores numéricos y positivos
            if (!int.TryParse(pagoId.Text, out int pagoIdValue) || pagoIdValue <= 0)
            {
                errorProvider2.SetError(pagoId, "PagoID debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!int.TryParse(provId.Text, out int provIdValue) || provIdValue <= 0)
            {
                errorProvider2.SetError(provId, "ProveedorID debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!int.TryParse(compraId.Text, out int compraIdValue) || compraIdValue <= 0)
            {
                errorProvider2.SetError(compraId, "CompraID debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!decimal.TryParse(pagoMonto.Text, out decimal pagoMontoValue) || pagoMontoValue <= 0)
            {
                errorProvider2.SetError(pagoMonto, "MontoPago debe ser un número mayor a cero.");
                tieneErrores = true;
            }

            if (!DateTime.TryParse(datePago.Text, out DateTime fechaPagoValue))
            {
                errorProvider2.SetError(datePago, "FechaPago debe tener un formato válido de fecha.");
                tieneErrores = true;
            }

            // Si hay errores, mostrar mensaje y no continuar
            if (tieneErrores)
            {
                MessageBox.Show("Corrija los errores marcados antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceder con el guardado
            if (MessageBox.Show("¿Desea editar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString2))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("spPagoProvUpdate", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Agregar los parámetros
                            cmd.Parameters.AddWithValue("@PagoID", pagoIdValue);
                            cmd.Parameters.AddWithValue("@ProveedorID", provIdValue);

                            // Lógica para CompraConID o CompraMedID
                            if (rdCon.Checked)
                            {
                                cmd.Parameters.AddWithValue("@CompraConID", compraIdValue);
                                cmd.Parameters.AddWithValue("@CompraMedID", DBNull.Value); // NULL para el otro campo
                            }
                            else if (rdMed.Checked)
                            {
                                cmd.Parameters.AddWithValue("@CompraConID", DBNull.Value); // NULL para el otro campo
                                cmd.Parameters.AddWithValue("@CompraMedID", compraIdValue);
                            }

                            cmd.Parameters.AddWithValue("@FechaPago", fechaPagoValue);
                            cmd.Parameters.AddWithValue("@MontoPago", pagoMontoValue);
                            cmd.Parameters.AddWithValue("@MetodoPago", comboMetodo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@EstadoPago", comboEstado.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Activo", true);

                            // Ejecutar el comando
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Registro editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarTxtBox();
                            CargarDatos();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el pago: " + ex.Message);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgPagoProv.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int pagoID = Convert.ToInt32(dgPagoProv.CurrentRow.Cells["PagoID"].Value);


            // Ejecutar el procedimiento almacenado para eliminar el proveedor
            if (MessageBox.Show("¿Desea eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString2))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("spPagoProvDelete", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pagoID", pagoID);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Proveedor eliminado correctamente.");
                    LimpiarTxtBox();
                    // Recargar los datos del DataGridView
                    CargarDatos();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void FiltrarDatos()
        {
            DataTable dt = ObtenerDatosDePago(); // Método que recupera los datos de productos
            DataView dv = new DataView(dt);  // Inicializar el DataView con el DataTable obtenido
            string columnaSeleccionada = comboBusca.SelectedItem.ToString();
            string filtro = txBusca.Text.ToLower();

            // Verificar si el filtro está vacío y no aplicar el RowFilter si es el caso
            if (string.IsNullOrEmpty(filtro))
            {
                dv.RowFilter = string.Empty; // No aplicar filtro
            }
            else
            {
                // Verificar que la columna seleccionada existe en el DataTable
                if (dt.Columns.Contains(columnaSeleccionada))
                {
                    // Obtener el tipo de la columna
                    Type tipoColumna = dt.Columns[columnaSeleccionada].DataType;

                    // Si la columna es de tipo string (texto), usar LIKE
                    if (tipoColumna == typeof(string))
                    {
                        dv.RowFilter = $"[{columnaSeleccionada}] LIKE '%{filtro}%'";
                    }
                    // Si la columna es de tipo numerico (int, decimal, etc.), usar un filtro con el valor exacto
                    else if (tipoColumna == typeof(int) || tipoColumna == typeof(decimal) || tipoColumna == typeof(double) || tipoColumna == typeof(float))
                    {
                        // Verificar que el filtro sea un número válido
                        if (decimal.TryParse(filtro, out decimal valorFiltro))
                        {
                            dv.RowFilter = $"[{columnaSeleccionada}] = {valorFiltro}";
                        }
                        else
                        {
                            // Si el filtro no es un número válido, limpiar el filtro
                            dv.RowFilter = string.Empty;
                            MessageBox.Show("El filtro no es un número válido.");
                        }
                    }
                    // Si la columna es de tipo fecha, hacer un filtro basado en la fecha
                    else if (tipoColumna == typeof(DateTime))
                    {
                        // Verificar que el filtro sea una fecha válida
                        if (DateTime.TryParse(filtro, out DateTime valorFiltroFecha))
                        {
                            dv.RowFilter = $"[{columnaSeleccionada}] = #{valorFiltroFecha.ToString("MM/dd/yyyy")}#";
                        }
                        else
                        {
                            // Si el filtro no es una fecha válida, limpiar el filtro
                            dv.RowFilter = string.Empty;
                            MessageBox.Show("El filtro no es una fecha válida.");
                        }
                    }
                    else
                    {
                        // Si el tipo de columna no es ni string, ni numérico, ni fecha, no aplicar filtro
                        dv.RowFilter = string.Empty;
                        MessageBox.Show($"El tipo de la columna {columnaSeleccionada} no es compatible para este filtro.");
                    }
                }
                else
                {
                    MessageBox.Show($"La columna {columnaSeleccionada} no existe en la tabla.");
                }
            }

            // Asignar el DataView filtrado al DataGridView
            dgPagoProv.DataSource = dv;
        }



        private DataTable ObtenerDatosDePago()
        {
            // Suponiendo que tienes una conexión a la base de datos y ejecutas una consulta
            DataTable dt = new DataTable();
            string query = "SELECT * FROM proyecto.PagoCompraCredito"; // Modificar según tus columnas

            using (SqlConnection conn = new SqlConnection(connectionString2))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private void txBusca_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void comboBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }


        private void toolTipsTxts()
        {
            toolTips = new System.Windows.Forms.ToolTip();
            toolTips.IsBalloon = true;
            toolTips.ToolTipIcon = ToolTipIcon.Info;
            toolTips.ToolTipTitle = "Ayuda";
            toolTips.UseAnimation = true;
            toolTips.SetToolTip(pagoId, "Ingrese un número de Referencia de Pago Válido");
            toolTips.SetToolTip(provId, "Ingrese un número de Proveedor Válido");
            toolTips.SetToolTip(comboName, "Seleccione el Nombre del Proveedor.");
            toolTips.SetToolTip(compraId, "Ingrese un Id de una Compra Existente.");
            toolTips.SetToolTip(datePago, "Seleccione la fecha del Pago.");
            toolTips.SetToolTip(pagoMonto, "Ingrese el Monto del Pago.");
            toolTips.SetToolTip(comboMetodo, "Seleccione el Método de Pago.");
            toolTips.SetToolTip(comboEstado, "Seleccione el Estado del Pago.");
            toolTips.SetToolTip(btnAtras, "Regresar al menú.");
            toolTips.SetToolTip(btnEliminar, "Eliminar el registro");
            toolTips.SetToolTip(button2, "Limpiar los cuadros de texto y fechas.");
            toolTips.SetToolTip(button4, "Editar el registro.");
            toolTips.SetToolTip(btnGuardar, "Guardar el registro.");
            toolTips.SetToolTip(comboBusca, "Seleccione el campo en el que desea buscar.");
            toolTips.SetToolTip(txBusca, "Ingrese registro a buscar");

        }
    }
}
