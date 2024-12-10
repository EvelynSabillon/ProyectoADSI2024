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
using System.Xml.Linq;

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
            // Limpiar errores previos
            errorProvider1.Clear();

            bool tieneErrores = false;

            // Validar que todos los campos requeridos estén llenos
            if (string.IsNullOrWhiteSpace(provId.Text))
            {
                errorProvider1.SetError(provId, "El ID no puede estar vacío.");
                tieneErrores = true;
            }
            string idLength = provId.Text;
            if (idLength.Length > 3)
            {
                errorProvider1.SetError(provId, "El ID no puede ser mayor a 999 caracteres.");
                tieneErrores = true;
            }

            if (string.IsNullOrWhiteSpace(provName.Text))
            {
                errorProvider1.SetError(provName, "El nombre no puede estar vacío.");
                tieneErrores = true;
            }
            string nameLength = provName.Text;
            if (nameLength.Length > 50)
            {
                errorProvider1.SetError(provName, "El nombre no puede exceder los 50 caracteres.");
                tieneErrores = true;
            }
            if (string.IsNullOrWhiteSpace(provRTN.Text))
            {
                errorProvider1.SetError(provRTN, "El RTN no puede estar vacío.");
                tieneErrores = true;
            }
            if (string.IsNullOrWhiteSpace(provDirec.Text))
            {
                errorProvider1.SetError(provDirec, "La dirección no puede estar vacía.");
                tieneErrores = true;
            }
            string direcLength= provDirec.Text;
            if (direcLength.Length > 100)
            {
                errorProvider1.SetError(provDirec, "La dirección no puede exceder los 100 caracteres.");
                tieneErrores = true;
            }


            if (string.IsNullOrWhiteSpace(provTelef.Text))
            {
                errorProvider1.SetError(provTelef, "El teléfono no puede estar vacío.");
                tieneErrores = true;
            }
            if (string.IsNullOrWhiteSpace(provEmail.Text))
            {
                errorProvider1.SetError(provEmail, "El correo no puede estar vacío.");
                tieneErrores = true;
            }

            // Validar el formato del RTN
            if (!Regex.IsMatch(provRTN.Text, @"^\d{4}-\d{4}-\d{5}$"))
            {
                errorProvider1.SetError(provRTN, "El RTN debe tener el formato ****-****-*****.");
                tieneErrores = true;
            }

            // Validar que el nombre contenga solo letras
            if (!Regex.IsMatch(provName.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                errorProvider1.SetError(provName, "El nombre debe contener solo letras y espacios.");
                tieneErrores = true;
            }

            // Validar el formato del teléfono
            if (!Regex.IsMatch(provTelef.Text, @"^\(\d{3}\)\d{4}-\d{4}$"))
            {
                errorProvider1.SetError(provTelef, "El formato del teléfono es inválido. Use el formato (***)****-****.");
                tieneErrores = true;
            }

            string emailLength = provEmail.Text;
            if (emailLength.Length > 40)
            {
                errorProvider1.SetError(provEmail, "El email no puede exceder los 40 caracteres.");
                tieneErrores = true;
            }

            // Validar el formato del correo electrónico
            if (!IsValidEmail(provEmail.Text))
            {
                errorProvider1.SetError(provEmail, "El correo electrónico no tiene un formato válido.");
                tieneErrores = true;
            }

            // Validar que el ID sea un número entero positivo
            if (!int.TryParse(provId.Text, out int provID) || provID <= 0)
            {
                errorProvider1.SetError(provId, "El ID debe ser un número entero positivo.");
                tieneErrores = true;
            }

            // Si hay errores, no continuar
            if (tieneErrores)
            {
                MessageBox.Show("Corrija los errores marcados antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Procesar el formulario (guardar en la base de datos)
            GuardarProveedor(provID, provName.Text, provRTN.Text, provDirec.Text, provTelef.Text, provEmail.Text, chboxActivo.Checked);
        }

        private void GuardarProveedor(int id, string nombre, string rtn, string direccion, string telefono, string email, bool activo)
        {
            if (MessageBox.Show("¿Desea guardar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTxtBox();
                    CargarDatos();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Código de error para clave duplicada en SQL Server
                    {
                        MessageBox.Show($"El Proveedor ID ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider1.SetError(provId, "El proveedor ID ingresado ya existe.");
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar el Proveedor ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                    }
                }
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

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM proyecto.Proveedor WHERE Activo = 1 ORDER BY ProveedorID ASC", conn))
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
            // Limpiar errores previos
            errorProvider2.Clear();

            bool tieneErrores = false;

            // Validar que el ID no esté vacío
            if (string.IsNullOrWhiteSpace(provId.Text))
            {
                errorProvider2.SetError(provId, "Por favor, ingrese el ID del proveedor para editar.");
                tieneErrores = true;
            }

            // Validar que el ID sea un número entero positivo
            if (!int.TryParse(provId.Text, out int provID) || provID <= 0)
            {
                errorProvider2.SetError(provId, "El ID debe ser un número entero positivo.");
                tieneErrores = true;
            }

            // Validar que el nombre contenga solo letras
            if (!Regex.IsMatch(provName.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                errorProvider2.SetError(provName, "El nombre debe contener solo letras y espacios.");
                tieneErrores = true;
            }

            // Validar el formato del RTN
            if (!Regex.IsMatch(provRTN.Text, @"^\d{4}-\d{4}-\d{5}$"))
            {
                errorProvider2.SetError(provRTN, "El RTN debe tener el formato ****-****-*****.");
                tieneErrores = true;
            }

            // Validar que la dirección no esté vacía
            if (string.IsNullOrWhiteSpace(provDirec.Text))
            {
                errorProvider2.SetError(provDirec, "La dirección no puede estar vacía.");
                tieneErrores = true;
            }

            // Validar el formato del teléfono
            if (!Regex.IsMatch(provTelef.Text, @"^\(\d{3}\)\d{4}-\d{4}$"))
            {
                errorProvider2.SetError(provTelef, "El formato del teléfono es inválido. Use el formato (***)****-****.");
                tieneErrores = true;
            }

            // Validar el formato del correo electrónico
            if (!IsValidEmail(provEmail.Text))
            {
                errorProvider2.SetError(provEmail, "El correo electrónico no tiene un formato válido.");
                tieneErrores = true;
            }

            // Si hay errores, no continuar
            if (tieneErrores)
            {
                MessageBox.Show("Corrija los errores marcados antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Procesar el formulario (actualizar en la base de datos)
            GuardarCambios(provID, provName.Text, provRTN.Text, provDirec.Text, provTelef.Text, provEmail.Text, chboxActivo.Checked);
        }

        private void GuardarCambios(int id, string nombre, string rtn, string direccion, string telefono, string email, bool activo)
        {
            if (MessageBox.Show("¿Desea editar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("spRegProvUpdate", conn))
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
                    MessageBox.Show("Registro editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTxtBox();
                    CargarDatos();
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

           

            // Ejecutar el procedimiento almacenado para eliminar el proveedor
            if (MessageBox.Show("¿Desea eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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

                    MessageBox.Show("Registro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTxtBox();
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    CargarDatos();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            string query = "SELECT * FROM proyecto.Proveedor WHERE Activo = 1 ORDER BY ProveedorID ASC"; // Modificar según tus columnas

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

        private void dgRegProv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgRegProv.Rows[e.RowIndex];
                provId.Text = row.Cells["ProveedorID"].Value.ToString();
                provName.Text = row.Cells["Nombre"].Value.ToString();
                provRTN.Text = row.Cells["RTN"].Value.ToString();
                provDirec.Text = row.Cells["Direccion"].Value.ToString();
                provTelef.Text = row.Cells["Telefono"].Value.ToString();
                provEmail.Text = row.Cells["Email"].Value.ToString();
                chboxActivo.Checked = true;
            }
        }
    }
}