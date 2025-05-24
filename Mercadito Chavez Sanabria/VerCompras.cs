using System; // Importa funcionalidades básicas del sistema
using System.Collections.Generic; // Importa colecciones genéricas
using System.ComponentModel; // Importa componentes para diseño y eventos
using System.Data; // Importa funcionalidades para trabajar con datos
using System.Data.SqlClient; // Importa clases para trabajar con SQL Server
using System.Drawing; // Importa clases para trabajar con gráficos
using System.Linq; // Importa LINQ para consultas en colecciones
using System.Text; // Importa clases para manipulación de texto
using System.Threading.Tasks; // Importa clases para tareas asíncronas
using System.Windows.Forms; // Importa clases para formularios de Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el espacio de nombres del proyecto
{
    public partial class VerCompras : Form // Define la clase parcial VerCompras que hereda de Form (ventana)
    {
        public VerCompras() // Constructor de la clase VerCompras
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario
        }

        Conexion cnn = new Conexion(); // Crea una instancia de la clase Conexion para manejo de BD
        ToolStripMenuItem cambiarEstadoItem; // Declara un item para el menú contextual que cambiará estado
        ToolStripMenuItem ImprimirCompraItem; // Declara un item para el menú contextual para imprimir compra

        private void btnRegresar_Click(object sender, EventArgs e) // Evento click botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form menu = new MENU(); // Crea una nueva instancia del formulario MENU
            menu.Show(); // Muestra el formulario MENU
        }

        private void VerCompras_Load(object sender, EventArgs e) // Evento Load del formulario VerCompras
        {
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            // Establece que la selección en dgvDestino será por fila (clic en el encabezado)

            ContextMenuStrip menu = new ContextMenuStrip(); // Crea un menú contextual nuevo
            cambiarEstadoItem = new ToolStripMenuItem(); // Inicializa el item para cambiar estado
            ImprimirCompraItem = new ToolStripMenuItem(); // Inicializa el item para imprimir compra
            cambiarEstadoItem.Click += CambiarEstadoCompra;
            // Asocia el evento Click del item cambiarEstadoItem al método CambiarEstadoCompra
            ImprimirCompraItem.Text = "Imprimir"; // Establece el texto del item ImprimirCompraItem
            ImprimirCompraItem.Click += AbrirReporteImprimir;
            // Asocia el evento Click del item ImprimirCompraItem al método AbrirReporteImprimir
            menu.Items.Add(cambiarEstadoItem); // Añade cambiarEstadoItem al menú contextual
            menu.Items.Add(ImprimirCompraItem); // Añade ImprimirCompraItem al menú contextual
            dgvOrigen.ContextMenuStrip = menu; // Asigna el menú contextual al DataGridView dgvOrigen
        }

        private void AbrirReporteImprimir(object sender, EventArgs e) // Método para abrir el reporte e imprimir
        {
            int idCompra = 0; // Inicializa variable para almacenar el id de compra seleccionado
            if (dgvOrigen.SelectedRows.Count > 0) // Si hay alguna fila seleccionada en dgvOrigen
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0];
                // Obtiene la primera fila seleccionada
                idCompra = Convert.ToInt32(filaSeleccionada.Cells["IDCompra"].Value);
                // Extrae el valor de la columna IDCompra y lo convierte a entero
            }
            Form n = new ImprimirCompra(idCompra); // Crea instancia del formulario ImprimirCompra pasando el idCompra
            n.Show(); // Muestra el formulario ImprimirCompra
        }

        private void CambiarEstadoCompra(object sender, EventArgs e) // Método para cambiar estado de compra
        {
            if (dgvOrigen.SelectedRows.Count > 0) // Si hay fila seleccionada en dgvOrigen
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0];
                // Obtiene la primera fila seleccionada
                int idCompra = Convert.ToInt32(filaSeleccionada.Cells["IDCompra"].Value);
                // Extrae el idCompra
                string estadoActual = filaSeleccionada.Cells["EstadoCompra"].Value.ToString();
                // Obtiene el estado actual de la compra como texto

                int nuevoEstado = estadoActual == "PEDIDO" ? 1 : 0;
                // Define nuevo estado: si es PEDIDO asigna 1, si no asigna 0

                string comando = $"exec sp_ActualizarCompra '{idCompra}', '{nuevoEstado}'";
                // Construye el comando para ejecutar el procedimiento almacenado que actualiza el estado

                bool update = cnn.Modificaciones(comando);
                // Ejecuta el comando y guarda si fue exitoso o no

                if (update) // Si la actualización fue exitosa
                {
                    CargarDatos(); // Recarga los datos en el DataGridView
                    MessageBox.Show("Estado de la compra actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Muestra mensaje de éxito
                }
                else // Si la actualización falló
                {
                    MessageBox.Show("Error al actualizar el estado de la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Muestra mensaje de error
                }
            }
        }

        private void CargarDatos() // Método para cargar datos en dgvOrigen filtrados por fechas
        {
            DateTime fechaInicio = dtpFechaInicio.Value; // Obtiene la fecha inicial desde el DateTimePicker
            DateTime fechaFin = dtpFechaFin.Value; // Obtiene la fecha final desde el DateTimePicker

            if (fechaFin < fechaInicio) // Verifica que la fecha final no sea anterior a la inicial
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Muestra mensaje de error si la condición no se cumple
                return; // Sale del método sin continuar
            }

            cnn.BusquedasDate("sp_BuscarCompras", dgvOrigen, "", fechaInicio, fechaFin);
            // Llama al método BusquedasDate para llenar dgvOrigen con datos filtrados por fechas usando procedimiento almacenado
        }

        private void btnBuscarFacturas_Click(object sender, EventArgs e) // Evento click del botón Buscar Facturas
        {
            CargarDatos(); // Llama al método para cargar datos filtrados por fecha
        }

        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // Evento doble click en una celda de dgvOrigen
        {
            if (e.RowIndex >= 0) // Verifica que el índice de la fila sea válido (no cabecera)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex]; // Obtiene la fila doble clickeada
                int idCompra = Convert.ToInt32(filaSeleccionada.Cells["IDCompra"].Value); // Extrae el idCompra de la fila
                ObtenerDetallesCompra(idCompra); // Llama al método para obtener los detalles de la compra
            }
        }

        private void dgvOrigen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        // Evento al presionar un botón del mouse sobre una celda en dgvOrigen
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            // Verifica que el botón sea el derecho y que el índice de fila sea válido
            {
                dgvOrigen.ClearSelection(); // Limpia la selección actual en dgvOrigen
                dgvOrigen.Rows[e.RowIndex].Selected = true; // Selecciona la fila donde se hizo clic derecho

                string estado = dgvOrigen.Rows[e.RowIndex].Cells["EstadoCompra"].Value.ToString();
                // Obtiene el estado de la compra en esa fila
                cambiarEstadoItem.Text = estado == "PEDIDO" ? "Recibir" : "Marcar como Pedida";
                // Cambia el texto del item del menú contextual según el estado actual
            }
        }

        private void ObtenerDetallesCompra(int idCompra) // Método para obtener los detalles de una compra por su id
        {
            string comando = $"exec sp_ConsultarDetallesCompra {idCompra}";
            // Construye el comando para el procedimiento almacenado que consulta detalles

            cnn.ConsultasGrid(comando, dgvDestino);
            // Ejecuta el comando y carga los resultados en el DataGridView dgvDestino
        }

        private void dgvDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        // Evento click en alguna celda de dgvDestino (vacío, sin implementación)
        {
        }
    }
}
