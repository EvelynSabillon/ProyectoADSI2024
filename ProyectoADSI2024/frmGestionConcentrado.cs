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


namespace ProyectoADSI2024
{
    public partial class frmGestionConcentrado : Form
    {
        private Conexion cnxconcentrado;
        SqlDataAdapter  adapterCompraConcen;
        DataTable dtCompraConcen;



        public frmGestionConcentrado()
        {
            
            InitializeComponent();
            cnxconcentrado = new Conexion();

            dtCompraConcen = new DataTable();
            adapterCompraConcen = new SqlDataAdapter("SpComprasActivas", cnxconcentrado.ObtenerConexion());
            adapterCompraConcen.SelectCommand.CommandType = CommandType.StoredProcedure;


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

        private void btnAgregarCompraCon_Click(object sender, EventArgs e)
        {

           

            try
            {
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



        }

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

        private void btnEditarCompraCon_Click(object sender, EventArgs e)
        {
            Form frmGestionConcentradoEditar = new frmGestionConcentradoEditar();
            frmGestionConcentradoEditar.Show();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
           LimpiarDatos();
        }

        private void btnEliminarCompraCon_Click(object sender, EventArgs e)
        {
            if (dgGestionConcentrado.CurrentRow ==null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int compraid = Convert.ToInt32(dgGestionConcentrado.CurrentRow.Cells["CompraID"].Value);
            SqlCommand cmdEliminar = new SqlCommand("SpEliminarCompraConcentrado", cnxconcentrado.ObtenerConexion());
            cmdEliminar.CommandType = CommandType.StoredProcedure;
            cmdEliminar.Parameters.AddWithValue("@CompraID",compraid);



            try
            {


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
    }
}
