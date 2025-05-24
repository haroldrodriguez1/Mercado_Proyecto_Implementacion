// Importa los espacios de nombres necesarios para trabajar con formularios, datos, colecciones, etc.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Define el espacio de nombres principal del proyecto
namespace Mercadito_Chavez_Sanabria
{
    // Define una clase parcial llamada ClientesFrecuentes que hereda de Form
    public partial class ClientesFrecuentes : Form
    {
        // Constructor de la clase ClientesFrecuentes
        public ClientesFrecuentes()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        // Evento que se ejecuta cuando se carga el formulario ClientesFrecuentes
        private void ClientesFrecuentes_Load(object sender, EventArgs e)
        {
            // Carga los datos del reporte "Reporte_ClientesFrecuentes" desde el dataset local (mercado_Chavez_SanabriaDataSet6local)
            this.reporte_ClientesFrecuentesTableAdapter1.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_ClientesFrecuentes);

            // Refresca el visor de reportes para mostrar el reporte cargado
            this.reportViewer1.RefreshReport();
        }

        // Evento que se ejecuta al hacer clic en el botón Regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
            Form n = new REPORTES(); // Crea una nueva instancia del formulario REPORTES
            n.Show(); // Muestra el formulario REPORTES
        }
    }
}
