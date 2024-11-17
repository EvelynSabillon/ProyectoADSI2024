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
    public partial class frmMedicamentoExistente : Form
    {

        private Conexion cnxCompraExisMed;
        SqlDataAdapter adpCompraExisMed;
        DataTable dtCompraExisMed;

        public frmMedicamentoExistente()
        {
            InitializeComponent();

            cnxCompraExisMed = new Conexion();
            dtCompraExisMed = new DataTable();

            adpCompraExisMed = new SqlDataAdapter("spMostrarMedicActivos", cnxCompraExisMed.ObtenerConexion());
            adpCompraExisMed.SelectCommand.CommandType = CommandType.StoredProcedure;

        }

        private void frmMedicamentoExistente_Load(object sender, EventArgs e)
        {

            LlenarComboProveedores();
            adpCompraExisMed.Fill(dtCompraExisMed);
            dgMedicamentoExist.DataSource = dtCompraExisMed;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void LimpiarDatos()
        {
            txtIDArticulo.Clear();
            txtNombreArticulo.Clear();
            txtCodigoArticulo.Clear();
            txtNombreArticulo.Clear();
            txtCantidadArt.Clear();
            cbxProveedorArticulo.ResetText();
            txtDocumentoArticulo.Clear();
            cbxTipoArticulo.ResetText();
            cbxEstadoCompraArticulo.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void btnEditarCompraCon_Click(object sender, EventArgs e)
        {
            try
            {  //COMPRA DE MEDICAMENTOO
                SqlConnection conexion = cnxCompraExisMed.ObtenerConexion();
                int proveedorID = Convert.ToInt32(cbxProveedorArticulo.SelectedValue);
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarCompra = new SqlCommand("spCompraMedicamentoExistente", conexion))
                {
                    cmdAgregarCompra.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarCompra.Parameters.AddWithValue("@ArticuloId", Convert.ToInt32(txtIDArticulo.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@cantidad", Convert.ToInt32(txtCantidadArt.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@fechacompra", Convert.ToDateTime(dtpFechaCompArt.Value));
                    cmdAgregarCompra.Parameters.AddWithValue("@documento", txtDocumentoArticulo.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@tipo", cbxTipoArticulo.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@estado", cbxEstadoCompraArticulo.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@proveedorid", proveedorID);


                    // Ejecuta el procedimiento almacenado
                    cmdAgregarCompra.ExecuteNonQuery();
                    MessageBox.Show("Compra registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.
                    txtIDArticulo.Text = "";
                    txtCodigoArticulo.Text = "";
                    txtNombreArticulo.Text = "";
                    txtNombreArticulo.Text = "";
                    cbxProveedorArticulo.SelectedIndex = -1;  // Deseleccionar proveedor
                    dtpFechaCompArt.Text = "";
                    txtDocumentoArticulo.Text = "";
                    cbxTipoArticulo.SelectedIndex = -1;  // Deseleccionar proveedor
                    cbxEstadoCompraArticulo.SelectedIndex = -1; // Deseleccionar estado




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }

        private void dgMedicamentoExist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = dgMedicamentoExist.Rows[e.RowIndex];

                // Asigno los valores de las celdas a los TextBox
                txtIDArticulo.Text = filaSeleccionada.Cells["ArticuloMedID"].Value?.ToString();
                txtCodigoArticulo.Text = filaSeleccionada.Cells["Codigo"].Value?.ToString();
                txtNombreArticulo.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                cbxTipoArticulo.Text = filaSeleccionada.Cells["Tipo"].Value?.ToString();


            }
        }

        private void LlenarComboProveedores()
        {
            try
            {

                SqlConnection conexion = cnxCompraExisMed.ObtenerConexion();

                // Crear el comando SQL para seleccionar los proveedores
                using (SqlCommand cmd = new SqlCommand("SELECT ProveedorID, Nombre FROM proyecto.Proveedor", conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Crear una tabla para almacenar temporalmente los datos de los proveedores
                        DataTable dtProveedores = new DataTable();
                        dtProveedores.Load(reader);

                        // Asignar el DataTable como DataSource del ComboBox
                        cbxProveedorArticulo.DataSource = dtProveedores;

                        // Mostrar el nombre del proveedor
                        cbxProveedorArticulo.DisplayMember = "Nombre";

                        // Internamente almacenar el ProveedorID
                        cbxProveedorArticulo.ValueMember = "ProveedorID";
                    }
                }
                //inicia vacio.
                cbxProveedorArticulo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }
    }
}
