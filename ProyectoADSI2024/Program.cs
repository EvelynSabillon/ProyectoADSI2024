using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static AuthManager;

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
            //UTILIZADO CUANDO SE INICIA SESION CON UN USUARIO DEBASE DE DATOS V1
                //SqlConnection myconexion; //Conexion a SQL Server
            //FIN UTILIZADO CUANDO SE INICIA SESION CON UN USUARIO DEBASE DE DATOS V1

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Muestra el Splash Screen
            using (frmSplashScreen frmSplash = new frmSplashScreen())
            {
                frmSplash.ShowDialog();
            }

            //UTILIZADO CUANDO SE INICIA SESION CON UN USUARIO DEBASE DE DATOS V2
            //// Muestra el formulario de Login después del Splash Screen
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.ShowDialog();

            //// Si la conexión fue exitosa, abre el formulario principal (Menu)
            //if (frmLogin.Conectado)
            //{
            //    myconexion = frmLogin.Conexion;
            //    Application.Run(new Menu()); // Abre el formulario principal
            //}
            //FIN //UTILIZADO CUANDO SE INICIA SESION CON UN USUARIO DEBASE DE DATOS V2

            bool sesionActiva = false;
            UserSession currentSession = null;

            //do
            //{
            //    // Mostrar el formulario de Login
            //    using (frmLogin frmLogin = new frmLogin())
            //    {
            //        frmLogin.ShowDialog();

            //        // Si el login fue exitoso
            //        if (frmLogin.Conectado)
            //        {
            //            sesionActiva = true;
            //            currentSession = frmLogin.CurrentSession;
            //        }
            //        else
            //        {
            //            // Si el usuario cierra el formulario de login sin iniciar sesión, salir del programa
            //            return;
            //        }
            //    }

            //    // Mostrar el formulario principal (Menu) si la sesión está activa
            //    using (Menu menuForm = new Menu(currentSession))
            //    {
            //        menuForm.ShowDialog();

            //        // Si el formulario principal indica que se cerró sesión
            //        if (menuForm.CerrarSesion)
            //        {
            //            sesionActiva = false;
            //        }
            //    }

            //} while (!sesionActiva);

            do
            {
                using (frmLogin frmLogin = new frmLogin())
                {
                    if (!sesionActiva)
                    {
                        frmLogin.ShowDialog();

                        if (frmLogin.Conectado)
                        {
                            sesionActiva = true;
                            currentSession = frmLogin.CurrentSession;
                        }
                        else
                        {
                            // Si el usuario cierra el formulario de login sin iniciar sesión, salir del programa
                            return;
                        }
                    }

                    // Mostrar el formulario principal (Menu) si la sesión está activa
                    using (Menu menuForm = new Menu(currentSession))
                    {

                        menuForm.ShowDialog();

                        // Si el formulario principal indica que se cerró sesión
                        if (menuForm.CerrarSesion)
                        {
                            sesionActiva = false;
                            frmLogin.Show(); // Mostrar nuevamente el login después de cerrar sesión
                        }
                    }
                }
            } while (!sesionActiva);


        }
    }
}
