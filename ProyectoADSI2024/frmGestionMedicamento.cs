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
            }
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
            toolTipCompraMedicamento.SetToolTip(btnAgregarCompraMed, "Agrega un item a la lista de la compra.");
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
    }
}
