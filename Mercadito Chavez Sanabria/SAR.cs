using System; // Importa funcionalidades básicas de .NET
using System.Collections.Generic; // Importa colecciones genéricas (no usadas explícitamente)
using System.ComponentModel; // Importa funcionalidades para componentes (no usadas explícitamente)
using System.Data; // Importa funcionalidades para datos (no usadas explícitamente)
using System.Drawing; // Importa funcionalidades gráficas (no usadas explícitamente)
using System.Linq; // Importa funcionalidades LINQ (no usadas aquí)
using System.Text; // Importa funcionalidades para manipulación de texto (no usadas)
using System.Threading.Tasks; // Importa tareas asincrónicas (no usadas)
using System.Windows.Forms; // Importa funcionalidades para formularios Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el namespace del proyecto
{
    public partial class SAR : Form // Define la clase SAR que hereda de Form (ventana)
    {
        public SAR() // Constructor de la clase SAR
        {
            InitializeComponent(); // Inicializa los componentes visuales generados por el diseñador
        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento para botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea una instancia del formulario MENU
            n.Show(); // Muestra el formulario MENU
        }

        private void Empleados_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar el formulario
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta las columnas para que llenen el espacio
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Establece el borde de las celdas como línea simple
            CargarDatos(); // Llama al método que carga los datos en el grid
        }

        Conexion cnn = new Conexion(); // Instancia de la clase Conexion para consultas a base de datos
        int selectedClientId = 0; // Variable para almacenar el ID del registro seleccionado
        string cai = ""; // Variable para almacenar el CAI (no usada directamente)
        string rangoinicio = ""; // Variable para almacenar rango inicio (no usada directamente)
        string rangofin = ""; // Variable para almacenar rango fin (no usada directamente)

        private void CargarDatos() // Método para cargar datos en el DataGridView
        {
            cnn.ConsultasGrid("exec sp_ConsultarSar", dataGridView1); // Ejecuta el stored procedure y llena el grid
        }

        private bool Check() // Método para validar los campos antes de guardar o editar
        {
            if (string.IsNullOrWhiteSpace(txtCai.Text) || // Verifica si txtCai está vacío o sólo espacios
                string.IsNullOrWhiteSpace(txtRangoFin.Text) || // Verifica si txtRangoFin está vacío o sólo espacios
                string.IsNullOrWhiteSpace(txtRangoInicio.Text)) // Verifica si txtRangoInicio está vacío o sólo espacios
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje de error
                return false; // Retorna falso, no pasa validación
            }

            if (!int.TryParse(txtRangoInicio.Text, out _)) // Valida que txtRangoInicio sea un número entero válido
            {
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje de error (el mensaje dice Telefono pero es txtRangoInicio)
                return false; // Retorna falso, no pasa validación
            }

            return true; // Si pasa todas las validaciones, retorna verdadero
        }

        private void Clear() // Método para limpiar los campos del formulario
        {
            txtRangoFin.Clear(); // Limpia txtRangoFin
            txtCai.Clear(); // Limpia txtCai
            txtRangoInicio.Clear(); // Limpia txtRangoInicio
        }

        private void EditarImg_Click(object sender, EventArgs e) // Evento para imagen o botón de editar
        {
            btnEditar.PerformClick(); // Simula el clic en el botón Editar
        }

        private void GuardarImg_Click(object sender, EventArgs e) // Evento para imagen o botón de guardar
        {
            btnGuardar.PerformClick(); // Simula el clic en el botón Guardar
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Evento que se dispara al hacer clic en una celda del DataGridView
        {
            MostrarBotones(); // Muestra los botones de edición y eliminación
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada sea válida
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); // Obtiene el ID del registro de la primera celda
                txtCai.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value); // Muestra el CAI en el textbox correspondiente
                txtRangoInicio.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value); // Muestra el rango inicio en el textbox
                txtRangoFin.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value); // Muestra el rango fin en el textbox
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value); // Asigna la fecha al DateTimePicker desde la celda 5

                selectedClientId = idCliente; // Guarda el ID seleccionado en la variable global
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Evento clic en el botón Guardar
        {
            if (Check()) // Valida que los campos estén correctos
            {
                DateTime fechaLimite = dateTimePicker1.Value; // Obtiene el valor de la fecha desde el DateTimePicker
                // Ejecuta el stored procedure para insertar un nuevo registro SAR con los datos del formulario
                cnn.Modificaciones("exec sp_InsertarSar '" + txtCai.Text + "','" + txtRangoInicio.Text + "','" + txtRangoFin.Text + "','" + fechaLimite.ToString("yyyy-MM-dd") + "'");

                CargarDatos(); // Recarga los datos en el grid para actualizar la vista
                OcultarBotones(); // Oculta los botones de edición/eliminación
                Clear(); // Limpia los campos del formulario
            }
        }

        private void OcultarBotones() // Método para ocultar botones de edición y eliminación
        {
            btnEditar.Visible = false; // Oculta el botón Editar
            pictureBox1.Visible = false; // Oculta la imagen o botón asociado (posiblemente eliminación)
        }

        private void MostrarBotones() // Método para mostrar botones de edición y eliminación
        {
            pictureBox1.Visible = true; // Muestra la imagen o botón asociado
            btnEditar.Visible = true; // Muestra el botón Editar
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Evento clic en el botón Eliminar
        {
            if (selectedClientId > 0) // Verifica que haya un registro seleccionado
            {
                // Ejecuta el stored procedure para eliminar el registro seleccionado
                bool resultado = cnn.Modificaciones("exec sp_EliminarSar '" + selectedClientId + "'");

                if (resultado) // Si la eliminación fue exitosa
                {
                    MessageBox.Show("Registro SAR eliminado exitosamente."); // Muestra mensaje de éxito
                    CargarDatos(); // Recarga los datos en el grid
                    OcultarBotones(); // Oculta los botones
                    Clear(); // Limpia los campos
                }
                else // Si hubo error en la eliminación
                {
                    MessageBox.Show("Hubo un error al eliminar el Registro SAR."); // Muestra mensaje de error
                }
            }
            else // Si no hay ningún registro seleccionado
            {
                MessageBox.Show("Por favor, selecciona un Registro SAR para eliminar."); // Pide que seleccione un registro
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) // Evento clic en el botón Editar
        {
            if (Check()) // Valida los campos
            {
                if (selectedClientId > 0) // Verifica que haya un registro seleccionado
                {
                    DateTime fechaLimite = dateTimePicker1.Value; // Obtiene la fecha seleccionada
                    // Ejecuta el stored procedure para actualizar el registro seleccionado con los nuevos datos
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarSar '" + selectedClientId + "','" + txtCai.Text + "','" + txtRangoInicio.Text + "','" + txtRangoFin.Text + "','" + fechaLimite.ToString("yyyy-MM-dd") + "'");

                    if (resultado) // Si la actualización fue exitosa
                    {
                        MessageBox.Show("Registro SAR editado exitosamente."); // Mensaje de éxito
                        CargarDatos(); // Recarga datos en el grid
                        OcultarBotones(); // Oculta botones
                        Clear(); // Limpia campos
                    }
                    else // Si hubo error al editar
                    {
                        MessageBox.Show("Hubo un error al editar el Registro SAR."); // Muestra mensaje de error
                    }
                }
                else // Si no hay registro seleccionado
                {
                    MessageBox.Show("Por favor, selecciona un Registro SAR para editar."); // Pide seleccionar un registro
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) // Evento clic en un label (vacío, no implementado)
        {

        }
    }
}
