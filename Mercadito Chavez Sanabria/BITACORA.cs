using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Define un espacio de nombres llamado 'Mercadito_Chavez_Sanabria'
namespace Mercadito_Chavez_Sanabria
{
    // Declara una clase parcial llamada 'BITACORA' que hereda de 'Form'
    public partial class BITACORA : Form
    {
        // Crea una instancia de la clase 'Conexion' llamada 'cnn'
        Conexion cnn = new Conexion();

        // Constructor de la clase 'BITACORA'
        public BITACORA()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
        }

        // Evento que se ejecuta cuando se hace clic en el botón 'btnRegresar'
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual
            this.Close();
            // Crea una nueva instancia del formulario 'MENU'
            Form n = new MENU();
            // Muestra el formulario 'MENU'
            n.Show();
        }

        // Evento que se ejecuta cuando el formulario 'BITACORA' se carga
        private void BITACORA_Load(object sender, EventArgs e)
        {
            // Ejecuta un procedimiento almacenado 'sp_ConsultarBitacora' y muestra el resultado en 'dataGridView1'
            cnn.ConsultasGrid("exec sp_ConsultarBitacora", dataGridView1);
        }
    }
}

