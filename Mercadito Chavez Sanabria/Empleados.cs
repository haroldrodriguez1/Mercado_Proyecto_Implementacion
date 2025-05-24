using System;                      // Importa el espacio de nombres para funcionalidades básicas del sistema
using System.Collections.Generic;  // Importa para trabajar con colecciones genéricas (no usado explícitamente aquí)
using System.ComponentModel;       // Importa para componentes (no usado explícitamente aquí)
using System.Data;                 // Importa para manejo de datos
using System.Drawing;              // Importa para manipulación de gráficos y dibujos (no usado explícitamente aquí)
using System.Linq;                 // Importa para consultas LINQ (no usado explícitamente aquí)
using System.Text;                 // Importa para manipulación de texto (no usado explícitamente aquí)
using System.Threading.Tasks;     // Importa para tareas asíncronas (no usado explícitamente aquí)
using System.Windows.Forms;       // Importa para crear aplicaciones de Windows Forms

namespace Mercadito_Chavez_Sanabria  // Declara el espacio de nombres del proyecto
{
    public partial class Empleados : Form  // Define la clase parcial 'Empleados' que hereda de 'Form'
    {
        public Empleados()  // Constructor de la clase Empleados
        {
            InitializeComponent();  // Inicializa los componentes del formulario (auto generado)
        }

        private void btnRegresar_Click(object sender, EventArgs e)  // Evento click para el botón "Regresar"
        {
            this.Close();  // Cierra el formulario actual
            Form n = new MENU();  // Crea una nueva instancia del formulario MENU
            n.Show();  // Muestra el formulario MENU
        }
        private void Empleados_Load(object sender, EventArgs e)  // Evento load del formulario Empleados
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Ajusta columnas para que llenen el ancho del DataGridView
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;  // Establece el estilo de borde de las celdas
            CargarDatos();  // Llama al método para cargar los datos en el DataGridView
        }


        Conexion cnn = new Conexion();  // Crea una instancia de la clase Conexion para operaciones en base de datos
        int selectedClientId = 0;  // Variable para almacenar el ID del empleado seleccionado
        string name = "";  // Variable para almacenar nombre (no usada explícitamente)
        string correo = "";  // Variable para almacenar correo (no usada explícitamente)
        string telefono = "";  // Variable para almacenar teléfono (no usada explícitamente)
        string estadotxt;  // Variable para almacenar estado como texto (no usada explícitamente)

