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
        private DataTable dtQuincenas1;
        private DataTable dtQuincenas2;
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
            txtTextoDetalle.Enabled = false;
            txtTextoSalida.Enabled = false;
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
            try
            {
                // Obtener los valores seleccionados de los combo boxes
                if (dgvQuincena1.SelectedRows.Count > 0 && dgvQuincena2.SelectedRows.Count > 0)
                //(cboxQuin1.SelectedValue != null && cboxQuin2.SelectedValue != null)
                {
                    //int quincenaid1 = Convert.ToInt32(cboxQuin1.SelectedValue);
                    int quincenaid1 = Convert.ToInt32(dgvQuincena1.SelectedRows[0].Cells["QuincenaID"].Value);
                    //int quincenaid2 = Convert.ToInt32(cboxQuin2.SelectedValue);
                    int quincenaid2 = Convert.ToInt32(dgvQuincena2.SelectedRows[0].Cells["QuincenaID"].Value);

                    subFrmNomina nomina = new subFrmNomina(quincenaid1, quincenaid2);

                    // Generar el número de reporte
                    Report_Manager reportManager = new Report_Manager();
                    string tipoReporte = "02"; // Tipo de reporte (puedes adaptarlo según sea necesario)
                    nomina.NumeroReporte = reportManager.GenerateReportNumber(tipoReporte);

                    // Mostrar el formulario
                    nomina.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar ambas quincenas antes de generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir si no están seleccionadas ambas quincenas
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // Pasar el número de reporte al formulario
           // frmNomina.NumeroReporte = numeroReporte;
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
                        dtQuincenas1 = new DataTable();
                        da.Fill(dtQuincenas1);

                        dgvQuincena1.DataSource = dtQuincenas1;
                        /*cboxQuin1.DataSource = dt;
                        cboxQuin1.DisplayMember = "Descripcion";
                        cboxQuin1.ValueMember = "QuincenaID";*/
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
                        dtQuincenas2 = new DataTable();
                        da.Fill(dtQuincenas2);

                        dgvQuincena2.DataSource = dtQuincenas2;
                        /*cboxQuin2.DataSource = dt;
                        cboxQuin2.DisplayMember = "Descripcion";
                        cboxQuin2.ValueMember = "QuincenaID";*/
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar segundas quincenas: {ex.Message}");
            }
        }

        private void cmbCampoSalida_Click(object sender, EventArgs e)
        {
            //txtTextoSalida.Enabled = true;
        }

        private void cmbCampoDetalle_Click(object sender, EventArgs e)
        {
            //txtTextoDetalle.Enabled = true;
        }

        private void txtTextoSalida_TextChanged(object sender, EventArgs e)
        {
            if (txtTextoSalida.Text.Length == 0)
            {
                dtQuincenas1.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = dtQuincenas1.Columns[cmbCampoSalida.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        dtQuincenas1.DefaultView.RowFilter = cmbCampoSalida.Text + " LIKE '%" + txtTextoSalida.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTextoSalida.Text, out int numero))
                        {
                            dtQuincenas1.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numero;
                        }
                        else
                        {
                            dtQuincenas1.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTextoSalida.Text, out decimal numeroDecimal))
                        {
                            dtQuincenas1.DefaultView.RowFilter = cmbCampoSalida.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            dtQuincenas1.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
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
                            dtQuincenas1.DefaultView.RowFilter = cmbCampoSalida.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            dtQuincenas1.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        dtQuincenas1.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dgvQuincena1.DataSource = dtQuincenas1.DefaultView.ToTable();
        }

        private void txtTextoDetalle_TextChanged(object sender, EventArgs e)
        {
            if (txtTextoDetalle.Text.Length == 0)
            {
                dtQuincenas2.DefaultView.RowFilter = ""; // Mostrar todo si el texto está vacío
            }
            else
            {
                try
                {
                    var columnType = dtQuincenas2.Columns[cmbCampoDetalle.Text].DataType;

                    if (columnType == typeof(string)) // Filtro para cadenas
                    {
                        dtQuincenas2.DefaultView.RowFilter = cmbCampoDetalle.Text + " LIKE '%" + txtTextoDetalle.Text + "%'";
                    }
                    else if (columnType == typeof(int)) // Filtro para enteros
                    {
                        if (int.TryParse(txtTextoDetalle.Text, out int numero))
                        {
                            dtQuincenas2.DefaultView.RowFilter = cmbCampoDetalle.Text + " = " + numero;
                        }
                        else
                        {
                            dtQuincenas2.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double)) // Filtro para números decimales
                    {
                        if (decimal.TryParse(txtTextoDetalle.Text, out decimal numeroDecimal))
                        {
                            dtQuincenas2.DefaultView.RowFilter = cmbCampoDetalle.Text + " = " + numeroDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            dtQuincenas2.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else if (columnType == typeof(DateTime)) // Filtro para fechas (día/mes/año)
                    {
                        if (DateTime.TryParseExact(txtTextoDetalle.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                        {
                            dtQuincenas2.DefaultView.RowFilter = cmbCampoDetalle.Text + " = #" + dateValue.ToString("MM/dd/yyyy") + "#";
                        }
                        else
                        {
                            dtQuincenas2.DefaultView.RowFilter = "1 = 0"; // Sin coincidencias
                        }
                    }
                    else
                    {
                        dtQuincenas2.DefaultView.RowFilter = "1 = 0"; // Tipo no compatible
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el filtrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dgvQuincena2.DataSource = dtQuincenas2.DefaultView.ToTable();

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

        private void cmbCampoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampoDetalle.SelectedIndex != -1)
            {
                txtTextoDetalle.Enabled = true;
            }
            else
            {
                txtTextoDetalle.Enabled = false;
            }
        }
    }
}
