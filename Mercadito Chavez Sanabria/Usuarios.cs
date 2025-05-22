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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            CargarDatos();
        }


        Conexion cnn = new Conexion();
        int selectedClientId = 0;
        string name = "";
        string estadotxt;

        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarUsuarios '"+""+"'", dataGridView1);
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(cmbUsuarios.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            

            return true;
        }
        private void Clear()
        {
            txtContrasena.Clear();
            txtNombre.Clear();
            cmbUsuarios.Items.Clear();
            cmbUsuarios.Items.Add("Administrador");
            cmbUsuarios.Items.Add("Cajero");


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
                txtNombre.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                txtContrasena.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                cmbUsuarios.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                if (cmbUsuarios.Text =="Administrador")
                {
                    cmbUsuarios.SelectedValue = 1;
                }
                else
                {
                    cmbUsuarios.SelectedValue=0;
                }
                selectedClientId = idCliente; 
               
                /*if (estadotxt == "ACTIVO")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }*/
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                int estado = 1;
                int rol = 0;
                
               
                if (cmbUsuarios.Text == "Administrador")
                {
                    rol = 1;
                }
                else
                {
                    rol = 0;
                }
                cnn.Modificaciones("exec sp_InsertarUsuario '" + txtNombre.Text + "','" + txtContrasena.Text + "','" + rol + "','" + estado + "'");
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
            imgEditar.Visible = false;
            imgEliminar.Visible = false;
        }
        private void MostrarBotones()
        {
            imgEditar.Visible = true;
            imgEliminar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedClientId > 0)
            {

                bool resultado = cnn.Modificaciones("exec sp_EliminarUsuario '" + selectedClientId + "'"); // Asumiendo que la clase 'Conexion' tiene este método para ejecutar comandos

                if (resultado)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.");
                    CargarDatos();
                    OcultarBotones();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el Usuario.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Usuario para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Check())
            {

                if (selectedClientId > 0)
                {
                    int estado = 1;
                    int rol = 0;
                    
                    if (cmbUsuarios.Text == "Administrador")
                    {
                        rol = 1;
                    }
                    else
                    {
                        rol = 0;
                    }
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarUsuario '" + selectedClientId + "','" + txtNombre.Text + "','" + txtContrasena.Text + "','" + rol + "','" + estado + "'");

                    if (resultado)
                    {
                        MessageBox.Show("Usuario editado exitosamente.");
                        CargarDatos();
                        OcultarBotones();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el Usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un empleado para editar.");
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
                string comando = "exec sp_ConsultarUsuarios @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, "");
            }
        }
    }
}
