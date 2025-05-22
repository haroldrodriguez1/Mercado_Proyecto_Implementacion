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
    public partial class Proveedores : Form
    {
        Conexion cnn = new Conexion();
        int selectedClientId = 0;
        string name = "";
        string correo = "";
        string telefono = "";
        string estadotxt;
        public Proveedores()
        {
            InitializeComponent();
        }

        private void PROVEEDORES_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            CargarDatos();
            DataSet ds = cnn.Consultas("exec sp_ConsultarEmpresas '"+""+"'");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
            {
                cmbEmpresa.DisplayMember = "Nombre Empresa";  
                cmbEmpresa.ValueMember = "ID Empresa";
                cmbEmpresa.DataSource = ds.Tables[0];
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
            cnn.ConsultasGrid("exec sp_ConsultarProveedores '"+""+"'", dataGridView1);
        }
        private bool Check()
        {
            if (
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbEmpresa.SelectedIndex == -1
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
            cmbEmpresa.Text = string.Empty;
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
                int idEmpresa = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                cmbEmpresa.SelectedValue = idEmpresa;
                selectedClientId = idCliente; 

            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                cnn.Modificaciones("exec sp_InsertarProveedor '" + txtName.Text + "', '" + txtTelefono.Text + "',' " + txtCorreo.Text + "', " + cmbEmpresa.SelectedValue + "");

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

                bool resultado = cnn.Modificaciones("exec sp_EliminarProveedor '" + selectedClientId + "'"); 

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

                    bool resultado = cnn.Modificaciones("exec sp_ActualizarProveedor '" + selectedClientId + "','" + txtName.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "', " + cmbEmpresa.SelectedValue + "");

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
                string comando = "exec sp_ConsultarProveedores @nombre = '" + busqueda + "'";
                cnn.Busquedas(comando, dataGridView1, "");
            }
        }
    }
}
