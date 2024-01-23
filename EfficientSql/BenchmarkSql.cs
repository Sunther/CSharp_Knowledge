using BenchmarkDotNet.Attributes;
using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.SqlClient;

namespace EfficientSql
{
    [MemoryDiagnoser]
    public class BenchmarkSql
    {
        const string ConnectionString = "Server=.;Database=MillonesDeRegistrosDB;Integrated Security=true;TrustServerCertificate=True";

        public BenchmarkSql()
        {
            if (File.Exists(Program.Path))
            {
                File.Delete(Program.Path);
            }

            using (var writer = new StreamWriter(Program.Path, append: true))
            {
                for (int i = 1; i <= 10_000_000; i++)
                {
                    writer.WriteLine($"valor {i}");
                }
            }
        }

        [Benchmark]
        public void StoreProcedure_DataTable()
        {
            using (var conexion = new SqlConnection(ConnectionString))
            {
                using (var comando = new SqlCommand("Valores_InsertarListado", conexion))
                {
                    DataTable dt = ConstructDataTable();
                    comando.CommandType = CommandType.StoredProcedure;
                    var param = comando.Parameters.AddWithValue("ListadoValores", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        [Benchmark]
        public void StoreProcedure_EnumerableWay()
        {
            using (var conexion = new SqlConnection(ConnectionString))
            {
                using (var comando = new SqlCommand("Valores_InsertarListado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    var parametro = new SqlParameter("@ListadoValores", SqlDbType.Structured)
                    {
                        TypeName = "dbo.ListadoValores",
                        Value = ConstructEnumerable()
                    };
                    comando.Parameters.Add(parametro);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
        private static IEnumerable<SqlDataRecord> ConstructEnumerable()
        {
            var esquema = new SqlMetaData[] {
                new SqlMetaData("valor", SqlDbType.NVarChar, 100)
            };

            var dataRecord = new SqlDataRecord(esquema);
            using (var reader = new StreamReader(Program.Path))
            {
                while (!reader.EndOfStream)
                {
                    dataRecord.SetString(0, reader.ReadLine());
                    yield return dataRecord;
                }
            }
        }
        private static DataTable ConstructDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("valor", typeof(string));

            StreamReader? _FileReader = null;

            try
            {
                _FileReader = new StreamReader(Program.Path);

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
