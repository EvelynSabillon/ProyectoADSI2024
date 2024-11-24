﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoADSI2024
{
    public partial class frmKardexMedicamento : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server
        public frmKardexMedicamento()
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spArticuloMedicamentoSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmKardexMedicamento_Load(object sender, EventArgs e)
        {
            try
            {
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Mostrar la tabla en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            frmReporteKardexMedicamento objformReporte = new frmReporteKardexMedicamento();

            int articuloid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            objformReporte.articuloid = articuloid;

            // Obtener el número de reporte generado desde el procedimiento almacenado
            Report_Manager reportManager = new Report_Manager();
            string tipoReporte = "05"; // Tipo de reporte (puedes adaptarlo según sea necesario)
            string numeroReporte = reportManager.GenerateReportNumber(tipoReporte);

            // Pasar el número de reporte al formulario
            objformReporte.NumeroReporte = numeroReporte;

            objformReporte.ShowDialog();
        }
    }
}
