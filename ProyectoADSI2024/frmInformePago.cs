﻿using System;
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
    public partial class frmInformePago : Form
    {
        public frmInformePago()
        {
            InitializeComponent();
        }
        public int idplanilla;
        private void frmInformePago_Load(object sender, EventArgs e)
        {
            crReportePagoSocio obj = new crReportePagoSocio();
            obj.SetParameterValue("@planillaid", idplanilla);
            crystalReportViewer1.ReportSource = obj;
            obj.SetDatabaseLogon("eugene.wu","EW20212030388","3.128.144.165","DB20212030388");
        }
    }
}
