// Importa los espacios de nombres necesarios para trabajar con formularios, base de datos y controles.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Define el espacio de nombres principal de la aplicación.
namespace Mercadito_Chavez_Sanabria
{
    // Define la clase parcial del formulario CrearCompra.
    public partial class CrearCompra : Form
    {
        // Constructor del formulario.
        public CrearCompra()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        // Instancia de la clase Conexion para acceder a la base de datos.
        Conexion cnn = new Conexion();

        // Variable para almacenar el ID SAR (no utilizada en este código).
        int idSar = 0;

        // Evento del clic sobre label7 (vacío, sin lógica).
        private void label7_Click(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta al hacer clic en el botón "Regresar".
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual.
            Form n = new MENU(); // Crea una nueva instancia del formulario MENU.
            n.Show(); // Muestra el formulario MENU.
        }

        // Evento que se ejecuta cuando se carga el formulario.
        private void Pedidos_Load(object sender, EventArgs e)
        {
            int idCompra = cnn.ObtenerUltimoId("Encabezado_Compras", "IdCom"); // Obtiene el último ID de compra.
            idCompra++; // Incrementa el ID en 1.
            lblCompra.Text = idCompra.ToString(); // Asigna el nuevo ID al label lblCompra.
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; // Establece el modo de selección del datagrid.

            // Crea un menú contextual para eliminar filas del datagrid.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");
            eliminarItem.Click += (s, args) => EliminarFilaSeleccionada(); // Agrega el evento para eliminar fila.
            menu.Items.Add(eliminarItem); // Añade el ítem al menú.
            dgvDestino.ContextMenuStrip = menu; // Asocia el menú al datagrid.

            CargarDatos(); // Llama al método para cargar los productos.

            // Consulta los proveedores y llena el comboBox de proveedores.
            DataSet ds = cnn.Consultas("exec sp_ConsultarProveedores '" + "" + "'");

            // Verifica si la consulta devolvió datos.
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                cmbProveedor.ValueMember = "ID Proveedor"; // Establece el valor del combo.
                cmbProveedor.DisplayMember = "Nombre Proveedor"; // Establece el texto visible del combo.
                cmbProveedor.DataSource = ds.Tables[0]; // Asigna la fuente de datos.
            }
            else
            {
                MessageBox.Show("No se encontraron categorías."); // Muestra mensaje si no hay datos.
            }

            // Consulta los empleados y llena el comboBox de empleados.
            DataSet ds2 = cnn.Consultas("exec sp_ConsultarEmpleados '" + "" + "'");

            // Verifica si la consulta devolvió datos.
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                cmbEmpleados.DisplayMember = "Nombre Empleado"; // Establece el texto visible.
                cmbEmpleados.ValueMember = "ID Empleado"; // Establece el valor.
                cmbEmpleados.DataSource = ds2.Tables[0]; // Asigna los datos.
            }
            else
            {
                MessageBox.Show("No se encontraron categorías."); // Mensaje si no hay empleados.
            }

            // Configura las columnas del datagrid de destino.
            dgvDestino.ColumnCount = 4;
            dgvDestino.Columns[0].Name = "Id Producto";
            dgvDestino.Columns[1].Name = "Nombre-Producto";
            dgvDestino.Columns[2].Name = "Precio de Costo";
            dgvDestino.Columns[3].Name = "Cantidad";

            // Establece todas las columnas como de solo lectura.
            foreach (DataGridViewColumn col in dgvDestino.Columns)
            {
                col.ReadOnly = true;
            }

            // Excepto la columna de cantidad que se permite editar.
            dgvDestino.Columns["Cantidad"].ReadOnly = false;

