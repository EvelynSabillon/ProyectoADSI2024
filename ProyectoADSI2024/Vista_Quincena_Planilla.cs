using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class Vista_Quincena_Planilla : Form
    {

        private Conexion conexion;
        SqlDataAdapter adaptador;
        DataTable tabla;
        frmNomina Nomina;
        
        public Vista_Quincena_Planilla()
        {
            InitializeComponent();
        }

        public Vista_Quincena_Planilla(frmNomina nom)
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            Nomina = nom;
            adaptador = new SqlDataAdapter("spQuincenasPlanilla", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección de la quincena?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Seleccione una QuincenaID para agregar al registro de planilla", "Ayuda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void Vista_Quincena_Planilla_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampo.SelectedIndex != -1)
            {
                txtTexto.Enabled = true;
            }
            else
            {
                txtTexto.Enabled = false;
            }
        }

        private void Vista_Quincena_Planilla_Load(object sender, EventArgs e)
        {
            txtTexto.Enabled = false;
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID 
                int quincenaid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["QuincenaID"].Value);
                DateTime fechaInicio = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["FechaInicio"].Value);
                DateTime fechaFinal = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["FechaFinal"].Value);

                // Confirmación para seleccionar 
                DialogResult result = MessageBox.Show("¿Está seguro de seleccionar esta Quincena?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Asignamos los datos a los textboxs del formulario frmNomina
                    Nomina.txtQuincenaID.Text = quincenaid.ToString();
                    Nomina.dtpFechaInicio.Value = fechaInicio;
                    Nomina.dtpFechaFinal.Value = fechaFinal;

                    this.Close(); // Cerramos el formulario 
                }
            }
        }
    }
}
