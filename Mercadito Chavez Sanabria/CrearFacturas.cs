using System; // Importa el espacio de nombres base de .NET
using System.Collections.Generic; // Para usar colecciones genéricas
using System.ComponentModel; // Para componentes de interfaz
using System.Data; // Para manejo de datos
using System.Data.SqlClient; // Para conexión a SQL Server
using System.Drawing; // Para gráficos y dibujos
using System.Linq; // Para LINQ
using System.Text; // Para manipulación de texto
using System.Threading.Tasks; // Para tareas asíncronas
using System.Windows.Forms; // Para formularios Windows Forms

namespace Mercadito_Chavez_Sanabria
{
    public partial class CrearFacturas : Form // Declara formulario de creación de facturas
    {
        public CrearFacturas()
        {
            InitializeComponent(); // Inicializa componentes del formulario
        }
        Conexion cnn = new Conexion(); // Instancia de clase para conexión a base de datos
        int idSar = 0; // Variable para almacenar ID del SAR

        private void label7_Click(object sender, EventArgs e)
        {
            // Evento click vacío para la etiqueta 7
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
            Form n = new MENU(); // Crea nueva instancia del menú
            n.Show(); // Muestra el formulario del menú
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            CargarSAR(); // Carga datos del SAR
            int idFactura = cnn.ObtenerUltimoId("EncabezadoFactura", "idFactura"); // Obtiene último ID de factura
            idFactura++; // Incrementa el ID para nueva factura
            lblFactura.Text = idFactura.ToString(); // Muestra nuevo número de factura
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; // Configura modo de selección del grid

            // Configura menú contextual para grid de destino
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");
            eliminarItem.Click += (s, args) => EliminarFilaSeleccionada();
            menu.Items.Add(eliminarItem);
            dgvDestino.ContextMenuStrip = menu;

            CargarDatos(); // Carga datos iniciales

            // Carga clientes en combobox
            DataSet ds = cnn.Consultas("exec sp_ConsultarClientes '" + "" + "'");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                cmbClientes.DisplayMember = "Nombre Cliente";  // Columna a mostrar
                cmbClientes.ValueMember = "ID Cliente"; // Valor asociado
                cmbClientes.DataSource = ds.Tables[0]; // Fuente de datos
            }
            else
            {
                MessageBox.Show("No se encontraron categorías.");
            }

            // Carga empleados en combobox
            DataSet ds2 = cnn.Consultas("exec sp_ConsultarEmpleados '" + "" + "'");
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                cmbEmpleados.DisplayMember = "Nombre Empleado";
                cmbEmpleados.ValueMember = "ID Empleado";
                cmbEmpleados.DataSource = ds2.Tables[0];
            }
            else
            {
                MessageBox.Show("No se encontraron categorías.");
            }

            // Configura columnas del grid de destino
            dgvDestino.ColumnCount = 4;
            dgvDestino.Columns[0].Name = "Id Producto";
            dgvDestino.Columns[1].Name = "Nombre-Producto";
            dgvDestino.Columns[2].Name = "Precio Producto";
            dgvDestino.Columns[3].Name = "Cantidad";

            // Hace todas las columnas de solo lectura excepto Cantidad
            foreach (DataGridViewColumn col in dgvDestino.Columns)
            {
                col.ReadOnly = true;
            }
            dgvDestino.Columns["Cantidad"].ReadOnly = false;

