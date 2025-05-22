using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercadito_Chavez_Sanabria
{
    public partial class Empresas : Form
    {
        Conexion cnn = new Conexion();
        int selectedClientId = 0;
        public Empresas()
        {
            InitializeComponent();
        }
        private void Empresas_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            CargarDatos();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       






        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarEmpresas '"+""+"'", dataGridView1);
        }
        private bool Check()
        {
            if (
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) 
                )
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
            txtName.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();

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
                txtName.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                txtCorreo.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                txtDireccion.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

                selectedClientId = idCliente; 

            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                cnn.Modificaciones("exec sp_InsertarEmpresa '" + txtName.Text + "', '" + txtTelefono.Text + "',' " + txtCorreo.Text + "', '" + txtDireccion.Text + "'");

                CargarDatos();
                OcultarBotones();
                Clear();
            }

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

                bool resultado = cnn.Modificaciones("exec sp_EliminarEmpresa '" + selectedClientId + "'"); 

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

                    bool resultado = cnn.Modificaciones("exec sp_ActualizarEmpresa '" + selectedClientId + "','" + txtName.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "', '" + txtDireccion.Text + "'");

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarDatos();
            }
            else
            {
                string comando = "exec sp_ConsultarEmpresas @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, "");
            }
        }
    }
}
