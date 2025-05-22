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
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void mERCADOCHAVEZSANABRIAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
         


        private void MENU_Load(object sender, EventArgs e)
        {
            ImgClientes.TabStop = false;
            if (GlobalVariable.UsuarioRol == 0)
            {
                txtRol.Text = "Cajero";
                btnUsuarios.Enabled = false;
                btnEmpleados.Enabled = false;
                btnBitacoras.Enabled = false;
                btnVentas.Enabled = false;

            }
            else
            {
                txtRol.Text = "Administrador";
            }
            
        }


   

        private void ImgClientes_MouseDown(object sender, MouseEventArgs e)
        {
            btnClientes.Focus();
            btnClientes.PerformClick();
        }

        private void ImgEmpleados_MouseDown(object sender, MouseEventArgs e)
        {
            btnEmpleados.Focus();
            btnEmpleados.PerformClick();
        }

        private void ImgUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            btnUsuarios.Focus();
            btnUsuarios.PerformClick();
        }

        private void ImgProductos_MouseDown(object sender, MouseEventArgs e)
        {
            btnProductos.Focus();
            btnProductos.PerformClick();
        }

        private void ImgCategorias_MouseDown(object sender, MouseEventArgs e)
        {
            btnCategorias.Focus();
            btnCategorias.PerformClick();
        }

        private void ImgProveedores_MouseDown(object sender, MouseEventArgs e)
        {
            btnProveedores.Focus();
            btnProveedores.PerformClick();
        }

        private void ImgEmpresas_MouseDown(object sender, MouseEventArgs e)
        {
            btnEmpresas.Focus();
            btnEmpresas.PerformClick();
        }

        private void ImgVentas_MouseDown(object sender, MouseEventArgs e)
        {
            btnVentas.Focus();
            btnVentas.PerformClick();
        }

        private void ImgCompras_MouseDown(object sender, MouseEventArgs e)
        {
            btnFacturas.Focus();
            btnFacturas.PerformClick();
        }

        private void ImgCrearCompra_MouseDown(object sender, MouseEventArgs e)
        {
            BtnCompra.Focus();
            BtnCompra.PerformClick();
        }

        private void ImgBitacora_MouseDown(object sender, MouseEventArgs e)
        {
            btnBitacoras.Focus();
            btnBitacoras.PerformClick();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login n = new Login();
            this.Hide();
            n.Show();
        }

        private void MENU_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new CLIENTE();
            n.Show();
        }

        private void btnBitacoras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new BITACORA();
            n.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Empleados();
            n.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Usuarios();
            n.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Productos();
            n.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Categorías();
            n.Show();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Proveedores();
            n.Show();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Empresas();
            n.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new VerFacturas();
            n.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new CrearFacturas();
            n.Show();

        }

       

        private void ImgClientes_Click(object sender, EventArgs e)
        {

        }

        private void btnSar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new SAR();
            n.Show();
        }

        private void ImageSar_MouseDown(object sender, MouseEventArgs e)
        {
            btnSar.Focus();
            btnSar.PerformClick();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new REPORTES();
            n.Show();
        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form n = new CrearCompra();
            n.Show();
        }
    }
}
