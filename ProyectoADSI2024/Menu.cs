using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //Libreria para mover la ventana
using System.Data.SqlClient; //Libreria para conexion a SQL Server
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace ProyectoADSI2024
{

    public partial class Menu : Form
    {
        private Timer alertTimer = new Timer();
        SqlConnection myconexion; //Conexion a SQL Server
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            dropdownMenu1.IsMainMenu = true;
            dropdownMenu1.PrimaryColor = Color.FromArgb(204, 185, 65);
            dropdownMenu2.IsMainMenu = true;
            dropdownMenu2.PrimaryColor = Color.FromArgb(204, 185, 65);
            dropdownMenu3.IsMainMenu = true;
            dropdownMenu3.PrimaryColor = Color.FromArgb(204, 185, 65);
            dropdownMenu4.IsMainMenu = true;
            dropdownMenu4.PrimaryColor = Color.FromArgb(204, 185, 65);
            dropdownMenu5.IsMainMenu = true;
            dropdownMenu5.PrimaryColor = Color.FromArgb(204, 185, 65);
            dropdownMenu6.IsMainMenu = true;
            dropdownMenu6.PrimaryColor = Color.FromArgb(204, 185, 65);
            dropdownMenu7.IsMainMenu = true;
            dropdownMenu7.PrimaryColor = Color.FromArgb(204, 185, 65);

            AbrirDashboardEnPanel();

            // Configurar el Timer
            alertTimer.Interval = 2000; // 2 segundos
            alertTimer.Tick += AlertTimer_Tick;
            alertTimer.Start();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 230)
            {
                MenuVertical.Width = 66;
                btnModuloIngresoLeche.Enabled = false;
                btnModuloGestionSocios.Enabled = false;
                btnModuloManejoProveedores.Enabled = false;
                btnModuloGestionInventario.Enabled = false;
                btnModuloGestionFinanciera.Enabled = false;
                btnModuloAdministracionGeneral.Enabled = false;
                btnReportes.Enabled = false;
            }
            else
            {
                MenuVertical.Width = 230;
                btnModuloIngresoLeche.Enabled = true;
                btnModuloGestionSocios.Enabled = true;
                btnModuloManejoProveedores.Enabled = true;
                btnModuloGestionInventario.Enabled = true;
                btnModuloGestionFinanciera.Enabled = true;
                btnModuloAdministracionGeneral.Enabled = true;
                btnReportes.Enabled = true;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizar.Image = Properties.Resources.white_square_icon;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizar.Image = Properties.Resources.white_doublesquare_icon;

            }
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void btnModuloIngresoLeche_Click(object sender, EventArgs e)
        {
            dropdownMenu1.Show(btnModuloIngresoLeche, btnModuloIngresoLeche.Width, 0);
        }

        private void btnModuloGestionSocios_Click(object sender, EventArgs e)
        {
            dropdownMenu2.Show(btnModuloGestionSocios, btnModuloGestionSocios.Width, 0);
        }

        private void btnModuloManejoProveedores_Click(object sender, EventArgs e)
        {
            dropdownMenu3.Show(btnModuloManejoProveedores, btnModuloManejoProveedores.Width, 0);
        }

        private void btnModuloGestionInventario_Click(object sender, EventArgs e)
        {
            dropdownMenu4.Show(btnModuloGestionInventario, btnModuloGestionInventario.Width, 0);
        }

        private void btnModuloGestionFinanciera_Click(object sender, EventArgs e)
        {
            dropdownMenu5.Show(btnModuloGestionFinanciera, btnModuloGestionFinanciera.Width, 0);
        }

        private void btnModuloAdministracionGeneral_Click(object sender, EventArgs e)
        {
            dropdownMenu6.Show(btnModuloAdministracionGeneral, btnModuloAdministracionGeneral.Width, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            dropdownMenu7.Show(btnReportes, btnReportes.Width, 0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            fh.Disposed += new EventHandler(FormHijo_Disposed);
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void FormHijo_Disposed(object sender, EventArgs e)
        {
            AbrirDashboardEnPanel(); // Mostrar el Dashboard cuando se cierre el formulario hijo
        }

        private void btn1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new IngresoDiarioLeche());
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dropdownMenu4_MouseClick(object sender, MouseEventArgs e)
        {
           

        }

        //evento click para gestionInventario/Concentrado
      /*  private void ConcentradoToolStrip_click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmGestionConcentrado());
        }

        //evento click para gestionInventario/Medicamento
        private void MedicamentoToolStrip_click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmGestionMedicamento());
        }*/

        private void btnPrestamoToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmPrestamo());
        }

        private void btnAnticipoToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAnticipo());
        }

        private void btnNominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmNomina());
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void articuloExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmGestionConcentrado());

        }

        private void nuevoMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmGestionMedicamento()); //nueva compra de medicamento
        }

        private void btnConsultaQuincenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ConsultaQuincenalLeche());
        }

        private void btnSociostoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new GestionSocios());
        }

        private void btnRegistroProvtoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new RegistroProveedores());
        }

        private void btnPagoProvtoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new PagoProveedores());
        }

        private void btnUsuariostoolStripMenuItem9_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new GestionUsuarios());
        }

        private void btnPermisostoolStripMenuItem10_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new GestionPermisos());
        }

        private void btnAyudatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ManualAyuda());
        }

        private void btnKardexConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmKardexConcentrado());
        }

        private void btnKardexMedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmKardexMedicamento());
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConcentradoExistente());
        }

        private void medicamentoExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMedicamentoExistente());
        }

        private void btnSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmSalidaConcentrado());
        }

        private void btnSalidaMedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmSalidaMedicamento());
        }

        public void AbrirDashboardEnPanel()
        {
            // Limpia el panel
            panelContenedor.Controls.Clear();

            // Crea una instancia del Dashboard y lo configura para que se muestre en el panel
            DashBoard dashboard = new DashBoard();
            dashboard.TopLevel = false;
            dashboard.FormBorderStyle = FormBorderStyle.None;
            dashboard.Dock = DockStyle.Fill;

            // Agrega el Dashboard al panel principal y lo muestra
            panelContenedor.Controls.Add(dashboard);
            dashboard.Show();
        }

        //Cada vez que se abra el Menu principal o se cierren los forms que van dentro del panelContenedor 
        //se muestre predeterminadamente el dashboard
        private void Menu_Activated(object sender, EventArgs e)
        {
            AbrirDashboardEnPanel();
        }

        private void reporteConsumoInsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVistaDeSocioParaReporteConsumoInsumo frmvistasociosreporteconsumoinsumo = new frmVistaDeSocioParaReporteConsumoInsumo();
            frmvistasociosreporteconsumoinsumo.Show();
        }

        private void reporteDeProducciónQuincenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProduccionGeneral frmReporteProduccionGral = new frmReporteProduccionGeneral();

            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "06"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
            frmReporteProduccionGral.NumeroReporte = numeroReporte;

            frmReporteProduccionGral.ShowDialog();
        }

        private void reporteEntregaQuincenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipalEntregaQuincenal reporteEntregas = new frmPrincipalEntregaQuincenal();
            reporteEntregas.Show();
        }

        private void reportePagoDeSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmplanilla = new frmplanillainforme();
            frmplanilla.Show();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void alertasDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager.ShowReport(@"ReporteGestionInventario\rptAlertas.rpt");
        }


        private void DetectarExistenciasBajasGlobal()
        {
            string queryConcentrado = @"
            SELECT Nombre, Existencia 
            FROM proyecto.ArticuloConcentrado 
            WHERE Existencia BETWEEN 0 AND 5";

            string queryMedicamento = @"
            SELECT Nombre, Existencia 
            FROM proyecto.ArticuloMedicamento 
            WHERE Existencia BETWEEN 0 AND 5";

            // Tablas para almacenar los resultados
            DataTable concentradoTable = new DataTable();
            DataTable medicamentoTable = new DataTable();

            string connectionString = "Server = 3.128.144.165; Database = DB20212030388; User ID = eugene.wu; Password = EW20212030388;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ejecutar consulta para ArticuloConcentrado
                SqlDataAdapter adapterCon = new SqlDataAdapter(queryConcentrado, connection);
                adapterCon.Fill(concentradoTable);

                // Ejecutar consulta para ArticuloMedicamento
                SqlDataAdapter adapterMed = new SqlDataAdapter(queryMedicamento, connection);
                adapterMed.Fill(medicamentoTable);
            }

            // Verificar si hay alertas en ambos
            if (concentradoTable.Rows.Count > 0 || medicamentoTable.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Se han detectado artículos con existencias críticas. ¿Desea ver el reporte?",
                    "Alerta de Existencias Bajas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    
                    //refrescar el reporte 
                    // Crear una instancia del reporte
                    ReportDocument reporte = new ReportDocument();

                    // Cargar el reporte desde la ruta especificada
                    string rutaReporte = @".\Reportes\ReporteGestionInventario\rptAlertas.rpt";
                    reporte.Load(rutaReporte);

                    // Refrescar el reporte para garantizar datos actualizados
                    reporte.Refresh();

                    // (Opcional) Configurar conexión a base de datos si es necesario
                    ConnectionInfo connectionInfo = new ConnectionInfo
                    {
                        ServerName = "3.128.144.165",
                        DatabaseName = "DB20212030388",
                        UserID = "eugene.wu",
                        Password = "EW20212030388"
                    };

                    foreach (Table table in reporte.Database.Tables)
                    {
                        TableLogOnInfo logOnInfo = table.LogOnInfo;
                        logOnInfo.ConnectionInfo = connectionInfo;
                        table.ApplyLogOnInfo(logOnInfo);
                    }

                    // Mostrar el reporte en el visor (o usar tu método personalizado para mostrarlo)
                    // Crear y configurar un visor de Crystal Reports

                    CrystalReportViewer visor = new CrystalReportViewer
                    {
                        Dock = DockStyle.Fill,        // Para que ocupe todo el formulario
                        ReportSource = reporte,
                        ToolPanelView = ToolPanelViewType.None// Asignar el reporte al visor
                    };
                    visor.RefreshReport();            // Habilitar refrescar reporte automáticamente
                    

                    // Crear un formulario para mostrar el visor
                    Form formularioVisor = new Form
                    {
                        Text = "Reporte de Alertas",
                        WindowState = FormWindowState.Maximized
                    };
                    formularioVisor.Controls.Add(visor);

                    // Mostrar el formulario con el visor
                    formularioVisor.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("No hay artículos en estado crítico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AlertTimer_Tick(object sender, EventArgs e)
        {
            // Detener el Timer
            alertTimer.Stop();

            // Llamar a la función para detectar existencias bajas
            DetectarExistenciasBajasGlobal();
        }

        private void reporteDeEntregasQuincenalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeProducciónGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProduccionGeneral frmReporteProduccionGral = new frmReporteProduccionGeneral();

            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "06"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
            frmReporteProduccionGral.NumeroReporte = numeroReporte;

            frmReporteProduccionGral.ShowDialog();
        }

        private void reporteDeConsumoInsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDePagosSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
