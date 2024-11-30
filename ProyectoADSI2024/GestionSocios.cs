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
                                CargarDatos();  // Recargar los datos para reflejar los cambios
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
                            //CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();  // Recargar datos en el DataGridView
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
        //FIN BOTON AGREGAR
        





    }
}
