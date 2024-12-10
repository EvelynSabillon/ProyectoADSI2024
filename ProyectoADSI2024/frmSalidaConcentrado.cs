using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Libreria para conexion con SQL Server

namespace ProyectoADSI2024
{
    public partial class frmSalidaConcentrado : Form
    {
        private Conexion conexion;
        SqlDataAdapter adapterSalida;
        DataTable tablaSalida;

        SqlDataAdapter adapterDetalle;
        DataTable tablaDetalle;

        public frmSalidaConcentrado()
        {
            InitializeComponent();
            conexion = new Conexion();
            adapterSalida = new SqlDataAdapter("spSalidaConSelect", conexion.ObtenerConexion());
            adapterSalida.SelectCommand.CommandType = CommandType.StoredProcedure;
            tablaSalida = new DataTable();
            
            adapterDetalle = new SqlDataAdapter("spSalidaDetalleConSelect", conexion.ObtenerConexion());
            adapterDetalle.SelectCommand.CommandType = CommandType.StoredProcedure;
            tablaDetalle = new DataTable();


            dgvSalida.SelectionChanged += dgvSalida_SelectionChanged; // Suscribirse al evento
            dgvDetalle.SelectionChanged += dgvDetalle_SelectionChanged;

            // Configurar ToolTips
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(btnAtras, "Volver al menú principal");
            toolTip1.SetToolTip(btnGuardar, "Guardar registro de Salida de concentrado");
            toolTip1.SetToolTip(btnGuardarDet, "Guardar registro de los detalles de la salida de concentrado");
            toolTip1.SetToolTip(btnEditar, "Editar registro de Salida o de los detalles de la salida de concentrado");
            toolTip1.SetToolTip(btnEditarDet, "Editar registro de los detalles de la salida de concentrado");
            toolTip1.SetToolTip(btnLimpiar, "Limpiar todos los campos");
            toolTip1.SetToolTip(btnEliminar, "Eliminar registro de Salida y los detalles de la salida de concentrado");
            toolTip1.SetToolTip(btnEliminarDet, "Eliminar registro de los detalles de la salida de concentrado");
            toolTip1.SetToolTip(btnSeleccionar, "Seleccionar un articulo/concentrado de las existencias");
            toolTip1.SetToolTip(dgvSalida, "Seleccionar una Salida para editar o eliminar");
            toolTip1.SetToolTip(dgvDetalle, "Seleccionar un detalle de Salida para editar o eliminar");
            toolTip1.SetToolTip(txtSalidaID, "ID de la Salida, campo de solo lectura, autonumerico, no se debe llenar");
            toolTip1.SetToolTip(txtArticuloID, "ID del Articulo seleccionado, campo de solo lectura, no se debe llenar");
            toolTip1.SetToolTip(txtSocioID, "ID del socio seleccionado, campo de solo lectura, no se debe llenar");
            toolTip1.SetToolTip(dtpFecha, "Seleccionar la fecha de la salida");
            toolTip1.SetToolTip(txtNombreArt, "Nombre del articulo seleccionado, campo de solo lectura, no se debe llenar");
            toolTip1.SetToolTip(cmbNombreSocio, "Seleccionar un socio");
            toolTip1.SetToolTip(txtCantidad, "Ingresar la cantidad de concentrado");
            toolTip1.SetToolTip(txtPrecio, "Ingresar el precio del concentrado");
            toolTip1.SetToolTip(txtTextoSalida, "Ingresar el texto a buscar en la tabla de salidas");
            toolTip1.SetToolTip(txtTextoDetalle, "Ingresar el texto a buscar en la tabla de detalle");
            toolTip1.SetToolTip(cmbCampoSalida, "Seleccionar el campo para buscar en la tabla de salidas");
            toolTip1.SetToolTip(cmbCampoDetalle, "Seleccionar el campo para buscar en la tabla de detalle");
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmSalidaConcentrado_Load(object sender, EventArgs e)
        {
            try
            { 
                LlenarComboSocios(); //Llenar el ComboBox de Socios
                
                adapterSalida.Fill(tablaSalida); //Llenar la tabla
                dgvSalida.DataSource = tablaSalida; //Mostrar la tabla en el DataGridView
                
                adapterDetalle.Fill(tablaDetalle); //Llenar la tabla
                dgvDetalle.DataSource = tablaDetalle; //Mostrar la tabla en el DataGridView
                
                txtTextoSalida.Enabled = false;
                txtTextoDetalle.Enabled = false;
                VerificarFecha();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboSocios()
        {
            try
            {
                SqlConnection con = conexion.ObtenerConexion();

                //Crear el comando SQL para seleccionar los socios
                using (SqlCommand cmd = new SqlCommand(
                    "select SocioID, Nombre from proyecto.Socio where Activo = 1", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dtSocios = new DataTable();
                        dtSocios.Load(dr);

                        // Asignar el DataTable como DataSource del ComboBox
                        cmbNombreSocio.DataSource = dtSocios;

                        // Mostrar el nombre del proveedor
                        cmbNombreSocio.DisplayMember = "Nombre";

                        // Internamente almacenar el ProveedorID
                        cmbNombreSocio.ValueMember = "SocioID";
                    }
                }
                //inicia vacio.
                cmbNombreSocio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNombreSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreSocio.SelectedIndex != -1)
            {
                txtSocioID.Text = cmbNombreSocio.SelectedValue.ToString();
            }
            else
            {
                txtSocioID.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposSalida())
            {
                if (MessageBox.Show("¿Desea guardar el registro de la salida?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = conexion.ObtenerConexion();
                        int SocioID = Convert.ToInt32(cmbNombreSocio.SelectedValue);
                        // Crear el comando y asociarlo con la conexión
                        using (SqlCommand cmdSalida = new SqlCommand("spInsertSalidaConcentrado", con))
                        {
                            cmdSalida.CommandType = CommandType.StoredProcedure;

                            // Agregar los parámetros necesarios
                            cmdSalida.Parameters.AddWithValue("@SocioID", SocioID);
                            cmdSalida.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                            cmdSalida.Parameters.AddWithValue("@Activo", true);


                            // Ejecuta el procedimiento almacenado
                            cmdSalida.ExecuteNonQuery();
                            MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                            txtSocioID.Text = "";
                            cmbNombreSocio.SelectedIndex = -1;  // Deseleccionar socio
                            dtpFecha.ResetText();

                            //Actualizar la tabla
                            tablaSalida.Clear();
                            adapterSalida.Fill(tablaSalida);


                            //Actualizar el llenado del cmbNombreSocio
                            LlenarComboSocios();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposSalida())
            {
                if (MessageBox.Show("¿¿Desea editar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //EDITAR UN REGISTRO, SELECCIONANDOLO EN EL DataGridView Y MODIFICANDO LOS CAMPOS EN LOS TEXTBOX
                    try
                    {
                        if (dgvSalida.SelectedRows.Count > 0)
                        {
                            int SalidaID = Convert.ToInt32(dgvSalida.SelectedRows[0].Cells["SalidaID"].Value);
                            SqlConnection con = conexion.ObtenerConexion();
                            using (SqlCommand cmdSalida = new SqlCommand("spSalidaConcentradoUpdate", con))
                            {
                                cmdSalida.CommandType = CommandType.StoredProcedure;
                                cmdSalida.Parameters.AddWithValue("@SalidaID", SalidaID);
                                cmdSalida.Parameters.AddWithValue("@SocioID", Convert.ToInt32(txtSocioID.Text));
                                cmdSalida.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                                cmdSalida.Parameters.AddWithValue("@activo", true);
                                cmdSalida.ExecuteNonQuery();
                                MessageBox.Show("Registro actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Actualizar la tabla
                                tablaSalida.Clear();
                                adapterSalida.Fill(tablaSalida);

                                txtSalidaID.Text = "";
                                dtpFecha.ResetText();
                                txtSocioID.Text = "";
                                cmbNombreSocio.SelectedIndex = -1;

                                //Actualizar el llenado del cmbNombreSocio
                                LlenarComboSocios();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
                    }
                }
            }
        }

        private bool ValidarCamposSalida()
        {
            bool esValido = true;
            errorProvider1.Clear();


            // Validar que la fecha solo pueda ser igual a la fecha actual
            if (dtpFecha.Value.Date != DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpFecha, "La fecha no puede ser mayor o menor a la fecha actual.");
                esValido = false;
            }

            // Validar que se haya seleccionado un socio
            if (cmbNombreSocio.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbNombreSocio, "Seleccione un socio.");
                esValido = false;
            }

            return esValido;
        }


        private void btnGuardarDet_Click(object sender, EventArgs e)
        {
            if (ValidarCamposDet())
            {
                if (MessageBox.Show("¿Desea guardar el registro del detalle de la salida?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = conexion.ObtenerConexion();

                        // Crear una lista para almacenar mensajes informativos
                        List<string> infoMessages = new List<string>();

                        // Agregar un manejador de eventos para capturar mensajes informativos
                        con.InfoMessage += (s, ev) =>
                        {
                            //HashSet<string> mensajesUnicos = new HashSet<string>(infoMessages);
                            if (!infoMessages.Contains(ev.Message))
                            {
                                infoMessages.Add(ev.Message);
                            }
                        };

                        int ArticuloID = Convert.ToInt32(txtArticuloID.Text);
                        // Crear el comando y asociarlo con la conexión

                        using (SqlCommand cmdSalidaDet = new SqlCommand("spInsertSalidaDetalleCon", con))
                        {
                            cmdSalidaDet.CommandType = CommandType.StoredProcedure;

                            // Agregar los parámetros necesarios
                            cmdSalidaDet.Parameters.AddWithValue("@SalidaID", Convert.ToInt32(txtSalidaID.Text));
                            cmdSalidaDet.Parameters.AddWithValue("@ArticuloID", ArticuloID);
                            cmdSalidaDet.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
                            cmdSalidaDet.Parameters.AddWithValue("@Precio", Convert.ToInt32(txtPrecio.Text));
                            cmdSalidaDet.Parameters.AddWithValue("@Activo", true);


                            // Ejecuta el procedimiento almacenado
                            cmdSalidaDet.ExecuteNonQuery();
                            MessageBox.Show("Registro guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mostrar mensajes informativos acumulados después del éxito
                            if (infoMessages.Count > 0)
                            {
                                string mensajes = string.Join(Environment.NewLine, infoMessages);
                                MessageBox.Show(mensajes, "Información adicional", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                            //Actualizar la tabla
                            CargarDetalles();

                            //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                            txtSalidaID.Text = "";
                            txtArticuloID.Text = "";
                            txtNombreArt.Text = "";
                            txtPrecio.Text = "";
                            txtCantidad.Text = "";  // Deseleccionar socio

                            //Actualizar el llenado del cmbNombreSocio
                            LlenarComboSocios();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Validar si el error viene del trigger mediante la severidad
                        if (ex.Class >= 16) // Error severo
                        {
                            MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Error SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //Validar error de duplicidad
                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("Error: El registro ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message + "\nAsegurese de haber seleccionado un registro de salida primero.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Mostrar el mensaje informativo cuando provenga de SQL Server
            MessageBox.Show(e.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void VerificarFecha()
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Today;

            // Comparar la fecha del campo con la fecha actual
            if (dtpFecha.Value.Date != fechaActual)
            {
                // Deshabilitar el botón si la fecha no es la actual
                btnGuardarDet.Enabled = false;
            }
            else
            {
                // Habilitar el botón si la fecha es la actual
                btnGuardarDet.Enabled = true;
            }
        }


        private void btnEditarDet_Click(object sender, EventArgs e)
        {
            if (ValidarCamposDet())
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //EDITAR UN REGISTRO, SELECCIONANDOLO EN EL DataGridView Y MODIFICANDO LOS CAMPOS EN LOS TEXTBOX
                    try
                    {
                        if (dgvDetalle.SelectedRows.Count > 0)
                        {
                            int SalidaID = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["SalidaID"].Value);
                            SqlConnection con = conexion.ObtenerConexion();
                            using (SqlCommand cmdSalidaDet = new SqlCommand("spSalidaDetalleConUpdate", con))
                            {
                                cmdSalidaDet.CommandType = CommandType.StoredProcedure;
                                cmdSalidaDet.Parameters.AddWithValue("@SalidaID", SalidaID);
                                cmdSalidaDet.Parameters.AddWithValue("@ArticuloID", Convert.ToInt32(txtArticuloID.Text));
                                cmdSalidaDet.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
                                cmdSalidaDet.Parameters.AddWithValue("@Precio", Convert.ToInt32(txtPrecio.Text));
                                cmdSalidaDet.Parameters.AddWithValue("@Activo", true);
                                cmdSalidaDet.ExecuteNonQuery();
                                MessageBox.Show("Registro actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Actualizar la tabla
                                CargarDetalles();


                                txtSalidaID.Text = "";
                                txtArticuloID.Text = "";
                                txtNombreArt.Text = "";
                                txtPrecio.Text = "";
                                txtCantidad.Text = "";  // Deseleccionar socio

                                //Actualizar el llenado del cmbNombreSocio
                                LlenarComboSocios();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de formato: " + ex.Message + "\nAsegurese de que los datos están en el formato correcto.");
                    }
                }
            }

        }


        private bool ValidarCamposDet()
        {
            bool esValido = true;
            errorProvider1.Clear();

            // Validar que la cantidad no sea negativa y sea un número válido
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !double.TryParse(txtCantidad.Text, out double cantidad) || cantidad <= 0)
            {
                errorProvider1.SetError(txtCantidad, "Ingrese una cantidad válida. Valores numéricos positivos y enteros.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text) || !double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
            {
                errorProvider1.SetError(txtPrecio, "Ingrese un precio válido. Valores numéricos positivos.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtArticuloID.Text) || !int.TryParse(txtPrecio.Text, out int articuloid ) || articuloid <= 0)
            {
                errorProvider1.SetError(txtArticuloID, "Ingrese un ID de articulo válido. Valores numéricos positivos y enteros.");
                esValido = false;
            }

            return esValido;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Pasamos la referencia de frmSalidaConcentrado al constructor de Vista_ArticuloCon y el parametro de conexion
                Vista_ArticuloCon frm = new Vista_ArticuloCon(conexion.ObtenerConexion(),this);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //LIMPIAR TODOS LOS CAMPOS
            txtTextoSalida.Enabled = false;
            txtTextoDetalle.Enabled = false;
            txtTextoSalida.Text = "";
            txtTextoDetalle.Text = "";

            txtSalidaID.Text = "";
            dtpFecha.ResetText();
            txtSocioID.Text = "";
            cmbNombreSocio.SelectedIndex = -1;  // Deseleccionar socio

            txtArticuloID.Text = "";
            txtNombreArt.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

            try
            {
                // Recargar todos los detalles (restablecer el estado inicial)
                CargarDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar la Salida y sus respectivos detalles?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ELIMINAR UN REGISTRO seleccionado en el DataGridView
                try
                {
                    if (dgvSalida.SelectedRows.Count > 0)
                    {
                        int SalidaID = Convert.ToInt32(dgvSalida.SelectedRows[0].Cells["SalidaID"].Value);
                        SqlConnection con = conexion.ObtenerConexion();
                        using (SqlCommand cmdSalida = new SqlCommand("spSalidaConDesactivarDetalles", con))
                        {
                            cmdSalida.CommandType = CommandType.StoredProcedure;
                            cmdSalida.Parameters.AddWithValue("@salidaid", SalidaID);
                            cmdSalida.ExecuteNonQuery();
                            MessageBox.Show("Salida eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Actualizar la tabla
                            tablaSalida.Clear();
                            adapterSalida.Fill(tablaSalida);
                            
                            //Actualizar la tabla
                            CargarDetalles();

                            txtSalidaID.Text = "";
                            dtpFecha.ResetText();
                            txtSocioID.Text = "";
                            cmbNombreSocio.SelectedIndex = -1;

                            //Actualizar el llenado del cmbNombreSocio
                            LlenarComboSocios();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un registro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnEliminarDet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el detalle?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ELIMINAR UN REGISTRO seleccionado en el DataGridView
                try
                {
                    if (dgvDetalle.SelectedRows.Count > 0)
                    {
                        int SalidaID = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["SalidaID"].Value);
                        int ArticuloID = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["ArticuloConID"].Value);
                        SqlConnection con = conexion.ObtenerConexion();
                        using (SqlCommand cmdSalidaDet = new SqlCommand("spSalidaDetallesDesactivar", con))
                        {
                            cmdSalidaDet.CommandType = CommandType.StoredProcedure;
                            cmdSalidaDet.Parameters.AddWithValue("@salidaid", SalidaID);
                            cmdSalidaDet.Parameters.AddWithValue("@articuloid", ArticuloID);
                            cmdSalidaDet.ExecuteNonQuery();
                            MessageBox.Show("Detalle eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Actualizar la tabla
                            CargarDetalles();

                            txtSalidaID.Text = "";
                            txtArticuloID.Text = "";
                            txtNombreArt.Text = "";
                            txtPrecio.Text = "";
                            txtCantidad.Text = "";  // Deseleccionar socio

                            //Actualizar el llenado del cmbNombreSocio
                            LlenarComboSocios();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un registro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvSalida_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalida.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvSalida.SelectedRows[0];
                    txtSalidaID.Text = row.Cells["SalidaID"].Value.ToString();
                    txtSocioID.Text = row.Cells["SocioID"].Value.ToString();
                    //Cuando aparezca el ID de Socio se debe autoseleccionar el valor en el cmbNombre Socio
                    cmbNombreSocio.SelectedValue = row.Cells["SocioID"].Value;
                    dtpFecha.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalle.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvDetalle.SelectedRows[0];
                    txtSalidaID.Text = row.Cells["SalidaID"].Value.ToString();
                    txtArticuloID.Text = row.Cells["ArticuloConID"].Value.ToString();
                    //Cuando aparezca el ID de Articulo se debe autoseleccionar el valor en el txtNombreArt 
                    txtNombreArt.Text = row.Cells["NombreArt"].Value.ToString();
                    txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                    txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtTextoSalida_TextChanged(object sender, EventArgs e)
        {
            if (txtTextoSalida.Text.Length == 0)
            {
                tablaSalida.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = tablaSalida.Columns[cmbCampoSalida.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tablaSalida.DefaultView.RowFilter = cmbCampoSalida.Text + " LIKE '%" + txtTextoSalida.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTextoSalida.Text, out int numero))
                        {
                            tablaSalida.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numero;
                        }
                        else
                        {
                            tablaSalida.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTextoSalida.Text, out decimal numeroDecimal))
                        {
                            tablaSalida.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            tablaSalida.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(DateTime)) // Filtro para fechas (día/mes/año)
                    {
                        string inputFecha = txtTextoSalida.Text.Trim();
                        string[] formatosFecha = { "dd/MM/yyyy", "dd/MM" }; // Soportar "día/mes/año" y "día/mes"
                        DateTime dateValue;

                        if (DateTime.TryParseExact(inputFecha, formatosFecha, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                        {
                            // Si no se proporciona el año, agregar el año actual
                            if (inputFecha.Length <= 5) // Formato corto: "dd/MM"
                            {
                                dateValue = new DateTime(DateTime.Now.Year, dateValue.Month, dateValue.Day);
                            }

                            // Convertir la fecha al formato requerido por RowFilter: "MM/dd/yyyy"
                            tablaSalida.DefaultView.RowFilter = cmbCampoSalida.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            tablaSalida.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        tablaSalida.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dgvSalida.DataSource = tablaSalida.DefaultView.ToTable();
        }

        private void cmbCampoSalida_Click(object sender, EventArgs e)
        {
            //txtTextoSalida.Enabled = true;
        }

        private void txtTextoDetalle_TextChanged(object sender, EventArgs e)
        {
            if (txtTextoDetalle.Text.Length == 0)
            {
                tablaDetalle.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = tablaDetalle.Columns[cmbCampoDetalle.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tablaDetalle.DefaultView.RowFilter = cmbCampoDetalle.Text + " LIKE '%" + txtTextoDetalle.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTextoDetalle.Text, out int numero))
                        {
                            tablaDetalle.DefaultView.RowFilter = cmbCampoDetalle.Text + " = " + numero;
                        }
                        else
                        {
                            tablaDetalle.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTextoDetalle.Text, out decimal numeroDecimal))
                        {
                            tablaDetalle.DefaultView.RowFilter = cmbCampoDetalle.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            tablaDetalle.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(DateTime)) // Filtro para fechas (día/mes/año)
                    {
                        if (DateTime.TryParseExact(txtTextoDetalle.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                        {
                            tablaDetalle.DefaultView.RowFilter = cmbCampoDetalle.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            tablaDetalle.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        tablaDetalle.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dgvDetalle.DataSource = tablaDetalle.DefaultView.ToTable();
        }

        private void cmbCampoDetalle_Click(object sender, EventArgs e)
        {
            //txtTextoDetalle.Enabled = true;
        }

        private void dgvSalida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtén el SalidaID de la fila seleccionada
                    int salidaID = Convert.ToInt32(dgvSalida.Rows[e.RowIndex].Cells["SalidaID"].Value);

                    // Conexión a la base de datos
                    SqlConnection con = conexion.ObtenerConexion();
                    using (SqlCommand cmd = new SqlCommand("spObtenerDetallesSalida", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SalidaID", salidaID);
                        cmd.ExecuteNonQuery();

                        // Adaptador y tabla para almacenar los resultados
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tablaDetalles = new DataTable();

                        tablaDetalles.Clear();
                        adapter.Fill(tablaDetalles);

                        // Asigna los resultados al dgvDetalle
                        dgvDetalle.DataSource = tablaDetalles;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarDetalles()
        {
            try
            {
                SqlConnection con = conexion.ObtenerConexion();
                using (SqlCommand cmd = new SqlCommand("spSalidaDetalleConSelect", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tablaDetalles = new DataTable();

                    tablaDetalles.Clear();
                    adapter.Fill(tablaDetalles);

                    // Asigna todas las filas al dgvDetalle
                    dgvDetalle.DataSource = tablaDetalles;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvSalida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que haya una fila seleccionada y que no sea la fila de encabezado
            if (e.RowIndex >= 0)
            {
                CargarDetalles();
            }
        }

        private void cmbCampoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCampoSalida.SelectedIndex != -1)
            {
                txtTextoSalida.Enabled = true;
            }
            else
            {
                txtTextoSalida.Enabled = false;
            }
        }

        private void cmbCampoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCampoDetalle.SelectedIndex != -1)
            {
                txtTextoDetalle.Enabled = true;
            }
            else
            {
                txtTextoDetalle.Enabled = false;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            VerificarFecha();
        }
    }
}