            dgvDestino.CellEndEdit += dgvDestino_CellEndEdit; // Asocia evento de edición
        }

        private void CargarSAR()
        {
            // Consulta datos del SAR
            DataSet ds = cnn.Consultas("exec sp_ConsultarSar");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0]; // Toma primera fila
                idSar = Convert.ToInt32(row["id"]); // Asigna ID SAR
                lblCai.Text = row["cai"].ToString(); // Muestra CAI
                lblrangodel.Text = row["rangoAutorizadoInicio"].ToString(); // Muestra rango inicial
                lblRangoAl.Text = row["rangoAutorizadoFin"].ToString(); // Muestra rango final
            }
            else
            {
                MessageBox.Show("No se encontró un registro activo en SAR.");
            }

            // Valida rango de facturación
            DataSet ds2 = cnn.Consultas("exec sp_ValidarUltimaFacturaEnRangoSAR");
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds2.Tables[0].Rows[0];
                int idResultado = Convert.ToInt32(row["Resultado"]);
                string mensaje = (row["Mensaje"]).ToString();
                if (idResultado == 0) // Si hay error en validación
                {
                    MessageBox.Show(mensaje);
                    this.Close(); // Cierra formulario
                    Form n = new MENU();
                    n.Show();
                }
            }
        }

        private void CargarDatos()
        {
            // Carga productos en grid origen
            cnn.ConsultasGrid("exec sp_ConsultarProductos '" + "" + "'", dgvOrigen);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            // Evento click vacío para etiqueta 12
        }

        private void label11_Click(object sender, EventArgs e)
        {
            // Evento click vacío para etiqueta 11
        }

        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Si se hizo click en fila válida
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex];
                // Verifica stock disponible
                if (Convert.ToInt32(filaSeleccionada.Cells["Stock Producto"].Value) == 0)
                {
                    MessageBox.Show("El producto esta agotado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Verifica si producto ya está agregado
                foreach (DataGridViewRow fila in dgvDestino.Rows)
                {
                    if (fila.Cells["Id Producto"].Value != null &&
                        fila.Cells["Id Producto"].Value.ToString() == filaSeleccionada.Cells["Id Producto"].Value.ToString())
                    {
                        MessageBox.Show("El producto ya está en la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Agrega producto al grid destino
                int nuevaFila = dgvDestino.Rows.Add();
                dgvDestino.Rows[nuevaFila].Cells["Id Producto"].Value = filaSeleccionada.Cells["Id Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Nombre-Producto"].Value = filaSeleccionada.Cells["Nombre-Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Precio Producto"].Value = filaSeleccionada.Cells["Precio Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Cantidad"].Value = 1; // Cantidad inicial 1

                CalcularTotal(); // Actualiza totales
            }
        }

        private void dgvDestino_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDestino.Columns["Cantidad"].Index) // Si se editó columna Cantidad
            {
                int cantidad;
                // Valida entrada numérica
                if (!int.TryParse(dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value?.ToString(), out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value = 1;
                    return;
                }

                string idProducto = dgvDestino.Rows[e.RowIndex].Cells["Id Producto"].Value?.ToString();
                int stockDisponible = 0;
                // Busca stock en grid origen
                foreach (DataGridViewRow fila in dgvOrigen.Rows)
                {
                    if (fila.Cells["Id Producto"].Value?.ToString() == idProducto)
                    {
                        stockDisponible = Convert.ToInt32(fila.Cells["Stock Producto"].Value);
                        break;
                    }
                }

                if (cantidad > stockDisponible) // Valida stock
                {
                    MessageBox.Show($"La cantidad no puede ser mayor al stock disponible ({stockDisponible}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value = stockDisponible;
                }

                CalcularTotal(); // Actualiza totales
            }
        }

        int subtotal = 0; // Variable para subtotal
        double impuesto = 0; // Variable para impuesto
        double total = 0; // Variable para total

        private void CalcularTotal()
        {
            subtotal = 0;
            // Calcula subtotal sumando precios * cantidades
            foreach (DataGridViewRow fila in dgvDestino.Rows)
            {
                if (fila.Cells["Precio Producto"].Value != null && fila.Cells["Cantidad"].Value != null)
                {
                    int precio = Convert.ToInt32(fila.Cells["Precio Producto"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    subtotal += precio * cantidad;
                }
            }
            impuesto = subtotal * 0.15; // Calcula 15% de impuesto
            total = subtotal + impuesto; // Calcula total

            // Actualiza etiquetas con formato numérico
            lblSubTotal.Text = "L " + subtotal.ToString("N2");
            lblimpuesto.Text = "L " + impuesto.ToString("N2");
            lblTotal.Text = "L " + total.ToString("N2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDestino.SelectedRows.Count > 0) // Si hay filas seleccionadas
            {
                foreach (DataGridViewRow row in dgvDestino.SelectedRows)
                {
                    dgvDestino.Rows.Remove(row); // Elimina filas seleccionadas
                }
                CalcularTotal(); // Actualiza totales
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento click vacío para celdas del grid destino
        }

        private void EliminarFilaSeleccionada()
        {
            if (dgvDestino.SelectedRows.Count > 0) // Si hay fila seleccionada
            {
                dgvDestino.Rows.RemoveAt(dgvDestino.SelectedRows[0].Index); // Elimina fila
                CalcularTotal(); // Actualiza totales
            }
        }

        private void InsertarFacturaYDetalle()
        {
            if (dgvDestino.Rows.Count == 0) // Valida productos agregados
            {
                MessageBox.Show("No hay productos en la tabla. No se puede insertar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fecha = DateTime.Now; // Obtiene fecha actual
            int idCliente = Convert.ToInt32(cmbClientes.SelectedValue); // Obtiene ID cliente
            // Obtiene datos del SAR
            string cai = lblCai.Text;
            string rangoAutorizadoInicio = lblrangodel.Text;
            string rangoAutorizadoFin = lblRangoAl.Text;
            string numeroFactura = lblFactura.Text;

            // Calcula montos
            decimal totalGravado = subtotal > 0 ? subtotal : 0;
            decimal isv = Convert.ToDecimal(impuesto);
            decimal total2 = totalGravado + isv;
            int estado = 1;

            // Consulta SQL para insertar encabezado de factura
            string consultaFactura = "exec sp_InsertarFactura '" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                     idCliente + ", '" + numeroFactura + "', " + totalGravado + ", " +
                                     isv + ", " + total2 + ", '" + estado + "'," + idSar + "";
            cnn.Modificaciones(consultaFactura); // Ejecuta consulta

            int idFactura = cnn.ObtenerUltimoId("EncabezadoFactura", "idFactura"); // Obtiene ID de nueva factura
            if (idFactura == 0)
            {
                MessageBox.Show("Error al obtener el ID de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inserta detalles de factura
            foreach (DataGridViewRow row in dgvDestino.Rows)
            {
                if (row.Cells["Id Producto"].Value != null)
                {
                    int idProducto = Convert.ToInt32(row.Cells["Id Producto"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioProducto = Convert.ToDecimal(row.Cells["Precio Producto"].Value);

                    // Consulta SQL para detalle de factura
                    string consultaDetalleFactura = "exec sp_InsertarDetalleFactura " + idFactura + ", " + idProducto + ", " +
                                                   cantidad + ", " + precioProducto;
                    cnn.Modificaciones(consultaDetalleFactura); // Ejecuta consulta
                }
            }

            // Pregunta si desea imprimir factura
            DialogResult dialogResult = MessageBox.Show("Factura y detalles insertados correctamente. ¿Desea Imprimir la Factura?", "Imprimir Factura", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form n = new ImprimirFactura(idFactura); // Crea formulario de impresión
                n.Show();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarFacturaYDetalle(); // Guarda factura
            Clear(); // Limpia formulario
        }

        private void Clear()
        {
            dgvDestino.Rows.Clear(); // Limpia grid de destino
            CargarDatos(); // Recarga datos
            int idFactura = cnn.ObtenerUltimoId("EncabezadoFactura", "idFactura"); // Obtiene nuevo ID
            idFactura++;
            lblFactura.Text = idFactura.ToString(); // Actualiza número de factura
            // Resetea etiquetas de totales
            lblTotal.Text = "L 0.00";
            lblimpuesto.Text = "L 0.00";
            lblSubTotal.Text = "L 0.00";
        }

        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscarProd.Text.Trim(); // Obtiene texto de búsqueda

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarDatos(); // Recarga todos los productos
            }
            else
            {
                // Filtra productos según búsqueda
                string comando = "exec sp_ConsultarProductos @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dgvOrigen, "");
            }
        }
    }
}