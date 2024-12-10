using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class AuthManager
{
    private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

    public UserSession Login(string username, string password)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //NUEVO
                //Verificar si el usuario existe pero esta inactivo
                string queryInactive = @"
                SELECT u.UsuarioID, u.Nombre, u.Usuario, u.PerfilID, p.NombrePerfil, u.Activo 
                FROM proyecto.Usuarios u
                INNER JOIN proyecto.Perfiles p ON u.PerfilID = p.PerfilID
                WHERE u.Usuario = @Usuario AND u.Contrasena = @Contrasena";

                SqlCommand commandInactive = new SqlCommand(queryInactive, connection);
                commandInactive.Parameters.AddWithValue("@Usuario", username);
                commandInactive.Parameters.AddWithValue("@Contrasena", password);

                connection.Open();
                SqlDataReader readerInactive = commandInactive.ExecuteReader();

                if (readerInactive.Read())
                {
                    // Si el usuario existe pero está inactivo
                    if (readerInactive["Activo"] != DBNull.Value && !(bool)readerInactive["Activo"])
                    {
                        MessageBox.Show("El usuario existe, pero está inactivo. Contacte al administrador.",
                            "Usuario Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                }
                readerInactive.Close();



                //INICIAR SESION CORRECTAMENTE
                //ANTES
                //string query = @"
                //SELECT u.UsuarioID, u.Nombre, u.Usuario, u.PerfilID, p.NombrePerfil, u.Activo 
                //FROM proyecto.Usuarios u
                //INNER JOIN proyecto.Perfiles p ON u.PerfilID = p.PerfilID
                //WHERE u.Usuario = @Usuario AND u.Contrasena = @Contrasena AND u.Activo = 1";

                //SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@Usuario", username);
                //command.Parameters.AddWithValue("@Contrasena", password);

                //connection.Open();
                //SqlDataReader reader = command.ExecuteReader();

                //if (reader.Read())
                //{
                //    return new UserSession
                //    {
                //        UsuarioID = reader["UsuarioID"] != DBNull.Value ? Convert.ToInt32(reader["UsuarioID"]) : 0,
                //        Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                //        PerfilID = reader["PerfilID"] != DBNull.Value ? Convert.ToInt32(reader["PerfilID"]) : 0,
                //        Perfil = reader["NombrePerfil"] != DBNull.Value ? reader["NombrePerfil"].ToString() : string.Empty
                //    };
                //}

                //NUEVO
                string queryActive = @"
                SELECT u.UsuarioID, u.Nombre, u.Usuario, u.PerfilID, p.NombrePerfil, u.Activo 
                FROM proyecto.Usuarios u
                INNER JOIN proyecto.Perfiles p ON u.PerfilID = p.PerfilID
                WHERE u.Usuario = @Usuario AND u.Contrasena = @Contrasena AND u.Activo = 1";

                SqlCommand commandActive = new SqlCommand(queryActive, connection);
                commandActive.Parameters.AddWithValue("@Usuario", username);
                commandActive.Parameters.AddWithValue("@Contrasena", password);

                SqlDataReader readerActive = commandActive.ExecuteReader();

                if (readerActive.Read())
                {
                    return new UserSession
                    {
                        UsuarioID = readerActive["UsuarioID"] != DBNull.Value ? Convert.ToInt32(readerActive["UsuarioID"]) : 0,
                        Nombre = readerActive["Nombre"] != DBNull.Value ? readerActive["Nombre"].ToString() : string.Empty,
                        PerfilID = readerActive["PerfilID"] != DBNull.Value ? Convert.ToInt32(readerActive["PerfilID"]) : 0,
                        Perfil = readerActive["NombrePerfil"] != DBNull.Value ? readerActive["NombrePerfil"].ToString() : string.Empty
                    };
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar otras excepciones generales
            MessageBox.Show("La base de datos se encuentra fuera de línea " /*+ ex.Message*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return null; // Usuario no válido o error
    }


    public class UserSession
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public int PerfilID { get; set; }
        public string Perfil { get; set; }

        public bool TieneAcceso(string modulo)
        {
            // Lista de módulos permitidos según el perfil del usuario
            var permisos = new Dictionary<string, List<string>>
    {
        { "Administrador", new List<string> { "Todos" } },
        { "Gerencial", new List<string> { "Control de Ingreso de Leche", "Gestión de Socios", "Gestión de Proveedores", "Gestión de Inventario", "Gestión de Préstamos y Finanzas", "Reportes", "Administración General", "Manual de Usuario" } },
        { "Fiscal", new List<string> { "Gestión de Préstamos y Finanzas", "Reportes", "Reporte General de Pagos", "Gestion de Socios", "Administración General", "Manual de Usuario" } },
        { "Tesorero", new List<string> { "Gestión de Préstamos y Finanzas", "Gestión de Inventario", "Reportes", "Reporte de Consumo de Insumos", "Gestion de Proveedores", "Administración General", "Manual de Usuario" } },
        { "Encargado de Suministros", new List<string> { "Gestión de Inventario", "Reportes", "Alertas de Bajo Inventario", "Administración General", "Manual de Usuario" } },
        { "Supervisor de Recolección", new List<string> { "Control de Ingreso de Leche", "Reportes", "Reporte de Entrega de Leche Quincenal", "Administración General", "Manual de Usuario"  } }
    };

            //Reportes
            /*Reporte de Ingreso de Leche Diaria        --> Modulo de Ingreso de Leche/Ingreso diario
             * Reporte de Nomina Quincena               --> Modulo de Gestion de Prestamos/Nomina y Finanzas
             * Reporte de Consumo de Insumos            --> Modulo Gestion de Invetarios y Modulo de Reportes
             * Kardex                                   --> Modulo de Gestion dde Inventarios
             * Reporte de Produccion General            --> Modulo de Ingreso de Leche y Modulo de Reportes
             * Reporte General de Pagos/ Pagos socios   --> Modulo de Gestion de Prestamos y Finanzas
             * Reporte de Entrega de Leche Quincenal    --> Modulo de Ingreso de Leche y Modulo de Reportes
             * Alertas de Bajo Inventario               --> Modulo de Reportes
             * Administracion General                   --> Modulo de Administracion General
             * Manual de Usuario                        --> Modulo de Administracion General
             */

            // Validar si el perfil tiene acceso al módulo
            if (permisos.ContainsKey(this.Perfil))
            {
                return permisos[this.Perfil].Contains("Todos") || permisos[this.Perfil].Contains(modulo);
            }

            return false; // Por defecto, no tiene acceso
        }


    }
}
