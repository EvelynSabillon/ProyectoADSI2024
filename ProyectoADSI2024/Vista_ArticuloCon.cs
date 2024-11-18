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
using System.Runtime.InteropServices;

namespace ProyectoADSI2024
{
    public partial class Vista_ArticuloCon : Form
    {
        private Conexion con;
        SqlDataAdapter adapter;
        DataTable tabla;
        frmSalidaConcentrado frmSalida;

        public Vista_ArticuloCon()
        {
            InitializeComponent();
        }

        public Vista_ArticuloCon(SqlConnection conexion, frmSalidaConcentrado SalidaCon)
        {
            InitializeComponent();
            cmbCampoSalida.SelectedIndex = 0;
            con = new Conexion();
            frmSalida = SalidaCon;
            adapter = new SqlDataAdapter("spArticuloConSelect", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void Vista_ArticuloCon_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección del concentrado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Vista_ArticuloCon_Load(object sender, EventArgs e)
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
                tabla.DefaultView.RowFilter = "";
            }
            else
            {
                if (tabla.Columns[cmbCampoSalida.Text].DataType == typeof(string))
                {
                    tabla.DefaultView.RowFilter = cmbCampoSalida.Text + " LIKE '%" + txtTextoSalida.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTextoSalida.Text, out numero))
                    {
                        tabla.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numero;
                    }
                    else
                    {
                        tabla.DefaultView.RowFilter = "1 = 0";
                    }
                }
            }

            dataGridView1.DataSource = tabla.DefaultView.ToTable();
        }

        private void cmbCampoSalida_Click(object sender, EventArgs e)
        {
            txtTextoSalida.Enabled = true;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del Articulo seleccionado
                int articuloID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ArticuloConID"].Value);
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
    }
}