            // Asigna el evento para manejar el fin de edición de celdas.
            dgvDestino.CellEndEdit += dgvDestino_CellEndEdit;
        }

        // Método para cargar los productos en el datagrid origen.
        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarProductos '" + "" + "'", dgvOrigen);
        }

        // Evento vacío para label12.
        private void label12_Click(object sender, EventArgs e)
        {

        }

        // Evento vacío para label11.
        private void label11_Click(object sender, EventArgs e)
        {

        }

        // Evento que se dispara al hacer doble clic en una celda del datagrid de origen.
        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex]; // Obtiene la fila seleccionada.

                // Recorre el datagrid destino para verificar si el producto ya fue agregado.
                foreach (DataGridViewRow fila in dgvDestino.Rows)
                {
                    if (fila.Cells["Id Producto"].Value != null &&
                        fila.Cells["Id Producto"].Value.ToString() == filaSeleccionada.Cells["Id Producto"].Value.ToString())
                    {
                        MessageBox.Show("El producto ya está en la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Sale si ya existe el producto.
                    }
                }

                // Agrega una nueva fila con los datos del producto seleccionado.
                int nuevaFila = dgvDestino.Rows.Add();
                dgvDestino.Rows[nuevaFila].Cells["Id Producto"].Value = filaSeleccionada.Cells["Id Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Nombre-Producto"].Value = filaSeleccionada.Cells["Nombre-Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Precio de Costo"].Value = filaSeleccionada.Cells["Precio de Costo"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Cantidad"].Value = 1; // Asigna cantidad por defecto.
            }
        }

        // Evento al terminar de editar una celda del datagrid de destino.
        private void dgvDestino_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDestino.Columns["Cantidad"].Index)
            {
                int cantidad;
                if (!int.TryParse(dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value?.ToString(), out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value = 1; // Asigna 1 si la cantidad es inválida.
                    return;
                }

                string idProducto = dgvDestino.Rows[e.RowIndex].Cells["Id Producto"].Value?.ToString(); // Obtiene el ID del producto.

                int stockDisponible = 0;
                foreach (DataGridViewRow fila in dgvOrigen.Rows)
                {
                    if (fila.Cells["Id Producto"].Value?.ToString() == idProducto)
                    {
                        stockDisponible = Convert.ToInt32(fila.Cells["Stock Producto"].Value); // Obtiene el stock.
                        break;
                    }
                }
            }
        }

        // Variables para cálculos de totales.
        int subtotal = 0;
        double impuesto = 0;
        double total = 0;

        // Evento para eliminar filas seleccionadas del datagrid destino.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDestino.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDestino.SelectedRows)
                {
                    dgvDestino.Rows.Remove(row); // Elimina las filas seleccionadas.
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clic en celda (vacío).
        private void dgvDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Método para eliminar una fila seleccionada.
        private void EliminarFilaSeleccionada()
        {
            if (dgvDestino.SelectedRows.Count > 0)
            {
                dgvDestino.Rows.RemoveAt(dgvDestino.SelectedRows[0].Index); // Elimina la primera fila seleccionada.
            }
        }

        // Método para insertar una compra y su detalle.
        private void InsertarCompraYDetalle()
        {
            int estado = 0;
            DialogResult dialogResult = MessageBox.Show(" ¿Desea Marcar Esta Compra como RECIBIDA, si selecciona NO, se marcara como PEDIDO", "Estado de Compra", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                estado = 1; // Si elige sí, estado es 1 (recibida).
            }

            if (dgvDestino.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la tabla. No se puede insertar la Compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fecha = DateTime.Now; // Obtiene la fecha actual.
            int idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue); // ID del proveedor.
            int idempleado = Convert.ToInt32(cmbEmpleados.SelectedValue); // ID del empleado.

            // Ejecuta el procedimiento almacenado para insertar la compra.
            string consultaCompra = "exec sp_InsertarCompra '" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                     idempleado + ", " + idProveedor + ", " + estado + " ";
            cnn.Modificaciones(consultaCompra);

            int idCompra = cnn.ObtenerUltimoId("Encabezado_Compras", "IdCom"); // Obtiene el nuevo ID de compra.
            if (idCompra == 0)
            {
                MessageBox.Show("Error al obtener el ID de la Compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recorre las filas del datagrid para insertar los detalles.
            foreach (DataGridViewRow row in dgvDestino.Rows)
            {
                if (row.Cells["Id Producto"].Value != null)
                {
                    int idProducto = Convert.ToInt32(row.Cells["Id Producto"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioProducto = Convert.ToDecimal(row.Cells["Precio de Costo"].Value);

                    string consultaDetalleCompra = "exec sp_InsertarDetalleCompra " + idCompra + ", " + idProducto + ", " +
                                                   cantidad + ", " + precioProducto;

                    cnn.Modificaciones(consultaDetalleCompra); // Inserta el detalle.
                }
            }

            MessageBox.Show("Compra y detalles insertados correctamente."); // Mensaje de éxito.
        }

        // Evento del botón guardar.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarCompraYDetalle(); // Llama al método para insertar compra y detalle.
            Clear(); // Limpia el formulario.
        }

        // Método para limpiar y reiniciar el formulario.
        private void Clear()
        {
            dgvDestino.Rows.Clear(); // Limpia las filas del datagrid destino.
            CargarDatos(); // Recarga los productos.

            int idCompra = cnn.ObtenerUltimoId("Encabezado_Compras", "IdCom"); // Obtiene el ID actual.
            idCompra++; // Incrementa en 1.
            lblCompra.Text = idCompra.ToString(); // Asigna el nuevo ID.
        }

        // Evento que se ejecuta al cambiar el texto del campo de búsqueda.
        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscarProd.Text.Trim(); // Obtiene el texto de búsqueda.

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarDatos(); // Si está vacío, carga todos los productos.
            }
            else
            {
                string comando = "exec sp_ConsultarProductos @nombre = '" + busqueda + "'"; // Ejecuta el procedimiento con filtro.
                cnn.Busquedas(comando, dgvOrigen, ""); // Ejecuta la búsqueda.
            }
        }
    }
}
