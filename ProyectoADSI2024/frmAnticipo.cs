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

namespace ProyectoADSI2024
{
    public partial class frmAnticipo : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server

        public frmAnticipo()
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spAnticipoSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged; // Suscribirse al evento

            // Configurar ToolTips
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(btnAtras, "Volver al menú principal");
            toolTip1.SetToolTip(btnGuardar, "Guardar el anticipo");
            toolTip1.SetToolTip(btnEditar, "Editar el anticipo seleccionado");
            toolTip1.SetToolTip(btnLimpiar, "Limpiar todos los campos");
            toolTip1.SetToolTip(btnEliminar, "Eliminar el anticipo seleccionado");
            toolTip1.SetToolTip(btnSalir, "Salir del sistema");
            toolTip1.SetToolTip(dataGridView1, "Seleccionar un anticipo para editar o eliminar");
            toolTip1.SetToolTip(txtAnticipoID, "ID del anticipo, campo de solo lectura, autonumerico, no se debe llenar");
            toolTip1.SetToolTip(txtSocioID, "ID del socio seleccionado, campo de solo lectura, no se debe llenar");
            toolTip1.SetToolTip(cmbNombreSocio, "Seleccionar un socio");
            toolTip1.SetToolTip(dtpFecha, "Seleccionar la fecha del anticipo");
            toolTip1.SetToolTip(txtMonto, "Ingresar el monto del anticipo");
            toolTip1.SetToolTip(txtTexto, "Buscar en la tabla de anticipos");
            toolTip1.SetToolTip(cmbCampo, "Seleccionar el campo para buscar");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmAnticipo_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarComboSocios(); //Llenar el ComboBox de Socios
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Mostrar la tabla en el DataGridView
                txtTexto.Enabled = false;
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
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Desea guardar el anticipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = conexion.ObtenerConexion();
                        int SocioID = Convert.ToInt32(cmbNombreSocio.SelectedValue);
                        // Crear el comando y asociarlo con la conexión
                        using (SqlCommand cmdAnticipo = new SqlCommand("spAnticipoInsert", con))
                        {
                            cmdAnticipo.CommandType = CommandType.StoredProcedure;

                            // Agregar los parámetros necesarios
                            cmdAnticipo.Parameters.AddWithValue("@socioid", SocioID);
                            cmdAnticipo.Parameters.AddWithValue("@fecha", dtpFecha.Value);
                            cmdAnticipo.Parameters.AddWithValue("@monto", Convert.ToDouble(txtMonto.Text));
                            cmdAnticipo.Parameters.AddWithValue("@activo", true);


                            // Ejecuta el procedimiento almacenado
                            cmdAnticipo.ExecuteNonQuery();
                            MessageBox.Show("Anticipo registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                            txtSocioID.Text = "";
                            cmbNombreSocio.SelectedIndex = -1;  // Deseleccionar socio
                            dtpFecha.ResetText();
                            txtMonto.Text = "";

                            //Actualizar la tabla
                            tabla.Clear();
                            adaptador.Fill(tabla);


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
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Desea editar el anticipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //EDITAR UN REGISTRO, SELECCIONANDOLO EN EL DataGridView Y MODIFICANDO LOS CAMPOS EN LOS TEXTBOX
                    try
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            int AnticipoID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AnticipoID"].Value);
                            SqlConnection con = conexion.ObtenerConexion();
                            using (SqlCommand cmdAnticipo = new SqlCommand("spAnticipoUpdate", con))
                            {
                                cmdAnticipo.CommandType = CommandType.StoredProcedure;
                                cmdAnticipo.Parameters.AddWithValue("@anticipoid", AnticipoID);
                                cmdAnticipo.Parameters.AddWithValue("@socioid", Convert.ToInt32(txtSocioID.Text));
                                cmdAnticipo.Parameters.AddWithValue("@fecha", dtpFecha.Value);
                                cmdAnticipo.Parameters.AddWithValue("@monto", Convert.ToDouble(txtMonto.Text));
                                cmdAnticipo.Parameters.AddWithValue("@activo", true);
                                cmdAnticipo.ExecuteNonQuery();
                                MessageBox.Show("Anticipo actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Actualizar la tabla
                                tabla.Clear();
                                adaptador.Fill(tabla);

                                //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                                txtSocioID.Text = "";
                                cmbNombreSocio.SelectedIndex = -1;  // Deseleccionar socio
                                dtpFecha.ResetText();
                                txtMonto.Text = "";

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

        private bool ValidarCampos()
        {
            bool esValido = true;
            errorProvider1.Clear();

            // Validar que el monto no sea negativo y sea un número válido
            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !double.TryParse(txtMonto.Text, out double monto) || monto <= 0)
            {
                errorProvider1.SetError(txtMonto, "Ingrese un monto válido. Valores numéricos positivos.");
                esValido = false;
            }

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //LIMPIAR TODOS LOS CAMPOS
            txtTexto.Enabled = false;
            txtTexto.Text = "";
            txtAnticipoID.Text = "";
            txtSocioID.Text = "";
            cmbNombreSocio.SelectedIndex = -1;  // Deseleccionar socio
            dtpFecha.ResetText();
            txtMonto.Text = "";
            cmbCampo.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el anticipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ELIMINAR UN REGISTRO seleccionado en el DataGridView
                try
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int AnticipoID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AnticipoID"].Value);
                        SqlConnection con = conexion.ObtenerConexion();
                        using (SqlCommand cmdAnticipo = new SqlCommand("spAnticipoDesactivar", con))
                        {
                            cmdAnticipo.CommandType = CommandType.StoredProcedure;
                            cmdAnticipo.Parameters.AddWithValue("@anticipoid", AnticipoID);
                            cmdAnticipo.ExecuteNonQuery();
                            MessageBox.Show("Anticipo eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Actualizar la tabla
                            tabla.Clear();
                            adaptador.Fill(tabla);

                            //LIMPIO TODOS LOS CAMPOS LUEGO DEL REGISTRO.
                            txtSocioID.Text = "";
                            cmbNombreSocio.SelectedIndex = -1;  // Deseleccionar socio
                            dtpFecha.ResetText();
                            txtMonto.Text = "";

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Salir del sistema y detener la ejecución
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtAnticipoID.Text = row.Cells["AnticipoID"].Value.ToString();
                txtSocioID.Text = row.Cells["SocioID"].Value.ToString();
                //Cuando aparezca el ID de Socio se debe autoseleccionar el valor en el cmbNombre Socio
                cmbNombreSocio.SelectedValue = row.Cells["SocioID"].Value;
                dtpFecha.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);
                txtMonto.Text = row.Cells["Monto"].Value.ToString();
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabla.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = tabla.Columns[cmbCampo.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tabla.DefaultView.RowFilter = cmbCampo.Text + " LIKE '%" + txtTexto.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTexto.Text, out int numero))
                        {
                            tabla.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTexto.Text, out decimal numeroDecimal))
                        {
                            tabla.DefaultView.RowFilter = cmbCampo.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(DateTime)) // Filtro para fechas (día/mes/año)
                    {
                        string inputFecha = txtTexto.Text.Trim();
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
                            tabla.DefaultView.RowFilter = cmbCampo.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        tabla.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dataGridView1.DataSource = tabla.DefaultView.ToTable();
        }

        private void cmbCampo_Click(object sender, EventArgs e)
        {
            txtTexto.Enabled = true;
        }
    }
}
