using System;                      // Importa el espacio de nombres básico del sistema
using System.Collections.Generic;  // Importa colecciones genéricas (no usado explícito aquí)
using System.ComponentModel;       // Importa para componentes (no usado explícito aquí)
using System.Data;                 // Importa para manejo de datos
using System.Drawing;              // Importa para gráficos (no usado explícito aquí)
using System.Linq;                 // Importa para LINQ (no usado explícito aquí)
using System.Text;                 // Importa para manejo de texto (no usado explícito aquí)
using System.Threading.Tasks;     // Importa para tareas asíncronas (no usado explícito aquí)
using System.Windows.Forms;       // Importa para Windows Forms

namespace Mercadito_Chavez_Sanabria  // Define el namespace del proyecto
{
    public partial class Empresas : Form  // Define la clase parcial Empresas que hereda de Form
    {
        Conexion cnn = new Conexion();  // Instancia objeto para conexión a base de datos
        int selectedClientId = 0;       // Variable para almacenar ID del cliente seleccionado

        public Empresas()  // Constructor de la clase Empresas
        {
            InitializeComponent();  // Inicializa componentes del formulario
        }

        private void Empresas_Load(object sender, EventArgs e)  // Evento load del formulario Empresas
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Ajusta columnas para llenar el ancho del grid
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;       // Define el estilo de borde de las celdas
            CargarDatos();  // Llama método para cargar datos en el DataGridView
        }

        private void btnRegresar_Click(object sender, EventArgs e)  // Evento click del botón regresar
        {
            this.Close();  // Cierra el formulario actual
            Form n = new MENU();  // Crea una instancia del formulario MENU
            n.Show();  // Muestra el formulario MENU
        }

        private void label6_Click(object sender, EventArgs e)  // Evento click del label6 (vacío)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)  // Evento cambio texto en textBox5 (vacío)
        {

        }

        // Espacio en blanco para posibles métodos o eventos

        private void CargarDatos()  // Método para cargar datos en el DataGridView
        {
            cnn.ConsultasGrid("exec sp_ConsultarEmpresas '" + "" + "'", dataGridView1);  // Ejecuta procedimiento almacenado para consultar empresas sin filtro y llena el grid
        }

        private bool Check()  // Método para validar campos del formulario
        {
            if (
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||  // Valida que txtCorreo no esté vacío o solo espacios
                string.IsNullOrWhiteSpace(txtName.Text) ||    // Valida que txtName no esté vacío o solo espacios
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||// Valida que txtTelefono no esté vacío o solo espacios
                string.IsNullOrWhiteSpace(txtDireccion.Text)  // Valida que txtDireccion no esté vacío o solo espacios
                )
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Muestra advertencia si hay campo vacío
                return false;  // Retorna falso porque no pasó validación
            }
            if (!int.TryParse(txtTelefono.Text, out _))  // Valida que txtTelefono sea un número entero válido
            {
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Muestra mensaje si teléfono no es número
                return false;  // Retorna falso porque no pasó validación
            }

