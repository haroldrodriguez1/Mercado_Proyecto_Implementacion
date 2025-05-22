using Microsoft.Reporting.WinForms;
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
    public partial class ImprimirFactura : Form
    {
        private int _idFactura;
        public ImprimirFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
        }

        private void ImprimirFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.sp_ImprimirFactura' Puede moverla o quitarla según sea necesario.
            this.sp_ImprimirFacturaTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.sp_ImprimirFactura,_idFactura);


            this.reportViewer1.RefreshReport();
        }
    }
}
