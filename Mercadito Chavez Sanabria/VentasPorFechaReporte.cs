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
    public partial class VentasPorFechaReporte : Form
    {
        public VentasPorFechaReporte()
        {
            InitializeComponent();
        }

        private void VentasPorFechaReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ventasPorFechaDataSet.Reporte_VentasPorFecha' Puede moverla o quitarla según sea necesario.



            this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            this.reporte_VentasPorFechaTableAdapter.Fill(this.ventasPorFechaDataSet.Reporte_VentasPorFecha,fechaInicio, fechaFin );

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
