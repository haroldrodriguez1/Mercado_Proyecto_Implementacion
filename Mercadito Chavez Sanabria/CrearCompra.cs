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
    public partial class CrearCompra : Form
    {
        public CrearCompra()
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
            int idCompra = cnn.ObtenerUltimoId("Encabezado_Compras", "IdCom");
            idCompra++;
            lblCompra.Text = idCompra.ToString();
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");
            eliminarItem.Click += (s, args) => EliminarFilaSeleccionada();
            menu.Items.Add(eliminarItem);
            dgvDestino.ContextMenuStrip = menu;
            CargarDatos();
            DataSet ds = cnn.Consultas("exec sp_ConsultarProveedores '"+""+"'");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
            {
                cmbProveedor.ValueMember = "ID Proveedor";  
                cmbProveedor.DisplayMember = "Nombre Proveedor";
                cmbProveedor.DataSource = ds.Tables[0];
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
            dgvDestino.Columns[2].Name = "Precio de Costo";
            dgvDestino.Columns[3].Name = "Cantidad";

            foreach (DataGridViewColumn col in dgvDestino.Columns)
            {
                col.ReadOnly = true; 
            }
            dgvDestino.Columns["Cantidad"].ReadOnly = false; 

            dgvDestino.CellEndEdit += dgvDestino_CellEndEdit;
           
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
                dgvDestino.Rows[nuevaFila].Cells["Precio de Costo"].Value = filaSeleccionada.Cells["Precio de Costo"].Value;
                dgvDestino.Rows[nuevaFila].Cells["Cantidad"].Value = 1; 

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


             
            }
        }
        int subtotal = 0;
        double impuesto = 0;
        double total = 0;
      

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDestino.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDestino.SelectedRows)
                {
                    dgvDestino.Rows.Remove(row);
                }

            
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
               
            }
        }

        private void InsertarCompraYDetalle()
        {
            int estado =0 ;
            DialogResult dialogResult = MessageBox.Show(" ¿Desea Marcar Esta Compra como RECIBIDA, si selecciona NO, se marcara como PEDIDO", "Estado de Compra", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                estado = 1;
            }
            if (dgvDestino.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la tabla. No se puede insertar la Compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fecha = DateTime.Now; 
            int idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            int idempleado = Convert.ToInt32(cmbEmpleados.SelectedValue);
            

            string consultaCompra = "exec sp_InsertarCompra '" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                     idempleado + ", " + idProveedor + ", " + estado + " ";
            cnn.Modificaciones(consultaCompra);

            int idCompra = cnn.ObtenerUltimoId("Encabezado_Compras", "IdCom");
            if (idCompra == 0)
            {
                MessageBox.Show("Error al obtener el ID de la Compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            foreach (DataGridViewRow row in dgvDestino.Rows)
            {
                if (row.Cells["Id Producto"].Value != null)
                {
                    int idProducto = Convert.ToInt32(row.Cells["Id Producto"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioProducto = Convert.ToDecimal(row.Cells["Precio de Costo"].Value);


                   

                    string consultaDetalleCompra = "exec sp_InsertarDetalleCompra " + idCompra + ", " + idProducto + ", " +
                                                   cantidad + ", " + precioProducto ;

                    cnn.Modificaciones(consultaDetalleCompra);
                }
            }

            MessageBox.Show("Compra y detalles insertados correctamente.");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarCompraYDetalle();
            Clear();
        }

        private void Clear()
        {
            dgvDestino.Rows.Clear();
            CargarDatos();
            int idCompra = cnn.ObtenerUltimoId("Encabezado_Compras", "IdCom");
            idCompra++;
            lblCompra.Text = idCompra.ToString();
           
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
