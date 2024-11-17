using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoADSI2024
{
    public partial class frmConcentradoExistente : Form
    {

        SqlDataAdapter adpConcentradoExistente;
        DataTable dtConcentradoExistente;
        private Conexion cnxConcentradoExistente;
        public frmConcentradoExistente()
        {
            InitializeComponent();
            cnxConcentradoExistente = new Conexion();
            dtConcentradoExistente = new DataTable();
            adpConcentradoExistente = new SqlDataAdapter("spArticulosMed", cnxConcentradoExistente.ObtenerConexion());
            adpConcentradoExistente.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmConcentradoExistente_Load(object sender, EventArgs e)
        {
            LlenarComboProveedores();
            adpConcentradoExistente.Fill(dtConcentradoExistente);
            dgConcentradoExist.DataSource = dtConcentradoExistente;

        }


        private void LimpiarDatos()
        {
            txtConIdCompraEx.Clear();
            txtNombreArticuloMed.Clear();
            txtCodigoCompra.Clear();
            txtNombreArticuloMed.Clear();
            txtDocumentoComEx.Clear();
            txtCantidadMed.Clear();

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void dgConcentradoExist_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
                
                if (e.RowIndex >= 0)
                {
                    
                    DataGridViewRow filaSeleccionada = dgConcentradoExist.Rows[e.RowIndex];

                    // Asigno los valores de las celdas a los TextBox
                    txtConIdCompraEx.Text = filaSeleccionada.Cells["ArticuloConID"].Value?.ToString();
                    txtCodigoCompra.Text = filaSeleccionada.Cells["Codigo"].Value?.ToString();
                    txtNombreArticuloMed.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                    cbxTipoComEx.Text = filaSeleccionada.Cells["Tipo"].Value?.ToString();
            }
            
        }

        private void LlenarComboProveedores()
        {
            try
            {

                SqlConnection conexion = cnxConcentradoExistente.ObtenerConexion();

                // Crear el comando SQL para seleccionar los proveedores
                using (SqlCommand cmd = new SqlCommand("SELECT ProveedorID, Nombre FROM proyecto.Proveedor", conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Crear una tabla para almacenar temporalmente los datos de los proveedores
                        DataTable dtProveedores = new DataTable();
                        dtProveedores.Load(reader);

                        // Asignar el DataTable como DataSource del ComboBox
                        cbxProvComEx.DataSource = dtProveedores;

                        // Mostrar el nombre del proveedor
                        cbxProvComEx.DisplayMember = "Nombre";

                        // Internamente almacenar el ProveedorID
                        cbxProvComEx.ValueMember = "ProveedorID";
                    }
                }
                //inicia vacio.
                cbxProvComEx.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void btnEditarCompraCon_Click(object sender, EventArgs e)
        {

            //@ArticuloId int , 
            //@cantidad INT,
            //@fechacompra DATETIME,
            //@documento VARCHAR(50),
            ////@tipo VARCHAR(50),
            //@estado VARCHAR(20),
            //@proveedorid INT

            try
            {  //COMPRA DE MEDICAMENTOO
                SqlConnection conexion = cnxConcentradoExistente.ObtenerConexion();
                int proveedorID = Convert.ToInt32(cbxProvComEx.SelectedValue);
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarCompra = new SqlCommand("spCompraConcentradoExistente", conexion))
                {
                    cmdAgregarCompra.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarCompra.Parameters.AddWithValue("@ArticuloId", Convert.ToInt32(txtConIdCompraEx.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@cantidad", Convert.ToInt32(txtCantidadMed.Text));
                    cmdAgregarCompra.Parameters.AddWithValue("@fechacompra", Convert.ToDateTime(dtpFechaCompraConExist.Value));         
                    cmdAgregarCompra.Parameters.AddWithValue("@documento", txtDocumentoComEx.Text);
                    cmdAgregarCompra.Parameters.AddWithValue("@tipo", cbxTipoComEx.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@estado", cbxEstadoCompraEx.SelectedItem.ToString());
                    cmdAgregarCompra.Parameters.AddWithValue("@proveedorid", proveedorID);


                    // Ejecuta el procedimiento almacenado
                    cmdAgregarCompra.ExecuteNonQuery();
                    MessageBox.Show("Compra registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.
                    txtConIdCompraEx.Text = "";
                    txtCodigoCompra.Text = "";
                    txtNombreArticuloMed.Text = "";
                    txtCantidadMed.Text = "";
                    cbxProvComEx.SelectedIndex = -1;  // Deseleccionar proveedor
                    dtpFechaConExist.Text = "";
                    txtDocumentoComEx.Text = "";
                    cbxTipoComEx.SelectedIndex = -1;  // Deseleccionar proveedor
                    cbxEstadoCompraEx.SelectedIndex = -1; // Deseleccionar estado
                   



                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }


}

    }

}
