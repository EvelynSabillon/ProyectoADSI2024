using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoADSI2024
{
    internal static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SqlConnection myconexion; //Conexion a SQL Server

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Muestra el Splash Screen
            using (frmSplashScreen frmSplash = new frmSplashScreen())
            {
                frmSplash.ShowDialog();
            }

            // Muestra el formulario de Login después del Splash Screen
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();

            // Si la conexión fue exitosa, abre el formulario principal (Menu)
            if (frmLogin.Conectado)
            {
                myconexion = frmLogin.Conexion;
                Application.Run(new Menu()); // Abre el formulario principal
            }
        }
    }
}
