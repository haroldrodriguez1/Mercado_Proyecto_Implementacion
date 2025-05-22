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

namespace Mercadito_Chavez_Sanabria
{
    public partial class CrearFacturas : Form
    {
        public CrearFacturas()
        {
            InitializeComponent();
        }
        Conexion cnn = new Conexion();
        int idSar = 0;
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            CargarSAR();
            int idFactura = cnn.ObtenerUltimoId("EncabezadoFactura", "idFactura");
            idFactura++;
            lblFactura.Text = idFactura.ToString();
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");
            eliminarItem.Click += (s, args) => EliminarFilaSeleccionada();
            menu.Items.Add(eliminarItem);
            dgvDestino.ContextMenuStrip = menu;
            CargarDatos();
            DataSet ds = cnn.Consultas("exec sp_ConsultarClientes '"+""+"'");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
            {
                cmbClientes.DisplayMember = "Nombre Cliente";  
                cmbClientes.ValueMember = "ID Cliente";
                cmbClientes.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No se encontraron categorías.");
            }
            DataSet ds2 = cnn.Consultas("exec sp_ConsultarEmpleados '"+""+"'");

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

            dgvDestino.ColumnCount = 4; 
            dgvDestino.Columns[0].Name = "Id Producto";
            dgvDestino.Columns[1].Name = "Nombre-Producto";
            dgvDestino.Columns[2].Name = "Precio Producto";
            dgvDestino.Columns[3].Name = "Cantidad";

            foreach (DataGridViewColumn col in dgvDestino.Columns)
            {
                col.ReadOnly = true; 
            }
            dgvDestino.Columns["Cantidad"].ReadOnly = false; 

