using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Mercadito_Chavez_Sanabria
{
    public partial class Productos : Form
    {
        Conexion cnn = new Conexion();
        int selectedClientId = 0;
        string name = "";
        string correo = "";
        string telefono = "";
        string estadotxt;
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            DataSet ds = cnn.Consultas("exec sp_ConsultarCategorias '"+""+"'");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
            {
                cmbCategoria.DisplayMember = "Nombre Categoria";  
                cmbCategoria.ValueMember = "ID Categoria";
                cmbCategoria.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No se encontraron categorías.");
            }
          
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

       

        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarProductos '"+""+"'", dataGridView1);
        }
        private bool Check()
        {
            if (NumberCantidad.Value <= 0 ||  
                NumberPrecioFinal.Value <= 0 ||
                NumberPreCost.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtInfoPro.Text) ||
                string.IsNullOrWhiteSpace(txtProducto.Text) ||
                cmbCategoria.SelectedIndex == -1
                )
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }
        private void Clear()
        {
            txtInfoPro.Clear();
            txtProducto.Clear();
            NumberPreCost.Value = 0;
            NumberPrecioFinal.Value = 0;
            NumberCantidad.Value = 0;
            cmbCategoria.Text = string.Empty;
            textBox1.Clear();
        }
        private void EditarImg_Click(object sender, EventArgs e)
        {
            btnEditar.PerformClick();
        }

        private void EliminarImg_Click(object sender, EventArgs e)
        {
            btnEliminar.PerformClick();
        }

        private void GuardarImg_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarBotones();
            if (e.RowIndex >= 0)
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                txtProducto.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                txtInfoPro.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                NumberPrecioFinal.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                NumberPreCost.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                NumberCantidad.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                int idCategoria = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value); 
                cmbCategoria.SelectedValue = idCategoria;
                
                selectedClientId = idCliente; 
                
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                cnn.Modificaciones("exec sp_InsertarProducto '" + txtProducto.Text + "', '" +txtInfoPro.Text + "', " + NumberPrecioFinal.Value + ", " +NumberPreCost.Value + ", " +NumberCantidad.Value + ", " +cmbCategoria.SelectedValue+""); 

                CargarDatos();
                OcultarBotones();
                Clear();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void OcultarBotones()
        {
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            ImgEditar.Visible = false;
            ImgEliminar.Visible = false;
        }
        private void MostrarBotones()
        {
            ImgEditar.Visible = true;
            ImgEliminar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedClientId > 0)
            {

                bool resultado = cnn.Modificaciones("exec sp_EliminarProducto '" + selectedClientId + "'"); 

                if (resultado)
                {
                    MessageBox.Show("Producto eliminado exitosamente.");
                    CargarDatos();
                    OcultarBotones();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el Producto.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Producto para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Check())
            {

                if (selectedClientId > 0)
                {
                    
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarProducto '" + selectedClientId + "','" + txtProducto.Text + "','" + txtInfoPro.Text + "'," + NumberPrecioFinal.Value + "," + NumberPreCost.Value + "," + NumberCantidad.Value + ", " + cmbCategoria.SelectedValue + "");

                    if (resultado)
                    {
                        MessageBox.Show("Producto editado exitosamente.");
                        CargarDatos();
                        OcultarBotones();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el Producto.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un Producto para editar.");
                }
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.Trim(); 

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarDatos(); 
            }
            else
            {
                string comando = "exec sp_ConsultarProductos @nombre = '" + busqueda + "'"; 
                cnn.Busquedas(comando, dataGridView1, ""); 
            }
        }
    }
}
