using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
           lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            chart1.Series["Produccion Mensual"].Name = "Produccion Mensual";

            // Agrega puntos de datos manualmente
            chart1.Series["Produccion Mensual"].Points.AddXY("Enero", 120);
            chart1.Series["Produccion Mensual"].Points.AddXY("Febrero", 80);
            chart1.Series["Produccion Mensual"].Points.AddXY("Marzo", 130);
            chart1.Series["Produccion Mensual"].Points.AddXY("Abril", 90);
            chart1.Series["Produccion Mensual"].Points.AddXY("Mayo", 150);
            chart1.Series["Produccion Mensual"].Points.AddXY("Junio", 110);


            chart2.Series["Consumo de Inventario"].Name = "Consumo de Inventario";

            // Agrega puntos de datos manualmente
            chart2.Series["Consumo de Inventario"].Points.AddXY("Enero", 120);
            chart2.Series["Consumo de Inventario"].Points.AddXY("Febrero", 80);
            chart2.Series["Consumo de Inventario"].Points.AddXY("Marzo", 130);
            chart2.Series["Consumo de Inventario"].Points.AddXY("Abril", 90);
            chart2.Series["Consumo de Inventario"].Points.AddXY("Mayo", 150);
            chart2.Series["Consumo de Inventario"].Points.AddXY("Junio", 110);


            chart3.Series["Series1"].Name = "Series1";

            // Agrega puntos de datos manualmente
            chart3.Series["Venta"].Points.AddXY("Enero", 120);
            chart3.Series["Venta"].Points.AddXY("Febrero", 80);
            chart3.Series["Venta"].Points.AddXY("Marzo", 130);
            chart3.Series["Venta"].Points.AddXY("Abril", 90);
            chart3.Series["Venta"].Points.AddXY("Mayo", 150);
            chart3.Series["Venta"].Points.AddXY("Junio", 110);

        }
    }
}
