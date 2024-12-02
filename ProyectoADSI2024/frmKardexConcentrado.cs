using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
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
    public partial class frmKardexConcentrado : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        Conexion cnxKardex;
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server
        public frmKardexConcentrado()
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spArticuloConcentradoSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla
            cnxKardex = new Conexion();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmKardexConcentrado_Load(object sender, EventArgs e)
        {
            try
            {
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Mostrar la tabla en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del artículo seleccionado
                int articuloId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ArticuloConID"].Value);

                // Abrir el formulario para seleccionar las fechas, pasando el ID del artículo
                Vista_SeleccionarFecha_Concentrado formFechas = new Vista_SeleccionarFecha_Concentrado(articuloId);
                formFechas.ShowDialog(); // Muestra el formulario de fechas como modal
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidaionError())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                SqlConnection conexion = cnxKardex.ObtenerConexion();
               
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexConcentrado", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarConKardex.Parameters.AddWithValue("@nombre", txtNomKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@codigo", txtCodKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@tipo", cbxTipoKarCon.SelectedItem.ToString());
                    cmdAgregarConKardex.Parameters.AddWithValue("@precio", float.Parse(txtKarPrecio.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtKarEntrada.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@salida",  Convert.ToInt32(txtKarSalida.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVenKar.Value);



                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Concentrado registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.
           



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }

           
        }

        private bool ValidaionError()
        {
            // Limpiar cualquier error previo
            epValidaGuardar.Clear();

            if (txtNomKarCon.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtNomKarCon, "El nombre del artículo es obligatorio.");
                return false;
            }
            else if (txtCodKarCon.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtCodKarCon, "El código del artículo es obligatorio.");
                return false;
            }
            else if (cbxTipoKarCon.SelectedIndex == -1)
            {
                epValidaGuardar.SetError(cbxTipoKarCon, "El tipo de artículo es obligatorio.");
                return false;
            }
            else if (txtKarPrecio.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarPrecio, "El precio del artículo es obligatorio.");
                return false;
            }
            else if (txtKarEntrada.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarEntrada, "La cantidad de entrada es obligatoria.");
                return false;
            }
            else if (txtKarSalida.Text == string.Empty)
            {
                epValidaGuardar.SetError(txtKarSalida, "La cantidad de salida es obligatoria.");
                return false;
            }
            else if (dtpFechaVenKar.Value == null)
            {
                epValidaGuardar.SetError(dtpFechaVenKar, "La fecha de vencimiento es obligatoria.");
                return false;
            }

            return true; // Si todas las validaciones son correctas, devuelve true

        }

        private void LimpiarDatos()
        {
            txtKardexConId.Clear();
            txtNomKarCon.Clear();
            txtCodKarCon.Clear();
            txtKarPrecio.Clear();
            cbxTipoKarCon.SelectedIndex = -1;
            txtKarEntrada.Clear();
            txtKarSalida.Clear();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
                // Verificamos si se ha hecho clic en una fila válida
                if (e.RowIndex >= 0)
                {

                
                    // Obtenemos la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
              
                // Asignamos los valores a los TextBox (ajusta los nombres de los TextBox y las columnas según tu diseño)
                    txtKardexConId.Text = filaSeleccionada.Cells["ArticuloConID"].Value.ToString();
                    txtNomKarCon.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    txtCodKarCon.Text = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    txtKarPrecio.Text = filaSeleccionada.Cells["Precio"].Value.ToString();
                    cbxTipoKarCon.SelectedItem = filaSeleccionada.Cells["Tipo"].Value.ToString();
                    txtKarEntrada.Text = filaSeleccionada.Cells["Entrada"].Value.ToString();
                    txtKarSalida.Text = filaSeleccionada.Cells["Salida"].Value.ToString();
                   
             

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarErrorEditar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }
                SqlConnection conexion = cnxKardex.ObtenerConexion();

                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexConcentradoEditar", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios
                    cmdAgregarConKardex.Parameters.AddWithValue("@articuloid", Convert.ToInt32(txtKardexConId.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@nombre", txtNomKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@codigo", txtCodKarCon.Text);
                    cmdAgregarConKardex.Parameters.AddWithValue("@tipo", cbxTipoKarCon.SelectedItem.ToString());
                    cmdAgregarConKardex.Parameters.AddWithValue("@precio", float.Parse(txtKarPrecio.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtKarEntrada.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@salida", Convert.ToInt32(txtKarSalida.Text));
                    cmdAgregarConKardex.Parameters.AddWithValue("@fechaVencimiento", dtpFechaVenKar.Value);



                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Concentrado actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }


        private bool ValidarErrorEditar()
        {
            // Limpiar cualquier error previo
            epValidarEditar.Clear();

            if (txtKardexConId.Text == string.Empty)
            {
                epValidarEditar.SetError(txtKardexConId, "Debe Seleccionar un articulo para actualizar su informacion.");
                return false;
            }
           

            return true; // Si todas las validaciones son correctas, devuelve true

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarErrorEliminar())
                {
                    return; // Si hay errores, salimos del método y no ejecutamos el procedimiento
                }

                SqlConnection conexion = cnxKardex.ObtenerConexion();

                if (MessageBox.Show("¿Desea Eliminar este concentrado de Kardex?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    
                // Crear el comando y asociarlo con la conexión
                using (SqlCommand cmdAgregarConKardex = new SqlCommand("spKardexConcentradoEliminar", conexion))
                {
                    cmdAgregarConKardex.CommandType = CommandType.StoredProcedure;
                    cmdAgregarConKardex.Parameters.AddWithValue("@concentradoid", Convert.ToInt32(txtKardexConId.Text));

                    // Ejecuta el procedimiento almacenado
                    cmdAgregarConKardex.ExecuteNonQuery();
                    MessageBox.Show("Concentrado eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LIMPIO TODOS LOS CAMPOS LUEGO DE LA COMPRA.

                    txtKardexConId.Clear();


                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message + "\nAsegúrate de que los datos están en el formato correcto.");
            }
        }

        private bool ValidarErrorEliminar()
        {
            // Limpiar cualquier error previo
            epValidarEliminar.Clear();

            if (txtKardexConId.Text == string.Empty)
            {
                epValidarEliminar.SetError(txtKardexConId, "Debe Seleccionar un articulo a eliminar.");
                return false;
            }


            return true; // Si todas las validaciones son correctas, devuelve true
        }
    }
   }
