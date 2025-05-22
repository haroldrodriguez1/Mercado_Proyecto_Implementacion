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
    public partial class ProductosMasVendidos : Form
    {
        public ProductosMasVendidos()
        {
            InitializeComponent();
        }

        private void ProductosMasVendidos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet.ObtenerProductosMasVendidos' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosMasVendidosTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet.ObtenerProductosMasVendidos);

            this.reportViewer1.RefreshReport();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new REPORTES();
            n.Show();
        }
    }
}
