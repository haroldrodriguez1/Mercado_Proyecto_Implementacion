using System; // Importa el espacio de nombres System que contiene clases básicas.
using System.Collections.Generic; // Importa colecciones genéricas.
using System.ComponentModel; // Importa componentes y controles.
using System.Data; // Importa clases para manejo de datos.
using System.Drawing; // Importa clases para gráficos.
using System.Linq; // Importa LINQ para consultas.
using System.Text; // Importa clases para manejo de texto.
using System.Threading.Tasks; // Importa tareas asincrónicas.
using System.Windows.Forms; // Importa clases para formularios Windows.
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button; // Importa elementos visuales específicos para botones.

namespace Mercadito_Chavez_Sanabria // Define el espacio de nombres del proyecto.
{
    public partial class Productos : Form // Define la clase Productos que hereda de Form.
    {
        Conexion cnn = new Conexion(); // Crea una instancia de la clase Conexion para operaciones con la base de datos.
        int selectedClientId = 0; // Variable para almacenar el ID del cliente/producto seleccionado.
        string name = ""; // Variable para almacenar nombre (no usada en el código visible).
        string correo = ""; // Variable para almacenar correo (no usada en el código visible).
        string telefono = ""; // Variable para almacenar teléfono (no usada en el código visible).
        string estadotxt; // Variable para almacenar estado (no usada en el código visible).

        public Productos() // Constructor de la clase Productos.
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        private void Productos_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar el formulario.
        {
            CargarDatos(); // Llama al método para cargar los datos en el DataGridView.
            DataSet ds = cnn.Consultas("exec sp_ConsultarCategorias '" + "" + "'"); // Ejecuta procedimiento almacenado para obtener categorías.

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)  // Verifica que haya tablas y filas en el DataSet.
            {
                cmbCategoria.DisplayMember = "Nombre Categoria";  // Establece el nombre de la columna para mostrar en el ComboBox.
                cmbCategoria.ValueMember = "ID Categoria"; // Establece el nombre de la columna que será el valor del ComboBox.
                cmbCategoria.DataSource = ds.Tables[0]; // Asigna la tabla al ComboBox como fuente de datos.
            }
            else
            {
                MessageBox.Show("No se encontraron categorías."); // Muestra mensaje si no hay categorías.
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento click para regresar al menú principal.
        {
            this.Close(); // Cierra el formulario actual.
            Form n = new MENU(); // Crea una instancia del formulario MENU.
            n.Show(); // Muestra el formulario MENU.
        }



        private void CargarDatos() // Método para cargar los datos en el DataGridView.
        {
            cnn.ConsultasGrid("exec sp_ConsultarProductos '" + "" + "'", dataGridView1); // Ejecuta procedimiento para llenar el DataGridView con productos.
        }

        private bool Check() // Método que valida los campos obligatorios antes de guardar o editar.
        {
            if (NumberCantidad.Value <= 0 ||  // Valida que la cantidad sea mayor a 0.
                NumberPrecioFinal.Value <= 0 || // Valida que el precio final sea mayor a 0.
                NumberPreCost.Value <= 0 || // Valida que el precio de costo sea mayor a 0.
                string.IsNullOrWhiteSpace(txtInfoPro.Text) || // Valida que el campo de información no esté vacío.
                string.IsNullOrWhiteSpace(txtProducto.Text) || // Valida que el campo producto no esté vacío.
                cmbCategoria.SelectedIndex == -1 // Valida que se haya seleccionado una categoría.
                )
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia si falta algún campo.
                return false; // Retorna falso si alguna validación falla.
            }


            return true; // Retorna verdadero si todas las validaciones pasan.
        }

        private void Clear() // Método para limpiar todos los campos del formulario.
        {
            txtInfoPro.Clear(); // Limpia el campo de información.
            txtProducto.Clear(); // Limpia el campo producto.
            NumberPreCost.Value = 0; // Resetea el campo precio de costo a 0.
            NumberPrecioFinal.Value = 0; // Resetea el campo precio final a 0.
            NumberCantidad.Value = 0; // Resetea el campo cantidad a 0.
            cmbCategoria.Text = string.Empty; // Limpia la selección del ComboBox.
            textBox1.Clear(); // Limpia el campo de búsqueda.
        }

        private void EditarImg_Click(object sender, EventArgs e) // Evento click sobre la imagen para editar.
        {
            btnEditar.PerformClick(); // Simula el click del botón editar.
        }

        private void EliminarImg_Click(object sender, EventArgs e) // Evento click sobre la imagen para eliminar.
        {
            btnEliminar.PerformClick(); // Simula el click del botón eliminar.
        }

