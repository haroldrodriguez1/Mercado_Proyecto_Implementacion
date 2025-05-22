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
    public partial class VerFacturas : Form
    {
        public VerFacturas()
        {
            InitializeComponent();
        }
        Conexion cnn = new Conexion();
        ToolStripMenuItem cambiarEstadoItem;
        ToolStripMenuItem ImprimirFacturaItem ;
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
           
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            ContextMenuStrip menu = new ContextMenuStrip();
            cambiarEstadoItem = new ToolStripMenuItem();
            ImprimirFacturaItem = new ToolStripMenuItem();
            cambiarEstadoItem.Click += CambiarEstadoFactura;
            ImprimirFacturaItem.Text = "Imprimir";
            ImprimirFacturaItem.Click += AbrirReporteImprimir;
            menu.Items.Add(cambiarEstadoItem);
            menu.Items.Add(ImprimirFacturaItem);
            dgvOrigen.ContextMenuStrip = menu;


        }
        private void AbrirReporteImprimir(object sender, EventArgs e)
        {
            int idFactura = 0;
            if (dgvOrigen.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0];
                 idFactura = Convert.ToInt32(filaSeleccionada.Cells["IDFactura"].Value);
            }
                Form n = new ImprimirFactura(idFactura);
            n.Show();
        }
        private void CambiarEstadoFactura(object sender, EventArgs e)
        {
            if (dgvOrigen.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0];
                int idFactura = Convert.ToInt32(filaSeleccionada.Cells["IDFactura"].Value);
                string estadoActual = filaSeleccionada.Cells["EstadoFactura"].Value.ToString();

                int nuevoEstado = estadoActual == "ACTIVO" ? 0 : 1;

                string comando = "exec sp_ActualizarFactura '"+idFactura+ "', '" + nuevoEstado + "'";

                bool update = cnn.Modificaciones(comando);
                if(update)
                {
                    CargarDatos();
                    MessageBox.Show("Estado de la factura actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error al actualizar el estado de la factura: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        
    }

        private void CargarDatos()
        {
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;

            if (fechaFin < fechaInicio)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cnn.BusquedasDate("sp_BuscarFacturas", dgvOrigen, "", fechaInicio, fechaFin);
            CalcularTotales();
        }



        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex];
                int idFactura = Convert.ToInt32(filaSeleccionada.Cells["IDFactura"].Value);  

                ObtenerDetallesFactura(idFactura);
            }
        }
        private void dgvOrigen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvOrigen.ClearSelection();
                dgvOrigen.Rows[e.RowIndex].Selected = true;

                string estadoFactura = dgvOrigen.Rows[e.RowIndex].Cells["EstadoFactura"].Value.ToString();

                cambiarEstadoItem.Text = estadoFactura == "ACTIVO" ? "Anular" : "Activar";
            }
        }
        private void ObtenerDetallesFactura(int idFactura)
        {
            string comando = "exec sp_ConsultarDetallesFactura " + idFactura;

            

            cnn.ConsultasGrid(comando, dgvDestino);
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

        private void btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CalcularTotales()
        {
            double subtotal = 0;
            double impuesto = 0;
            double total = 0;

            foreach (DataGridViewRow fila in dgvOrigen.Rows)
            {
                if (fila.Cells["TotalGravado"].Value != null)
                {
                    subtotal += Convert.ToDouble(fila.Cells["TotalGravado"].Value);
                }
                if (fila.Cells["Impuesto"].Value != null)
                {
                    impuesto += Convert.ToDouble(fila.Cells["Impuesto"].Value);
                }
                if (fila.Cells["TotalFactura"].Value != null)
                {
                    total += Convert.ToDouble(fila.Cells["TotalFactura"].Value);
                }
            }

            lblSubTotal.Text = "L " + subtotal.ToString("N2"); 
            lblimpuesto.Text = "L " + impuesto.ToString("N2"); 
            lblTotal.Text = "L " + total.ToString("N2"); 
        }
    }
}
