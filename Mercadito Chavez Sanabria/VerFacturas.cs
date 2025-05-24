using System; // Importa el espacio de nombres System, que contiene clases fundamentales
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genéricas
using System.ComponentModel; // Importa el espacio de nombres para componentes y atributos
using System.Data; // Importa el espacio de nombres para operaciones con datos
using System.Data.SqlClient; // Importa el espacio de nombres para trabajar con SQL Server
using System.Drawing; // Importa el espacio de nombres para gráficos y dibujo
using System.Linq; // Importa el espacio de nombres para LINQ
using System.Text; // Importa el espacio de nombres para manipulación de texto
using System.Threading.Tasks; // Importa el espacio de nombres para tareas asincrónicas
using System.Windows.Forms; // Importa el espacio de nombres para formularios de Windows

namespace Mercadito_Chavez_Sanabria // Define el namespace para organizar el código
{
    public partial class VerFacturas : Form // Declara la clase VerFacturas que hereda de Form
    {
        public VerFacturas() // Constructor de la clase VerFacturas
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }
        Conexion cnn = new Conexion(); // Crea una instancia de la clase Conexion para manejar BD
        ToolStripMenuItem cambiarEstadoItem; // Declara un menú para cambiar estado
        ToolStripMenuItem ImprimirFacturaItem; // Declara un menú para imprimir factura

