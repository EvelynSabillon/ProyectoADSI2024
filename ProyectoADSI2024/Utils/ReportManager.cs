using CrystalDecisions.CrystalReports.Engine;
using ProyectoADSI2024.Reportes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*namespace ProyectoADSI2024.Utils
{
    internal class ReportManager
    {
    }
}
*/

public static class ReportManager
{
    private static readonly string RutaBaseReporte = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes");


    public static void ShowReport(string rutarelativa)
    {
        try
        {
            // Ruta completa de los reportes
            string reporteRuta = Path.Combine(RutaBaseReporte, rutarelativa);

            // Validacion si el reporte existe
            if (!File.Exists(reporteRuta))
            {
                throw new FileNotFoundException($"El archivo de reporte no se encontró en la ruta: {reporteRuta}");
            }

            // Cargar el reporte
            ReportDocument report = new ReportDocument();
            report.Load(reporteRuta);

            // Mostrar el reporte en el Form de visualzacion de Reportes
            using (frmReportViewer viewer = new frmReportViewer())
            {
                viewer.LoadReport(report);
                viewer.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
