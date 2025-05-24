using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
// Define el espacio de nombres del proyecto
namespace Mercadito_Chavez_Sanabria
{
    // Define una clase parcial llamada CLIENTE que hereda de Form
    public partial class CLIENTE : Form
    {
        // Constructor de la clase CLIENTE
        public CLIENTE()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        // Crea una instancia de la clase Conexion
        Conexion cnn = new Conexion();

        // Variable para almacenar el ID del cliente seleccionado
        int selectedClientId = 0;

        // Variables para almacenar datos del cliente
        string name = "";
        string correo = "";
        string telefono = "";

        // Evento que se ejecuta cuando el formulario CLIENTE se carga
        private void CLIENTE_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta automáticamente el ancho de las columnas
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Establece el estilo del borde de las celdas
            CargarDatos(); // Llama al método para cargar los datos al DataGridView
        }

        // Método para cargar datos en el DataGridView usando un procedimiento almacenado
        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarClientes '" + "" + "'", dataGridView1); // Ejecuta el procedimiento almacenado y llena el DataGridView
        }

        // Método para verificar si los campos obligatorios están llenos
        private bool Check()
        {
            // Verifica si algún campo está vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                // Muestra un mensaje de advertencia
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Retorna falso si hay campos vacíos
            }

            // Verifica que el campo teléfono sea un número válido
            if (!int.TryParse(txtTelefono.Text, out _))
            {
                // Muestra un mensaje de advertencia si no es un número
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Retorna falso si no es numérico
            }

            return true; // Retorna verdadero si pasa todas las validaciones
        }

        // Método para limpiar los campos de entrada
        private void Clear()
        {
            txtCorreo.Clear(); // Limpia el campo correo
            txtNombre.Clear(); // Limpia el campo nombre
            txtTelefono.Clear(); // Limpia el campo teléfono
        }

        // Evento al hacer clic en pictureBox1, simula clic en el botón Editar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnEditar.PerformClick(); // Simula clic en el botón Editar
        }

        // Evento al hacer clic en pictureBox3, simula clic en el botón Eliminar
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnEliminar.PerformClick(); // Simula clic en el botón Eliminar
        }

        // Evento al hacer clic en pictureBox2, simula clic en el botón Guardar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick(); // Simula clic en el botón Guardar
        }

        // Evento que se ejecuta al hacer clic en una celda del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarBotones(); // Muestra los botones de edición y eliminación

            // Verifica si el clic fue en una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtiene el ID del cliente desde la celda 0
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                // Llena los campos del formulario con los datos de la fila seleccionada
                txtNombre.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                txtCorreo.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

                // Almacena el ID del cliente seleccionado
                selectedClientId = idCliente;
            }
        }

        // Evento que se ejecuta al hacer clic en el botón Regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea una nueva instancia del formulario MENU
            n.Show(); // Muestra el formulario MENU
        }

        // Evento que se ejecuta al hacer clic en el botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verifica que los datos sean válidos
            if (Check())
            {
                // Ejecuta el procedimiento almacenado para insertar un nuevo cliente
                cnn.Modificaciones("exec sp_InsertarCliente '" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "'");
                CargarDatos(); // Vuelve a cargar los datos en el DataGridView
                OcultarBotones(); // Oculta los botones
                Clear(); // Limpia los campos
            }
        }

        // Evento duplicado que no tiene implementación
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        // Método para ocultar los botones de editar y eliminar
        private void OcultarBotones()
        {
            btnEditar.Visible = false; // Oculta el botón Editar
            btnEliminar.Visible = false; // Oculta el botón Eliminar
            pictureBox1.Visible = false; // Oculta la imagen de editar
            pictureBox3.Visible = false; // Oculta la imagen de eliminar
        }

        // Método para mostrar los botones de editar y eliminar
        private void MostrarBotones()
        {
            pictureBox1.Visible = true; // Muestra la imagen de editar
            pictureBox3.Visible = true; // Muestra la imagen de eliminar
            btnEditar.Visible = true; // Muestra el botón Editar
            btnEliminar.Visible = true; // Muestra el botón Eliminar
        }

        // Evento que se ejecuta al hacer clic en el botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay un cliente seleccionado
            if (selectedClientId > 0)
            {
                // Ejecuta el procedimiento almacenado para eliminar el cliente
                bool resultado = cnn.Modificaciones("exec sp_EliminarCliente '" + selectedClientId + "'"); // Asumiendo que la clase 'Conexion' tiene este método para ejecutar comandos

                // Verifica si la operación fue exitosa
                if (resultado)
                {
                    MessageBox.Show("Cliente eliminado exitosamente."); // Muestra mensaje de éxito
                    CargarDatos(); // Vuelve a cargar los datos
                    OcultarBotones(); // Oculta los botones
                    Clear(); // Limpia los campos
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el cliente."); // Muestra mensaje de error
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente para eliminar."); // Muestra mensaje si no se ha seleccionado cliente
            }
        }

        // Evento que se ejecuta al hacer clic en el botón Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica que los datos sean válidos
            if (Check())
            {
                // Verifica que haya un cliente seleccionado
                if (selectedClientId > 0)
                {
                    // Ejecuta el procedimiento almacenado para actualizar los datos del cliente
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarCliente '" + selectedClientId + "','" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "'");

                    // Verifica si la operación fue exitosa
                    if (resultado)
                    {
                        MessageBox.Show("Cliente editado exitosamente."); // Muestra mensaje de éxito
                        CargarDatos(); // Vuelve a cargar los datos
                        OcultarBotones(); // Oculta los botones
                        Clear(); // Limpia los campos
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el cliente."); // Muestra mensaje de error
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente para editar."); // Muestra mensaje si no se ha seleccionado cliente
                }
            }
        }

        // Evento que se ejecuta al cambiar el texto del TextBox de búsqueda
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.Trim(); // Obtiene el texto sin espacios

            // Verifica si el campo de búsqueda está vacío
            if (string.IsNullOrEmpty(busqueda))
            {
                CargarDatos(); // Carga todos los datos si no hay búsqueda
            }
            else
            {
                // Ejecuta el procedimiento almacenado con parámetro de búsqueda
                string comando = "exec sp_ConsultarClientes @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, ""); // Realiza la búsqueda en la base de datos
            }
        }
    }
}

