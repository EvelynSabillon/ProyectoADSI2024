using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Libreria para conexion con SQL Server

namespace ProyectoADSI2024
{
    public partial class frmPrestamo : Form
    {
        private Conexion conexion; //Conexion con SQL Server
        SqlDataAdapter adaptador; //Adaptador para SQL Server
        DataTable tabla; //Tabla para SQL Server

        public frmPrestamo()
        {
            InitializeComponent();
            conexion = new Conexion(); //Inicializar la conexion
            adaptador = new SqlDataAdapter("spPrestamoSelect", conexion.ObtenerConexion()); //Inicializar el adaptador
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure; //Tipo de comando
            tabla = new DataTable(); //Inicializar la tabla
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea volver al menu principal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void frmPrestamo_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarComboSocios(); //Llenar el ComboBox de Socios
                adaptador.Fill(tabla); //Llenar la tabla
                dataGridView1.DataSource = tabla; //Mostrar la tabla en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboSocios()
        {
            try
            {
                SqlConnection con = conexion.ObtenerConexion();

                //Crear el comando SQL para seleccionar los socios
                using (SqlCommand cmd = new SqlCommand(
                    "select SocioID, Nombre from proyecto.Socio where SocioID not in (select ps.SocioID from proyecto.Socio ps inner join proyecto.Prestamo pp on ps.SocioID = pp.SocioID where ps.Activo = 1 and pp.Pagado = 0 or (ps.Activo = 0 and pp.Pagado = 0 )) and Activo = 1", con))
                { 
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dtSocios = new DataTable();
                        dtSocios.Load(dr);

                        // Asignar el DataTable como DataSource del ComboBox
                        cmbNombreSocio.DataSource = dtSocios;

                        // Mostrar el nombre del proveedor
                        cmbNombreSocio.DisplayMember = "Nombre";

                        // Internamente almacenar el ProveedorID
                        cmbNombreSocio.ValueMember = "SocioID";
                    }
                }
                //inicia vacio.
                cmbNombreSocio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNombreSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreSocio.SelectedIndex != -1)
            {
                txtSocioID.Text = cmbNombreSocio.SelectedValue.ToString();
            }
            else
            {
                txtSocioID.Text = "";
            }
        }
    }
}
