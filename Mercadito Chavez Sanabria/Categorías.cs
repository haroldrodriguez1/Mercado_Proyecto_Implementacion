using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

// Define el espacio de nombres 'Mercadito_Chavez_Sanabria'
namespace Mercadito_Chavez_Sanabria
{
    // Define una clase parcial llamada 'Categorías' que hereda de 'Form'
    public partial class Categorías : Form
    {
        // Constructor de la clase 'Categorías'
        public Categorías()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
        }

        // Evento que se ejecuta al hacer clic en el label1
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta al hacer clic en el botón 'btnRegresar'
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual
            this.Close();
            // Crea una nueva instancia del formulario 'MENU'
            Form n = new MENU();
            // Muestra el formulario 'MENU'
            n.Show();
        }

        // Evento que se ejecuta cuando el formulario 'Categorías' se carga
        private void Categorías_Load(object sender, EventArgs e)
        {
            // Establece el modo de autoajuste de columnas para que se llenen horizontalmente
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Establece el estilo del borde de las celdas como borde simple
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            // Llama al método para cargar los datos en el DataGridView
            CargarDatos();
        }

        // Crea una instancia de la clase 'Conexion' llamada 'cnn'
        Conexion cnn = new Conexion();
        // Declara una variable entera para almacenar el ID del cliente seleccionado
        int selectedClientId = 0;

        // Método para cargar los datos en el DataGridView utilizando un procedimiento almacenado
        private void CargarDatos()
        {
            // Ejecuta el procedimiento almacenado 'sp_ConsultarCategorias' con parámetro vacío
            cnn.ConsultasGrid("exec sp_ConsultarCategorias '" + "" + "'", dataGridView1);
        }

        // Método para validar que los campos no estén vacíos
        private bool Check()
        {
            // Verifica si el campo de texto de la categoría está vacío o contiene solo espacios
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                // Muestra un mensaje de advertencia si el campo está vacío
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Retorna falso indicando que la validación falló
                return false;
            }

            // Retorna verdadero si la validación fue exitosa
            return true;
        }

        // Método para limpiar los campos del formulario
        private void Clear()
        {
            // Limpia el campo de texto de la categoría
            txtCategoria.Clear();
        }

        // Evento que se ejecuta al hacer clic en la imagen 'EditarImg'
        private void EditarImg_Click(object sender, EventArgs e)
        {
            // Simula un clic en el botón 'btnEditar'
            btnEditar.PerformClick();
        }

        // Evento que se ejecuta al hacer clic en la imagen 'EliminarImg'
        private void EliminarImg_Click(object sender, EventArgs e)
        {
            // Simula un clic en el botón 'btnEliminar'
            btnEliminar.PerformClick();
        }

        // Evento que se ejecuta al hacer clic en la imagen 'GuardarImg'
        private void GuardarImg_Click(object sender, EventArgs e)
        {
            // Simula un clic en el botón 'btnGuardar'
            btnGuardar.PerformClick();
        }

        // Evento que se ejecuta al hacer clic en una celda del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Muestra los botones de editar y eliminar
            MostrarBotones();
            // Verifica que se haya hecho clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtiene el ID de la categoría seleccionada desde la primera celda de la fila
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                // Asigna el nombre de la categoría al campo de texto
                txtCategoria.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                // Asigna el ID de la categoría seleccionada a la variable 'selectedClientId'
                selectedClientId = idCliente;
            }
        }

        // Evento que se ejecuta al hacer clic en el botón 'btnGuardar'
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verifica si los campos son válidos
            if (Check())
            {
                // Ejecuta el procedimiento almacenado para insertar la nueva categoría
                cnn.Modificaciones("exec sp_InsertarCategoria '" + txtCategoria.Text + "'");
                // Recarga los datos en el DataGridView
                CargarDatos();
                // Oculta los botones de editar y eliminar
                OcultarBotones();
                // Limpia los campos del formulario
                Clear();
            }
        }

        // Método para ocultar los botones e imágenes de edición y eliminación
        private void OcultarBotones()
        {
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            ImgEliminar.Visible = false;
            ImgEditar.Visible = false;
        }

        // Método para mostrar los botones e imágenes de edición y eliminación
        private void MostrarBotones()
        {
            ImgEditar.Visible = true;
            ImgEliminar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }

        // Evento que se ejecuta al hacer clic en el botón 'btnEliminar'
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una categoría
            if (selectedClientId > 0)
            {
                // Ejecuta el procedimiento almacenado para eliminar la categoría seleccionada
                bool resultado = cnn.Modificaciones("exec sp_EliminarCategoria '" + selectedClientId + "'"); // Asumiendo que la clase 'Conexion' tiene este método para ejecutar comandos

                // Verifica si la eliminación fue exitosa
                if (resultado)
                {
                    // Muestra un mensaje de confirmación
                    MessageBox.Show("Categoria eliminada exitosamente.");
                    // Recarga los datos
                    CargarDatos();
                    // Oculta los botones
                    OcultarBotones();
                    // Limpia los campos
                    Clear();
                }
                else
                {
                    // Muestra un mensaje de error
                    MessageBox.Show("Hubo un error al eliminar la Categoria.");
                }
            }
            else
            {
                // Muestra un mensaje si no se ha seleccionado ninguna categoría
                MessageBox.Show("Por favor, selecciona una Categoria para eliminar.");
            }
        }

        // Evento que se ejecuta al hacer clic en el botón 'btnEditar'
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica si los campos son válidos
            if (Check())
            {
                // Verifica si hay una categoría seleccionada
                if (selectedClientId > 0)
                {
                    // Ejecuta el procedimiento almacenado para actualizar la categoría
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarCategoria '" + selectedClientId + "','" + txtCategoria.Text + "'");

                    // Verifica si la actualización fue exitosa
                    if (resultado)
                    {
                        // Muestra un mensaje de confirmación
                        MessageBox.Show("Categoria editado exitosamente.");
                        // Recarga los datos
                        CargarDatos();
                        // Oculta los botones
                        OcultarBotones();
                        // Limpia los campos
                        Clear();
                    }
                    else
                    {
                        // Muestra un mensaje de error
                        MessageBox.Show("Hubo un error al editar el Categoria.");
                    }
                }
                else
                {
                    // Muestra un mensaje si no se ha seleccionado ninguna categoría
                    MessageBox.Show("Por favor, selecciona un Categoria para editar.");
                }
            }
        }

        // Evento que se ejecuta cuando se cambia el texto en el TextBox1 (buscador)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Obtiene el texto ingresado y elimina espacios en blanco al inicio y al final
            string busqueda = textBox1.Text.Trim();

            // Verifica si el texto de búsqueda está vacío
            if (string.IsNullOrEmpty(busqueda))
            {
                // Si está vacío, carga todos los datos
                CargarDatos();
            }
            else
            {
                // Si hay texto, construye el comando de búsqueda usando un procedimiento almacenado
                string comando = "exec sp_ConsultarCategorias @nombre = '" + busqueda + "'";
                // Ejecuta la búsqueda y muestra los resultados en el DataGridView
                cnn.Busquedas(comando, dataGridView1, "");
            }
        }
    }
}

