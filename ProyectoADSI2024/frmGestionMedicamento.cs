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
    public partial class frmGestionMedicamento : Form
    {
        SqlDataAdapter adpCompraMed;
        DataTable dtCompraMed;
        private Conexion cnxCompraMedic;
        System.Windows.Forms.ToolTip toolTipCompraMedicamento;

        public frmGestionMedicamento()
        {
            InitializeComponent();
            //mostrar compra en el dg
            cnxCompraMedic = new Conexion();
            adpCompraMed = new SqlDataAdapter("spMostrarCompradMedActivas", cnxCompraMedic.ObtenerConexion());
            adpCompraMed.SelectCommand.CommandType = CommandType.StoredProcedure;
            dtCompraMed = new DataTable();
            tooltipcompramedicamento1();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmGestionMedicamento_Load(object sender, EventArgs e)
        {
            //LOAD compras de medicamentos. 
            LlenarComboProveedores();
            adpCompraMed.Fill(dtCompraMed);
            dgGestionMedCompra.DataSource = dtCompraMed;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {

            txtNombeArticuloMed.Clear();
            txtCodigoMed.Clear();
            txtPrecioMed.Clear();
            txtCantidadMed.Clear();
            txtDocumentoMed.Clear();
            txtCostoMed.Clear();
            txtCompraIDMed.Clear();
            txtconIDMed.Clear();
            cbxEstadoCompraMed.SelectedIndex = -1;
            cbxProveedorMed.SelectedIndex = -1;
            cbxTipoMed.SelectedIndex = -1;
        }

        private void btnEliminarCompraMed_Click(object sender, EventArgs e)
        {

            if (!ValidarErrorEliminar())
            {
                return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
            }
            //eliminar registros del dg (eliminacion logica)
            if (dgGestionMedCompra.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int compraid = Convert.ToInt32(dgGestionMedCompra.CurrentRow.Cells["CompraID"].Value);
            SqlCommand cmdEliminar = new SqlCommand("SpEliminarMedicamento", cnxCompraMedic.ObtenerConexion());
            cmdEliminar.CommandType = CommandType.StoredProcedure;
            cmdEliminar.Parameters.AddWithValue("@CompraID", compraid);//de medicamento



            try
            {

                cmdEliminar.ExecuteNonQuery();
                MessageBox.Show("Compra eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtCompraMed.Clear();
                adpCompraMed.Fill(dtCompraMed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCompraCon_Click(object sender, EventArgs e)
        {
            /*
            try


            {


                if (!ValidaionAgregar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                //COMPRA DE MEDICAMENTOO
                SqlConnection conexion = cnxCompraMedic.ObtenerConexion();
                int proveedorID = Convert.ToInt32(cbxProveedorMed.SelectedValue);
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarCompra = new SqlCommand("spCompraMedicamento", conexion))
                {
                    cmdAgregarCompra.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarCompra.Parameters.AddWithValue("@nombrearticuloMed", txtNombeArticuloMed.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@codigoMed", txtCodigoMed.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@precioMed", Convert.ToDouble(txtPrecioMed.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@fechaVencimientoMed", dtpFechaVenMed.Value);
                    cmdAgregarCompra.Parameters.AddWithValue("@cantidadMed", Convert.ToInt32(txtCantidadMed.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@fechacompraMed", Convert.ToDateTime(dtpFechaCompraMed.Value));
                    cmdAgregarCompra.Parameters.AddWithValue("@documentoMed", txtDocumentoMed.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@tipoMed", cbxTipoMed.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@estadoMed", cbxEstadoCompraMed.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@costoMed", Convert.ToDouble(txtCostoMed.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@proveedorIDMed", proveedorID);


                    // Ejecuta el procedimiento almacenado
                    cmdAgregarCompra.ExecuteNonQuery();
                    MessageBox.Show("Compra registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.
                    txtNombeArticuloMed.Text = "";
                    txtCodigoMed.Text = "";
                    txtPrecioMed.Text = "";
                    //txtVencimiento.Text = "";
                    txtCantidadMed.Text = "";
                    dtpFechaCompraMed.ResetText();
                    txtDocumentoMed.Text = "";
                    txtCostoMed.Text = "";
                    cbxProveedorMed.SelectedIndex = -1;  // Deseleccionar proveedor
                    cbxTipoMed.SelectedIndex = -1;       // Deseleccionar tipo
                    cbxEstadoCompraMed.SelectedIndex = -1; // Deseleccionar estado

                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }*/
        }

        private void LlenarComboProveedores()
        {
            try
            {

                SqlConnection conexion = cnxCompraMedic.ObtenerConexion();

                // Crear el comando SQL para seleccionar los proveedores
                using (SqlCommand cmd = new SqlCommand("SELECT ProveedorID, Nombre FROM proyecto.Proveedor", conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Crear una tabla para almacenar temporalmente los datos de los proveedores
                        DataTable dtProveedores = new DataTable();
                        dtProveedores.Load(reader);

                        // Asignar el DataTable como DataSource del ComboBox
                        cbxProveedorMed.DataSource = dtProveedores;

                        // Mostrar el nombre del proveedor
                        cbxProveedorMed.DisplayMember = "Nombre";

                        // Internamente almacenar el ProveedorID
                        cbxProveedorMed.ValueMember = "ProveedorID";
                    }
                }
                //inicia vacio.
                cbxProveedorMed.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }
        private bool ValidaionAgregar()
        {
            // Limpiar cualquier error previo
            epAgregar.Clear();

            if (txtNombeArticuloMed.Text == string.Empty)
            {
                epAgregar.SetError(txtNombeArticuloMed, "Debe agregar el nombre del concentrado.");
                return false;
            }
            else if (txtCodigoMed.Text == string.Empty)
            {
                epAgregar.SetError(txtCodigoMed, "El código del concentrado es obligatorio.");
                return false;
            }
            else if (txtPrecioMed.Text == string.Empty)
            {
                epAgregar.SetError(txtPrecioMed, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (txtCantidadMed.Text == string.Empty)
            {
                epAgregar.SetError(txtCantidadMed, "La cantidad de entrada es obligatoria.");
                return false;
            }

            else if (cbxProveedorMed.SelectedIndex == -1)
            {
                epAgregar.SetError(cbxProveedorMed, "Debe seleccionar un proveedor.");
                return false;
            }
            else if (txtDocumentoMed.Text == string.Empty)
            {
                epAgregar.SetError(txtDocumentoMed, "Debe agregar un documento para la compra.");
                return false;
            }

            else if (cbxTipoMed.SelectedIndex == -1)
            {
                epAgregar.SetError(cbxTipoMed, "El tipo de compra es obligatorio.");
                return false;
            }
            else if (cbxEstadoCompraMed.SelectedIndex == -1)
            {
                epAgregar.SetError(cbxEstadoCompraMed, "El estado de compra es obligatorio.");
                return false;
            }


            else if (txtCostoMed.Text == string.Empty)
            {
                epAgregar.SetError(txtCostoMed, "El costo de compra es obligatorio.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true

        }
        private bool ValidarErrorEditar()
        {
            // Limpiar cualquier error previo
            epEditar.Clear();

            if (txtCompraIDMed.Text == string.Empty)
            {
                epEditar.SetError(txtCompraIDMed, "Debe Seleccionar un articulo para actualizar su informacion.");
                return false;
            }
            if (txtNombeArticuloMed.Text == string.Empty)
            {
                epEditar.SetError(txtNombeArticuloMed, "Debe agregar el nombre del concentrado.");
                return false;
            }
            else if (txtCodigoMed.Text == string.Empty)
            {
                epEditar.SetError(txtCodigoMed, "El código del concentrado es obligatorio.");
                return false;
            }
            else if (txtPrecioMed.Text == string.Empty)
            {
                epEditar.SetError(txtPrecioMed, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (txtCantidadMed.Text == string.Empty)
            {
                epEditar.SetError(txtCantidadMed, "La cantidad de entrada es obligatoria.");
                return false;
            }

            else if (cbxProveedorMed.SelectedIndex == -1)
            {
                epEditar.SetError(cbxProveedorMed, "Debe seleccionar un proveedor.");
                return false;
            }
            else if (txtDocumentoMed.Text == string.Empty)
            {
                epEditar.SetError(txtDocumentoMed, "Debe agregar un documento para la compra.");
                return false;
            }

            else if (cbxTipoMed.SelectedIndex == -1)
            {
                epEditar.SetError(cbxTipoMed, "El tipo de compra es obligatorio.");
                return false;
            }
            else if (cbxEstadoCompraMed.SelectedIndex == -1)
            {
                epEditar.SetError(cbxEstadoCompraMed, "El estado de compra es obligatorio.");
                return false;
            }


            else if (txtCostoMed.Text == string.Empty)
            {
                epAgregar.SetError(txtCostoMed, "El costo de compra es obligatorio.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true

        }

        private bool ValidarErrorEliminar()
        {
            // Limpiar cualquier error previo
            epEliminar.Clear();

            if (txtCompraIDMed.Text == string.Empty)
            {
                epEliminar.SetError(txtCompraIDMed, "Debe Seleccionar un articulo a eliminar.");
                return false;
            }


            return true; // Si todas las validaciones son correctas, devuelve true
        }

        private void btnEditarCompraCon_Click(object sender, EventArgs e)
        {
            if (!ValidarErrorEditar())
            {
                return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
            }

            try
            {
                if (!ValidarErrorEditar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }

                using (SqlConnection conexion = cnxCompraMedic.ObtenerConexion())
                {
                    // Asegurarse de que la conexión esté abierta
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

                    // Crear el comando y asociarlo con la conexión
                    using (SqlCommand cmdModificarCompra = new SqlCommand("spModificarMedicamento", conexion))
                    {
                        cmdModificarCompra.CommandType = CommandType.StoredProcedure;
                        int proveedorID = Convert.ToInt32(cbxProveedorMed.SelectedValue);


                        // Agregar los parámetros necesarios
                        cmdModificarCompra.Parameters.AddWithValue("@nombre", txtNombeArticuloMed.Text.Trim());
                        cmdModificarCompra.Parameters.AddWithValue("@codigo", txtCodigoMed.Text.Trim());
                        cmdModificarCompra.Parameters.AddWithValue("@precio", Convert.ToDouble(txtPrecioMed.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVenMed.Value);
                        cmdModificarCompra.Parameters.AddWithValue("@cantidad", Convert.ToInt32(txtCantidadMed.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@fechaCompra", dtpFechaCompraMed.Value);
                        cmdModificarCompra.Parameters.AddWithValue("@documento", txtDocumentoMed.Text.Trim());
                        cmdModificarCompra.Parameters.AddWithValue("@tipo", cbxTipoMed.SelectedItem?.ToString() ?? string.Empty);
                        cmdModificarCompra.Parameters.AddWithValue("@estadocompra", cbxEstadoCompraMed.SelectedItem?.ToString() ?? string.Empty);
                        cmdModificarCompra.Parameters.AddWithValue("@proveedorID", proveedorID);
                        cmdModificarCompra.Parameters.AddWithValue("@costo", Convert.ToDouble(txtCostoMed.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@compraid", Convert.ToInt32(txtCompraIDMed.Text));
                        cmdModificarCompra.Parameters.AddWithValue("@medicamentoid", txtconIDMed.Text.Trim());

                        // Ejecutar el procedimiento almacenado
                        cmdModificarCompra.ExecuteNonQuery();
                        MessageBox.Show("Compra Modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los datos después de la operación
                        LimpiarDatos();
                        dtCompraMed.Clear(); // Limpia los datos actuales del DataTable
                        adpCompraMed.Fill(dtCompraMed); // Vuelve a cargar los datos desde la base de datos
                        dgGestionMedCompra.Refresh(); // Refresca la interfaz
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
        private void tooltipcompramedicamento1()
        {
            toolTipCompraMedicamento = new System.Windows.Forms.ToolTip();
            toolTipCompraMedicamento.IsBalloon = true;
            toolTipCompraMedicamento.ToolTipIcon = ToolTipIcon.Info;
            toolTipCompraMedicamento.ToolTipTitle = "Ayuda";
            toolTipCompraMedicamento.UseAnimation = true;
            toolTipCompraMedicamento.SetToolTip(txtNombeArticuloMed, "Ingrese el nombre del concentrado");
            toolTipCompraMedicamento.SetToolTip(txtCodigoMed, "Codigo del neuvo concentrado.");
            toolTipCompraMedicamento.SetToolTip(txtPrecioMed, "Precio del concentrado.");
            toolTipCompraMedicamento.SetToolTip(txtCantidadMed, "Ingrese la cantidad de items a comprar de este concentrado.");
            toolTipCompraMedicamento.SetToolTip(cbxProveedorMed, "Eliga un proveedor al que se registrara la compra.");
            toolTipCompraMedicamento.SetToolTip(txtDocumentoMed, "Debe ingresar el documento");
            toolTipCompraMedicamento.SetToolTip(cbxTipoMed, "Elija el tipo de compra.");
            toolTipCompraMedicamento.SetToolTip(cbxEstadoCompraMed, "Elija el termino en el que se realizo la compra");
            toolTipCompraMedicamento.SetToolTip(txtCostoMed, "Ingrese el costo.");
            toolTipCompraMedicamento.SetToolTip(button2, "Agrega un item a la lista de la compra.");
            toolTipCompraMedicamento.SetToolTip(btnEditarCompraCon, "Se registra la compra de todos los items registrados.");
            toolTipCompraMedicamento.SetToolTip(btnEliminarCompraMed, "Edita un item en la tabla compra.");
            toolTipCompraMedicamento.SetToolTip(button1, "Limpia los campos del formulario.");



        }

        private void dgGestionMedCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                // Obtenemos la fila seleccionada
                DataGridViewRow filaSeleccionada = dgGestionMedCompra.Rows[e.RowIndex];

                // Asignamos los valores a los TextBox (ajusta los nombres de los TextBox y las columnas según tu diseño)
                txtNombeArticuloMed.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtCodigoMed.Text = filaSeleccionada.Cells["Codigo"].Value.ToString();
                txtPrecioMed.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                txtCantidadMed.Text = filaSeleccionada.Cells["Cantidad"].Value.ToString();
                cbxProveedorMed.SelectedItem = filaSeleccionada.Cells["NombreProveedor"].Value.ToString();
                txtDocumentoMed.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                cbxTipoMed.SelectedItem = filaSeleccionada.Cells["Tipo"].Value.ToString();
                cbxEstadoCompraMed.SelectedItem = filaSeleccionada.Cells["Estado"].Value.ToString();
                txtCostoMed.Text = filaSeleccionada.Cells["Costo"].Value.ToString();
                txtCompraIDMed.Text = filaSeleccionada.Cells["CompraID"].Value.ToString();
                txtconIDMed.Text = filaSeleccionada.Cells["ArticuloMedID"].Value.ToString();

            }
        }

        //ESTE BOTON ES DE AGREGAR UN ITEM A LA COMPRA
        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidaionAgregar())
            {
                return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
            }

            string Nombre = txtNombeArticuloMed.Text;
            string Codigo = txtCodigoMed.Text;
            decimal Precio = decimal.Parse(txtPrecioMed.Text);
            int Cantidad = int.Parse(txtCantidadMed.Text);

            string Proveedor = cbxProveedorMed.Text;
            string Documento = txtDocumentoMed.Text;

            string Tipo = cbxTipoMed.SelectedItem?.ToString();
            string Estado = cbxEstadoCompraMed.SelectedItem?.ToString();
            decimal Costo = decimal.Parse(txtCostoMed.Text);

            DateTime FechaCompra = dtpFechaCompraMed.Value;
            DateTime FechaVencimiento = dtpFechaVenMed.Value;
            // Validar datos
            if (string.IsNullOrWhiteSpace(Codigo) || string.IsNullOrWhiteSpace(Nombre) ||
                Cantidad <= 0 || Precio <= 0 || Proveedor == null || Tipo == null || Estado == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Agregar al DataGridView
            dgarticuloscompra.Rows.Add(Nombre, Codigo, Precio, Cantidad, Proveedor, Documento, Tipo, Estado, Costo, FechaCompra, FechaVencimiento);

            LimpiarDatos();
        }


        //BOTON COMPRAR ITEMS
        private void button3_Click(object sender, EventArgs e)
        {
          

            if (dgarticuloscompra.Rows.Count == 0)
            {
                MessageBox.Show("No hay artículos para comprar.");
                return;
            }

            // Conexión a la base de datos
            SqlConnection conexion = cnxCompraMedic.ObtenerConexion();

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
                    using (SqlCommand cmd = new SqlCommand("spPruebaAgregarVariosMedicamentos", conexion, transaction))
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

                dtCompraMed.Clear(); // Limpia los datos actuales del DataTable
                adpCompraMed.Fill(dtCompraMed); // Vuelve a cargar los datos desde la base de datos
                dgGestionMedCompra.Refresh(); // Refresca la interfaz

            }
            catch (Exception ex)
            {
                // Revertir la transacción en caso de error
                transaction.Rollback();
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }
      

    }
}
