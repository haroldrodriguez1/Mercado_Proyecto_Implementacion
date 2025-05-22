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
    public partial class VerCompras : Form
    {
        public VerCompras()
        {
            InitializeComponent();
        }

        Conexion cnn = new Conexion();
        ToolStripMenuItem cambiarEstadoItem;
        ToolStripMenuItem ImprimirCompraItem;

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form menu = new MENU();
            menu.Show();
        }

        private void VerCompras_Load(object sender, EventArgs e)
        {
            dgvDestino.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            ContextMenuStrip menu = new ContextMenuStrip();
            cambiarEstadoItem = new ToolStripMenuItem();
            ImprimirCompraItem = new ToolStripMenuItem();
            cambiarEstadoItem.Click += CambiarEstadoCompra;
            ImprimirCompraItem.Text = "Imprimir";
            ImprimirCompraItem.Click += AbrirReporteImprimir;
            menu.Items.Add(cambiarEstadoItem);
            menu.Items.Add(ImprimirCompraItem);
            dgvOrigen.ContextMenuStrip = menu;
        }

        private void AbrirReporteImprimir(object sender, EventArgs e)
        {
            int idCompra = 0;
            if (dgvOrigen.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0];
                idCompra = Convert.ToInt32(filaSeleccionada.Cells["IDCompra"].Value);
            }
            Form n = new ImprimirCompra(idCompra);
            n.Show();
        }

        private void CambiarEstadoCompra(object sender, EventArgs e)
        {
            if (dgvOrigen.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.SelectedRows[0];
                int idCompra = Convert.ToInt32(filaSeleccionada.Cells["IDCompra"].Value);
                string estadoActual = filaSeleccionada.Cells["EstadoCompra"].Value.ToString();

                int nuevoEstado = estadoActual == "PEDIDO" ? 1 : 0;

                string comando = $"exec sp_ActualizarCompra '{idCompra}', '{nuevoEstado}'";

                bool update = cnn.Modificaciones(comando);
                if (update)
                {
                    CargarDatos();
                    MessageBox.Show("Estado de la compra actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el estado de la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            cnn.BusquedasDate("sp_BuscarCompras", dgvOrigen, "", fechaInicio, fechaFin);
        }

        private void btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvOrigen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrigen.Rows[e.RowIndex];
                int idCompra = Convert.ToInt32(filaSeleccionada.Cells["IDCompra"].Value);
                ObtenerDetallesCompra(idCompra);
            }
        }

        private void dgvOrigen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvOrigen.ClearSelection();
                dgvOrigen.Rows[e.RowIndex].Selected = true;

                string estado = dgvOrigen.Rows[e.RowIndex].Cells["EstadoCompra"].Value.ToString();
                cambiarEstadoItem.Text = estado == "PEDIDO" ? "Recibir" : "Marcar como Pedida";
            }
        }

        private void ObtenerDetallesCompra(int idCompra)
        {
            string comando = $"exec sp_ConsultarDetallesCompra {idCompra}";
            cnn.ConsultasGrid(comando, dgvDestino);
        }

        

        

        private void dgvDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

       
    }
}
