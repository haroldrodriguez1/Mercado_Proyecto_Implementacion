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
    public partial class REPORTES : Form
    {
        public REPORTES()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new MENU();
            n.Show();
        }

        private void btnMasVendidos_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new ProductosMasVendidos();
            n.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new ClientesFrecuentes();
            n.Show();
        }

        private void btnComprasProveedor_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new ComprasProveedor();
            n.Show();
        }

        private void btnComprasEmpleados_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new ComprasEmpleados();
            n.Show();
        }

        private void btnFactAnuladas_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new FacturasAnuladas();
            n.Show();
        }

        private void btnIngresosCategoria_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new IngresosCategoria();
            n.Show();
        }

        private void btnProductosBajoStock_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new ProductosBajoStock();
            n.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new VentasPorFechaReporte();
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new VerCompras();
            n.Show();
        }

        private void REPORTES_Load(object sender, EventArgs e)
        {
            if(GlobalVariable.UsuarioRol==0)
            {
                btnComprasEmpleados.Enabled = false;
                btnFactAnuladas.Enabled = false;
                btnIngresosCategoria.Enabled = false;
                btnVentas.Enabled = false;
            }
        }
    }
}
