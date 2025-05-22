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
    public partial class Categorías : Form
    {
        public Categorías()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void Categorías_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            CargarDatos();
        }



        Conexion cnn = new Conexion();
        int selectedClientId = 0;
 

        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarCategorias '"+""+"'", dataGridView1);
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))       
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            return true;
        }
        private void Clear()
        {
            txtCategoria.Clear();

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
                txtCategoria.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
              selectedClientId = idCliente;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
               
                cnn.Modificaciones("exec sp_InsertarCategoria '" + txtCategoria.Text + "'");
                CargarDatos();
                OcultarBotones();
                Clear();
            }

        }

      
        private void OcultarBotones()
        {
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            ImgEliminar.Visible = false;
            ImgEditar.Visible = false;
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

                bool resultado = cnn.Modificaciones("exec sp_EliminarCategoria '" + selectedClientId + "'"); // Asumiendo que la clase 'Conexion' tiene este método para ejecutar comandos

                if (resultado)
                {
                    MessageBox.Show("Categoria eliminada exitosamente.");
                    CargarDatos();
                    OcultarBotones();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar la Categoria.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una Categoria para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Check())
            {

                if (selectedClientId > 0)
                {
                   
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarCategoria '" + selectedClientId + "','" + txtCategoria.Text + "'");

                    if (resultado)
                    {
                        MessageBox.Show("Categoria editado exitosamente.");
                        CargarDatos();
                        OcultarBotones();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el Categoria.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un Categoria para editar.");
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
                string comando = "exec sp_ConsultarCategorias @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, "");
            }
        }
    }
}
