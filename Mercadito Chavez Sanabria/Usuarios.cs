using System; // Importa el espacio de nombres System que contiene clases fundamentales
using System.Collections.Generic; // Importa clases para colecciones genéricas
using System.ComponentModel; // Importa clases para componentes
using System.Data; // Importa clases para acceso a datos
using System.Drawing; // Importa clases para manejo de gráficos
using System.Linq; // Importa clases para consultas LINQ
using System.Text; // Importa clases para manipulación de texto
using System.Threading.Tasks; // Importa clases para programación asíncrona y tareas
using System.Windows.Forms; // Importa clases para la creación de formularios y controles Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el namespace del proyecto o aplicación
{
    public partial class Usuarios : Form // Clase parcial Usuarios que hereda de Form (ventana de Windows Forms)
    {
        public Usuarios() // Constructor de la clase Usuarios
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario
        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento click del botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea una nueva instancia del formulario MENU
            n.Show(); // Muestra el formulario MENU
        }

        private void Usuarios_Load(object sender, EventArgs e) // Evento Load del formulario Usuarios
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Configura que las columnas del DataGridView se ajusten automáticamente para llenar el espacio
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Establece el estilo del borde de las celdas como línea simple
            CargarDatos(); // Llama al método que carga los datos en el DataGridView
        }

        Conexion cnn = new Conexion(); // Crea una instancia de la clase Conexion para manejo de base de datos
        int selectedClientId = 0; // Variable para almacenar el ID del usuario seleccionado
        string name = ""; // Variable string para almacenar nombre (no usada en este código)
        string estadotxt; // Variable string para almacenar estado (no usada en este código)

        private void CargarDatos() // Método para cargar datos en el DataGridView
        {
            cnn.ConsultasGrid("exec sp_ConsultarUsuarios '" + "" + "'", dataGridView1); // Ejecuta el procedimiento almacenado sp_ConsultarUsuarios con parámetro vacío y carga el resultado en dataGridView1
        }

        private bool Check() // Método para validar campos antes de guardar o editar
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || // Verifica si el campo Nombre está vacío o con espacios
                string.IsNullOrWhiteSpace(txtContrasena.Text) || // Verifica si el campo Contraseña está vacío o con espacios
                string.IsNullOrWhiteSpace(cmbUsuarios.Text)) // Verifica si el ComboBox de Usuarios está vacío o con espacios
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje de advertencia
                return false; // Retorna falso porque no pasa la validación
            }

            return true; // Retorna verdadero si todo está correcto
        }

        private void Clear() // Método para limpiar los campos del formulario
        {
            txtContrasena.Clear(); // Limpia el campo Contraseña
            txtNombre.Clear(); // Limpia el campo Nombre
            cmbUsuarios.Items.Clear(); // Limpia los ítems del ComboBox Usuarios
            cmbUsuarios.Items.Add("Administrador"); // Agrega el ítem "Administrador" al ComboBox
            cmbUsuarios.Items.Add("Cajero"); // Agrega el ítem "Cajero" al ComboBox
        }

        private void EditarImg_Click(object sender, EventArgs e) // Evento click de la imagen Editar
        {
            btnEditar.PerformClick(); // Simula el click en el botón Editar
        }

        private void EliminarImg_Click(object sender, EventArgs e) // Evento click de la imagen Eliminar
        {
            btnEliminar.PerformClick(); // Simula el click en el botón Eliminar
        }

        private void GuardarImg_Click(object sender, EventArgs e) // Evento click de la imagen Guardar
        {
            btnGuardar.PerformClick(); // Simula el click en el botón Guardar
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Evento click en el contenido de una celda del DataGridView
        {
            MostrarBotones(); // Muestra los botones de editar y eliminar
            if (e.RowIndex >= 0) // Si la fila clickeada es válida (no encabezado)
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); // Obtiene el ID del usuario de la primera celda de la fila
                txtNombre.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value); // Coloca el nombre del usuario en el textbox Nombre
                txtContrasena.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value); // Coloca la contraseña del usuario en el textbox Contraseña
                cmbUsuarios.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value); // Coloca el rol del usuario en el ComboBox Usuarios
                if (cmbUsuarios.Text == "Administrador") // Si el texto del ComboBox es "Administrador"
                {
                    cmbUsuarios.SelectedValue = 1; // Selecciona el valor 1 (probablemente para manejar roles internamente)
                }
                else
                {
                    cmbUsuarios.SelectedValue = 0; // Selecciona el valor 0 en otro caso
                }
                selectedClientId = idCliente; // Guarda el ID del usuario seleccionado en la variable

                /*if (estadotxt == "ACTIVO") // Código comentado para manejo de estado con checkbox
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }*/
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Evento click del botón Guardar
        {
            if (Check()) // Si pasa la validación de campos
            {
                int estado = 1; // Estado por defecto activo
                int rol = 0; // Rol por defecto 0

                if (cmbUsuarios.Text == "Administrador") // Si el rol es Administrador
                {
                    rol = 1; // Asigna rol 1
                }
                else
                {
                    rol = 0; // Si no, rol 0
                }
                cnn.Modificaciones("exec sp_InsertarUsuario '" + txtNombre.Text + "','" + txtContrasena.Text + "','" + rol + "','" + estado + "'"); // Ejecuta procedimiento almacenado para insertar usuario
                CargarDatos(); // Recarga los datos en el DataGridView
                OcultarBotones(); // Oculta los botones de editar y eliminar
                Clear(); // Limpia los campos
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e) // Evento no implementado, parece duplicado
        {

        }

        private void OcultarBotones() // Método para ocultar botones e imágenes de editar y eliminar
        {
            btnEditar.Visible = false; // Oculta botón Editar
            btnEliminar.Visible = false; // Oculta botón Eliminar
            imgEditar.Visible = false; // Oculta imagen Editar
            imgEliminar.Visible = false; // Oculta imagen Eliminar
        }

        private void MostrarBotones() // Método para mostrar botones e imágenes de editar y eliminar
        {
            imgEditar.Visible = true; // Muestra imagen Editar
            imgEliminar.Visible = true; // Muestra imagen Eliminar
            btnEditar.Visible = true; // Muestra botón Editar
            btnEliminar.Visible = true; // Muestra botón Eliminar
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Evento click del botón Eliminar
        {
            if (selectedClientId > 0) // Si se ha seleccionado un usuario válido
            {
                bool resultado = cnn.Modificaciones("exec sp_EliminarUsuario '" + selectedClientId + "'"); // Ejecuta procedimiento almacenado para eliminar usuario

                if (resultado) // Si la eliminación fue exitosa
                {
                    MessageBox.Show("Usuario eliminado exitosamente."); // Muestra mensaje de éxito
                    CargarDatos(); // Recarga datos
                    OcultarBotones(); // Oculta botones
                    Clear(); // Limpia campos
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el Usuario."); // Muestra mensaje de error
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Usuario para eliminar."); // Indica que no hay usuario seleccionado
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) // Evento click del botón Editar
        {
            if (Check()) // Si pasa la validación de campos
            {
                if (selectedClientId > 0) // Si hay un usuario seleccionado
                {
                    int estado = 1; // Estado activo
                    int rol = 0; // Rol por defecto 0

                    if (cmbUsuarios.Text == "Administrador") // Si el rol es Administrador
                    {
                        rol = 1; // Asigna rol 1
                    }
                    else
                    {
                        rol = 0; // Si no, rol 0
                    }
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarUsuario '" + selectedClientId + "','" + txtNombre.Text + "','" + txtContrasena.Text + "','" + rol + "','" + estado + "'"); // Ejecuta procedimiento para actualizar usuario

                    if (resultado) // Si actualización fue exitosa
                    {
                        MessageBox.Show("Usuario editado exitosamente."); // Muestra mensaje de éxito
                        CargarDatos(); // Recarga datos
                        OcultarBotones(); // Oculta botones
                        Clear(); // Limpia campos
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el Usuario."); // Muestra mensaje de error
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un empleado para editar."); // Indica que no hay usuario seleccionado para editar
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Evento TextChanged para un TextBox (posiblemente búsqueda)
        {
            string busqueda = textBox1.Text.Trim(); // Obtiene el texto del textbox sin espacios

            if (string.IsNullOrEmpty(busqueda)) // Si el texto está vacío
            {
                CargarDatos(); // Carga todos los datos
            }
            else
            {
                string comando = "exec sp_ConsultarUsuarios @nombre = '" + busqueda + "'"; // Crea comando con parámetro nombre para búsqueda
                cnn.Busquedas(comando, dataGridView1, ""); // Ejecuta búsqueda y carga resultados en el DataGridView
            }
        }
    }
}
