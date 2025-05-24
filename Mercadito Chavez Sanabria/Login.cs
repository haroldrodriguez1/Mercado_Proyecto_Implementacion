using System;                      // Importa el espacio de nombres básico del sistema
using System.Collections.Generic; // Importa colecciones genéricas (no usado explícito aquí)
using System.ComponentModel;      // Importa para componentes (no usado explícito aquí)
using System.Data;                // Importa para manejo de datos (no usado explícito aquí)
using System.Diagnostics;         // Importa para diagnóstico (no usado explícito aquí)
using System.Drawing;             // Importa para gráficos (no usado explícito aquí)
using System.Linq;                // Importa para LINQ (no usado explícito aquí)
using System.Text;                // Importa para manejo de texto (no usado explícito aquí)
using System.Threading.Tasks;    // Importa para tareas asíncronas (no usado explícito aquí)
using System.Windows.Forms;      // Importa para Windows Forms
using System.Xml.Linq;            // Importa para manipulación XML con LINQ (no usado explícito aquí)

namespace Mercadito_Chavez_Sanabria  // Define el namespace del proyecto
{
    public partial class Login : Form  // Define clase parcial Login que hereda de Form
    {
        public Login()  // Constructor de la clase Login
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        Conexion cnn = new Conexion();  // Crea instancia para conexión a base de datos o lógica

        private void pictureBox1_Click(object sender, EventArgs e)  // Evento click en pictureBox1 (vacío)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)  // Evento click en pictureBox2 (vacío)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)  // Evento click botón Iniciar Sesión
        {
            string usuario = textBox1.Text.Trim();     // Obtiene y limpia el texto del usuario
            string contrasena = textBox2.Text.Trim();  // Obtiene y limpia el texto de la contraseña

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))  // Valida campos vacíos
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Muestra advertencia
                return;  // Sale del método si hay campos vacíos
            }

            int resultado = cnn.IniciarSesion(usuario, contrasena);  // Llama al método para iniciar sesión y guarda resultado

            if (resultado == 1)  // Si resultado es 1 (usuario activo tipo administrador)
            {
                GlobalVariable.UsuarioRol = 1;  // Establece rol global a 1 (administrador)
                this.Hide();                    // Oculta formulario actual
                Form n = new MENU();            // Crea instancia del formulario MENU
                n.Show();                      // Muestra el formulario MENU

            }
            if (resultado == 2)  // Si resultado es 2 (administrador inactivo)
            {
                MessageBox.Show("Usuario tipo ADMINISTRADOR esta inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra mensaje de error
            }
            if (resultado == 3)  // Si resultado es 3 (usuario activo tipo cajero)
            {
                GlobalVariable.UsuarioRol = 0;  // Establece rol global a 0 (cajero)
                this.Hide();                   // Oculta formulario actual
                Form n = new MENU();           // Crea instancia del formulario MENU
                n.Show();                     // Muestra el formulario MENU

            }
            if (resultado == 4)  // Si resultado es 4 (cajero inactivo)
            {
                MessageBox.Show("Usuario tipo CAJERO esta inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra mensaje de error
            }
            if (resultado == 0)  // Si resultado es 0 (usuario o contraseña incorrectos)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra mensaje de error
            }
        }

        private void Login_Load(object sender, EventArgs e)  // Evento Load del formulario Login
        {
            textBox2.UseSystemPasswordChar = true;  // Activa la máscara de contraseña en el textbox2
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)  // Evento cambio estado del checkbox1
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;  // Muestra u oculta la contraseña según el checkbox
        }
    }
}
