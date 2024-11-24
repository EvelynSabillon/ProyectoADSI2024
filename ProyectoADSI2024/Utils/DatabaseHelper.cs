using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoADSI2024.Utils
{
    //internal class DatabaseHelper
    //{
    //}

    public static class DatabaseHelper
    {
        // Cadena de conexión (ajusta según tu base de datos)
        private static string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=eugene.wu; password=EW20212030388";

        /// <summary>
        /// Valida si existen datos en la tabla para la fecha proporcionada.
        /// </summary>
        /// <param name="date">La fecha que deseas verificar.</param>
        /// <returns>True si hay datos, False en caso contrario.</returns>
        public static bool HasDataForDate(DateTime date)
        {
            // Consulta SQL para contar registros para la fecha específica
            string query = "SELECT COUNT(*) FROM proyecto.IngresoLeche WHERE CONVERT(DATE, DiaID) = @Fecha";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Agregar parámetro de la fecha
                    cmd.Parameters.AddWithValue("@Fecha", date.Date);

                    // Abrir conexión y ejecutar la consulta
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    // Devolver true si hay registros, false si no
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones (opcional: loguearlas)
                Console.WriteLine($"Error al verificar datos: {ex.Message}");
                return false;
            }
        }
    }

}
