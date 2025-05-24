using System; // Importa funcionalidades base de .NET
using System.Collections.Generic; // Importa colecciones genéricas (no usadas explícitamente)
using System.ComponentModel; // Importa componentes para diseño y eventos
using System.Data; // Importa funcionalidades para manejo de datos (no usadas explícitamente)
using System.Drawing; // Importa funcionalidades para gráficos (no usadas explícitamente)
using System.Linq; // Importa LINQ (no usado aquí)
using System.Text; // Importa funcionalidades para manipulación de texto (no usado)
using System.Threading.Tasks; // Importa tareas asincrónicas (no usadas)
using System.Windows.Forms; // Importa la funcionalidad para interfaces gráficas Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el espacio de nombres del proyecto
{
    public partial class REPORTES : Form // Define la clase REPORTES que hereda de Form (ventana)
    {
        public REPORTES() // Constructor de la clase
        {
            InitializeComponent(); // Inicializa los componentes visuales generados por el diseñador
        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento para el botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea una instancia del formulario MENU
            n.Show(); // Muestra el formulario MENU
        }

        private void btnMasVendidos_Click(object sender, EventArgs e) // Evento para el botón Productos Más Vendidos
        {
            this.Close(); // Cierra el formulario actual
            Form n = new ProductosMasVendidos(); // Crea la instancia del formulario ProductosMasVendidos
            n.Show(); // Muestra el formulario ProductosMasVendidos
        }

        private void btnClientes_Click(object sender, EventArgs e) // Evento para el botón Clientes Frecuentes
        {
            this.Close(); // Cierra el formulario actual
            Form n = new ClientesFrecuentes(); // Crea la instancia del formulario ClientesFrecuentes
            n.Show(); // Muestra el formulario ClientesFrecuentes
        }

        private void btnComprasProveedor_Click(object sender, EventArgs e) // Evento para el botón Compras por Proveedor
        {
            this.Close(); // Cierra el formulario actual
            Form n = new ComprasProveedor(); // Crea la instancia del formulario ComprasProveedor
            n.Show(); // Muestra el formulario ComprasProveedor
        }

        private void btnComprasEmpleados_Click(object sender, EventArgs e) // Evento para el botón Compras por Empleados
        {
            this.Close(); // Cierra el formulario actual
            Form n = new ComprasEmpleados(); // Crea la instancia del formulario ComprasEmpleados
            n.Show(); // Muestra el formulario ComprasEmpleados
        }

        private void btnFactAnuladas_Click(object sender, EventArgs e) // Evento para el botón Facturas Anuladas
        {
            this.Close(); // Cierra el formulario actual
            Form n = new FacturasAnuladas(); // Crea la instancia del formulario FacturasAnuladas
            n.Show(); // Muestra el formulario FacturasAnuladas
        }

        private void btnIngresosCategoria_Click(object sender, EventArgs e) // Evento para el botón Ingresos por Categoría
        {
            this.Close(); // Cierra el formulario actual
            Form n = new IngresosCategoria(); // Crea la instancia del formulario IngresosCategoria
            n.Show(); // Muestra el formulario IngresosCategoria
        }

        private void btnProductosBajoStock_Click(object sender, EventArgs e) // Evento para el botón Productos Bajo Stock
        {
            this.Close(); // Cierra el formulario actual
            Form n = new ProductosBajoStock(); // Crea la instancia del formulario ProductosBajoStock
            n.Show(); // Muestra el formulario ProductosBajoStock
        }

        private void btnVentas_Click(object sender, EventArgs e) // Evento para el botón Ventas por Fecha Reporte
        {
            this.Close(); // Cierra el formulario actual
            Form n = new VentasPorFechaReporte(); // Crea la instancia del formulario VentasPorFechaReporte
            n.Show(); // Muestra el formulario VentasPorFechaReporte
        }

        private void button1_Click(object sender, EventArgs e) // Evento para el botón (no identificado, quizás Ver Compras)
        {
            this.Close(); // Cierra el formulario actual
            Form n = new VerCompras(); // Crea la instancia del formulario VerCompras
            n.Show(); // Muestra el formulario VerCompras
        }

        private void REPORTES_Load(object sender, EventArgs e) // Evento que se ejecuta cuando el formulario REPORTES se carga
        {
            if (GlobalVariable.UsuarioRol == 0) // Verifica si el rol del usuario es 0 (posiblemente rol con permisos limitados)
            {
                btnComprasEmpleados.Enabled = false; // Deshabilita el botón Compras Empleados
                btnFactAnuladas.Enabled = false; // Deshabilita el botón Facturas Anuladas
                btnIngresosCategoria.Enabled = false; // Deshabilita el botón Ingresos por Categoría
                btnVentas.Enabled = false; // Deshabilita el botón Ventas
            }
        }
    }
}