        private void CargarDatos()  // Método para cargar datos en el DataGridView
        {
            cnn.ConsultasGrid("exec sp_ConsultarEmpleados '" + "" + "'", dataGridView1);  // Ejecuta el procedimiento almacenado para consultar empleados sin filtro y llena el DataGridView
        }
        private bool Check()  // Método que valida los campos del formulario antes de guardar o editar
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||  // Valida que el campo Nombre no esté vacío o sólo espacios
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||  // Valida que el campo Correo no esté vacío o sólo espacios
                string.IsNullOrWhiteSpace(txtTelefono.Text))  // Valida que el campo Teléfono no esté vacío o sólo espacios
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Muestra mensaje de error si algún campo está vacío
                return false;  // Retorna falso indicando que la validación falló
            }

            if (!int.TryParse(txtTelefono.Text, out _))  // Valida que el teléfono sea un número entero válido
            {
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Muestra advertencia si no es un número
                return false;  // Retorna falso indicando fallo en validación
            }

            return true;  // Retorna verdadero si todas las validaciones pasan
        }
        private void Clear()  // Método para limpiar los campos de texto del formulario
        {
            txtCorreo.Clear();  // Limpia el campo correo
            txtNombre.Clear();  // Limpia el campo nombre
            txtTelefono.Clear();  // Limpia el campo teléfono
        }
        private void EditarImg_Click(object sender, EventArgs e)  // Evento click para la imagen que representa "Editar"
        {
            btnEditar.PerformClick();  // Ejecuta el evento click del botón Editar programáticamente
        }

        private void EliminarImg_Click(object sender, EventArgs e)  // Evento click para la imagen que representa "Eliminar"
        {
            btnEliminar.PerformClick();  // Ejecuta el evento click del botón Eliminar programáticamente
        }

        private void GuardarImg_Click(object sender, EventArgs e)  // Evento click para la imagen que representa "Guardar"
        {
            btnGuardar.PerformClick();  // Ejecuta el evento click del botón Guardar programáticamente
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  // Evento click en una celda del DataGridView
        {
            MostrarBotones();  // Muestra los botones de editar y eliminar
            if (e.RowIndex >= 0)  // Verifica que la fila seleccionada sea válida (no encabezado)
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);  // Obtiene el ID del empleado de la fila seleccionada
                txtNombre.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);  // Llena el campo nombre con el valor de la fila
                txtTelefono.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);  // Llena el campo teléfono
                txtCorreo.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);  // Llena el campo correo
                selectedClientId = idCliente;  // Guarda el ID del empleado seleccionado

            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)  // Evento click para el botón Guardar
        {
            if (Check())  // Valida los campos antes de insertar
            {
                int estado = 1;  // Estado activo (probablemente 1 representa activo)

                // Ejecuta procedimiento almacenado para insertar empleado con los valores de los campos
                cnn.Modificaciones("exec sp_InsertarEmpleado '" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "','" + estado + "'");
                CargarDatos();  // Recarga el DataGridView con los datos actualizados
                OcultarBotones();  // Oculta los botones de editar y eliminar
                Clear();  // Limpia los campos del formulario
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)  // Evento vacío (sin implementación)
        {

        }
        private void OcultarBotones()  // Método para ocultar botones y sus imágenes asociadas
        {
            btnEditar.Visible = false;  // Oculta botón editar
            btnEliminar.Visible = false;  // Oculta botón eliminar
            pictureBox1.Visible = false;  // Oculta imagen (probablemente ícono editar)
            pictureBox3.Visible = false;  // Oculta imagen (probablemente ícono eliminar)
        }
        private void MostrarBotones()  // Método para mostrar botones y sus imágenes asociadas
        {
            pictureBox1.Visible = true;  // Muestra imagen editar
            pictureBox3.Visible = true;  // Muestra imagen eliminar
            btnEditar.Visible = true;  // Muestra botón editar
            btnEliminar.Visible = true;  // Muestra botón eliminar
        }
        private void btnEliminar_Click(object sender, EventArgs e)  // Evento click para botón eliminar
        {
            if (selectedClientId > 0)  // Verifica que se haya seleccionado un empleado válido
            {

                // Ejecuta procedimiento almacenado para eliminar empleado por ID
                bool resultado = cnn.Modificaciones("exec sp_EliminarEmpleado '" + selectedClientId + "'");

                if (resultado)  // Si la eliminación fue exitosa
                {
                    MessageBox.Show("Empleado eliminado exitosamente.");  // Mensaje de éxito
                    CargarDatos();  // Recarga el DataGridView
                    OcultarBotones();  // Oculta botones
                    Clear();  // Limpia campos
                }
                else  // Si hubo error al eliminar
                {
                    MessageBox.Show("Hubo un error al eliminar el Empleado.");  // Mensaje de error
                }
            }
            else  // Si no hay empleado seleccionado
            {
                MessageBox.Show("Por favor, selecciona un Empleado para eliminar.");  // Mensaje solicitando selección
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)  // Evento click para botón editar
        {
            if (Check())  // Valida campos antes de editar
            {

                if (selectedClientId > 0)  // Verifica que haya empleado seleccionado
                {
                    int estado = 1;  // Estado activo

                    // Ejecuta procedimiento almacenado para actualizar empleado con los valores de los campos
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarEmpleado '" + selectedClientId + "','" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "','" + estado + "'");

                    if (resultado)  // Si actualización exitosa
                    {
                        MessageBox.Show("Empleado editado exitosamente.");  // Mensaje éxito
                        CargarDatos();  // Recarga datos
                        OcultarBotones();  // Oculta botones
                        Clear();  // Limpia campos
                    }
                    else  // Si error al actualizar
                    {
                        MessageBox.Show("Hubo un error al editar el empleado.");  // Mensaje error
                    }
                }
                else  // Si no hay empleado seleccionado
                {
                    MessageBox.Show("Por favor, selecciona un empleado para editar.");  // Mensaje solicitando selección
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)  // Evento cambio de texto en el textbox para búsqueda
        {
            string busqueda = textBox1.Text.Trim();  // Obtiene texto ingresado y elimina espacios al inicio y final

            if (string.IsNullOrEmpty(busqueda))  // Si la búsqueda está vacía
            {
                CargarDatos();  // Carga todos los empleados sin filtro
            }
            else  // Si hay texto para buscar
            {
                // Crea el comando para ejecutar el procedimiento almacenado con filtro por nombre
                string comando = "exec sp_ConsultarEmpleados @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, "");  // Ejecuta búsqueda y muestra resultados en DataGridView
            }
        }
    }
}
