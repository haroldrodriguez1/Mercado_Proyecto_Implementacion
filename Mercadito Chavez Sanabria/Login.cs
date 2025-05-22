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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        Conexion cnn = new Conexion();

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            string usuario = textBox1.Text.Trim();
            string contrasena = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resultado = cnn.IniciarSesion(usuario, contrasena);

            if (resultado == 1)
            {
                GlobalVariable.UsuarioRol = 1;
                this.Hide();
                Form n = new MENU();
                n.Show();
                
            }
             if (resultado == 2)
            {
                MessageBox.Show("Usuario tipo ADMINISTRADOR esta inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (resultado ==3 )
            {
                GlobalVariable.UsuarioRol = 0;
                this.Hide();
                Form n = new MENU();
                n.Show();
                

            }
            if (resultado ==4)
            {
                MessageBox.Show("Usuario tipo CAJERO esta inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (resultado == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
    }

