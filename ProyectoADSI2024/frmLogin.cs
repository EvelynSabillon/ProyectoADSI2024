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
    public partial class frmLogin : Form
    {
        SqlConnection conexion;
        public bool conectado;

        public SqlConnection Conexion
        {
            get { return conexion; }
        }

        public bool Conectado
        {
            get { return conectado; }
        }

        public frmLogin()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        [DllImport("Gdi32.DLL", EntryPoint = "CreateRoundRectRgn")]
        private extern static IntPtr CreateRoundRectRgn
        (
            int nLeftRect, 
            int nTopRect, 
            int nRightRect, 
            int nBottomRect, 
            int nWidthEllipse, 
            int nHeightEllipse
         );

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.FromArgb(84, 130, 51);
                txtUsuario.Font = new Font(txtUsuario.Font, FontStyle.Bold);
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.FromArgb(84, 142, 51);
                txtUsuario.Font = new Font(txtUsuario.Font, FontStyle.Regular);
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if(txtContrasena.Text == "CONTRASEÑA")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.FromArgb(84, 130, 51);
                txtContrasena.Font = new Font(txtContrasena.Font, FontStyle.Bold);
                txtContrasena.PasswordChar = '*';
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if(txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA";
                txtContrasena.ForeColor = Color.FromArgb(84, 142, 51);
                txtContrasena.Font = new Font(txtContrasena.Font, FontStyle.Regular);
                txtContrasena.PasswordChar = '\0';
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void chkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            if(txtContrasena.Text == "CONTRASEÑA")
            {

            }
            else
            {
                if (chkMostrarContra.Checked)
                {
                    txtContrasena.PasswordChar = '\0';
                }
                else
                {
                    txtContrasena.PasswordChar = '*';
                }
            }

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            string servidor = "3.128.144.165";
            string bd = "DB20212030388";
            string usuario = txtUsuario.Text.Trim();
            string pw = txtContrasena.Text.Trim();


            string connectionString = $"Server={servidor};Database={bd};User Id={usuario};Password={pw};";

            try
            {
                conectado = false;
                conexion = new SqlConnection(connectionString);
                conexion.Open();
                conectado = true;
                MessageBox.Show("Se conecto correctamente a la base de datos", "Conexion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    if (ex.Errors[i].Number == 18456)
                    {
                        MessageBox.Show("El usuario o contraseña es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se logro conectar a la base de datos " + ex.ToString());
                    }
                }

            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
