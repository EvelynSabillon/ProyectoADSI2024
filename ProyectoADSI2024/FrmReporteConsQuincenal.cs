﻿using ProyectoADSI2024.Reportes.ReportePrestamosFinanzas;
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
    public partial class FrmReporteConsQuincenal : Form
    {
        public string NumeroReporte { get; set; }
        public FrmReporteConsQuincenal()
        {
            InitializeComponent();
        }

        private void FrmReporteConsQuincenal_Load(object sender, EventArgs e)
        {
            crReporteConsQuincenal objreporte = new crReporteConsQuincenal();
            objreporte.SetParameterValue("NumeroReporte", NumeroReporte); // Nuevo parámetro

            objreporte.SetDatabaseLogon("eugene.wu", "EW20212030388", "3.128.144.165", "DB20212030388");
            crystalReportViewer1.ReportSource = objreporte;
        }
    }
}
