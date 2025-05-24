using System; // Importa el espacio de nombres base para tipos y funcionalidades básicas de .NET
using System.Collections.Generic; // Importa colecciones genéricas (no usadas explícitamente en este código)
using System.ComponentModel; // Importa componentes para diseño y eventos
using System.Data; // Importa funcionalidades para manejo de datos
using System.Drawing; // Importa funcionalidades para gráficos y dibujo
using System.Linq; // Importa funcionalidades para consultas LINQ (no usadas aquí)
using System.Text; // Importa funcionalidades para manipulación de texto (no usadas aquí)
using System.Threading.Tasks; // Importa funcionalidades para tareas asincrónicas (no usadas aquí)
using System.Windows.Forms; // Importa funcionalidades para crear interfaces gráficas con Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el espacio de nombres para organizar las clases de la aplicación
{
    public partial class ProductosMasVendidos : Form // Define la clase ProductosMasVendidos que hereda de Form para crear una ventana
    {
        public ProductosMasVendidos() // Constructor público de la clase
        {
            InitializeComponent(); // Inicializa los componentes visuales generados por el diseñador
        }

        private void ProductosMasVendidos_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar el formulario
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet.ObtenerProductosMasVendidos' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosMasVendidosTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet.ObtenerProductosMasVendidos);
            // Utiliza el TableAdapter para llenar el dataset con los datos de productos más vendidos

            this.reportViewer1.RefreshReport(); // Actualiza el control reportViewer para mostrar el reporte con los datos cargados
        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new REPORTES(); // Crea una nueva instancia del formulario REPORTES
            n.Show(); // Muestra el formulario REPORTES
        }
    }
}
