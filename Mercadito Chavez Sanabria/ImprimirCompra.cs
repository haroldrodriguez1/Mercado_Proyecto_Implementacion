using System;                      // Importa el espacio de nombres básico del sistema
using System.Collections.Generic;  // Importa colecciones genéricas (no usado explícito aquí)
using System.ComponentModel;       // Importa para componentes (no usado explícito aquí)
using System.Data;                 // Importa para manejo de datos (no usado explícito aquí)
using System.Drawing;              // Importa para gráficos (no usado explícito aquí)
using System.Linq;                 // Importa para LINQ (no usado explícito aquí)
using System.Text;                 // Importa para manejo de texto (no usado explícito aquí)
using System.Threading.Tasks;     // Importa para tareas asíncronas (no usado explícito aquí)
using System.Windows.Forms;       // Importa para Windows Forms

namespace Mercadito_Chavez_Sanabria  // Define el namespace del proyecto
{
    public partial class ImprimirCompra : Form  // Define clase parcial ImprimirCompra que hereda de Form
    {
        private int _compraId;  // Campo privado para almacenar el ID de la compra a imprimir

        public ImprimirCompra(int compraId)  // Constructor de la clase que recibe el ID de la compra
        {
            InitializeComponent();  // Inicializa los componentes del formulario
            _compraId = compraId;   // Asigna el ID de compra recibido al campo privado
        }

        private void ImprimirCompra_Load(object sender, EventArgs e)  // Evento Load del formulario ImprimirCompra
        {
            // TODO: esta línea de código carga datos en la tabla 'mercado_Chavez_SanabriaDataSet6local.sp_ImprimirCompra' Puede moverla o quitarla según sea necesario.
            this.sp_ImprimirCompraTableAdapter.Fill(this.mercado_Chavez_SanabriaDataSet6local.sp_ImprimirCompra, _compraId);  // Llena el DataSet con la compra específica usando el ID

            this.reportViewer1.RefreshReport();  // Actualiza el control ReportViewer para mostrar los datos cargados
        }
    }
}
