// Importa los espacios de nombres necesarios para trabajar con formularios, controles, datos, gráficos, etc.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Define el espacio de nombres del proyecto
namespace Mercadito_Chavez_Sanabria
{
    // Define la clase parcial 'ComprasProveedor' que hereda de 'Form'
    public partial class ComprasProveedor : Form
    {
        // Constructor de la clase 'ComprasProveedor'
        public ComprasProveedor()
        {
            InitializeComponent(); // Llama al método que inicializa todos los componentes del formulario
        }

        // Evento que se ejecuta cuando el formulario 'ComprasProveedor' se carga
        private void ComprasProveedor_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.Reporte_ComprasPorProveedor' Puede moverla o quitarla según sea necesario.
            this.reporte_ComprasPorProveedorTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.Reporte_ComprasPorProveedor); // Llama al método Fill del adaptador para llenar el dataset con los datos del reporte

            this.reportViewer1.RefreshReport(); // Refresca el control ReportViewer para mostrar el reporte actualizado
        }

        // Evento que se ejecuta cuando el usuario hace clic en el botón 'btnRegresar'
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual

            Form n = new REPORTES(); // Crea una nueva instancia del formulario 'REPORTES'

            n.Show(); // Muestra el formulario 'REPORTES'
        }
    }
}
