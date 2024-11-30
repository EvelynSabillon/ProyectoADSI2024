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
    public partial class GestionSocios : Form
    {
        private string conexion = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

        public GestionSocios()
        {
            InitializeComponent();
        }

        // METODO PARA CARGAR LOS DATOS EN EL DATAGRIDVIEW
        private void CargarDatos()
        {
            // Crear el DataTable donde se almacenarán los datos
            DataTable dtSocios = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarSocios", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dtSocios);
                        }
                    }
                }

                // Asignar el DataTable al DataGridView
                dgGestionSocios.DataSource = dtSocios;
                dgGestionSocios.Columns["activo"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Boton Atras
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

       
        private void GestionSocios_Load(object sender, EventArgs e)
        {
            //Cargando datos al DGv
            CargarDatos();

            //EVENTRO SELECCION DE FILAS
            dgGestionSocios.SelectionChanged += dgGestionSocios_SelectionChanged;

        }


        //UTILIZADO PARA LIMPIAR
        private void LimpiarCampos()
        {
            tboxSocioID.Clear();
            tboxNombre.Clear();
            mktboxDNI.Clear();
            tboxDireccion.Clear();
            mktboxTelefono.Clear();
            tboxEmail.Clear();

            //Utilizado para editar
            tboxSocioID.Enabled = true;
            dgGestionSocios.ClearSelection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        //FIN LIMPIAR



        //UTILIZADO PARA EL BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgGestionSocios.SelectedRows.Count > 0)
            {
                int socioID = Convert.ToInt32(dgGestionSocios.SelectedRows[0].Cells["SocioID"].Value);

                DialogResult result = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conexion))
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_EliminarSocio", connection))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SocioID", socioID);

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
        }
        //FIN BOTON ELIMINAR



        //UTILIZADO PARA EL BOTON GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Pendiente de cambiar esta validacion por el error provider
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(tboxSocioID.Text) ||
                string.IsNullOrWhiteSpace(tboxNombre.Text) ||
                string.IsNullOrWhiteSpace(mktboxDNI.Text) ||
                string.IsNullOrWhiteSpace(tboxDireccion.Text) ||
                string.IsNullOrWhiteSpace(mktboxTelefono.Text) ||
                string.IsNullOrWhiteSpace(tboxEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            int socioID = int.Parse(tboxSocioID.Text);
            string nombre = tboxNombre.Text;
            string dni = mktboxDNI.Text;
            string direccion = tboxDireccion.Text;
            string telefono = mktboxTelefono.Text;
            string email = tboxEmail.Text;
            bool activo = chboxActivo.Checked;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_AgregarSocio", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SocioID", socioID);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@DNI", dni);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Activo", activo);

                        // Parámetros de salida
                        SqlParameter existeParam = new SqlParameter("@Existe", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter proximoIDParam = new SqlParameter("@ProximoID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(existeParam);
                        cmd.Parameters.Add(proximoIDParam);

                        connection.Open();
                        cmd.ExecuteNonQuery();

                        bool existe = Convert.ToBoolean(existeParam.Value);
                        int proximoID = proximoIDParam.Value != DBNull.Value ? Convert.ToInt32(proximoIDParam.Value) : 1;

                        if (existe)
                        {
                            MessageBox.Show($"El SocioID {socioID} ya existe. El siguiente SocioID disponible es {proximoID}.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tboxSocioID.Text = proximoID.ToString();
                            
                        }
                        else
                        {
                            MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();  
                            LimpiarCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON GUARDAR


        //UTILIZADO PARA EL BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgGestionSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("¿Desea editar el registro actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                int socioID = int.Parse(dgGestionSocios.SelectedRows[0].Cells["SocioID"].Value.ToString());
                string nuevoNombre = tboxNombre.Text;
                string nuevoDNI = mktboxDNI.Text;
                string nuevaDireccion = tboxDireccion.Text;
                string nuevoTelefono = mktboxTelefono.Text;
                string nuevoEmail = tboxEmail.Text;
                bool activo = chboxActivo.Checked;

                try
                {
                    using (SqlConnection connection = new SqlConnection(conexion))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_EditarSocio", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@SocioID", socioID);
                            cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                            cmd.Parameters.AddWithValue("@DNI", nuevoDNI);
                            cmd.Parameters.AddWithValue("@Direccion", nuevaDireccion);
                            cmd.Parameters.AddWithValue("@Telefono", nuevoTelefono);
                            cmd.Parameters.AddWithValue("@Email", nuevoEmail);
                            cmd.Parameters.AddWithValue("@Activo", activo);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro actualizado con éxito.");
                    CargarDatos();  
                    LimpiarCampos();
                    btnGuardar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //FIN BOTON EDITAR


        //SELECCION DE SOCIOS EN EL DATAGRIDVIEW (UTILIZADO POR EDITAR Y ELIMINAR)
        private void dgGestionSocios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgGestionSocios.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgGestionSocios.SelectedRows[0];

                // Asignar los valores de la fila seleccionada a los TextBox
                tboxSocioID.Text = filaSeleccionada.Cells["SocioID"].Value.ToString();
                tboxNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                mktboxDNI.Text = filaSeleccionada.Cells["DNI"].Value.ToString();
                tboxDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
                mktboxTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
                tboxEmail.Text = filaSeleccionada.Cells["Correo"].Value.ToString();
                chboxActivo.Checked = Convert.ToBoolean(filaSeleccionada.Cells["activo"].Value);

                tboxSocioID.Enabled = false;

            }
        }


        //PARA LA FUNCIONALIDAD DE BUSQUEDA
        
        //Llenar 
        private void LlenarComboBoxColumnas()
        {
            // Agregando las columnas
            cboxBuscar.Items.Add("SocioID");
            cboxBuscar.Items.Add("Nombre");
            cboxBuscar.Items.Add("DNI");
            cboxBuscar.Items.Add("Direccion");
            cboxBuscar.Items.Add("Telefono");
            cboxBuscar.Items.Add("Email");
            cboxBuscar.Items.Add("No activo");

            cboxBuscar.SelectedIndex = 0; // Seleccionar la primera opción por defecto
        }

        //Filtro aplicado
        private void FiltrarDatos()
        {
            string columnaSeleccionada = cboxBuscar.SelectedItem.ToString();
            string filtro = tboxBuscar.Text.Trim();

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                string query;

                if (columnaSeleccionada == "No activo")
                {
                    // Mostrar socios no activos y buscar solo por SocioID
                    query = @"SELECT SocioID, Nombre, DNI, Direccion, Telefono, Email AS Correo, Activo
                      FROM proyecto.Socio
                      WHERE Activo = 0 AND SocioID LIKE @Filtro";
                }
                else
                {
                    // Filtrar dentro de los socios activos por la columna seleccionada
                    query = $@"SELECT SocioID, Nombre, DNI, Direccion, Telefono, Email AS Correo, Activo
                       FROM proyecto.Socio 
                       WHERE Activo = 1 AND {columnaSeleccionada} LIKE @Filtro";
                }

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dgGestionSocios.DataSource = dt;

                    // Ocultar la columna Activo
                    if (dgGestionSocios.Columns["Activo"] != null)
                    {
                        dgGestionSocios.Columns["Activo"].Visible = false;
                    }
                }
            }
        }

        private void cboxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void tboxBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        //FIN FUNCIONALIDAD DE BUSCAR


        //OBLIGANDO EL USO DE SOLO NUMERO CAMPO SOCIOID
        private void tboxSocioID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, tecla de retroceso y tecla de borrado
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese cualquier otro carácter
            }
        }
        





    }
}
