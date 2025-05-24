using System; // Importa el espacio de nombres System, que contiene clases básicas y fundamentales.
using System.Collections.Generic; // Importa las clases para colecciones genéricas.
using System.ComponentModel; // Importa clases para el manejo de componentes.
using System.Data; // Importa clases para acceso y manejo de datos.
using System.Drawing; // Importa clases para manejo de gráficos.
using System.Linq; // Importa LINQ para consultas en colecciones.
using System.Text; // Importa clases para manipulación de texto.
using System.Threading.Tasks; // Importa soporte para programación asíncrona y paralela.
using System.Windows.Forms; // Importa clases para interfaces gráficas con Windows Forms.

namespace Mercadito_Chavez_Sanabria // Define el espacio de nombres del proyecto o aplicación.
{
    public partial class MENU : Form // Define la clase MENU que hereda de Form (ventana).
    {
        public MENU() // Constructor público de la clase MENU.
        {
            InitializeComponent(); // Inicializa los componentes visuales y eventos del formulario.
        }

        private void mERCADOCHAVEZSANABRIAToolStripMenuItem_Click(object sender, EventArgs e) // Evento click sobre un item de menú, actualmente sin implementación.
        {

        }



        private void MENU_Load(object sender, EventArgs e) // Evento que se ejecuta cuando se carga el formulario MENU.
        {
            ImgClientes.TabStop = false; // Quita el foco de tabulación al control ImgClientes.
            if (GlobalVariable.UsuarioRol == 0) // Verifica si el rol del usuario es 0 (Cajero).
            {
                txtRol.Text = "Cajero"; // Muestra el texto "Cajero" en el textbox txtRol.
                btnUsuarios.Enabled = false; // Deshabilita el botón Usuarios.
                btnEmpleados.Enabled = false; // Deshabilita el botón Empleados.
                btnBitacoras.Enabled = false; // Deshabilita el botón Bitacoras.
                btnVentas.Enabled = false; // Deshabilita el botón Ventas.

            }
            else // Si no es rol 0 (Cajero), entonces...
            {
                txtRol.Text = "Administrador"; // Muestra el texto "Administrador" en el textbox txtRol.
            }

        }


        private void ImgClientes_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgClientes.
        {
            btnClientes.Focus(); // Da foco al botón btnClientes.
            btnClientes.PerformClick(); // Simula un clic en btnClientes.
        }

        private void ImgEmpleados_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgEmpleados.
        {
            btnEmpleados.Focus(); // Da foco al botón btnEmpleados.
            btnEmpleados.PerformClick(); // Simula un clic en btnEmpleados.
        }

        private void ImgUsuarios_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgUsuarios.
        {
            btnUsuarios.Focus(); // Da foco al botón btnUsuarios.
            btnUsuarios.PerformClick(); // Simula un clic en btnUsuarios.
        }

        private void ImgProductos_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgProductos.
        {
            btnProductos.Focus(); // Da foco al botón btnProductos.
            btnProductos.PerformClick(); // Simula un clic en btnProductos.
        }

        private void ImgCategorias_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgCategorias.
        {
            btnCategorias.Focus(); // Da foco al botón btnCategorias.
            btnCategorias.PerformClick(); // Simula un clic en btnCategorias.
        }

        private void ImgProveedores_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgProveedores.
        {
            btnProveedores.Focus(); // Da foco al botón btnProveedores.
            btnProveedores.PerformClick(); // Simula un clic en btnProveedores.
        }

        private void ImgEmpresas_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgEmpresas.
        {
            btnEmpresas.Focus(); // Da foco al botón btnEmpresas.
            btnEmpresas.PerformClick(); // Simula un clic en btnEmpresas.
        }

        private void ImgVentas_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgVentas.
        {
            btnVentas.Focus(); // Da foco al botón btnVentas.
            btnVentas.PerformClick(); // Simula un clic en btnVentas.
        }

        private void ImgCompras_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgCompras.
        {
            btnFacturas.Focus(); // Da foco al botón btnFacturas.
            btnFacturas.PerformClick(); // Simula un clic en btnFacturas.
        }

        private void ImgCrearCompra_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgCrearCompra.
        {
            BtnCompra.Focus(); // Da foco al botón BtnCompra.
            BtnCompra.PerformClick(); // Simula un clic en BtnCompra.
        }

