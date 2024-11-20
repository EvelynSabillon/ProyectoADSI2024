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
        public PagoProveedores()
        {
            InitializeComponent();
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
            

            comboMetodo.Items.Add("Crédito");
            comboMetodo.Items.Add("Efectivo");

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

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString2))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spPagoProvInsert", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agrega los parámetros
                        cmd.Parameters.AddWithValue("@PagoID", int.Parse(pagoId.Text));
                        cmd.Parameters.AddWithValue("@ProveedorID", int.Parse(provId.Text));

                        // Lógica para CompraConID o CompraMedID
                        if (rdCon.Checked)
                        {
                            cmd.Parameters.AddWithValue("@CompraConID", int.Parse(compraId.Text));
                            cmd.Parameters.AddWithValue("@CompraMedID", DBNull.Value); // NULL para el otro campo
                        }
                        else if (rdMed.Checked)
                        {
                            cmd.Parameters.AddWithValue("@CompraConID", DBNull.Value); // NULL para el otro campo
                            cmd.Parameters.AddWithValue("@CompraMedID", int.Parse(compraId.Text));
                        }

                        cmd.Parameters.AddWithValue("@FechaPago", DateTime.Parse(datePago.Text));
                        cmd.Parameters.AddWithValue("@MontoPago", decimal.Parse(pagoMonto.Text));
                        cmd.Parameters.AddWithValue("@MetodoPago", comboMetodo.SelectedItem.ToString());

                        // Valores de Checkbox (true o false)
                        string estadoPago = chboxPen.Checked ? "Pendiente" : "Completado";
                        cmd.Parameters.AddWithValue("@EstadoPago", estadoPago);

                        cmd.Parameters.AddWithValue("@Activo", chboxActivo.Checked);

                        // Ejecutar el comando
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Pago guardado exitosamente.");

                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el pago: " + ex.Message);
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
                chboxPen.Checked = false; // Desmarcar el CheckBox
                chboxActivo.Checked = false; // Desmarcar el CheckBox
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
    }
}
