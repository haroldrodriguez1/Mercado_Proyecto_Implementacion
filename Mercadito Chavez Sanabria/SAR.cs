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
    public partial class SAR : Form
    {
        public SAR()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }
        private void Empleados_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            CargarDatos();
        }

       
        Conexion cnn = new Conexion();
        int selectedClientId = 0;
        string cai = "";
        string rangoinicio = "";
        string rangofin = "";
        
        private void CargarDatos()
        {
            cnn.ConsultasGrid("exec sp_ConsultarSar", dataGridView1);
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(txtCai.Text) ||
                string.IsNullOrWhiteSpace(txtRangoFin.Text) ||
                string.IsNullOrWhiteSpace(txtRangoInicio.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtRangoInicio.Text, out _))
            {
                MessageBox.Show("El campo Telefono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Clear()
        {
            txtRangoFin.Clear();
            txtCai.Clear();
            txtRangoInicio.Clear();
        }
        private void EditarImg_Click(object sender, EventArgs e)
        {
            btnEditar.PerformClick();
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
                txtCai.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                txtRangoInicio.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                txtRangoFin.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

                selectedClientId = idCliente;
               
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Check())
            {

                DateTime fechaLimite = dateTimePicker1.Value;
                cnn.Modificaciones("exec sp_InsertarSar '" + txtCai.Text + "','" + txtRangoInicio.Text + "','" + txtRangoFin.Text + "','" + fechaLimite.ToString("yyyy-MM-dd") + "'");

                CargarDatos();
                OcultarBotones();
                Clear();
            }

        }

      
        private void OcultarBotones()
        {
            btnEditar.Visible = false;
            pictureBox1.Visible = false;
        }
        private void MostrarBotones()
        {
            pictureBox1.Visible = true;
        
            btnEditar.Visible = true;
     
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedClientId > 0)
            {

                bool resultado = cnn.Modificaciones("exec sp_EliminarSar '" + selectedClientId + "'"); 

                if (resultado)
                {
                    MessageBox.Show("Registro SAR eliminado exitosamente.");
                    CargarDatos();
                    OcultarBotones();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el Registro SAR.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Registro SAR para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                
                if (selectedClientId > 0)
                {

                    DateTime fechaLimite = dateTimePicker1.Value;
                    bool resultado = cnn.Modificaciones("exec sp_ActualizarSar '" + selectedClientId + "','" + txtCai.Text + "','" + txtRangoInicio.Text + "','" + txtRangoFin.Text + "','" + fechaLimite.ToString("yyyy-MM-dd") + "'");

                    if (resultado)
                    {
                        MessageBox.Show("Registro SAR editado exitosamente.");
                        CargarDatos();
                        OcultarBotones();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al editar el Registro SAR.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un Registro SAR para editar.");
                }
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
