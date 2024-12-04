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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace ProyectoADSI2024
{
    public partial class RegistroProveedores : Form
    {

        private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";
        SqlConnection conexion;
        SqlDataAdapter adp;

        System.Windows.Forms.ToolTip toolTips;


        public RegistroProveedores()
        {
            InitializeComponent();
            toolTipsTxts();
            txBusca.Enabled = false;
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
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el formato del RTN
            if (!Regex.IsMatch(provRTN.Text, @"^\d{4}-\d{4}-\d{5}$"))
            {
                MessageBox.Show("El RTN debe tener el formato ****-****-***** (solo números y guiones).", "RTN inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el nombre contenga solo letras
            if (!Regex.IsMatch(provName.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre debe contener solo letras y espacios.", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el formato del teléfono
            if (!Regex.IsMatch(provTelef.Text, @"^\(\d{3}\)\d{4}-\d{4}$"))
            {
                MessageBox.Show("El formato del número de teléfono es inválido. Use el formato (***)****-****.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el formato del correo electrónico
            if (!IsValidEmail(provEmail.Text))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el ID sea un número entero positivo
            if (!int.TryParse(provId.Text, out int provID) || provID <= 0)
            {
                MessageBox.Show("El ID debe ser un número entero positivo.", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Procesar el formulario (guardar en la base de datos)
            GuardarProveedor(provID, provName.Text, provRTN.Text, provDirec.Text, provTelef.Text, provEmail.Text, chboxActivo.Checked);
        }

        private void GuardarProveedor(int id, string nombre, string rtn, string direccion, string telefono, string email, bool activo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spRegProvInsert", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@provID", id);
                        cmd.Parameters.AddWithValue("@provName", nombre);
                        cmd.Parameters.AddWithValue("@provRTN", rtn);
                        cmd.Parameters.AddWithValue("@provDirec", direccion);
                        cmd.Parameters.AddWithValue("@provTelef", telefono);
                        cmd.Parameters.AddWithValue("@provEmail", email);
                        cmd.Parameters.AddWithValue("@chboxActivo", activo);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTxtBox();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validar formato de correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
            string query = "SELECT * FROM proyecto.Proveedor WHERE Activo = 1"; // Modificar según tus columnas

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
            txBusca.Enabled = true;
            txBusca.Text = " ";
            FiltrarDatos();
        }

        private void toolTipsTxts()
        {
            toolTips = new System.Windows.Forms.ToolTip();
            toolTips.IsBalloon = true;
            toolTips.ToolTipIcon = ToolTipIcon.Info;
            toolTips.ToolTipTitle = "Ayuda";
            toolTips.UseAnimation = true;
            toolTips.SetToolTip(provId, "Ingrese un número de Proveedor Válido");
            toolTips.SetToolTip(provName, "Ingrese el Nombre del Proveedor.");
            toolTips.SetToolTip(provRTN, "Ingrese un RTN válido del Proveedor.");
            toolTips.SetToolTip(provDirec, "Ingrese la Dirección del Proveedor.");
            toolTips.SetToolTip(provTelef, "Ingrese el Número del Proveedor.");
            toolTips.SetToolTip(provEmail, "Ingrese el Email del Proveedor. ");
            toolTips.SetToolTip(btnAtras, "Regresar al menú.");
            toolTips.SetToolTip(btnEliminar, "Eliminar el registro");
            toolTips.SetToolTip(button2, "Limpiar los cuadros de texto y fechas.");
            toolTips.SetToolTip(button1, "Editar el registro.");
            toolTips.SetToolTip(btnGuardar, "Guardar el registro.");
            toolTips.SetToolTip(comboBusca, "Seleccione el campo en el que desea buscar.");
            toolTips.SetToolTip(txBusca, "Ingrese registro a buscar");

        }

        private void dgRegProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}