        private void GuardarImg_Click(object sender, EventArgs e) // Evento click sobre la imagen para guardar.
        {
            btnGuardar.PerformClick(); // Simula el click del botón guardar.
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Evento click en una celda del DataGridView.
        {
            MostrarBotones(); // Muestra los botones de editar y eliminar.
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada sea válida.
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); // Obtiene el ID del producto seleccionado.
                txtProducto.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value); // Llena el campo producto con el valor de la fila.
                txtInfoPro.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value); // Llena la información del producto.
                NumberPrecioFinal.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value); // Asigna el precio final.
                NumberPreCost.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value); // Asigna el precio de costo.
                NumberCantidad.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value); // Asigna la cantidad.
                int idCategoria = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);  // Obtiene el ID de la categoría.
                cmbCategoria.SelectedValue = idCategoria; // Selecciona la categoría correspondiente.

                selectedClientId = idCliente;  // Asigna el ID seleccionado a la variable global.

            }
        }


        private void btnGuardar_Click(object sender, EventArgs e) // Evento click para guardar un nuevo producto.
        {
            if (Check()) // Verifica que los campos sean válidos.
            {
                cnn.Modificaciones("exec sp_InsertarProducto '" + txtProducto.Text + "', '" + txtInfoPro.Text + "', " + NumberPrecioFinal.Value + ", " + NumberPreCost.Value + ", " + NumberCantidad.Value + ", " + cmbCategoria.SelectedValue + ""); // Ejecuta el procedimiento para insertar producto.

                CargarDatos(); // Recarga los datos en el DataGridView.
                OcultarBotones(); // Oculta los botones de editar y eliminar.
                Clear(); // Limpia los campos del formulario.
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e) // Evento vacio para CellContentClick con otro tipo de argumento.
        {

        }

        private void OcultarBotones() // Método para ocultar botones e imágenes de editar y eliminar.
        {
            btnEditar.Visible = false; // Oculta botón editar.
            btnEliminar.Visible = false; // Oculta botón eliminar.
            ImgEditar.Visible = false; // Oculta imagen editar.
            ImgEliminar.Visible = false; // Oculta imagen eliminar.
        }

        private void MostrarBotones() // Método para mostrar botones e imágenes de editar y eliminar.
        {
            ImgEditar.Visible = true; // Muestra imagen editar.
            ImgEliminar.Visible = true; // Muestra imagen eliminar.
            btnEditar.Visible = true; // Muestra botón editar.
            btnEliminar.Visible = true; // Muestra botón eliminar.
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Evento click para eliminar un producto.
        {
            if (selectedClientId > 0) // Verifica que un producto esté seleccionado.
            {

                bool resultado = cnn.Modificaciones("exec sp_EliminarProducto '" + selectedClientId + "'"); // Ejecuta procedimiento para eliminar producto.

                if (resultado) // Si la eliminación fue exitosa.
                {
                    MessageBox.Show("Producto eliminado exitosamente."); // Muestra mensaje de éxito.
                    CargarDatos(); // Recarga datos.
                    OcultarBotones(); // Oculta botones.
                    Clear(); // Limpia formulario.
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el Producto."); // Muestra mensaje de error.
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Producto para eliminar."); // Muestra mensaje si no hay producto seleccionado.
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) // Evento click para editar un producto.
        {
            if (Check()) // Valida campos antes de editar.
            {

                if (selectedClientId > 0) // Verifica que haya un producto seleccionado.
                {

                    bool resultado = cnn.Modificaciones("exec sp_ActualizarProducto '" + selectedClientId + "','" + txtProducto.Text + "','" + txtInfoPro.Text + "'," + NumberPrecioFinal.Value + "," + NumberPreCost.Value + "," + NumberCantidad.Value + ", " + cmbCategoria.SelectedValue + ""); // Ejecuta el procedimiento para actualizar producto.

                    if (resultado) // Si la actualización fue exitosa.
                    {
                        MessageBox.Show("Producto editado exitosamente."); // Muestra mensaje de éxito.
                        CargarDatos(); // Recarga datos.
                        OcultarBotones(); // Oculta botones.
                        Clear(); // Limpia formulario.
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el Producto."); // Muestra mensaje de error.
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un Producto para editar."); // Muestra mensaje si no hay producto seleccionado.
                }
            }


        }

        private void label2_Click(object sender, EventArgs e) // Evento click vacío para label2 (sin implementación).
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Evento que se ejecuta cuando cambia el texto del textbox de búsqueda.
        {
            string busqueda = textBox1.Text.Trim();  // Obtiene el texto ingresado y elimina espacios al inicio y final.

            if (string.IsNullOrEmpty(busqueda)) // Si el campo de búsqueda está vacío.
            {
                CargarDatos();  // Carga todos los datos.
            }
            else
            {
                string comando = "exec sp_ConsultarProductos @nombre = '" + busqueda + "'"; // Construye el comando para búsqueda filtrada.
                cnn.Busquedas(comando, dataGridView1, ""); // Ejecuta la búsqueda y llena el DataGridView.
            }
        }
    }
}
