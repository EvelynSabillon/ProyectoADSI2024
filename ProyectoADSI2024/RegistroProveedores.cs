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
using System.Data.Common;

namespace ProyectoADSI2024
{
    public partial class RegistroProveedores : Form
    {

        private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";
        SqlConnection conexion;
        SqlDataAdapter adp;

 

        public RegistroProveedores()
        {
            InitializeComponent();
          

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos requeridos estén llenos
            if (string.IsNullOrWhiteSpace(provId.Text) ||
                string.IsNullOrWhiteSpace(provName.Text) ||
                string.IsNullOrWhiteSpace(provRTN.Text) ||
                string.IsNullOrWhiteSpace(provDirec.Text) ||
                string.IsNullOrWhiteSpace(provTelef.Text) ||
                string.IsNullOrWhiteSpace(provEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Convertir el ID y el estado del checkbox
            if (!int.TryParse(provId.Text, out int provID))
            {
                MessageBox.Show("El ID debe ser un número válido.");
                return;
            }
            bool activo = chboxActivo.Checked;

            // Ejecutar el procedimiento almacenado
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spRegProvInsert", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        cmd.Parameters.AddWithValue("@provID", provID);
                        cmd.Parameters.AddWithValue("@provName", provName.Text);
                        cmd.Parameters.AddWithValue("@provRTN", provRTN.Text);
                        cmd.Parameters.AddWithValue("@provDirec", provDirec.Text);
                        cmd.Parameters.AddWithValue("@provTelef", provTelef.Text);
                        cmd.Parameters.AddWithValue("@provEmail", provEmail.Text);
                        cmd.Parameters.AddWithValue("@chboxActivo", activo);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proveedor guardado correctamente.");

                // Limpiar los controles
                LimpiarTxtBox();

                // Actualizar el DataGridView
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM proyecto.Proveedor WHERE Activo = 1 ORDER BY Nombre desc", conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgRegProv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }


        private void LimpiarTxtBox()
        {
            provId.Clear();
            provName.Clear();
            provRTN.Clear();
            provDirec.Clear();
            provEmail.Clear();
            provTelef.Clear();
            chboxActivo.Checked = false;
        }

        private void RegistroProveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarTxtBox();

            comboBusca.Items.Add("ProveedorID");
            comboBusca.Items.Add("Nombre");
            comboBusca.Items.Add("RTN");
            comboBusca.Items.Add("Direccion");
            comboBusca.Items.Add("Telefono");
            comboBusca.Items.Add("Email");
            comboBusca.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarTxtBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Validar que todos los campos requeridos estén llenos
            if (string.IsNullOrWhiteSpace(provId.Text))
            {
                MessageBox.Show("Por favor, ingrese el ID del proveedor para editar.");
                return;
            }

            // Convertir el ID y el estado del checkbox
            if (!int.TryParse(provId.Text, out int provID))
            {
                MessageBox.Show("El ID debe ser un número válido.");
                return;
            }

            bool activo = chboxActivo.Checked;

            // Ejecutar el procedimiento almacenado
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spRegProvUpdate", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        cmd.Parameters.AddWithValue("@provID", provID);
                        cmd.Parameters.AddWithValue("@provName", provName.Text);
                        cmd.Parameters.AddWithValue("@provRTN", provRTN.Text);
                        cmd.Parameters.AddWithValue("@provDirec", provDirec.Text);
                        cmd.Parameters.AddWithValue("@provTelef", provTelef.Text);
                        cmd.Parameters.AddWithValue("@provEmail", provEmail.Text);
                        cmd.Parameters.AddWithValue("@chboxActivo", activo);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proveedor editado correctamente.");
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgRegProv.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int proveId = Convert.ToInt32(dgRegProv.CurrentRow.Cells["ProveedorID"].Value);

            // Confirmar eliminación
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?",
                                                     "Confirmar Eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
            if (resultado != DialogResult.Yes) return;

            // Ejecutar el procedimiento almacenado para eliminar el proveedor
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spRegProvDelete", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@provID", proveId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proveedor eliminado correctamente.");

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tboxBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            // Suponiendo que ya tienes un DataTable como origen de datos para el DataGridView
            DataTable dt = ObtenerDatosDeProveedor(); // Método que recupera los datos de proveedores
            string columnaSeleccionada = comboBusca.SelectedItem.ToString();
            string filtro = txBusca.Text.ToLower();

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
            dgRegProv.DataSource = dv;
        }


        private DataTable ObtenerDatosDeProveedor()
        {
            // Suponiendo que tienes una conexión a la base de datos y ejecutas una consulta
            DataTable dt = new DataTable();
            string query = "SELECT * FROM proyecto.Proveedor"; // Modificar según tus columnas

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private void comboBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
    }
}