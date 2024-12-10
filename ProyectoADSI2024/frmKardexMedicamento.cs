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
    public partial class frmKardexMedicamento : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server
        private Conexion cnxkardexMed;
        System.Windows.Forms.ToolTip toolTipKardexMed;
        BindingSource bindingSource;
        public frmKardexMedicamento()
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spArticuloMedicamentoSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla
            cnxkardexMed = new Conexion();
            toolTipKardexMedicamento();
        
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmKardexMedicamento_Load(object sender, EventArgs e)
        {
            tboxBuscar.Enabled = false;
            try
            {
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Mostrar la tabla en el DataGridView
                toolTipKardexMedicamento();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del artículo seleccionado
                int articuloId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ArticuloMedID"].Value);

                // Abrir el formulario para seleccionar las fechas, pasando el ID del artículo
                Vista_SeleccionarFecha_Medicamento formFechas = new Vista_SeleccionarFecha_Medicamento(articuloId);
                formFechas.ShowDialog(); // Muestra el formulario de fechas como modal
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidaionErrorMedicamento())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                SqlConnection conexion = cnxkardexMed.ObtenerConexion();

                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexMedicamentoAgregar", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarConKardex.Parameters.AddWithValue("@nombre", txtNombreMedKardex.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@codigo", txtCodigoKardexMed.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@precio", float.Parse(txtPrecioKardexMed.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtEntradaMedKardex.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@salida", Convert.ToInt32(txtSalidaMedKardex.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@fechaVencimiento", dtpvencmed.Value);



                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Medicamento/Insumo registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.
                    LimpiarDatos();
                    tabla.Clear(); // Limpia los datos actuales del DataTable
                    adaptador.Fill(tabla); // Vuelve a cargar los datos desde la base de datos
                    dataGridView1.Refresh(); // Refresca la interfaz



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }

        private bool ValidaionErrorMedicamento()
        {
            // Limpiar cualquier error previo
            epguardarMedicamKardex.Clear();

            if (txtNombreMedKardex.Text == string.Empty)
            {
                epguardarMedicamKardex.SetError(txtNombreMedKardex, "El nombre del artículo es obligatorio.");
                return false;
            }
            else if (txtCodigoKardexMed.Text == string.Empty)
            {
                epguardarMedicamKardex.SetError(txtCodigoKardexMed, "El código del artículo es obligatorio.");
                return false;
            }
            else if (txtPrecioKardexMed.Text == string.Empty)
            {
                epguardarMedicamKardex.SetError(txtPrecioKardexMed, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (!decimal.TryParse(txtPrecioKardexMed.Text, out decimal precio) || precio < 0)
            {
                epguardarMedicamKardex.SetError(txtPrecioKardexMed, "El precio del artículo debe ser un número positivo.");
                return false;
            }
            else if (txtEntradaMedKardex.Text == string.Empty)
            {
                epguardarMedicamKardex.SetError(txtEntradaMedKardex, "La cantidad de entrada es obligatoria.");
                return false;
            }
            else if (!int.TryParse(txtEntradaMedKardex.Text, out int entrada) || entrada < 0)
            {
                epguardarMedicamKardex.SetError(txtEntradaMedKardex, "La cantidad de entrada debe ser un número entero positivo.");
                return false;
            }
            else if (txtSalidaMedKardex.Text == string.Empty)
            {
                epguardarMedicamKardex.SetError(txtSalidaMedKardex, "La cantidad de salida es obligatoria.");
                return false;
            }
            else if (!int.TryParse(txtSalidaMedKardex.Text, out int salida) || salida <= 0)
            {
                epguardarMedicamKardex.SetError(txtSalidaMedKardex, "La cantidad de salida debe ser un número entero positivo  o 0.");
                return false;
            }
            else if (dtpvencmed.Value == null)
            {
                epguardarMedicamKardex.SetError(dtpvencmed, "La fecha de vencimiento es obligatoria.");
                return false;
            }
            else if (dtpvencmed.Value < DateTime.Now)
            {
                epguardarMedicamKardex.SetError(dtpvencmed, "La fecha de vencimiento no puede ser menor a la fecha actual.");
                return false;
            }
            else if (entrada == 0)
            {
                epguardarMedicamKardex.SetError(txtEntradaMedKardex, "La cantidad de entrada debe ser mayor a 0.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //editar try
            try
            {
                if (!ValidarErrorEditarMedicamento())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                SqlConnection conexion = cnxkardexMed.ObtenerConexion();

                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexMedicamentoEditar", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarConKardex.Parameters.AddWithValue("@articuloid", Convert.ToInt32(txtArticuloKardexid.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@nombre", txtNombreMedKardex.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@codigo", txtCodigoKardexMed.Text);
                   
                    cmdAgregarConKardex.Parameters.AddWithValue("@precio", float.Parse(txtPrecioKardexMed.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtEntradaMedKardex.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@salida", Convert.ToInt32(txtSalidaMedKardex.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@fechaVencimiento", dtpvencmed.Value);



                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Medicamento/Insumo actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.

                    LimpiarDatos();
                    tabla.Clear(); // Limpia los datos actuales del DataTable
                    adaptador.Fill(tabla); // Vuelve a cargar los datos desde la base de datos
                    dataGridView1.Refresh(); // Refresca la interfaz


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }

        private bool ValidarErrorEditarMedicamento()
        {
            // Limpiar cualquier error previo
            epEditarKardexMed.Clear();

            if (txtArticuloKardexid.Text == string.Empty)
            {
                epEditarKardexMed.SetError(txtArticuloKardexid, "Debe Seleccionar un medicamento/insumo para actualizar su informacion.");
                return false;
            }
            else if (txtNombreMedKardex.Text == string.Empty)
            {
                epEditarKardexMed.SetError(txtNombreMedKardex, "El nombre del artículo es obligatorio.");
                return false;
            }
            else if (txtCodigoKardexMed.Text == string.Empty)
            {
                epEditarKardexMed.SetError(txtCodigoKardexMed, "El código del artículo es obligatorio.");
                return false;
            }
           
            else if (txtPrecioKardexMed.Text == string.Empty)
            {
                epEditarKardexMed.SetError(txtPrecioKardexMed, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (txtEntradaMedKardex.Text == string.Empty)
            {
                epEditarKardexMed.SetError(txtEntradaMedKardex, "La cantidad de entrada es obligatoria.");
                return false;
            }
            else if (txtSalidaMedKardex.Text == string.Empty)
            {
                epEditarKardexMed.SetError(txtSalidaMedKardex, "La cantidad de salida es obligatoria.");
                return false;
            }
            else if (dtpvencmed.Value == null)
            {
                epEditarKardexMed.SetError(dtpvencmed, "La fecha de vencimiento es obligatoria.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true

        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                // Obtenemos la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                // Asignamos los valores a los TextBox (ajusta los nombres de los TextBox y las columnas según tu diseño)
                txtArticuloKardexid.Text = filaSeleccionada.Cells["ArticuloMedID"].Value.ToString();
                txtNombreMedKardex.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtCodigoKardexMed.Text = filaSeleccionada.Cells["Codigo"].Value.ToString();
                txtPrecioKardexMed.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                txtEntradaMedKardex.Text = filaSeleccionada.Cells["Entrada"].Value.ToString();
                txtSalidaMedKardex.Text = filaSeleccionada.Cells["Salida"].Value.ToString();
                dtpvencmed.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaVencimiento"].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //btb limpiar
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtArticuloKardexid.Clear();
            txtNombreMedKardex.Clear();
            txtCodigoKardexMed.Clear();
            txtPrecioKardexMed.Clear();
            
            txtEntradaMedKardex.Clear();
            txtSalidaMedKardex.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarErrorEliminarKardex())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }

                SqlConnection conexion = cnxkardexMed.ObtenerConexion();
               
                if (MessageBox.Show("¿Desea Eliminar este medicamento/articulolo de Kardex?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Crear el comando y asociarlo con la conexión
                    using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexMedicamentoEliminar", conexion))
                    {
                         cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;
                         cmdAgregarConKardex.Parameters.AddWithValue("@medicamentoid", Convert.ToInt32(txtArticuloKardexid.Text));

                         // Ejecuta el procedimiento almacenado
                         cmdAgregarConKardex.ExecuteNonQuery();
                         MessageBox.Show("Medicamento/articulo eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.

                         txtArticuloKardexid.Clear();

                         tabla.Clear(); // Limpia los datos actuales del DataTable
                         adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }
        private bool ValidarErrorEliminarKardex()
        {
            // Limpiar cualquier error previo
            epEliminarKardexMed.Clear();

            if (txtArticuloKardexid.Text == string.Empty)
            {
                epEliminarKardexMed.SetError(txtArticuloKardexid, "Debe Seleccionar un articulo a eliminar.");
                return false;
            }

            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                epEliminarKardexMed.SetError(dataGridView1, "Debe seleccionar un artículo de la lista.");
                return false;
            }

            // Verificar si la columna "Existencia" tiene un valor válido y convertirlo a entero
            DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
            if (filaSeleccionada.Cells["Existencia"].Value == null ||
                !int.TryParse(filaSeleccionada.Cells["Existencia"].Value.ToString(), out int existencia))
            {
                epEliminarKardexMed.SetError(dataGridView1, "La columna 'Existencia' no contiene un valor válido.");
                return false;
            }

            // Validar si la existencia es mayor a cero
            if (existencia > 0)
            {
                MessageBox.Show("No se puede eliminar un artículo con existencia mayor a 0 en Kardex.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true
        }

        private void toolTipKardexMedicamento()
        {
            toolTipKardexMed = new System.Windows.Forms.ToolTip();
            toolTipKardexMed.IsBalloon = true;
            toolTipKardexMed.ToolTipIcon = ToolTipIcon.Info;
            toolTipKardexMed.ToolTipTitle = "Ayuda";
            toolTipKardexMed.UseAnimation = true;

            toolTipKardexMed.SetToolTip(cboxBuscar, "Seleccione el campo por el cual desea buscar.");
            toolTipKardexMed.SetToolTip(tboxBuscar, "Ingrese el valor a buscar.");
            toolTipKardexMed.SetToolTip(btnAtras, "Vuelve al menu principal.");

            toolTipKardexMed.SetToolTip(txtArticuloKardexid, "El ID del articulo/medicamento es un campo de solo lectura. No debe llenarse.");
            toolTipKardexMed.SetToolTip(txtCodigoKardexMed, "Ingrese el codigo del articulo/medicamento");
            toolTipKardexMed.SetToolTip(txtNombreMedKardex, "Ingrese el nombre del articulo/medicamento");
            
            toolTipKardexMed.SetToolTip(txtPrecioKardexMed, "Ingrese el precio del articulo/medicamento");
            toolTipKardexMed.SetToolTip(txtEntradaMedKardex, "Ingrese la cantidad de entrada del articulo/medicamento");
            toolTipKardexMed.SetToolTip(txtSalidaMedKardex, "Ingrese la cantidad de salida del articulo/medicamento");
            toolTipKardexMed.SetToolTip(dtpvencmed, "Seleccione la fecha de vencimiento del articulo/medicamento");
            toolTipKardexMed.SetToolTip(btnGuardar, "Guarda el movimiento de Kardex");
            toolTipKardexMed.SetToolTip(btnEliminar, "Elimina el movimiento de Kardex");
            toolTipKardexMed.SetToolTip(button1, "Editar el articulo/medicamento seleccionado.");
            toolTipKardexMed.SetToolTip(button2, "Limpia los campos del formulario.");
            toolTipKardexMed.SetToolTip(btnGenerarReporte, "Genera reporte de kardex de articulo/medicamento.");
            toolTipKardexMed.SetToolTip(dataGridView1, "Doble click para seleccionar un articulo/medicamento en kardex.");


        }

        private void tboxBuscar_KeyDown(object sender, KeyEventArgs e)
        {



        }

        private void FiltrarDatos()
        {
            // Suponiendo que ya tienes un DataTable como origen de datos para el DataGridView
            DataTable dt = tabla; // Método que recupera los datos de proveedores
            string columnaSeleccionada = cboxBuscar.SelectedItem.ToString();
            string filtro = tboxBuscar.Text.ToLower();

            // Filtrar la DataTable según la columna seleccionada y el valor de búsqueda
            DataView dv = dt.DefaultView;
            if (string.IsNullOrEmpty(filtro))
            {
                dv.RowFilter = string.Empty; // Si no hay texto, mostrar todos
            }
            else
            {
                dv.RowFilter = $"{columnaSeleccionada} LIKE '%{filtro}%'";
            }

            // Asignar el DataView filtrado al DataGridView
            dataGridView1.DataSource = dv;
        }

        private void tboxBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cboxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si hay una selección en el ComboBox, habilita el TextBox
            tboxBuscar.Enabled = cboxBuscar.SelectedIndex >= 0;

            // Si el TextBox estaba habilitado y ya hay un filtro escrito, aplicamos el filtro
            if (tboxBuscar.Enabled)
            {
                FiltrarDatos();
            }
        }

        private void txtNombreMedKardex_TextChanged(object sender, EventArgs e)
        {
            // Obtén el texto ingresado y elimina espacios extra
            string nombre = txtNombreMedKardex.Text.Trim();

            // Verifica que no esté vacío
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                // Divide el texto en palabras, eliminando palabras vacías generadas por múltiples espacios
                string[] palabras = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Toma las tres primeras letras de la primera palabra
                string inicialesPrimera = palabras.Length > 0
                    ? (palabras[0].Length >= 3
                        ? palabras[0].Substring(0, 3).ToUpper()
                        : palabras[0].ToUpper())
                    : "";

                // Toma las tres primeras letras de la segunda palabra (si existe)
                string inicialesSegunda = palabras.Length > 1
                    ? (palabras[1].Length >= 3
                        ? palabras[1].Substring(0, 3).ToUpper()
                        : palabras[1].ToUpper())
                    : "";

                // Agrega el código de la bodega (por ejemplo: 001 para medicamentos)
                string codigoBodega = "001";

                // Combina las iniciales y el código de la bodega
                string codigoArticulo = $"{inicialesPrimera}{inicialesSegunda}{codigoBodega}";

                // Asigna el código generado al TextBox del código
                txtCodigoKardexMed.Text = codigoArticulo;
            }
            else
            {
                // Limpia el campo del código si no hay texto válido en el nombre
                txtCodigoKardexMed.Text = string.Empty;
            }
        }
    }
}
