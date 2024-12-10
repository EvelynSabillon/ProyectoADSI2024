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
    public partial class Vista_ArticuloMed : Form
    {
        private Conexion con;
        SqlDataAdapter adapter;
        DataTable tabla;
        frmSalidaMedicamento frmSalida;
        public Vista_ArticuloMed()
        {
            InitializeComponent();
        }

        public Vista_ArticuloMed(SqlConnection conexion, frmSalidaMedicamento SalidaMed)
        {
            InitializeComponent();
            cmbCampoSalida.SelectedIndex = 0;
            con = new Conexion();
            frmSalida = SalidaMed;
            adapter = new SqlDataAdapter("spArticuloMedSelect", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void Vista_ArticuloMed_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección del medicamento/articulo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Vista_ArticuloMed_Load(object sender, EventArgs e)
        {
            try
            {
                tabla = new DataTable();
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                txtTextoSalida.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTextoSalida_TextChanged(object sender, EventArgs e)
        {
            if (txtTextoSalida.Text.Length == 0)
            {
                tabla.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = tabla.Columns[cmbCampoSalida.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        tabla.DefaultView.RowFilter = cmbCampoSalida.Text + " LIKE '%" + txtTextoSalida.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTextoSalida.Text, out int numero))
                        {
                            tabla.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numero;
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTextoSalida.Text, out decimal numeroDecimal))
                        {
                            tabla.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            tabla.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
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
                            tabla.DefaultView.RowFilter = cmbCampoSalida.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
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

        private void cmbCampoSalida_Click(object sender, EventArgs e)
        {
            //txtTextoSalida.Enabled = true;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del Articulo seleccionado
                int articuloID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ArticuloMedID"].Value);
                string nombre = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Nombre"].Value);
                double precio = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["Precio"].Value);

                // Confirmación para seleccionar el articulo
                DialogResult result = MessageBox.Show("¿Está seguro de seleccionar este articulo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Asignamos los datos del articulo a los textboxs del formulario frmSalidaConcentrado
                    frmSalida.txtArticuloID.Text = articuloID.ToString();
                    frmSalida.txtNombreArt.Text = nombre.ToString();
                    frmSalida.txtPrecio.Text = precio.ToString();
                    this.Close(); // Cerramos el formulario VistaProveedores
                }
            }
        }

        private void cmbCampoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampoSalida.SelectedIndex != -1)
            {
                txtTextoSalida.Enabled = true;
            }
            else
            {
                txtTextoSalida.Enabled = false;
            }
        }
    }
}
