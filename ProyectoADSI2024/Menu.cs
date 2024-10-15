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

namespace ProyectoADSI2024
{
    public partial class Menu : Form
    {
        SqlConnection conexion = new SqlConnection(); //Conexion a SQL Server
        SqlCommand comando = new SqlCommand(); //Comando SQL
        public Menu()
        {
            InitializeComponent();
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
            }
            else
            {
                MenuVertical.Width = 230;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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
    }
}
