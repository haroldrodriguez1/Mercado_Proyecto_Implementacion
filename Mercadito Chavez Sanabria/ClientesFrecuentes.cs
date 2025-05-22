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
    public partial class ClientesFrecuentes : Form
    {
        public ClientesFrecuentes()
        {
            InitializeComponent();
        }

        private void ClientesFrecuentes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.Reporte_ClientesFrecuentes' Puede moverla o quitarla según sea necesario.
            this.reporte_ClientesFrecuentesTableAdapter1.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_ClientesFrecuentes);
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6.Reporte_ClientesFrecuentes' Puede moverla o quitarla según sea necesario.

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
