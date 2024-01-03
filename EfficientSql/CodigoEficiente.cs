using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.SqlClient;

namespace EfficientSql
{
    public class CodigoEficiente
    {
        public static void InsertarDatos(string ruta)
        {
            var connString = "Server=.;Database=MillonesDeRegistrosDB;Integrated Security=true;TrustServerCertificate=True";
            using (var conexion = new SqlConnection(connString))
            {
                using (var comando = new SqlCommand("Valores_InsertarListado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlParameter parametro = new SqlParameter("@ListadoValores", SqlDbType.Structured);
                    parametro.TypeName = "dbo.ListadoValores";
                    parametro.Value = ObtenerContenidoArchivo(ruta);
                    comando.Parameters.Add(parametro);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        private static IEnumerable<SqlDataRecord> ObtenerContenidoArchivo(string ruta)
        {
            var esquema = new SqlMetaData[] {
                new SqlMetaData("valor", SqlDbType.NVarChar, 100)
            };

            var dataRecord = new SqlDataRecord(esquema);
            using (var reader = new StreamReader(ruta))
            {
                while (!reader.EndOfStream)
                {
                    dataRecord.SetString(0, reader.ReadLine());
                    yield return dataRecord;
                }
            }
        }

    }
}
