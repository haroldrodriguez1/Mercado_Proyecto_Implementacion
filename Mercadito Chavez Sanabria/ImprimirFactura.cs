using Microsoft.Reporting.WinForms;  // Importa el espacio de nombres para trabajar con ReportViewer
using System;                        // Importa el espacio de nombres básico del sistema
using System.Collections.Generic;   // Importa colecciones genéricas (no usado explícito aquí)
using System.ComponentModel;        // Importa para componentes (no usado explícito aquí)
using System.Data;                  // Importa para manejo de datos (no usado explícito aquí)
using System.Drawing;               // Importa para gráficos (no usado explícito aquí)
using System.Linq;                  // Importa para LINQ (no usado explícito aquí)
using System.Text;                  // Importa para manejo de texto (no usado explícito aquí)
using System.Threading.Tasks;      // Importa para tareas asíncronas (no usado explícito aquí)
using System.Windows.Forms;        // Importa para Windows Forms

namespace Mercadito_Chavez_Sanabria  // Define el namespace del proyecto
{
    public partial class ImprimirFactura : Form  // Define clase parcial ImprimirFactura que hereda de Form
    {
        private int _idFactura;  // Campo privado para almacenar el ID de la factura a imprimir

        public ImprimirFactura(int idFactura)  // Constructor de la clase que recibe el ID de la factura
        {
            InitializeComponent();  // Inicializa los componentes del formulario
            _idFactura = idFactura; // Asigna el ID de factura recibido al campo privado
        }

        private void ImprimirFactura_Load(object sender, EventArgs e)  // Evento Load del formulario ImprimirFactura
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.sp_ImprimirFactura' Puede moverla o quitarla según sea necesario.
            this.sp_ImprimirFacturaTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.sp_ImprimirFactura, _idFactura);  // Llena el DataSet con la factura específica usando el ID

            this.reportViewer1.RefreshReport();  // Actualiza el control ReportViewer para mostrar los datos cargados
        }
    }
}