        private void ImgBitacora_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImgBitacora.
        {
            btnBitacoras.Focus(); // Da foco al botón btnBitacoras.
            btnBitacoras.PerformClick(); // Simula un clic en btnBitacoras.
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e) // Evento click en el botón para cerrar sesión.
        {
            Login n = new Login(); // Crea una instancia del formulario Login.
            this.Hide(); // Oculta el formulario actual MENU.
            n.Show(); // Muestra el formulario Login.
        }

        private void MENU_FormClosing(object sender, FormClosingEventArgs e) // Evento que ocurre al cerrar el formulario MENU.
        {
            Application.Exit(); // Finaliza la aplicación.
        }

        private void btnClientes_Click(object sender, EventArgs e) // Evento click en botón btnClientes.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new CLIENTE(); // Crea una instancia del formulario CLIENTE.
            n.Show(); // Muestra el formulario CLIENTE.
        }

        private void btnBitacoras_Click(object sender, EventArgs e) // Evento click en botón btnBitacoras.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new BITACORA(); // Crea una instancia del formulario BITACORA.
            n.Show(); // Muestra el formulario BITACORA.
        }

        private void btnEmpleados_Click(object sender, EventArgs e) // Evento click en botón btnEmpleados.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new Empleados(); // Crea una instancia del formulario Empleados.
            n.Show(); // Muestra el formulario Empleados.
        }

        private void btnUsuarios_Click(object sender, EventArgs e) // Evento click en botón btnUsuarios.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new Usuarios(); // Crea una instancia del formulario Usuarios.
            n.Show(); // Muestra el formulario Usuarios.
        }

        private void btnProductos_Click(object sender, EventArgs e) // Evento click en botón btnProductos.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new Productos(); // Crea una instancia del formulario Productos.
            n.Show(); // Muestra el formulario Productos.
        }

        private void btnCategorias_Click(object sender, EventArgs e) // Evento click en botón btnCategorias.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new Categorías(); // Crea una instancia del formulario Categorías.
            n.Show(); // Muestra el formulario Categorías.
        }

        private void btnProveedores_Click(object sender, EventArgs e) // Evento click en botón btnProveedores.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new Proveedores(); // Crea una instancia del formulario Proveedores.
            n.Show(); // Muestra el formulario Proveedores.
        }

        private void btnEmpresas_Click(object sender, EventArgs e) // Evento click en botón btnEmpresas.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new Empresas(); // Crea una instancia del formulario Empresas.
            n.Show(); // Muestra el formulario Empresas.
        }

        private void btnVentas_Click(object sender, EventArgs e) // Evento click en botón btnVentas.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new VerFacturas(); // Crea una instancia del formulario VerFacturas.
            n.Show(); // Muestra el formulario VerFacturas.
        }

        private void btnCompras_Click(object sender, EventArgs e) // Evento click en botón btnCompras.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new CrearFacturas(); // Crea una instancia del formulario CrearFacturas.
            n.Show(); // Muestra el formulario CrearFacturas.

        }


        private void ImgClientes_Click(object sender, EventArgs e) // Evento click sobre ImgClientes, sin implementación.
        {

        }

        private void btnSar_Click(object sender, EventArgs e) // Evento click en botón btnSar.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new SAR(); // Crea una instancia del formulario SAR.
            n.Show(); // Muestra el formulario SAR.
        }

        private void ImageSar_MouseDown(object sender, MouseEventArgs e) // Evento al presionar botón del mouse sobre ImageSar.
        {
            btnSar.Focus(); // Da foco al botón btnSar.
            btnSar.PerformClick(); // Simula un clic en btnSar.
        }

        private void btnReportes_Click(object sender, EventArgs e) // Evento click en botón btnReportes.
        {
            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new REPORTES(); // Crea una instancia del formulario REPORTES.
            n.Show(); // Muestra el formulario REPORTES.
        }

        private void BtnCompra_Click(object sender, EventArgs e) // Evento click en botón BtnCompra.
        {

            this.Hide(); // Oculta el formulario actual MENU.
            Form n = new CrearCompra(); // Crea una instancia del formulario CrearCompra.
            n.Show(); // Muestra el formulario CrearCompra.
        }
    }
}
