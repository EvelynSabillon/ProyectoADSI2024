﻿using System;
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

namespace ProyectoADSI2024
{

    public partial class Menu : Form
    {
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
            Form frmvistasociosreporteconsumoinsumo = new frmVistaDeSocioParaReporteConsumoInsumo();
            frmvistasociosreporteconsumoinsumo.Show();
        }

        private void reporteDeProducciónQuincenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReporteProduccionGral = new frmReporteProduccionGeneral();
            formReporteProduccionGral.Show();
        }

        private void reporteEntregaQuincenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteEntregaQuincenal reporteEntregas = new frmReporteEntregaQuincenal();
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
    }
}
