// Importa los espacios de nombres necesarios para el manejo de formularios, datos, gráficos, etc.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Define el espacio de nombres del proyecto
namespace Mercadito_Chavez_Sanabria
{
    // Define la clase parcial ComprasEmpleados, que hereda de la clase Form
    public partial class ComprasEmpleados : Form
    {
        // Constructor de la clase ComprasEmpleados
        public ComprasEmpleados()
        {
            InitializeComponent(); // Llama al método que inicializa los componentes del formulario
        }

        // Evento que se ejecuta al cargarse el formulario ComprasEmpleados
        private void ComprasEmpleados_Load(object sender, EventArgs e)
        {
            // Carga los datos del reporte 'Reporte_EmpleadosCompras' en el dataset local 'mercado_Chavez_SanabriaDataSet6local'
            this.reporte_EmpleadosComprasTableAdapter1.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_EmpleadosCompras);

            // Refresca el visor del reporte para mostrar los datos cargados
            this.reportViewer1.RefreshReport();
        }

        // Evento que se ejecuta al hacer clic en el botón btnRegresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
            Form n = new REPORTES(); // Crea una nueva instancia del formulario REPORTES
            n.Show(); // Muestra el formulario REPORTES
        }
    }
}
