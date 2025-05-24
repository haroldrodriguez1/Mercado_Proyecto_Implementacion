using Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6TableAdapters; // Importa el espacio de nombres donde están los TableAdapters para manejar datos del dataset
using System; // Importa el espacio de nombres base de .NET para tipos básicos
using System.Collections.Generic; // Importa colecciones genéricas, aunque no se usan explícitamente en este código
using System.ComponentModel; // Importa componentes para diseño y eventos
using System.Data; // Importa funcionalidades de acceso a datos
using System.Drawing; // Importa funcionalidades para gráficos y dibujo
using System.Linq; // Importa funcionalidades para consultas LINQ, no usadas explícitamente aquí
using System.Text; // Importa clases para manipulación de texto, no usadas explícitamente aquí
using System.Threading.Tasks; // Importa funcionalidades para tareas asincrónicas, no usadas aquí
using System.Windows.Forms; // Importa funcionalidades para crear formularios y controles de Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el namespace para agrupar clases relacionadas con la aplicación
{
    public partial class ProductosBajoStock : Form // Define la clase ProductosBajoStock que hereda de Form para crear una ventana
    {
        public ProductosBajoStock() // Constructor público de la clase
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario (generado por el diseñador)
        }

        private void ProductosBajoStock_Load(object sender, EventArgs e) // Evento que se ejecuta cuando el formulario se carga
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.Reporte_ProductosBajoStock' Puede moverla o quitarla según sea necesario.
            this.reporte_ProductosBajoStockTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_ProductosBajoStock, 10);
            // Llama al método Fill del TableAdapter para cargar datos en el dataset usando un parámetro 10 (probablemente cantidad o filtro)

            reportViewer1.RefreshReport(); // Actualiza el control reportViewer para mostrar el reporte con los datos cargados

        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new REPORTES(); // Crea una nueva instancia del formulario REPORTES
            n.Show(); // Muestra el formulario REPORTES
        }
    }
}
