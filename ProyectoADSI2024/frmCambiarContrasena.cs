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
    public partial class frmCambiarContrasena : Form
    {
        private string conn = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

        //tooltip
        System.Windows.Forms.ToolTip toolTip1;

        public frmCambiarContrasena()
        {
            InitializeComponent();
            toolTips();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); //Metodo para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); //Metodo para mover la ventana

        //VALIDACION DE CAMPOS
        private bool ValidarFormulario()
        {
            bool valido = true;

            // Limpiar errores previos
            errorProvider1.Clear();

            // Validar Usuario
            if (string.IsNullOrWhiteSpace(tboxUsuario.Text))
            {
                errorProvider1.SetError(tboxUsuario, "El campo Usuario es obligatorio.");
                valido = false;
            }

            // Validar Contraseña Actual
            if (string.IsNullOrWhiteSpace(tboxConActual.Text))
            {
                errorProvider1.SetError(tboxConActual, "El campo Contraseña Actual es obligatorio.");
                valido = false;
            }

            // Validar Nueva Contraseña
            if (!ValidarContrasena(tboxConNueva.Text))
            {
                errorProvider1.SetError(tboxConNueva, "La nueva contraseña debe tener minimo 8 caracteres, iniciar con una letra mayúscula, contener números y al menos un carácter especial.");
                valido = false;
            }

            // Validar Confirmación de Contraseña
            if (tboxConNueva.Text != tboxConNuevaConfirmacion.Text)
            {
                errorProvider1.SetError(tboxConNuevaConfirmacion, "La confirmación no coincide con la nueva contraseña.");
                valido = false;
            }

            return valido;
        }
        //FIN DE VALIDACION DE CAMPOS


        //VALIDAR CONTRASEÑA
        //private bool ValidarContrasena(string contrasena)
        //{
        //    if (contrasena.Length < 8) return false;
        //    if (!char.IsUpper(contrasena[0])) return false;
        //    if (!contrasena.Any(char.IsDigit)) return false;

        //    return true;
        //}

        //NUEVO
        private bool ValidarContrasena(string contrasena)
        {
            // Verificar longitud mínima
            if (contrasena.Length < 8)
                return false;

            // Verificar que comience con una letra mayúscula
            if (!char.IsUpper(contrasena[0]))
                return false;

            // Verificar que contenga al menos un número
            if (!contrasena.Any(char.IsDigit))
                return false;

            // Verificar que contenga al menos un carácter especial
            if (!contrasena.Any(ch => "!@#$%^&*()_+-=[]{}|;:',.<>?/".Contains(ch)))
                return false;

            // Si cumple todos los requisitos
            return true;
        }

        //FIN VALIDAR CONTRASEÑA

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //FUNCIONALIDAD PARA CAMBIAR CONTRASEÑA AL ACEPTAR
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            // Validar el formulario
            if (!ValidarFormulario())
            {
                return; // Si hay errores, no continuar.
            }

            string usuario = tboxUsuario.Text.Trim();
            string contrasenaActual = tboxConActual.Text.Trim();
            string contrasenaNueva = tboxConNueva.Text.Trim();

            // Llamar al procedimiento almacenado
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CambiarContrasena", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@ContrasenaAnterior", contrasenaActual);
                        cmd.Parameters.AddWithValue("@ContrasenaNueva", contrasenaNueva);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                tboxUsuario.Clear();
                tboxConActual.Clear();
                tboxConNueva.Clear();
                tboxConNuevaConfirmacion.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cambiar la contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FUNCIONALIDAD PARA CAMBIAR CONTRASEÑA AL ACEPTAR


        //MOSTRAR/OCULTAR CONTRASEÑAS
        private void chboxVerPass_CheckedChanged(object sender, EventArgs e)
        {
            // Cambiar el estado de visibilidad de la contraseña según el CheckBox
            if (chboxVerPass.Checked)
            {
                tboxConActual.UseSystemPasswordChar = false;
                tboxConNueva.UseSystemPasswordChar = false;
                tboxConNuevaConfirmacion.UseSystemPasswordChar = false;
            }
            else
            {
                tboxConActual.UseSystemPasswordChar = true;
                tboxConNueva.UseSystemPasswordChar = true;
                tboxConNuevaConfirmacion.UseSystemPasswordChar = true;
            }
        }
        //FIN MOSTRAR/OCULTAR CONTRASEÑAS


        //MENSAJES DE AYUDA PARA LLENAR LA INFORMACION DE LOS USUARIOS
        private void toolTips()
        {
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseAnimation = true;
            toolTip1.SetToolTip(tboxUsuario, "Ingrese el usuario de inicio de sesion.");
            toolTip1.SetToolTip(tboxConActual, "Ingrese la contraseña actual de su usuario.");
            toolTip1.SetToolTip(tboxConNueva, "Ingrese una contraseña nueva.");
            toolTip1.SetToolTip(tboxConNuevaConfirmacion, "Ingrese la confirmacion de la contraseña.");
            toolTip1.SetToolTip(chboxVerPass, "Ver Contraseña.");
        }

        private void frmCambiarContrasena_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //Mover la ventana
        }
        //FIN MENSAJES DE AYUDA PARA LLENAR LA INFORMACION DE LOS USUARIOS

    }
}
