using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class GestionUsuarios : Form
    {
        //CADENA DE CONEXION
        private string conexion = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

        //tooltip
        System.Windows.Forms.ToolTip toolTip1;

        //PARA PODER EDITAR CON UNA FECHA ANTERIOR
        private bool GuardarEdicionFecha = false;

        public GestionUsuarios()
        {
            InitializeComponent();
            toolTips();
        }

        //private void btnAtras_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        this.Dispose();
        //}


        // METODO PARA CARGAR LOS DATOS EN EL DATAGRIDVIEW
        private void CargarDatos()
        {
            // Crear el DataTable donde se almacenarán los datos
            DataTable dtUsuarios = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dtUsuarios);
                        }
                    }
                }

                // Asignar el DataTable al DataGridView
                dgUsuarios.DataSource = dtUsuarios;
                dgUsuarios.Columns["activo"].Visible = false;
                dgUsuarios.Columns["Contraseña"].Visible = false;

                //NUEVO
                // Ajustar tamaño automáticamente
                dgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN METODO DE CARGA DE DATOS EN DATAGRIDVIEW

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LlenarComboBoxPerfiles();
            LlenarComboBoxColumnas();
            FiltrarDatos();
        }

        //LLENAR COMBOBOX DE LOS PERFILES
        private void LlenarComboBoxPerfiles()
        {
            string query = "SELECT PerfilID, NombrePerfil FROM proyecto.Perfiles";

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cboxPerfil.DataSource = dt;
                    cboxPerfil.DisplayMember = "NombrePerfil";
                    cboxPerfil.ValueMember = "PerfilID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar perfiles: {ex.Message}");
                }
            }
        }
        //FIN LLENADO DE COMBOBOX DE LOS PERFILES


        //VALIDAR DATOS
        private bool ValidarDatos()
        {
            bool esValido = true;

            // Validar Nombre
            //if (string.IsNullOrWhiteSpace(tboxNombre.Text))
            //{
            //    errorProvider1.SetError(tboxNombre, "El nombre no puede estar vacío.");
            //    esValido = false;
            //}
            //else if (tboxNombre.Text.Any(char.IsDigit))
            //{
            //    errorProvider1.SetError(tboxNombre, "El nombre no puede contener números.");
            //    esValido = false;
            //}
            //else
            //{
            //    errorProvider1.SetError(tboxNombre, string.Empty);
            //}

            //NUEVO
            // Validar Nombre
            if (string.IsNullOrWhiteSpace(tboxNombre.Text))
            {
                errorProvider1.SetError(tboxNombre, "El nombre no puede estar vacío.");
                esValido = false;
            }
            else if (!Regex.IsMatch(tboxNombre.Text, @"^[a-zA-ZÁÉÍÓÚáéíóúÑñ\s]+$"))
            {
                errorProvider1.SetError(tboxNombre, "El nombre solo puede contener letras, espacios y acentos.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(tboxNombre, string.Empty);
            }

            // Validar Usuario
            if (string.IsNullOrWhiteSpace(tboxUsuario.Text))
            {
                errorProvider1.SetError(tboxUsuario, "El usuario no puede estar vacío.");
                esValido = false;
            }
            else if (tboxUsuario.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(tboxUsuario, "El usuario no puede contener números.");
                esValido = false;
            }
            else if (tboxUsuario.Text.Length >= 20)
            {
                errorProvider1.SetError(tboxUsuario, "El usuario debe tener menos de 20 caracteres.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(tboxUsuario, string.Empty);
            }

            // Validar Contraseña
            //if (string.IsNullOrWhiteSpace(tboxContrasena.Text))
            //{
            //    errorProvider1.SetError(tboxContrasena, "La contraseña no puede estar vacía.");
            //    esValido = false;
            //}
            //else if (tboxContrasena.Text.Length < 8)
            //{
            //    errorProvider1.SetError(tboxContrasena, "La contraseña debe tener al menos 8 caracteres.");
            //    esValido = false;
            //}
            //else if (!tboxContrasena.Text.Any(char.IsDigit))
            //{
            //    errorProvider1.SetError(tboxContrasena, "La contraseña debe incluir al menos un número.");
            //    esValido = false;
            //}
            //else if (!char.IsUpper(tboxContrasena.Text[0]))
            //{
            //    errorProvider1.SetError(tboxContrasena, "La primera letra de la contraseña debe ser mayúscula.");
            //    esValido = false;
            //}
            //else
            //{
            //    errorProvider1.SetError(tboxContrasena, string.Empty);
            //}

            //NUEVO
            // Validar Contraseña
            if (string.IsNullOrWhiteSpace(tboxContrasena.Text))
            {
                errorProvider1.SetError(tboxContrasena, "La contraseña no puede estar vacía.");
                esValido = false;
            }
            else if (tboxContrasena.Text.Length < 8)
            {
                errorProvider1.SetError(tboxContrasena, "La contraseña debe tener al menos 8 caracteres.");
                esValido = false;
            }
            else if (!tboxContrasena.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(tboxContrasena, "La contraseña debe incluir al menos un número.");
                esValido = false;
            }
            else if (!tboxContrasena.Text.Any(ch => "!@#$%^&*()_+-=[]{}|;:',.<>?/".Contains(ch)))
            {
                errorProvider1.SetError(tboxContrasena, "La contraseña debe incluir al menos un carácter especial.");
                esValido = false;
            }
            else if (!char.IsUpper(tboxContrasena.Text[0]))
            {
                errorProvider1.SetError(tboxContrasena, "La primera letra de la contraseña debe ser mayúscula.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(tboxContrasena, string.Empty);
            }

            // Validar Confirmar Contraseña
            if (string.IsNullOrWhiteSpace(tboxContrasenaConf.Text))
            {
                errorProvider1.SetError(tboxContrasenaConf, "Debe confirmar la contraseña.");
                esValido = false;
            }
            else if (tboxContrasenaConf.Text != tboxContrasena.Text)
            {
                errorProvider1.SetError(tboxContrasenaConf, "Las contraseñas no coinciden.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(tboxContrasenaConf, string.Empty);
            }

            // Validar Fecha de Registro
            if (!GuardarEdicionFecha && dtpFecha.Value.Date != DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpFecha, "La fecha de registro debe ser la fecha actual.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(dtpFecha, string.Empty);
            }

            // Validar Perfil
            if (cboxPerfil.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboxPerfil, "Debe seleccionar un perfil.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(cboxPerfil, string.Empty);
            }

            return esValido;

        }
        //FIN VALIDAR DATOS


        //FUNCION GUARDAR
        //private void GuardarUsuario()
        //{
        //    if (!ValidarDatos())
        //        return;

        //    //string connectionString = "Server=192.168.1.10; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

        //    using (SqlConnection connection = new SqlConnection(conexion))
        //    {
        //        SqlCommand command = new SqlCommand("sp_AgregarUsuario", connection);
        //        command.CommandType = CommandType.StoredProcedure;

        //        // Agregar parámetros
        //        command.Parameters.AddWithValue("@Nombre", tboxNombre.Text);
        //        command.Parameters.AddWithValue("@Usuario", tboxUsuario.Text);
        //        command.Parameters.AddWithValue("@Contrasena", tboxContrasena.Text); // Considera cifrar la contraseña antes.
        //        command.Parameters.AddWithValue("@FechaRegistro", dtpFecha.Value);
        //        command.Parameters.AddWithValue("@PerfilID", cboxPerfil.SelectedValue);
        //        command.Parameters.AddWithValue("@Activo", chboxActivo.Checked);

        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            //MessageBox.Show("Usuario guardado correctamente.");
        //            MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LimpiarFormulario();
        //            CargarDatos();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error al guardar usuario: {ex.Message}");
        //        }
        //    }
        //}

        //NUEVO
        private void GuardarUsuario()
        {
            if (!ValidarDatos())
                return;

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                SqlCommand command = new SqlCommand("sp_AgregarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros
                command.Parameters.AddWithValue("@Nombre", tboxNombre.Text);
                command.Parameters.AddWithValue("@Usuario", tboxUsuario.Text);
                command.Parameters.AddWithValue("@Contrasena", tboxContrasena.Text); // Considera cifrar la contraseña antes.
                command.Parameters.AddWithValue("@FechaRegistro", dtpFecha.Value);
                command.Parameters.AddWithValue("@PerfilID", cboxPerfil.SelectedValue);
                command.Parameters.AddWithValue("@Activo", chboxActivo.Checked);

                // Parámetro de salida
                SqlParameter existeParam = new SqlParameter("@Existe", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(existeParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    bool existe = Convert.ToBoolean(existeParam.Value);

                    if (existe)
                    {
                        MessageBox.Show("El usuario ya existe. Por favor, elija un nombre de usuario diferente.", "Usuario Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        CargarDatos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar usuario: {ex.Message}");
                }
            }
        }
        //FIN Metodo GUARDAR


        //LIMPIAR FORMULARIO
        private void LimpiarFormulario()
        {
            tboxUsuarioID.Clear();
            tboxNombre.Clear();
            tboxUsuario.Clear();
            tboxContrasena.Clear();
            tboxContrasenaConf.Clear();
            cboxPerfil.SelectedIndex = -1;
            cboxBuscar.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            chboxActivo.Checked = true; // Activo por defecto.

            btnGuardar.Enabled = true;
        }
        //FIN LIMPIAR FORMULARIO

        //BOTON GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
            GuardarEdicionFecha = false;
        }
        //FIN BOTON GUARDAR

        //BOTON LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            GuardarEdicionFecha = false;
        }
        //FIN BOTON LIMPIAR


        //PARA EL BOTON EDITAR
        private void ActualizarUsuario(int usuarioID)
        {
            if (!ValidarDatos())
                return;

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                SqlCommand command = new SqlCommand("sp_EditarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                command.Parameters.AddWithValue("@Nombre", tboxNombre.Text);
                command.Parameters.AddWithValue("@Usuario", tboxUsuario.Text);
                command.Parameters.AddWithValue("@Contrasena", tboxContrasena.Text);
                command.Parameters.AddWithValue("@FechaRegistro", dtpFecha.Value);
                command.Parameters.AddWithValue("@PerfilID", cboxPerfil.SelectedValue);
                command.Parameters.AddWithValue("@Activo", chboxActivo.Checked);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    //MessageBox.Show("Usuario actualizado correctamente.");
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar usuario: {ex.Message}");
                }
            }
        }
        //FIN PARA EL BOTON EDITAR

        //BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            GuardarEdicionFecha = true;
            if (int.TryParse(tboxUsuarioID.Text, out int usuarioID))
            {
                ActualizarUsuario(usuarioID);
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario válido para editar.");
            }
        }
        //FIN BOTON EDITAR


        //PARA LA FUNCION DE BUSCAR
        private void LlenarComboBoxColumnas()
        {
            cboxBuscar.Items.Add("UsuarioID");
            cboxBuscar.Items.Add("Nombre");
            cboxBuscar.Items.Add("Usuario");
            cboxBuscar.Items.Add("No Activo");

            if (cboxBuscar.Items.Count > 0)
            {
                cboxBuscar.SelectedIndex = 0; 
            }
        }
        //FIN FUNCION BUSCAR


        //FILTRAR DATOS
        private void FiltrarDatos()
        {
            if (cboxBuscar.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string columnaSeleccionada = cboxBuscar.SelectedItem.ToString();
            string filtro = tboxBuscar.Text.Trim();

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                string query;

                if (columnaSeleccionada == "No Activo")
                {
                    //tboxBuscar.Enabled = false;
                    // Filtrar usuarios por estado Activo/No Activo
                    query = @"SELECT 
                        u.UsuarioID AS [ID Usuario], 
                        u.Nombre, 
                        u.Usuario, 
                        u.FechaRegistro AS [Fecha Registro], 
                        u.Contrasena AS Contraseña, 
                        p.NombrePerfil AS Perfil, 
                        u.Activo 
                      FROM proyecto.Usuarios u
                      INNER JOIN proyecto.Perfiles p ON u.PerfilID = p.PerfilID
                      WHERE u.Activo = 0 AND u.UsuarioID LIKE @Filtro";
                    //WHERE u.Activo = CASE WHEN @Filtro LIKE '1' THEN 1 ELSE 0 END"
                }
                else
                {
                    //tboxBuscar.Enabled = true;
                    // Filtrar por la columna seleccionada
                    query = $@"SELECT 
                        u.UsuarioID AS [ID Usuario], 
                        u.Nombre, 
                        u.Usuario, 
                        u.FechaRegistro AS [Fecha Registro], 
                        u.Contrasena AS Contraseña, 
                        p.NombrePerfil AS Perfil, 
                        u.Activo
                      FROM proyecto.Usuarios u
                      INNER JOIN proyecto.Perfiles p ON u.PerfilID = p.PerfilID
                      WHERE u.Activo = 1 and {columnaSeleccionada} LIKE @Filtro";
                }

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Parametrizar el filtro
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    // Llenar el DataGridView
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dgUsuarios.DataSource = dt;

                    // Ocultar la columna Activo (opcional)
                    if (dgUsuarios.Columns["Activo"] != null)
                    {
                        dgUsuarios.Columns["Activo"].Visible = false;
                    }
                    //Nuevo
                    if (dgUsuarios.Columns["Contraseña"] != null)
                    {
                        dgUsuarios.Columns["Contraseña"].Visible = false;
                    }
                }
            }
        }
        //FIN FILTRAR DATOS

        //COMBOBOX BUSCAR
        private void cboxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        //FIN COMBOBOX BUSCAR

        //TEXTBOX BUSCAR
        private void tboxBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        //FIN TEXTBOX BUSCAR

        //MENSAJES DE AYUDA PARA LLENAR LA INFORMACION DE LOS USUARIOS
        private void toolTips()
        {
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseAnimation = true;
            toolTip1.SetToolTip(tboxUsuarioID, "ID del usuario.");
            toolTip1.SetToolTip(tboxNombre, "Ingrese el nombre del la persona a registrar.");
            toolTip1.SetToolTip(tboxUsuario, "Ingrese el nombre del usuario.");
            toolTip1.SetToolTip(tboxContrasena, "Ingrese la contraseña.");
            toolTip1.SetToolTip(tboxContrasenaConf, "Ingrese la confirmacion de la contraseña.");
            toolTip1.SetToolTip(dtpFecha, "Ingrese la fecha.");
            toolTip1.SetToolTip(cboxPerfil, "Seleccione el perfil correspondiente.");
            toolTip1.SetToolTip(cboxBuscar, "Seleccione un campo para poder buscar.");
            toolTip1.SetToolTip(btnGuardar, "Al hacer click se guardará la información previa.");
            toolTip1.SetToolTip(btnEditar, "Seleccione una fila de la tabla para editar. Hacer click en el botón de Editar para guardar los cambios.");
            toolTip1.SetToolTip(btnLimpiar, "Al hacer click se vaciarán los cuadros de texto.");
            toolTip1.SetToolTip(btnEliminar, "Se eliminará un registro al hacer click.");
            toolTip1.SetToolTip(btnAtras, "Regresara a la pantalla principal.");
            toolTip1.SetToolTip(chboxActivo, "Al desmarcarlo se ocultará el registro actual.");
            toolTip1.SetToolTip(chboxVerPass, "Ver contraseña.");
        }
        //FIN MENSAJES DE AYUDA

        //CHECKBOX OCULTAR/MOSTRAR CONTRASEÑA
        private void chboxVerPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxVerPass.Checked)
            {
                tboxContrasena.UseSystemPasswordChar = false; 
                tboxContrasenaConf.UseSystemPasswordChar = false;
            }
            else
            {
                tboxContrasena.UseSystemPasswordChar = true;
                tboxContrasenaConf.UseSystemPasswordChar = true;
            }
        }
        //FIN CHECKBOX OCULTAR/MOSTRAR CONTRASEÑA

        //BOTON ATRAS
        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
        //FIN //BOTON ATRAS

        //SELECCION DE USUARIOS EN EL DATAGRIDVIEW (UTILIZADO POR EDITAR Y ELIMINAR)
        private void dgUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgUsuarios.SelectedRows[0];

                // Asignar los valores de la fila seleccionada a los TextBox
                tboxUsuarioID.Text = filaSeleccionada.Cells["ID Usuario"].Value.ToString();
                tboxNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                tboxUsuario.Text = filaSeleccionada.Cells["Usuario"].Value.ToString();
                tboxContrasena.Text = filaSeleccionada.Cells["Contraseña"].Value.ToString();
                tboxContrasenaConf.Text = filaSeleccionada.Cells["Contraseña"].Value.ToString();
                dtpFecha.Text = filaSeleccionada.Cells["Fecha Registro"].Value.ToString();
                cboxPerfil.Text = filaSeleccionada.Cells["Perfil"].Value.ToString();
                chboxActivo.Checked = Convert.ToBoolean(filaSeleccionada.Cells["activo"].Value);

                tboxUsuarioID.Enabled = false;
                dtpFecha.Enabled = false;

                btnGuardar.Enabled = false;
                ButtonEnableDisableStyle.AttachPaintHandler(btnGuardar);

            }
        }
        //FIN SELECCION DE USUARIOS EN EL DATAGRIDVIEW

        ///PARA EL BOTON DE ELIMIANR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                int socioID = Convert.ToInt32(dgUsuarios.SelectedRows[0].Cells["ID Usuario"].Value);

                DialogResult result = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conexion))
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", connection))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@UsuarioID", socioID);

                                connection.Open();
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Registro eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDatos();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GuardarEdicionFecha = false;
        }
        //FIN PARA EL BOTON ELIMINAR



    }
}