            return true;  // Retorna verdadero si todos los campos son válidos
        }

        private void Clear()  // Método para limpiar campos del formulario
        {
            txtCorreo.Clear();    // Limpia txtCorreo
            txtName.Clear();      // Limpia txtName
            txtTelefono.Clear();  // Limpia txtTelefono
            txtDireccion.Clear(); // Limpia txtDireccion
        }

        private void EditarImg_Click(object sender, EventArgs e)  // Evento click en imagen editar
        {
            btnEditar.PerformClick();  // Ejecuta el click del botón editar
        }

        private void EliminarImg_Click(object sender, EventArgs e)  // Evento click en imagen eliminar
        {
            btnEliminar.PerformClick();  // Ejecuta el click del botón eliminar
        }

        private void GuardarImg_Click(object sender, EventArgs e)  // Evento click en imagen guardar
        {
            btnGuardar.PerformClick();  // Ejecuta el click del botón guardar
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  // Evento click en celda del DataGridView
        {
            MostrarBotones();  // Muestra botones de editar y eliminar
            if (e.RowIndex >= 0)  // Verifica que la fila seleccionada sea válida (no encabezado)
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);  // Obtiene ID de la fila seleccionada
                txtName.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);  // Llena txtName con valor de la fila
                txtTelefono.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);  // Llena txtTelefono
                txtCorreo.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);  // Llena txtCorreo
                txtDireccion.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);  // Llena txtDireccion

                selectedClientId = idCliente;  // Guarda ID seleccionado
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)  // Evento click en botón guardar
        {
            if (Check())  // Valida campos antes de insertar
            {
                cnn.Modificaciones("exec sp_InsertarEmpresa '" + txtName.Text + "', '" + txtTelefono.Text + "',' " + txtCorreo.Text + "', '" + txtDireccion.Text + "'");  // Inserta empresa en base de datos

                CargarDatos();  // Recarga datos en el grid
                OcultarBotones();  // Oculta botones editar y eliminar
                Clear();  // Limpia campos del formulario
            }

        }

        private void OcultarBotones()  // Método para ocultar botones y sus imágenes
        {
            btnEditar.Visible = false;  // Oculta botón editar
            btnEliminar.Visible = false;  // Oculta botón eliminar
            ImgEditar.Visible = false;  // Oculta imagen editar
            ImgEliminar.Visible = false;  // Oculta imagen eliminar
        }

        private void MostrarBotones()  // Método para mostrar botones y sus imágenes
        {
            ImgEditar.Visible = true;  // Muestra imagen editar
            ImgEliminar.Visible = true;  // Muestra imagen eliminar
            btnEditar.Visible = true;  // Muestra botón editar
            btnEliminar.Visible = true;  // Muestra botón eliminar
        }

        private void btnEliminar_Click(object sender, EventArgs e)  // Evento click en botón eliminar
        {
            if (selectedClientId > 0)  // Verifica que se haya seleccionado un ID válido
            {

                bool resultado = cnn.Modificaciones("exec sp_EliminarEmpresa '" + selectedClientId + "'");  // Ejecuta procedimiento para eliminar empresa

                if (resultado)  // Si eliminación exitosa
                {
                    MessageBox.Show("Producto eliminado exitosamente.");  // Mensaje éxito (nota: dice Producto, no Empresa)
                    CargarDatos();  // Recarga datos en grid
                    OcultarBotones();  // Oculta botones
                    Clear();  // Limpia campos
                }
                else  // Si error al eliminar
                {
                    MessageBox.Show("Hubo un error al eliminar el Producto.");  // Mensaje error (nota: dice Producto)
                }
            }
            else  // Si no hay selección válida
            {
                MessageBox.Show("Por favor, selecciona un Producto para eliminar.");  // Mensaje solicitando selección (nota: dice Producto)
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)  // Evento click en botón editar
        {
            if (Check())  // Valida campos antes de editar
            {

                if (selectedClientId > 0)  // Verifica que se haya seleccionado un ID válido
                {

                    bool resultado = cnn.Modificaciones("exec sp_ActualizarEmpresa '" + selectedClientId + "','" + txtName.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "', '" + txtDireccion.Text + "'");  // Ejecuta procedimiento para actualizar empresa

                    if (resultado)  // Si actualización exitosa
                    {
                        MessageBox.Show("Producto editado exitosamente.");  // Mensaje éxito (nota: dice Producto)
                        CargarDatos();  // Recarga datos en grid
                        OcultarBotones();  // Oculta botones
                        Clear();  // Limpia campos
                    }
                    else  // Si error al actualizar
                    {
                        MessageBox.Show("Hubo un error al editar el Producto.");  // Mensaje error (nota: dice Producto)
                    }
                }
                else  // Si no hay selección válida
                {
                    MessageBox.Show("Por favor, selecciona un Producto para editar.");  // Mensaje solicitando selección (nota: dice Producto)
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)  // Evento cambio texto en caja de búsqueda
        {
            string busqueda = textBox1.Text.Trim();  // Obtiene texto de búsqueda y elimina espacios

            if (string.IsNullOrEmpty(busqueda))  // Si texto de búsqueda está vacío
            {
                CargarDatos();  // Carga todos los datos sin filtro
            }
            else  // Si hay texto para buscar
            {
                string comando = "exec sp_ConsultarEmpresas @nombre = '" + busqueda + "'";  // Comando para procedimiento almacenado con filtro por nombre
                cnn.Busquedas(comando, dataGridView1, "");  // Ejecuta búsqueda y llena el DataGridView
            }
        }
    }
}