            dgvDestino.CellEndEdit += dgvDestino_CellEndEdit;
           
        }
        private void CargarSAR()
        {
            DataSet ds = cnn.Consultas("exec sp_ConsultarSar");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0]; 
                idSar = Convert.ToInt32(row["id"]);
                lblCai.Text = row["cai"].ToString();
                lblrangodel.Text = row["rangoAutorizadoInicio"].ToString();
                lblRangoAl.Text = row["rangoAutorizadoFin"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró un registro activo en SAR.");
            }
            DataSet ds2 = cnn.Consultas("exec sp_ValidarUltimaFacturaEnRangoSAR");

            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds2.Tables[0].Rows[0];
               int idResultado = Convert.ToInt32(row["Resultado"]);
                string mensaje = (row["Mensaje"]).ToString();
                if (idResultado == 0)
                {
                    MessageBox.Show(mensaje);
                    this.Close();
                    Form n = new MENU();
                    n.Show();
                }
            }
            
        }

        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarProductos '" + "" + "'", dgvOrigen);
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex];
                if (Convert.ToInt32(filaSeleccionada.Cells["Stock Producto"].Value) == 0)
                {
                    MessageBox.Show("El producto esta agotado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (DataGridViewRow fila in dgvDestino.Rows)
                {


                    if (fila.Cells["Id Producto"].Value != null &&
                        fila.Cells["Id Producto"].Value.ToString() == filaSeleccionada.Cells["Id Producto"].Value.ToString())
                    {
                        MessageBox.Show("El producto ya está en la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }

                int nuevaFila = dgvDestino.Rows.Add();
                dgvDestino.Rows[nuevaFila].Cells["Id Producto"].Value = filaSeleccionada.Cells["Id Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Nombre-Producto"].Value = filaSeleccionada.Cells["Nombre-Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Precio Producto"].Value = filaSeleccionada.Cells["Precio Producto"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Cantidad"].Value = 1; 

                CalcularTotal();
            }
        }
        private void dgvDestino_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDestino.Columns["Cantidad"].Index)
            {
                int cantidad;
                if (!int.TryParse(dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value?.ToString(), out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value = 1;
                    return;
                }

                string idProducto = dgvDestino.Rows[e.RowIndex].Cells["Id Producto"].Value?.ToString();

                int stockDisponible = 0;
                foreach (DataGridViewRow fila in dgvOrigen.Rows)
                {
                    if (fila.Cells["Id Producto"].Value?.ToString() == idProducto)
                    {
                        stockDisponible = Convert.ToInt32(fila.Cells["Stock Producto"].Value);
                        break;
                    }
                }

                if (cantidad > stockDisponible)
                {
                    MessageBox.Show($"La cantidad no puede ser mayor al stock disponible ({stockDisponible}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDestino.Rows[e.RowIndex].Cells["Cantidad"].Value = stockDisponible;
                }

                CalcularTotal();
            }
        }
        int subtotal = 0;
        double impuesto = 0;
        double total = 0;
        private void CalcularTotal()
        {
            subtotal = 0;
            foreach (DataGridViewRow fila in dgvDestino.Rows)
            {
                if (fila.Cells["Precio Producto"].Value != null && fila.Cells["Cantidad"].Value != null)
                {
                    int precio = Convert.ToInt32(fila.Cells["Precio Producto"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    subtotal += precio * cantidad;

                }
            }
            impuesto = subtotal * 0.15;
            total = subtotal + impuesto;
            lblSubTotal.Text = "L " + subtotal.ToString("N2"); 
            lblimpuesto.Text = "L " + impuesto.ToString("N2");
            lblTotal.Text = "L " + total.ToString("N2");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDestino.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDestino.SelectedRows)
                {
                    dgvDestino.Rows.Remove(row);
                }

                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void EliminarFilaSeleccionada()
        {
            if (dgvDestino.SelectedRows.Count > 0)
            {
                dgvDestino.Rows.RemoveAt(dgvDestino.SelectedRows[0].Index);
                CalcularTotal();
            }
        }

        private void InsertarFacturaYDetalle()
        {
            if (dgvDestino.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la tabla. No se puede insertar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fecha = DateTime.Now; 
            int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
            string cai = lblCai.Text;
            string rangoAutorizadoInicio = lblrangodel.Text;
            string rangoAutorizadoFin = lblRangoAl.Text;
            string numeroFactura = lblFactura.Text;
            decimal totalGravado = subtotal > 0 ? subtotal : 0; ;
            decimal isv = Convert.ToDecimal(impuesto);
            decimal total2 = totalGravado + isv;
            int estado = 1;

            string consultaFactura = "exec sp_InsertarFactura '" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                     idCliente + ", '" + numeroFactura + "', " + totalGravado + ", " +
                                     isv + ", " + total2 + ", '" + estado + "'," + idSar + "";
            cnn.Modificaciones(consultaFactura);

            int idFactura = cnn.ObtenerUltimoId("EncabezadoFactura", "idFactura");
            if (idFactura == 0)
            {
                MessageBox.Show("Error al obtener el ID de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            foreach (DataGridViewRow row in dgvDestino.Rows)
            {
                if (row.Cells["Id Producto"].Value != null)
                {
                    int idProducto = Convert.ToInt32(row.Cells["Id Producto"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioProducto = Convert.ToDecimal(row.Cells["Precio Producto"].Value);


                    decimal totalProducto = precioProducto * cantidad;

                    string consultaDetalleFactura = "exec sp_InsertarDetalleFactura " + idFactura + ", " + idProducto + ", " +
                                                   cantidad + ", " + precioProducto ;

                    cnn.Modificaciones(consultaDetalleFactura);
                }
            }

           DialogResult dialogResult = MessageBox.Show("Factura y detalles insertados correctamente. ¿Desea Imprimir la Factura?","Imprimir Factura",MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Form n = new ImprimirFactura(idFactura);
                n.Show();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarFacturaYDetalle();
            Clear();
        }

        private void Clear()
        {
            dgvDestino.Rows.Clear();
            CargarDatos();
            int idFactura = cnn.ObtenerUltimoId("EncabezadoFactura", "idFactura");
            idFactura++;
            lblFactura.Text = idFactura.ToString();
            lblTotal.Text = "L 0.00";
            lblimpuesto.Text = "L 0.00";
            lblSubTotal.Text = "L 0.00";
        }

        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscarProd.Text.Trim(); 

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarDatos(); 
            }
            else
            {
                string comando = "exec sp_ConsultarProductos @nombre = '" + busqueda + "'"; 
                cnn.Busquedas(comando, dgvOrigen, ""); 
            }
        }
    }
}
