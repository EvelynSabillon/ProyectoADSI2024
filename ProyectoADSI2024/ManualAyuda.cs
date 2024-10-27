using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace ProyectoADSI2024
{
    public partial class ManualAyuda : Form
    {
        private PdfViewer pdfViewer;



        public ManualAyuda()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void ManualAyuda_Load(object sender, EventArgs e)
        {
            // Inicializa el control PdfViewer
            pdfViewer = new PdfViewer
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(pdfViewer);

            // Construye la ruta del archivo PDF en la carpeta Resources
            string pdfPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "ManualUsuario.pdf");

            // Carga el PDF
            LoadPdf(pdfPath);
        }

        private void LoadPdf(string filePath)
        {
            pdfViewer.Document?.Dispose(); // Libera el documento previo
            pdfViewer.Document = PdfDocument.Load(filePath);
        }
    }
}
