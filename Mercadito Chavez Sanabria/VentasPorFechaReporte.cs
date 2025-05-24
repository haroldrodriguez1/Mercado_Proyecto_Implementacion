using Microsoft.Reporting.WinForms; // Importa el espacio de nombres para trabajar con ReportViewer de Windows Forms
using System; // Importa clases básicas del sistema
using System.Collections.Generic; // Importa clases para colecciones genéricas
using System.ComponentModel; // Importa clases para componentes
using System.Data; // Importa clases para acceso a datos
using System.Drawing; // Importa clases para gráficos y dibujo
using System.Linq; // Importa clases para consultas LINQ
using System.Text; // Importa clases para manipulación de texto
using System.Threading.Tasks; // Importa clases para programación asíncrona
using System.Windows.Forms; // Importa clases para crear interfaces Windows Forms

namespace Mercadito_Chavez_Sanabria // Define el namespace de la aplicación o proyecto
{
    public partial class VentasPorFechaReporte : Form // Clase parcial VentasPorFechaReporte que hereda de Form (ventana)
    {
        public VentasPorFechaReporte() // Constructor de la clase VentasPorFechaReporte
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario
        }

        private void VentasPorFechaReporte_Load(object sender, EventArgs e) // Evento Load del formulario VentasPorFechaReporte
        {
            // TODO: esta línea de código carga datos en la tabla 'ventasPorFechaDataSet.Reporte_VentasPorFecha' Puede moverla o quitarla según sea necesario.
            // Comentario generado automáticamente para indicar que normalmente aquí se cargan datos al dataset para el reporte

            this.reportViewer1.RefreshReport(); // Refresca el control ReportViewer para mostrar los datos actuales
        }

        private void btnGenerar_Click(object sender, EventArgs e) // Evento click del botón Generar
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date; // Obtiene la fecha inicial seleccionada en el DateTimePicker y le quita la hora
            DateTime fechaFin = dtpFechaFin.Value.Date; // Obtiene la fecha final seleccionada en el DateTimePicker y le quita la hora
            this.reporte_VentasPorFechaTableAdapter.Fill(this.ventasPorFechaDataSet.Reporte_VentasPorFecha, fechaInicio, fechaFin);
            // Llama al método Fill del TableAdapter para llenar el dataset con los datos del reporte entre las fechas seleccionadas

            reportViewer1.RefreshReport(); // Refresca el ReportViewer para mostrar el reporte actualizado con los datos filtrados
        }

        private void btnRegresar_Click(object sender, EventArgs e) // Evento click del botón Regresar
        {
            this.Close(); // Cierra el formulario actual
            Form n = new REPORTES(); // Crea una instancia del formulario REPORTES
            n.Show(); // Muestra el formulario REPORTES
        }
    }
}
