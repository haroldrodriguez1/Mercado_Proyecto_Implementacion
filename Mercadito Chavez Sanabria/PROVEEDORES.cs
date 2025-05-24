using System; // Importa el espacio de nombres base para tipos y funcionalidades básicas de .NET
using System.Collections.Generic; // Importa colecciones genéricas (no usadas explícitamente aquí)
using System.ComponentModel; // Importa componentes para diseño y eventos
using System.Data; // Importa funcionalidades para manejo de datos
using System.Drawing; // Importa funcionalidades para gráficos y dibujo (no usadas explícitamente aquí)
using System.Linq; // Importa funcionalidades para consultas LINQ (no usadas aquí)
using System.Text; // Importa funcionalidades para manipulación de texto (no usadas aquí)
using System.Threading.Tasks; // Importa funcionalidades para tareas asincrónicas (no usadas aquí)
using System.Windows.Forms; // Importa funcionalidades para interfaces gráficas Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el espacio de nombres del proyecto
{
    public partial class Proveedores : Form // Define la clase Proveedores que hereda de Form (ventana)
    {
        Conexion cnn = new Conexion(); // Crea una instancia de la clase Conexion para manejar la BD
        int selectedClientId = 0; // Variable para almacenar el ID del proveedor seleccionado
        string name = ""; // Variable para almacenar nombre (no usada explícitamente en este código)
        string correo = ""; // Variable para almacenar correo (no usada explícitamente)
        string telefono = ""; // Variable para almacenar teléfono (no usada explícitamente)
        string estadotxt; // Variable para almacenar estado en texto (no usada explícitamente)

        public Proveedores() // Constructor de la clase
        {
            InitializeComponent(); // Inicializa los componentes visuales generados por el diseñador
        }

        private void PROVEEDORES_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar el formulario
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta las columnas para que llenen el ancho del DataGridView
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Define el estilo de borde de las celdas del DataGridView
            CargarDatos(); // Llama a la función para cargar los datos en el DataGridView
            DataSet ds = cnn.Consultas("exec sp_ConsultarEmpresas '" + "" + "'"); // Ejecuta el procedimiento almacenado para consultar empresas y guarda el resultado en un DataSet

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) // Verifica que existan tablas y filas en el resultado
            {
                cmbEmpresa.DisplayMember = "Nombre Empresa"; // Define el campo que se mostrará en el ComboBox
                cmbEmpresa.ValueMember = "ID Empresa"; // Define el campo que será el valor interno del ComboBox
                cmbEmpresa.DataSource = ds.Tables[0]; // Asigna la tabla con los datos al ComboBox
            }
            else
            {
                MessageBox.Show("No se encontraron categorías."); // Muestra mensaje si no hay datos
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento para el botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea una nueva instancia del formulario MENU
            n.Show(); // Muestra el formulario MENU
        }

        private void CargarDatos() // Método para cargar datos en el DataGridView
        {
            cnn.ConsultasGrid("exec sp_ConsultarProveedores '" + "" + "'", dataGridView1); // Ejecuta el procedimiento almacenado para obtener proveedores y llena el DataGridView
        }

        private bool Check() // Método para validar los campos antes de insertar o actualizar
        {
            if (
                string.IsNullOrWhiteSpace(txtCorreo.Text) || // Verifica que el campo correo no esté vacío o solo con espacios
                string.IsNullOrWhiteSpace(txtName.Text) || // Verifica que el campo nombre no esté vacío o solo con espacios
                string.IsNullOrWhiteSpace(txtTelefono.Text) || // Verifica que el campo teléfono no esté vacío o solo con espacios
                cmbEmpresa.SelectedIndex == -1 // Verifica que se haya seleccionado una empresa en el ComboBox
                )
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje de error si alguna validación falla
                return false; // Retorna falso si la validación falla
            }

            if (!int.TryParse(txtTelefono.Text, out _)) // Verifica que el teléfono sea un número válido
            {
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje si teléfono no es un número
                return false; // Retorna falso si la validación falla
            }

            return true; // Retorna verdadero si todas las validaciones pasan
        }

        private void Clear() // Método para limpiar los campos del formulario
        {
            txtCorreo.Clear(); // Limpia el campo correo
            txtName.Clear(); // Limpia el campo nombre
            txtTelefono.Clear(); // Limpia el campo teléfono
            cmbEmpresa.Text = string.Empty; // Limpia el texto del ComboBox empresa
        }

        private void EditarImg_Click(object sender, EventArgs e) // Evento para el clic en la imagen de editar
        {
            btnEditar.PerformClick(); // Simula el clic en el botón Editar
        }

        private void EliminarImg_Click(object sender, EventArgs e) // Evento para el clic en la imagen de eliminar
        {
            btnEliminar.PerformClick(); // Simula el clic en el botón Eliminar
        }

        private void GuardarImg_Click(object sender, EventArgs e) // Evento para el clic en la imagen de guardar
        {
            btnGuardar.PerformClick(); // Simula el clic en el botón Guardar
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Evento para cuando se hace clic en una celda del DataGridView
        {
            MostrarBotones(); // Muestra los botones de editar y eliminar
            if (e.RowIndex >= 0) // Verifica que el índice de fila sea válido
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); // Obtiene el ID del proveedor seleccionado
                txtName.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value); // Llena el campo nombre con el valor de la fila seleccionada
                txtTelefono.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value); // Llena el campo teléfono con el valor de la fila seleccionada
                txtCorreo.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value); // Llena el campo correo con el valor de la fila seleccionada
                int idEmpresa = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value); // Obtiene el ID de la empresa asociada
                cmbEmpresa.SelectedValue = idEmpresa; // Selecciona la empresa en el ComboBox
                selectedClientId = idCliente; // Guarda el ID seleccionado para operaciones posteriores
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Evento para el botón Guardar
        {
            if (Check()) // Valida los campos
            {
                cnn.Modificaciones("exec sp_InsertarProveedor '" + txtName.Text + "', '" + txtTelefono.Text + "',' " + txtCorreo.Text + "', " + cmbEmpresa.SelectedValue + "");
                // Ejecuta el procedimiento almacenado para insertar un nuevo proveedor con los datos ingresados

                CargarDatos(); // Recarga los datos en el DataGridView
                OcultarBotones(); // Oculta los botones de editar y eliminar
                Clear(); // Limpia los campos del formulario
            }
        }

        private void OcultarBotones() // Método para ocultar botones y sus imágenes
        {
            btnEditar.Visible = false; // Oculta el botón Editar
            btnEliminar.Visible = false; // Oculta el botón Eliminar
            ImgEditar.Visible = false; // Oculta la imagen de editar
            ImgEliminar.Visible = false; // Oculta la imagen de eliminar
        }

        private void MostrarBotones() // Método para mostrar botones y sus imágenes
        {
            ImgEditar.Visible = true; // Muestra la imagen de editar
            ImgEliminar.Visible = true; // Muestra la imagen de eliminar
            btnEditar.Visible = true; // Muestra el botón Editar
            btnEliminar.Visible = true; // Muestra el botón Eliminar
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Evento para el botón Eliminar
        {
            if (selectedClientId > 0) // Verifica que haya un proveedor seleccionado
            {
                bool resultado = cnn.Modificaciones("exec sp_EliminarProveedor '" + selectedClientId + "'");
                // Ejecuta el procedimiento almacenado para eliminar el proveedor seleccionado

                if (resultado) // Si la eliminación fue exitosa
                {
                    MessageBox.Show("Producto eliminado exitosamente."); // Muestra mensaje de éxito
                    CargarDatos(); // Recarga los datos en el DataGridView
                    OcultarBotones(); // Oculta los botones
                    Clear(); // Limpia los campos
                }
                else // Si hubo error en la eliminación
                {
                    MessageBox.Show("Hubo un error al eliminar el Producto."); // Muestra mensaje de error
                }
            }
            else // Si no hay proveedor seleccionado
            {
                MessageBox.Show("Por favor, selecciona un Producto para eliminar."); // Indica que se debe seleccionar un producto
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) // Evento para el botón Editar
        {
            if (Check()) // Valida los campos
            {
                if (selectedClientId > 0) // Verifica que haya un proveedor seleccionado
                {
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarProveedor '" + selectedClientId + "','" + txtName.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "', " + cmbEmpresa.SelectedValue + "");
                    // Ejecuta el procedimiento almacenado para actualizar los datos del proveedor seleccionado

                    if (resultado) // Si la actualización fue exitosa
                    {
                        MessageBox.Show("Producto editado exitosamente."); // Muestra mensaje de éxito
                        CargarDatos(); // Recarga los datos
                        OcultarBotones(); // Oculta los botones
                        Clear(); // Limpia los campos
                    }
                    else // Si hubo error en la actualización
                    {
                        MessageBox.Show("Hubo un error al editar el Producto."); // Muestra mensaje de error
                    }
                }
                else // Si no hay proveedor seleccionado
                {
                    MessageBox.Show("Por favor, selecciona un Producto para editar."); // Indica que se debe seleccionar un producto
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Evento que se ejecuta al cambiar texto en textBox1 (búsqueda)
        {
            string busqueda = textBox1.Text.Trim(); // Obtiene el texto ingresado y elimina espacios al inicio y final

            if (string.IsNullOrEmpty(busqueda)) // Si el texto está vacío
            {
                CargarDatos(); // Carga todos los datos sin filtro
            }
            else // Si hay texto en búsqueda
            {
                string comando = "exec sp_ConsultarProveedores @nombre = '" + busqueda + "'"; // Construye el comando para búsqueda filtrada
                cnn.Busquedas(comando, dataGridView1, ""); // Ejecuta la búsqueda y muestra resultados en el DataGridView
            }
        }
    }
}
