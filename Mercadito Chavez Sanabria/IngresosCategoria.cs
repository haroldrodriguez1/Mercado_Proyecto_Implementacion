using System;                      // Importa el espacio de nombres básico del sistema
using System.Collections.Generic; // Importa colecciones genéricas (no usado explícito aquí)
using System.ComponentModel;      // Importa para componentes (no usado explícito aquí)
using System.Data;                // Importa para manejo de datos (no usado explícito aquí)
using System.Drawing;             // Importa para gráficos (no usado explícito aquí)
using System.Linq;                // Importa para LINQ (no usado explícito aquí)
using System.Text;                // Importa para manejo de texto (no usado explícito aquí)
using System.Threading.Tasks;    // Importa para tareas asíncronas (no usado explícito aquí)
using System.Windows.Forms;      // Importa para Windows Forms

namespace Mercadito_Chavez_Sanabria  // Define el namespace del proyecto
{
    public partial class IngresosCategoria : Form  // Define clase parcial IngresosCategoria que hereda de Form
    {
        public IngresosCategoria()  // Constructor de la clase
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        private void IngresosCategoria_Load(object sender, EventArgs e)  // Evento Load del formulario IngresosCategoria
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.Reporte_IngresosPorCategoria' Puede moverla o quitarla según sea necesario.
            this.reporte_IngresosPorCategoriaTableAdapter1.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_IngresosPorCategoria);  // Llena el dataset con los datos para el reporte de ingresos por categoría

            this.reportViewer1.RefreshReport();  // Actualiza el control ReportViewer para mostrar el reporte cargado
        }

        private void btnRegresar_Click(object sender, EventArgs e)  // Evento Click del botón Regresar
        {
            this.Close();       // Cierra el formulario actual
            Form n = new REPORTES();  // Crea una nueva instancia del formulario REPORTES
            n.Show();           // Muestra el formulario REPORTES
        }
    }
}
