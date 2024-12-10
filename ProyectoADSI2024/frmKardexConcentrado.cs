using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
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
    public partial class frmKardexConcentrado : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        Conexion cnxKardex;
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server

        System.Windows.Forms.ToolTip toolTipKardex1;
        public frmKardexConcentrado()
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spArticuloConcentradoSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla
            cnxKardex = new Conexion();
            toolTipKardex();


        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmKardexConcentrado_Load(object sender, EventArgs e)
        {
            tboxBuscar.Enabled = false;
            try
            {
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Mostrar la tabla en el DataGridView
                toolTipKardex();
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
                int articuloId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ArticuloConID"].Value);

                // Abrir el formulario para seleccionar las fechas, pasando el ID del artículo
                Vista_SeleccionarFecha_Concentrado formFechas = new Vista_SeleccionarFecha_Concentrado(articuloId);
                formFechas.ShowDialog(); // Muestra el formulario de fechas como modal
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidaionError())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                SqlConnection conexion = cnxKardex.ObtenerConexion();
               
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexConcentrado", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarConKardex.Parameters.AddWithValue("@nombre", txtNomKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@codigo", txtCodKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@tipo", cbxTipoKarCon.SelectedItem.ToString());
                    cmdAgregarConKardex.Parameters.AddWithValue("@precio", float.Parse(txtKarPrecio.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtKarEntrada.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@salida",  Convert.ToInt32(txtKarSalida.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVenKar.Value);



                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Concentrado registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private bool ValidaionError()
        {
            // Limpiar cualquier error previo
            epValidaGuardar.Clear();

            if (txtNomKarCon.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtNomKarCon, "El nombre del artículo es obligatorio.");
                return false;
            }
            else if (txtCodKarCon.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtCodKarCon, "El código del artículo es obligatorio.");
                return false;
            }
            else if (cbxTipoKarCon.SelectedIndex == -1)
            {
                epValidaGuardar.SetError(cbxTipoKarCon, "El tipo de artículo es obligatorio.");
                return false;
            }
            else if (txtKarPrecio.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarPrecio, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (!decimal.TryParse(txtKarPrecio.Text, out decimal precio) || precio < 0)
            {
                epValidaGuardar.SetError(txtKarPrecio, "El precio del artículo debe ser un número positivo.");
                return false;
            }
            else if (txtKarEntrada.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarEntrada, "La cantidad de entrada es obligatoria.");
                return false;
            }
            else if (!int.TryParse(txtKarEntrada.Text, out int entrada) || entrada < 0)
            {
                epValidaGuardar.SetError(txtKarEntrada, "La cantidad de entrada debe ser un número entero positivo.");
                return false;
            }
            else if (txtKarSalida.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarSalida, "La cantidad de salida es obligatoria.");
                return false;
            }
            else if (!int.TryParse(txtKarSalida.Text, out int salida) || salida <= 0)
            {
                epValidaGuardar.SetError(txtKarSalida, "La cantidad de salida debe ser un número entero positivo o 0.");
                return false;
            }
            else if (dtpFechaVenKar.Value == null)
            {
                epValidaGuardar.SetError(dtpFechaVenKar, "La fecha de vencimiento es obligatoria.");
                return false;
            }
            else if (dtpFechaVenKar.Value < DateTime.Now)
            {
                epValidaGuardar.SetError(dtpFechaVenKar, "La fecha de vencimiento no puede ser menor a la fecha actual.");
                return false;
            }
            else if (entrada == 0)
            {
                epValidaGuardar.SetError(txtKarEntrada, "La cantidad de entrada debe ser mayor a 0.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true
        }


        private void LimpiarDatos()
        {
            txtKardexConId.Clear();
            txtNomKarCon.Clear();
            txtCodKarCon.Clear();
            txtKarPrecio.Clear();
            cbxTipoKarCon.SelectedIndex = -1;
            txtKarEntrada.Clear();
            txtKarSalida.Clear();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
                // Verificamos si se ha hecho clic en una fila válida
                if (e.RowIndex >= 0)
                {

                    // Obtenemos la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
              
                    // Asignamos los valores a los TextBox (ajusta los nombres de los TextBox y las columnas según tu diseño)
                    txtKardexConId.Text = filaSeleccionada.Cells["ArticuloConID"].Value.ToString();
                    txtNomKarCon.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    txtCodKarCon.Text = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    txtKarPrecio.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                    cbxTipoKarCon.SelectedItem = filaSeleccionada.Cells["Tipo"].Value.ToString();
                    txtKarEntrada.Text = filaSeleccionada.Cells["Entrada"].Value.ToString();
                    txtKarSalida.Text = filaSeleccionada.Cells["Salida"].Value.ToString();
                    dtpFechaVenKar.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaVencimiento"].Value);

                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarErrorEditar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                SqlConnection conexion = cnxKardex.ObtenerConexion();

                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexConcentradoEditar", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarConKardex.Parameters.AddWithValue("@articuloid", Convert.ToInt32(txtKardexConId.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@nombre", txtNomKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@codigo", txtCodKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@tipo", cbxTipoKarCon.SelectedItem.ToString());
                    cmdAgregarConKardex.Parameters.AddWithValue("@precio", float.Parse(txtKarPrecio.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtKarEntrada.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@salida", Convert.ToInt32(txtKarSalida.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVenKar.Value);



                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Concentrado actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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


        private bool ValidarErrorEditar()
        {
            // Limpiar cualquier error previo
            epValidarEditar.Clear();

            if (txtKardexConId.Text == string.Empty)
            {
                epValidarEditar.SetError(txtKardexConId, "Debe Seleccionar un articulo para actualizar su informacion.");
                return false;
            }
            else if (txtNomKarCon.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtNomKarCon, "El nombre del artículo es obligatorio.");
                return false;
            }
            else if (txtCodKarCon.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtCodKarCon, "El código del artículo es obligatorio.");
                return false;
            }
            else if (cbxTipoKarCon.SelectedIndex == -1)
            {
                epValidaGuardar.SetError(cbxTipoKarCon, "El tipo de artículo es obligatorio.");
                return false;
            }
            else if (txtKarPrecio.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarPrecio, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (txtKarEntrada.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarEntrada, "La cantidad de entrada es obligatoria.");
                return false;
            }
            else if (txtKarSalida.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarSalida, "La cantidad de salida es obligatoria.");
                return false;
            }
            else if (dtpFechaVenKar.Value == null)
            {
                epValidaGuardar.SetError(dtpFechaVenKar, "La fecha de vencimiento es obligatoria.");
                return false;
            }


            return true; // Si todas las validaciones son correctas, devuelve true

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarErrorEliminar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }

                SqlConnection conexion = cnxKardex.ObtenerConexion();

                if (MessageBox.Show("¿Desea Eliminar este concentrado de Kardex?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexConcentradoEliminar", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;
                    cmdAgregarConKardex.Parameters.AddWithValue("@concentradoid", Convert.ToInt32(txtKardexConId.Text));

                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Concentrado eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.

                    txtKardexConId.Clear();

                    tabla.Clear(); // Limpia los datos actuales del DataTable
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }

        private bool ValidarErrorEliminar()
        {
            // Limpiar cualquier error previo
            epValidarEliminar.Clear();

            if (txtKardexConId.Text == string.Empty)
            {
                epValidarEliminar.SetError(txtKardexConId, "Debe seleccionar un concentrado a eliminar.");
                return false;
            }

            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                epValidarEliminar.SetError(dataGridView1, "Debe seleccionar un concentrado de la lista.");
                return false;
            }

            // Verificar si la columna "Existencia" tiene un valor válido y convertirlo a entero
            DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
            if (filaSeleccionada.Cells["Existencia"].Value == null ||
                !int.TryParse(filaSeleccionada.Cells["Existencia"].Value.ToString(), out int existencia))
            {
                epValidarEliminar.SetError(dataGridView1, "La columna 'Existencia' no contiene un valor válido.");
                return false;
            }

            // Validar si la existencia es mayor a cero
            if (existencia > 0)
            {
                MessageBox.Show("No se puede eliminar un concentrado con existencia mayor a 0 en Kardex.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true
        }


        private void toolTipKardex()
        {
            toolTipKardex1 = new System.Windows.Forms.ToolTip();
            toolTipKardex1.IsBalloon = true;
            toolTipKardex1.ToolTipIcon = ToolTipIcon.Info;
            toolTipKardex1.ToolTipTitle = "Ayuda";
            toolTipKardex1.UseAnimation = true;
            toolTipKardex1.SetToolTip(txtCodKarCon, "Ingrese el codigo del concentrado");
            toolTipKardex1.SetToolTip(txtNomKarCon, "Ingrese el nombre del concentrado");
            toolTipKardex1.SetToolTip(cbxTipoKarCon, "Seleccione el tipo de concentrado");
            toolTipKardex1.SetToolTip(txtKarPrecio, "Ingrese el precio del concentrado");
            toolTipKardex1.SetToolTip(txtKarEntrada, "Ingrese la cantidad de entrada del concentrado");
            toolTipKardex1.SetToolTip(txtKarSalida, "Ingrese la cantidad de salida del concentrado");
            toolTipKardex1.SetToolTip(dtpFechaVenKar, "Seleccione la fecha de vencimiento del concentrado");
            toolTipKardex1.SetToolTip(btnGuardar, "Guarda el movimiento de Kardex");
            toolTipKardex1.SetToolTip(btnEliminar, "Elimina el movimiento de Kardex");
            toolTipKardex1.SetToolTip(button1, "Editar el concentrado seleccioando.");
            toolTipKardex1.SetToolTip(button2, "Limpia los campos del formulario.");
            toolTipKardex1.SetToolTip(btnGenerarReporte, "Genera reporte de kardex de concentrado.");
            toolTipKardex1.SetToolTip(cboxBuscar, "Seleccione el campo por el cual desea buscar.");
            toolTipKardex1.SetToolTip(tboxBuscar, "Ingrese el valor a buscar.");
            toolTipKardex1.SetToolTip(btnAtras, "Vuelve al menu principal.");

            toolTipKardex1.SetToolTip(txtKardexConId, "El ID del concentrado es un campo de solo lectura. No debe llenarse.");
            toolTipKardex1.SetToolTip(dataGridView1, "Seleccione un concentrado de la lista para editar o eliminar.");

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

        private void txtNomKarCon_TextChanged(object sender, EventArgs e)
        {
            // Obtén el texto ingresado y elimina espacios extra
            string nombre = txtNomKarCon.Text.Trim();

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
                string codigoBodega = "002";

                // Combina las iniciales y el código de la bodega
                string codigoArticulo = $"{inicialesPrimera}{inicialesSegunda}{codigoBodega}";

                // Asigna el código generado al TextBox del código
                txtCodKarCon.Text = codigoArticulo;
            }
            else
            {
                // Limpia el campo del código si no hay texto válido en el nombre
                txtCodKarCon.Text = string.Empty;
            }
        }
    }
}
