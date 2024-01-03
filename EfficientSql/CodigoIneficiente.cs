using System.Data;
using System.Data.SqlClient;

namespace EfficientSql
{
    internal class CodigoIneficiente
    {
        public static void InsertarDatos(string ruta)
        {
            using (SqlConnection conexion = new SqlConnection("Server=.;Database=MillonesDeRegistrosDB;Integrated Security=true;TrustServerCertificate=True"))
            {
                using (SqlCommand comando = new SqlCommand("Valores_InsertarListado", conexion))
                {
                    DataTable dt = ArmarDataTable(ruta);
                    comando.CommandType = CommandType.StoredProcedure;
                    var param = comando.Parameters.AddWithValue("ListadoValores", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        private static DataTable ArmarDataTable(string ruta)
        {
            var dt = new DataTable();
            dt.Columns.Add("valor", typeof(string));

            StreamReader? _FileReader = null;

            try
            {
                _FileReader = new StreamReader(ruta);

                while (!_FileReader.EndOfStream)
                {
                    dt.Rows.Add(_FileReader.ReadLine());
                }
            }
            finally
            {
                _FileReader?.Close();
            }

            return dt;
        }
    }
}
