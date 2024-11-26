using ProyectoADSI2024.Reportes.ReportePrestamosFinanzas;
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
    
    public partial class frmDialogNomina : Form
    {
        public frmDialogNomina()
        {
            InitializeComponent();
        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void frmDialogNomina_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB20212030388DataSet1.Quincena' Puede moverla o quitarla según sea necesario.
            this.quincenaTableAdapter.Fill(this.dB20212030388DataSet1.Quincena);
            CargarPrimerasQuincenas();
            CargarSegundasQuincenas();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la selección de la nomina?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Seleccione una QuincenaID para consultar o imprimir un reporte.", "Ayuda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void frmDialogNomina_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {
            subFrmNomina nomina = new subFrmNomina();

            try
            {
                // Obtener los valores seleccionados de los combo boxes
                if (cboxQuin1.SelectedValue != null && cboxQuin2.SelectedValue != null)
                {
                    nomina.quincenaid1 = Convert.ToInt32(cboxQuin1.SelectedValue);
                    nomina.quincenaid2 = Convert.ToInt32(cboxQuin2.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar ambas quincenas antes de generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir si no están seleccionadas ambas quincenas
                }

                // Generar el número de reporte
                Report_Manager reportManager = new Report_Manager();
                string tipoReporte = "02"; // Tipo de reporte (puedes adaptarlo según sea necesario)
                nomina.NumeroReporte = reportManager.GenerateReportNumber(tipoReporte);

                // Mostrar el formulario
                nomina.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPrimerasQuincenas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=3.128.144.165;Database=DB20212030388;User ID=eugene.wu;Password=EW20212030388"))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerPrimerasQuincenas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboxQuin1.DataSource = dt;
                        cboxQuin1.DisplayMember = "Descripcion";
                        cboxQuin1.ValueMember = "QuincenaID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar primeras quincenas: {ex.Message}");
            }
        }

        private void CargarSegundasQuincenas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=3.128.144.165;Database=DB20212030388;User ID=eugene.wu;Password=EW20212030388"))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerSegundasQuincenas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboxQuin2.DataSource = dt;
                        cboxQuin2.DisplayMember = "Descripcion";
                        cboxQuin2.ValueMember = "QuincenaID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar segundas quincenas: {ex.Message}");
            }
        }




    }
}
