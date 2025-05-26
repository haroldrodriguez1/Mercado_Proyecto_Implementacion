// Espacios de nombres necesarios para trabajar con datos, conexiones SQL y formularios
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

// Espacio de nombres del proyecto
namespace Mercadito_Chavez_Sanabria
{
    // Clase interna Conexion: encapsula toda la lógica de conexión a la base de datos
    internal class Conexion
    {
        // Método para ejecutar consultas y devolver un DataSet
        public DataSet Consultas(string Comando)
        {
            DataSet Cons = new DataSet(); // DataSet que se retornará
            DataSet Dsa = new DataSet();  // DataSet temporal

            // Conexión a la base de datos
            SqlConnection CnnSql = new SqlConnection("Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true");

            // Adaptador que ejecuta el comando SQL
            SqlDataAdapter DA = new SqlDataAdapter(Comando, CnnSql);

            // Llenado del DataSet temporal con los resultados
            DA.Fill(Dsa, "Tabla");

            // Asignación del DataSet a retornar
            Cons = Dsa;

            // Liberación de recursos
            DA.Dispose();
            Dsa.Dispose();
            CnnSql.Dispose();

            return Cons;
        }

        // Método para obtener el último ID de una tabla
        public int ObtenerUltimoId(string nombreTabla, string campo)
        {
            int ultimoId = 0;

            try
            {
                string consulta = $"SELECT MAX({campo}) FROM {nombreTabla}";

                using (SqlConnection conn = new SqlConnection("Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true"))
                {
                    conn.Open(); // Abre la conexión

                    using (SqlCommand cmd = new SqlCommand(consulta, conn))
                    {
                        var result = cmd.ExecuteScalar(); // Ejecuta la consulta y obtiene un solo valor

                        // Si el resultado es null (tabla vacía), devuelve 0, si no, lo convierte a int
                        ultimoId = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ultimoId;
        }

        // Método para ejecutar comandos de modificación (insertar, actualizar, eliminar)
        public bool Modificaciones(string Comando)
        {
            SqlConnection CnnSql = new SqlConnection("Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true");
            SqlCommand Cmp = new SqlCommand(Comando, CnnSql);

            CnnSql.Open();        // Abre la conexión
            Cmp.ExecuteNonQuery(); // Ejecuta el comando (sin retorno de resultados)
            Cmp.Dispose();        // Libera recursos
            CnnSql.Dispose();     // Libera recursos

            return true; // Retorna éxito
        }

        // Método para cargar resultados en un DataGridView desde un procedimiento o consulta
        public void ConsultasGrid(string comando, DataGridView datagridview1)
        {
            DataSet dsa = new DataSet();
            SqlConnection CnnSql = new SqlConnection("Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true");
            SqlDataAdapter DA1 = new SqlDataAdapter(comando, CnnSql);
            DA1.Fill(dsa, "Tabla");
            datagridview1.DataSource = dsa.Tables[0]; // Asigna los datos al control
            dsa.Dispose();
            DA1.Dispose();
            CnnSql.Dispose();
        }

        // Método para realizar búsquedas con filtro en un DataGridView
        public void Busquedas(string Comando, DataGridView grid, string Columna)
        {
            DataSet dsa = new DataSet();
            BindingSource bs = new BindingSource();
            DataTable dt = new DataTable();

            string strConn = "Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true";
            SqlConnection CnnSql = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter(Comando, CnnSql);
            da.Fill(dt);

            bs.DataSource = dt.DefaultView;
            grid.DataSource = bs;

            DataSet ds = new DataSet();
            ds.Tables.Add(dt.Copy());

            // Filtro por columna (aunque no se está usando correctamente aquí)
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = Columna;

            // Si hay resultados, mostrar; si no, limpiar el grid
            if (dv.Count != 0)
            {
                grid.DataSource = dv;
            }
            else
            {
                grid.DataSource = null;
            }
        }

        // Método para realizar búsquedas por rango de fechas con un procedimiento almacenado
        public void BusquedasDate(string procedimiento, DataGridView grid, string columna, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            string strConn = "Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true";

            using (SqlConnection CnnSql = new SqlConnection(strConn))
            {
                CnnSql.Open();

                using (SqlCommand cmd = new SqlCommand(procedimiento, CnnSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = fechaInicio;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = fechaFin;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt); // Llenado del datatable
                }
            }

            grid.DataSource = dt; // Se asignan los datos al grid
        }

        // Método para iniciar sesión usando procedimiento almacenado
        public int IniciarSesion(string usuario, string contrasena)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=localhost; Initial Catalog=Mercado_Chavez_Sanabria; Integrated Security=true"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NomUsr", usuario);
                    cmd.Parameters.AddWithValue("@ConUsr", contrasena);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar()); // Retorna resultado del SP
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }
    }
}
