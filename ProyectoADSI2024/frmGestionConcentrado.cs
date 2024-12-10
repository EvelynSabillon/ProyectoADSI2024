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
using System.Data.Common;
using System.Net;
using System.Net.Configuration;


namespace ProyectoADSI2024
{
    public partial class frmGestionConcentrado : Form
    {
        private Conexion cnxconcentrado;
        SqlDataAdapter  adapterCompraConcen;
        DataTable dtCompraConcen;
        System.Windows.Forms.ToolTip toolTipCompra;



        public frmGestionConcentrado()
        {
          
            InitializeComponent();
            cnxconcentrado = new Conexion();

            dtCompraConcen = new DataTable();
            adapterCompraConcen = new SqlDataAdapter("spVistaGestionCompra", cnxconcentrado.ObtenerConexion());
            adapterCompraConcen.SelectCommand.CommandType = CommandType.StoredProcedure;
            toolTipsCompra();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmGestionConcentrado_Load(object sender, EventArgs e)
        {
            //Conexion cnxconcentrado = new Conexion();
            LlenarComboProveedores(); //llena el cbx con los proveedores
            adapterCompraConcen.Fill(dtCompraConcen);
           dgGestionConcentrado.DataSource = dtCompraConcen;
            // Configuración del DateTimePicker
            dtpFechaVencimiento.MinDate = DateTime.Today; // No permite fechas anteriores a hoy
            dtpFechaVencimiento.ValueChanged += dtpFechaVencimiento_ValueChanged;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private bool ValidaionAgregar()
        {
            // Limpiar cualquier error previo
            epAgregar.Clear();

            if (txtNombeArticulo.Text == string.Empty || !System.Text.RegularExpressions.Regex.IsMatch(txtNombeArticulo.Text, @"^[a-zA-Z\s]+$"))
            {
                epAgregar.SetError(txtNombeArticulo, "Debe agregar el nombre del concentrado y sin numeros.");
                return false;
            }
            else if (txtCodigo.Text == string.Empty)
            {
                epAgregar.SetError(txtCodigo, "El código del concentrado es obligatorio.");
                return false;
            }
            else if (txtPrecio.Text == string.Empty || !decimal.TryParse(txtPrecio.Text, out _))
            {
                epAgregar.SetError(txtPrecio, "El precio del artículo es obligatorio y deben ser valores numericos.");
                return false;
            }
            else if (txtCantidad.Text == string.Empty || !int.TryParse(txtCantidad.Text, out _))
            {
                epAgregar.SetError(txtCantidad, "La cantidad de entrada es obligatoria y cantidades enteras, no decimales.");
                return false;
            } 
           
            else if (cbxProveedor.SelectedIndex == -1)
            {
                epAgregar.SetError(cbxProveedor, "Debe seleccionar un proveedor.");
                return false;
            } 
            else if (txtDocumento.Text == string.Empty)
            {
                epAgregar.SetError(txtDocumento, "Debe agregar un documento para la compra.");
                return false;
            }
           
            else if (cbxTipo.SelectedIndex == -1)
            {
                epAgregar.SetError(cbxTipo, "El tipo de compra es obligatorio.");
                return false;
            }
            else if (cbxEstadoCompra.SelectedIndex == -1)
            {
                epAgregar.SetError(cbxEstadoCompra, "El estado de compra es obligatorio.");
                return false;
            }
           
           
            else if (txtCosto.Text == string.Empty || !decimal.TryParse(txtCosto.Text, out _))
            {
                epAgregar.SetError(txtCosto, "El costo de compra es obligatorio y deben ser valores numericos.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true

        }

        
        /*private void btnAgregarCompraCon_Click(object sender, EventArgs e)
        {

           

            try
            {

                if (!ValidaionAgregar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }

                SqlConnection conexion = cnxconcentrado.ObtenerConexion();
                int proveedorID = Convert.ToInt32(cbxProveedor.SelectedValue);
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarCompra = new SqlCommand("spCompraConcentrado", conexion))
                {
                    cmdAgregarCompra.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarCompra.Parameters.AddWithValue("@nombrearticulo", txtNombeArticulo.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@precio", Convert.ToDouble(txtPrecio.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVencimiento.Value);
                    cmdAgregarCompra.Parameters.AddWithValue("@cantidad", Convert.ToInt32(txtCantidad.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@fechacompra", Convert.ToDateTime(dtpFehcaCompra.Value));
                    cmdAgregarCompra.Parameters.AddWithValue("@documento", txtDocumento.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@tipo", cbxTipo.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@estado", cbxEstadoCompra.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@costo", Convert.ToDouble(txtCosto.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@proveedorID", proveedorID);


                    // Ejecuta el procedimiento almacenado
                    cmdAgregarCompra.ExecuteNonQuery();
                    MessageBox.Show("Compra registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.
                    txtNombeArticulo.Text = "";
                    txtCodigo.Text = "";
                    txtPrecio.Text = "";
                    //txtVencimiento.Text = "";
                    txtCantidad.Text = "";
                    dtpFehcaCompra.ResetText();
                    txtDocumento.Text = "";
                    txtCosto.Text = "";
                    cbxProveedor.SelectedIndex = -1;  // Deseleccionar proveedor
                    cbxTipo.SelectedIndex = -1;       // Deseleccionar tipo
                    cbxEstadoCompra.SelectedIndex = -1; // Deseleccionar estado



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }

        

        }*/

        private void LlenarComboProveedores()
        {
            try
            {
                
                SqlConnection conexion = cnxconcentrado.ObtenerConexion();

                // Crear el comando SQL para seleccionar los proveedores
                using (SqlCommand cmd = new SqlCommand("SELECT ProveedorID, Nombre FROM proyecto.Proveedor", conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Crear una tabla para almacenar temporalmente los datos de los proveedores
                        DataTable dtProveedores = new DataTable();
                        dtProveedores.Load(reader);

                        // Asignar el DataTable como DataSource del ComboBox
                        cbxProveedor.DataSource = dtProveedores;

                        // Mostrar el nombre del proveedor
                        cbxProveedor.DisplayMember = "Nombre";

                        // Internamente almacenar el ProveedorID
                        cbxProveedor.ValueMember = "ProveedorID";
                    }
                }
                //inicia vacio.
                cbxProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private bool ValidarErrorEditar()
        {
            // Limpiar cualquier error previo
            epEditar.Clear();

            if (txtCompraID.Text == string.Empty)
            {
                epEditar.SetError(txtCompraID, "Debe Seleccionar un articulo para actualizar su informacion.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombeArticulo.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtNombeArticulo.Text, @"^[a-zA-Z\s]+$"))
            {
                epEditar.SetError(txtNombeArticulo, "Debe agregar el nombre del concentrado.");
                return false;
            }
            else if (txtCodigo.Text == string.Empty)
            {
                epEditar.SetError(txtCodigo, "El código del concentrado es obligatorio.");
                return false;
            }
            else if (txtPrecio.Text == string.Empty || !float.TryParse(txtPrecio.Text, out _))
            {
                epEditar.SetError(txtPrecio, "El precio del artículo es obligatorio y solo valores nuemericos.");
                return false;
            }
            else if (txtCantidad.Text == string.Empty || !int.TryParse(txtCantidad.Text, out _))
            {
                epEditar.SetError(txtCantidad, "La cantidad de entrada es obligatoria y debe ser cantidades enteras.");
                return false;
            }

            else if (cbxProveedor.SelectedIndex == -1)
            {
                epEditar.SetError(cbxProveedor, "Debe seleccionar un proveedor.");
                return false;
            }
            else if (txtDocumento.Text == string.Empty)
            {
                epEditar.SetError(txtDocumento, "Debe agregar un documento para la compra.");
                return false;
            }

            else if (cbxTipo.SelectedIndex == -1)
            {
                epEditar.SetError(cbxTipo, "El tipo de compra es obligatorio.");
                return false;
            }
            else if (cbxEstadoCompra.SelectedIndex == -1)
            {
                epEditar.SetError(cbxEstadoCompra, "El estado de compra es obligatorio.");
                return false;
            }


            else if (txtCosto.Text == string.Empty || !float.TryParse(txtCosto.Text, out _))
            {
                epAgregar.SetError(txtCosto, "El costo de compra es obligatorio y unicamente valores numericos.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true

        }

        private void btnEditarCompraCon_Click(object sender, EventArgs e)
        {
            //Form frmGestionConcentradoEditar = new frmGestionConcentradoEditar();
            //frmGestionConcentradoEditar.Show();


            try
            {
                if (!ValidarErrorEditar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }

                using (SqlConnection conexion = cnxconcentrado.ObtenerConexion())
                {
                    // Asegurarse de que la conexión esté abierta
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

                    // Crear el comando y asociarlo con la conexión
                    using (SqlCommand cmdModificarCompra = new SqlCommand("spModificarConcentrado", conexion))
                    {
                        cmdModificarCompra.CommandType = CommandType.StoredProcedure;
                        int proveedorID = Convert.ToInt32(cbxProveedor.SelectedValue);

                        
                        // Agregar los parámetros necesarios
                        cmdModificarCompra.Parameters.AddWithValue("@nombre", txtNombeArticulo.Text.Trim());
                        cmdModificarCompra.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim());
                        cmdModificarCompra.Parameters.AddWithValue("@precio", Convert.ToDouble(txtPrecio.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVencimiento.Value);
                        cmdModificarCompra.Parameters.AddWithValue("@cantidad", Convert.ToInt32(txtCantidad.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@fechaCompra", dtpFehcaCompra.Value);
                        cmdModificarCompra.Parameters.AddWithValue("@documento", txtDocumento.Text.Trim());
                        cmdModificarCompra.Parameters.AddWithValue("@tipo", cbxTipo.SelectedItem?.ToString() ?? string.Empty);
                        cmdModificarCompra.Parameters.AddWithValue("@estadocompra", cbxEstadoCompra.SelectedItem?.ToString() ?? string.Empty);
                        cmdModificarCompra.Parameters.AddWithValue("@proveedorID", proveedorID);
                        cmdModificarCompra.Parameters.AddWithValue("@costo", Convert.ToDouble(txtCosto.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@compraid", Convert.ToInt32(txtCompraID.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@concentradoid", txtconID.Text.Trim());

                        // Ejecutar el procedimiento almacenado
                        cmdModificarCompra.ExecuteNonQuery();
                        MessageBox.Show("Compra Modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los datos después de la operación
                        LimpiarDatos();
                        dtCompraConcen.Clear(); // Limpia los datos actuales del DataTable
                        adapterCompraConcen.Fill(dtCompraConcen); // Vuelve a cargar los datos desde la base de datos
                        dgGestionConcentrado.Refresh(); // Refresca la interfaz
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error de formato: {ex.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //metodo para el boton limpiar

        private void LimpiarDatos()
        {

            txtNombeArticulo.Clear();
            txtCodigo.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtDocumento.Clear();
            txtCosto.Clear();
            txtconID.Clear();
            txtCompraID.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           LimpiarDatos();
        }
        private bool ValidarErrorEliminar()
        {
            // Limpiar cualquier error previo
            epEliminar.Clear();

            if (txtCompraID.Text == string.Empty)
            {
                epEliminar.SetError(txtCompraID, "Debe Seleccionar un articulo a eliminar.");
                return false;
            }


            return true; // Si todas las validaciones son correctas, devuelve true
        }

        private void btnEliminarCompraCon_Click(object sender, EventArgs e)
        {
           

            try
            {
                if (!ValidarErrorEliminar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }



                if (MessageBox.Show("¿Desea Eliminar este concentrado de Kardex?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;

            int compraid = Convert.ToInt32(dgGestionConcentrado.CurrentRow.Cells["CompraID"].Value);
            SqlCommand cmdEliminar = new SqlCommand("SpEliminarCompraConcentrado", cnxconcentrado.ObtenerConexion());
            cmdEliminar.CommandType = CommandType.StoredProcedure;
            cmdEliminar.Parameters.AddWithValue("@CompraID",compraid);


                cmdEliminar.ExecuteNonQuery();
                MessageBox.Show("Compra eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtCompraConcen.Clear();
                adapterCompraConcen.Fill(dtCompraConcen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la compra: " + ex.Message,  "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }




        private void dgGestionConcentrado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //doble click para enviar a los txt
            // Verificamos si se ha hecho clic en una fila válida
            if (e.RowIndex >= 0)
            {


                // Obtenemos la fila seleccionada
                DataGridViewRow filaSeleccionada = dgGestionConcentrado.Rows[e.RowIndex];

                // Asignamos los valores a los TextBox (ajusta los nombres de los TextBox y las columnas según tu diseño)
                txtNombeArticulo.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtCodigo.Text = filaSeleccionada.Cells["Codigo"].Value.ToString();
                txtPrecio.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                txtCantidad.Text = filaSeleccionada.Cells["Cantidad"].Value.ToString();
                cbxProveedor.SelectedItem = filaSeleccionada.Cells["NombreProveedor"].Value.ToString();
                txtDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                cbxTipo.SelectedItem = filaSeleccionada.Cells["Tipo"].Value.ToString();
                cbxEstadoCompra.SelectedItem = filaSeleccionada.Cells["Estado"].Value.ToString();
                txtCosto.Text = filaSeleccionada.Cells["Costo"].Value.ToString();
                txtCompraID.Text = filaSeleccionada.Cells["CompraID"].Value.ToString();
                txtconID.Text = filaSeleccionada.Cells["ArticuloConID"].Value.ToString();

            }
        }

        private void btnAgregarVarios_Click(object sender, EventArgs e)
        {

            if (!ValidaionAgregar())
            {
                return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
            }
            //------------------------------------------------
            decimal costo = Convert.ToDecimal(txtCosto.Text);
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            string nombre = txtNombeArticulo.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            // Validar que el costo no sea mayor que el precio
            if (costo > precio)
            {
                // Usar ErrorProvider para mostrar un mensaje de error en el campo correspondiente
                epAgregar.SetError(txtCosto, "El costo no puede ser mayor que el precio.");
                epAgregar.SetError(txtPrecio, "El costo no puede ser mayor que el precio.");

                // Cambiar el color de fondo a rojo para resaltar el error
                txtCosto.BackColor = Color.FromArgb(204, 185, 65);
                txtPrecio.BackColor = Color.FromArgb(204, 185, 65);

                // Evitar que el formulario se guarde si hay error
                return;
            }
            else
            {
                // Limpiar el mensaje de error si la validación es correcta
                epAgregar.SetError(txtCosto, string.Empty);
                epAgregar.SetError(txtPrecio, string.Empty);

                // Restablecer colores
                txtCosto.BackColor = Color.White;
                txtPrecio.BackColor = Color.White;
            }

            if (nombre.Length > 50)
            {
                // Mostrar el mensaje de error en el campo de nombre
                epAgregar.SetError(txtNombeArticulo, "El nombre debe tener un tamaño menor a 50 letras..");

                // Cambiar el color de fondo del TextBox
                txtNombeArticulo.BackColor = Color.FromArgb(204, 185, 65); // Color personalizado

                // Evitar que el formulario se guarde si hay error
                return;
            }
            else
            {
                // Limpiar el mensaje de error si la validación es correcta
                epAgregar.SetError(txtNombeArticulo, string.Empty);

                // Restablecer el color de fondo
                txtNombeArticulo.BackColor = Color.White;
            }
            if (cantidad > 100)
            {
                MessageBox.Show("Cantidad inusual, revisar campo 'Cantidad'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Opcional: limpiar el campo de cantidad o establecer un límite
               
            }



            //--------------------------------------------------

            string Nombre = txtNombeArticulo.Text;
            string Codigo = txtCodigo.Text;
            decimal Precio = decimal.Parse(txtPrecio.Text);
            int Cantidad = int.Parse(txtCantidad.Text);
            
            string Proveedor = cbxProveedor.Text;
            string Documento = txtDocumento.Text;

            string Tipo = cbxTipo.SelectedItem?.ToString();
            string Estado = cbxEstadoCompra.SelectedItem?.ToString();
            decimal Costo = decimal.Parse(txtCosto.Text);

            DateTime FechaCompra = dtpFehcaCompra.Value;
            DateTime FechaVencimiento = dtpFechaVencimiento.Value;
            // Validar datos
            if (string.IsNullOrWhiteSpace(Codigo) || string.IsNullOrWhiteSpace(Nombre) ||
                Cantidad <= 0 || Precio <= 0 || Proveedor == null || Tipo == null || Estado == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Agregar al DataGridView
            dgarticuloscompra.Rows.Add(Nombre,Codigo, Precio, Cantidad, Proveedor, Documento,Tipo, Estado,Costo,FechaCompra, FechaVencimiento);

            LimpiarDatos();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            

            if (dgarticuloscompra.Rows.Count == 0)
            {
                MessageBox.Show("No hay artículos para comprar.");
                return;
            }

            // Conexión a la base de datos
            SqlConnection conexion = cnxconcentrado.ObtenerConexion();

            SqlTransaction transaction = conexion.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow row in dgarticuloscompra.Rows)
                    {
                        if (row.IsNewRow) continue; // Saltar la fila nueva en DataGridView

                        // Leer datos de la fila
                        string codigo = row.Cells["Codigo"].Value.ToString();
                        string nombre = row.Cells["Nombre"].Value.ToString();
                        int cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString());
                        decimal precio = decimal.Parse(row.Cells["Precio"].Value.ToString());
                        string proveedor = row.Cells["Proveedor"].Value.ToString();
                        string tipo = row.Cells["Tipo"].Value.ToString();
                        string estado = row.Cells["EstadoCompra"].Value.ToString();
                        string documento = row.Cells["Documento"].Value.ToString();
                    decimal costo = decimal.Parse(row.Cells["Costo"].Value.ToString());
                    DateTime fechaCompra = DateTime.Parse(row.Cells["FechaCompra"].Value.ToString());
                    DateTime fechaVencimiento = DateTime.Parse(row.Cells["FechaVencimiento"].Value.ToString());

                    // Llamar al procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("spPruebaAgregarVariosConcentrado", conexion, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Codigo", codigo);
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@Precio", precio);
                            cmd.Parameters.AddWithValue("@Proveedor", proveedor);
                            cmd.Parameters.AddWithValue("@Tipo", tipo);
                            cmd.Parameters.AddWithValue("@EstadoCompra", estado);
                        cmd.Parameters.AddWithValue("@Documento", documento);
                        cmd.Parameters.AddWithValue("@Costo", costo);
                        cmd.Parameters.AddWithValue("@FechaCompra", fechaCompra);
                        cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);

                        cmd.ExecuteNonQuery();
                        }
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                    MessageBox.Show("Compra realizada con éxito.");
                    dgarticuloscompra.Rows.Clear();

                dtCompraConcen.Clear(); // Limpia los datos actuales del DataTable
                adapterCompraConcen.Fill(dtCompraConcen); // Vuelve a cargar los datos desde la base de datos
                dgGestionConcentrado.Refresh(); // Refresca la interfaz

            }
            catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaction.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }


            
        }
        private void toolTipsCompra()
        {
            toolTipCompra = new System.Windows.Forms.ToolTip();
            toolTipCompra.IsBalloon = true;
            toolTipCompra.ToolTipIcon = ToolTipIcon.Info;
            toolTipCompra.ToolTipTitle = "Ayuda";
            toolTipCompra.UseAnimation = true;
            toolTipCompra.SetToolTip(txtNombeArticulo, "Ingrese el nombre del concentrado");
            toolTipCompra.SetToolTip(txtCodigo, "Codigo del neuvo concentrado.");
            toolTipCompra.SetToolTip(txtPrecio, "Precio del concentrado.");
            toolTipCompra.SetToolTip(txtCantidad, "Ingrese la cantidad de items a comprar de este concentrado.");
            toolTipCompra.SetToolTip(cbxProveedor, "Eliga un proveedor al que se registrara la compra.");
            toolTipCompra.SetToolTip(txtDocumento, "Debe ingresar el documento");
            toolTipCompra.SetToolTip(cbxTipo, "Elija el tipo de compra.");
            toolTipCompra.SetToolTip(cbxEstadoCompra, "Elija el termino en el que se realizo la compra");
            toolTipCompra.SetToolTip(txtCosto, "Ingrese el costo.");
            toolTipCompra.SetToolTip(btnAgregarVarios, "Agrega un item a la lista de la compra.");
            toolTipCompra.SetToolTip(btnComprar, "Se registra la compra de todos los items registrados.");
            toolTipCompra.SetToolTip(btnEditarCompraCon, "Edita un item en la tabla compra.");
            toolTipCompra.SetToolTip(btnLimpiarConcentradoCompara, "Limpia los campos necesarios del formulario.");
            toolTipCompra.SetToolTip(btnEliminarCompraCon, "Elimina una compra.");
           


        }

        private void txtNombeArticulo_TextChanged(object sender, EventArgs e)
        {
            // Obtén el texto ingresado y elimina espacios extra
            string nombre = txtNombeArticulo.Text.Trim();

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
                txtCodigo.Text = codigoArticulo;
            }
            else
            {
                // Limpia el campo del código si no hay texto válido en el nombre
                txtCodigo.Text = string.Empty;
            }
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada
            DateTime selectedDate = dtpFechaVencimiento.Value.Date;

            if (selectedDate == DateTime.Today)
            {
                // Mostrar mensaje con las opciones Sí o No
                DialogResult result = MessageBox.Show(
                    "El producto está próximo a vencer. ¿Desea realizar la compra?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
