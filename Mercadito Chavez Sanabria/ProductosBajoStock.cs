using Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6TableAdapters;
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
    public partial class ProductosBajoStock : Form
    {
        public ProductosBajoStock()
        {
            InitializeComponent();
        }

        private void ProductosBajoStock_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.Reporte_ProductosBajoStock' Puede moverla o quitarla según sea necesario.
            this.reporte_ProductosBajoStockTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_ProductosBajoStock,10);



            reportViewer1.RefreshReport();



        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form n = new REPORTES();
            n.Show();
        }
    }
}
