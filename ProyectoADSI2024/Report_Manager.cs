using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoADSI2024
{
    public class Report_Manager
    {
        private string connectionString = "Server = 3.128.144.165; Database = DB20212030388; User ID = eugene.wu; Password = EW20212030388";

        public string GenerateReportNumber(string reportType)
        {
            string generatedNumber = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GenerateReportNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    command.Parameters.AddWithValue("@ReportType", reportType);

                    // Parámetro de salida
                    SqlParameter outputParam = new SqlParameter("@GeneratedNumber", SqlDbType.NVarChar, 10)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Obtener el número generado
                    generatedNumber = outputParam.Value.ToString();
                }
            }

            return generatedNumber;
        }
    }
}
