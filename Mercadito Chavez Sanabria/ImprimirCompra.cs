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
    public partial class ImprimirCompra : Form
    {
        private int _compraId;
        public ImprimirCompra(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
        }

        private void ImprimirCompra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.sp_ImprimirCompra' Puede moverla o quitarla según sea necesario.
            this.sp_ImprimirCompraTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.sp_ImprimirCompra,_compraId);

            this.reportViewer1.RefreshReport();
        }
    }
}
