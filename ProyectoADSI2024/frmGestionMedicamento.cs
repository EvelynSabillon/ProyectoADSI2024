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

namespace ProyectoADSI2024
{
    public partial class frmGestionMedicamento : Form
    {
        SqlDataAdapter adpCompraMed;
        DataTable dtCompraMed;
        private Conexion cnxCompraMedic;
        
        public frmGestionMedicamento()
        {
            InitializeComponent();
            //mostrar compra en el dg
            cnxCompraMedic = new Conexion();
            adpCompraMed = new SqlDataAdapter("spMostrarCompradMedActivas", cnxCompraMedic.ObtenerConexion());
            adpCompraMed.SelectCommand.CommandType = CommandType.StoredProcedure;
            dtCompraMed = new DataTable();
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
            {  //COMPRA DE MEDICAMENTOO
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

    }
}