        private void btnRegresar_Click(object sender, EventArgs e) // Evento click del botón regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea una nueva instancia del formulario MENU
            n.Show(); // Muestra el formulario MENU
        }

        private void Pedidos_Load(object sender, EventArgs e) // Evento Load del formulario (se llama Pedidos_Load)
        {
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; // Define modo de selección por fila en dgvDestino

            ContextMenuStrip menu = new ContextMenuStrip(); // Crea un menú contextual
            cambiarEstadoItem = new ToolStripMenuItem(); // Instancia el ítem para cambiar estado
            ImprimirFacturaItem = new ToolStripMenuItem(); // Instancia el ítem para imprimir factura
            cambiarEstadoItem.Click += CambiarEstadoFactura; // Asocia evento click para cambiar estado
            ImprimirFacturaItem.Text = "Imprimir"; // Define texto para ítem imprimir
            ImprimirFacturaItem.Click += AbrirReporteImprimir; // Asocia evento click para imprimir factura
            menu.Items.Add(cambiarEstadoItem); // Agrega el ítem cambiar estado al menú contextual
            menu.Items.Add(ImprimirFacturaItem); // Agrega el ítem imprimir al menú contextual
            dgvOrigen.ContextMenuStrip = menu; // Asigna el menú contextual al DataGridView dgvOrigen
        }

        private void AbrirReporteImprimir(object sender, EventArgs e) // Método para abrir el formulario de impresión
        {
            int idFactura = 0; // Inicializa variable para almacenar ID de factura
            if (dgvOrigen.SelectedRows.Count > 0) // Verifica que haya una fila seleccionada
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0]; // Obtiene la fila seleccionada
                idFactura = Convert.ToInt32(filaSeleccionada.Cells["IDFactura"].Value); // Convierte el valor de la celda IDFactura a entero
            }
            Form n = new ImprimirFactura(idFactura); // Crea instancia del formulario ImprimirFactura con el id
            n.Show(); // Muestra el formulario ImprimirFactura
        }

        private void CambiarEstadoFactura(object sender, EventArgs e) // Método para cambiar el estado de la factura
        {
            if (dgvOrigen.SelectedRows.Count > 0) // Verifica que haya una fila seleccionada
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0]; // Obtiene la fila seleccionada
                int idFactura = Convert.ToInt32(filaSeleccionada.Cells["IDFactura"].Value); // Convierte valor de IDFactura a entero
                string estadoActual = filaSeleccionada.Cells["EstadoFactura"].Value.ToString(); // Obtiene el estado actual de la factura

                int nuevoEstado = estadoActual == "ACTIVO" ? 0 : 1; // Define el nuevo estado según el estado actual

                string comando = "exec sp_ActualizarFactura '" + idFactura + "', '" + nuevoEstado + "'"; // Comando SQL para actualizar estado

                bool update = cnn.Modificaciones(comando); // Ejecuta la modificación en la BD y almacena resultado
                if (update) // Si la actualización fue exitosa
                {
                    CargarDatos(); // Recarga los datos en el DataGridView
                    MessageBox.Show("Estado de la factura actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito

                }
                else // Si hubo error en la actualización
                {
                    MessageBox.Show("Error al actualizar el estado de la factura: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error

                }
            }
        }

        private void CargarDatos() // Método para cargar los datos de facturas
        {
            DateTime fechaInicio = dtpFechaInicio.Value; // Obtiene la fecha inicio del control DateTimePicker
            DateTime fechaFin = dtpFechaFin.Value; // Obtiene la fecha fin del control DateTimePicker

            if (fechaFin < fechaInicio) // Valida que la fecha fin no sea anterior a la inicio
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
                return; // Sale del método
            }

            cnn.BusquedasDate("sp_BuscarFacturas", dgvOrigen, "", fechaInicio, fechaFin); // Ejecuta procedimiento almacenado para buscar facturas entre fechas
            CalcularTotales(); // Llama al método para calcular totales en el DataGridView
        }

        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // Evento doble click en una celda del dgvOrigen
        {
            if (e.RowIndex >= 0) // Verifica que la fila sea válida
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex]; // Obtiene la fila seleccionada
                int idFactura = Convert.ToInt32(filaSeleccionada.Cells["IDFactura"].Value);  // Obtiene el idFactura convertido a entero

                ObtenerDetallesFactura(idFactura); // Llama al método para obtener detalles de la factura
            }
        }

        private void dgvOrigen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) // Evento mouse down en dgvOrigen (click derecho)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) // Verifica que sea click derecho y fila válida
            {
                dgvOrigen.ClearSelection(); // Limpia selección previa
                dgvOrigen.Rows[e.RowIndex].Selected = true; // Selecciona la fila en la que se hizo click derecho

                string estadoFactura = dgvOrigen.Rows[e.RowIndex].Cells["EstadoFactura"].Value.ToString(); // Obtiene el estado de la factura en esa fila

                cambiarEstadoItem.Text = estadoFactura == "ACTIVO" ? "Anular" : "Activar"; // Cambia el texto del ítem según estado
            }
        }

        private void ObtenerDetallesFactura(int idFactura) // Método para obtener los detalles de una factura
        {
            string comando = "exec sp_ConsultarDetallesFactura " + idFactura; // Define comando SQL para consultar detalles

            cnn.ConsultasGrid(comando, dgvDestino); // Ejecuta consulta y muestra resultados en dgvDestino
        }

        int subtotal = 0; // Variable para almacenar subtotal
        double impuesto = 0; // Variable para almacenar impuesto
        double total = 0; // Variable para almacenar total

        private void CalcularTotal() // Método para calcular total, subtotal e impuesto basado en dgvDestino
        {
            subtotal = 0; // Inicializa subtotal a cero
            foreach (DataGridViewRow fila in dgvDestino.Rows) // Itera por cada fila del dgvDestino
            {
                if (fila.Cells["Precio Producto"].Value != null && fila.Cells["Cantidad"].Value != null) // Verifica que las celdas no sean nulas
                {
                    int precio = Convert.ToInt32(fila.Cells["Precio Producto"].Value); // Convierte precio a entero
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value); // Convierte cantidad a entero
                    subtotal += precio * cantidad; // Suma al subtotal el producto de precio por cantidad
                }
            }
            impuesto = subtotal * 0.15; // Calcula impuesto como 15% del subtotal
            total = subtotal + impuesto; // Calcula total sumando subtotal más impuesto
            lblSubTotal.Text = "L " + subtotal.ToString("N2");  // Muestra subtotal en etiqueta lblSubTotal con formato moneda
            lblimpuesto.Text = "L " + impuesto.ToString("N2"); // Muestra impuesto en etiqueta lblimpuesto con formato moneda
            lblTotal.Text = "L " + total.ToString("N2"); // Muestra total en etiqueta lblTotal con formato moneda
        }

        private void dgvDestino_CellClick(object sender, DataGridViewCellEventArgs e) // Evento click en dgvDestino (vacío)
        {

        }

        private void EliminarFilaSeleccionada() // Método para eliminar fila seleccionada en dgvDestino
        {
            if (dgvDestino.SelectedRows.Count > 0) // Verifica que haya fila seleccionada
            {
                dgvDestino.Rows.RemoveAt(dgvDestino.SelectedRows[0].Index); // Elimina la fila seleccionada
                CalcularTotal(); // Recalcula totales luego de eliminar fila
            }
        }

        private void btnBuscarFacturas_Click(object sender, EventArgs e) // Evento click para botón buscar facturas
        {
            CargarDatos(); // Llama al método para cargar datos según filtros de fecha
        }

        private void CalcularTotales() // Método para calcular totales basados en dgvOrigen (facturas)
        {
            double subtotal = 0; // Inicializa subtotal a cero
            double impuesto = 0; // Inicializa impuesto a cero
            double total = 0; // Inicializa total a cero

            foreach (DataGridViewRow fila in dgvOrigen.Rows) // Itera por cada fila en dgvOrigen
            {
                if (fila.Cells["TotalGravado"].Value != null) // Verifica que celda TotalGravado no sea nula
                {
                    subtotal += Convert.ToDouble(fila.Cells["TotalGravado"].Value); // Suma el valor al subtotal
                }
                if (fila.Cells["Impuesto"].Value != null) // Verifica que celda Impuesto no sea nula
                {
                    impuesto += Convert.ToDouble(fila.Cells["Impuesto"].Value); // Suma el valor al impuesto
                }
                if (fila.Cells["TotalFactura"].Value != null) // Verifica que celda TotalFactura no sea nula
                {
                    total += Convert.ToDouble(fila.Cells["TotalFactura"].Value); // Suma el valor al total
                }
            }

            lblSubTotal.Text = "L " + subtotal.ToString("N2");  // Muestra subtotal formateado en lblSubTotal
            lblimpuesto.Text = "L " + impuesto.ToString("N2");  // Muestra impuesto formateado en lblimpuesto
            lblTotal.Text = "L " + total.ToString("N2");  // Muestra total formateado en lblTotal
        }
    }
}
