using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mercadito_Chavez_Sanabria
{
    public partial class CLIENTE : Form
    {
        public CLIENTE()
        {
            InitializeComponent();
        }
        Conexion cnn = new Conexion();
        int selectedClientId = 0;
        string name = "";
        string correo = "";
        string telefono = "";
        private void CLIENTE_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            CargarDatos();
            
        }
        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarClientes '"+""+"'", dataGridView1);
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Clear()
        {
            txtCorreo.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnEditar.PerformClick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnEliminar.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarBotones();
            if (e.RowIndex >= 0)
            {
                int idCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                txtNombre.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                txtCorreo.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

                selectedClientId = idCliente; 
                
            }
        }

    

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                cnn.Modificaciones("exec sp_InsertarCliente '" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "'");
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
            pictureBox1.Visible = false;
            pictureBox3.Visible = false;
        }
        private void MostrarBotones()
        {
            pictureBox1.Visible = true;
           pictureBox3.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedClientId > 0)
            {
               
                bool resultado = cnn.Modificaciones("exec sp_EliminarCliente '" + selectedClientId+ "'"); // Asumiendo que la clase 'Conexion' tiene este método para ejecutar comandos

                if (resultado)
                {
                    MessageBox.Show("Cliente eliminado exitosamente.");
                    CargarDatos(); 
                    OcultarBotones();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el cliente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (selectedClientId > 0)
                {

                    bool resultado = cnn.Modificaciones("exec sp_ActualizarCliente '" + selectedClientId + "','" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "'");

                    if (resultado)
                    {
                        MessageBox.Show("Cliente editado exitosamente.");
                        CargarDatos();
                        OcultarBotones();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el cliente.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente para editar.");
                }
            }
            

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
                string comando = "exec sp_ConsultarClientes @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, "");
            }
        }
    }
}
