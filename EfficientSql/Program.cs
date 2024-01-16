using EfficientSql;
using System.Diagnostics;


internal class Program
{
    ///https://www.youtube.com/watch?v=sVoYqnGai_I
    private static void Main()
    {
        Console.WriteLine("Procesando");

        var ruta = @"C:\Users\ASUS\source\repos\DiezMillonesDemo\DiezMillonesDemo\data.txt";

        // Calentamiento
        Utilidades.Calentamiento(ruta);

        Utilidades.CrearArchivoConDatos(10_000_000, ruta);

        Console.WriteLine("Insertando los datos en SQL Server");

        EfficientWay(ruta);
        InefficientWay(ruta);

        Console.WriteLine("Fin");
    }

    private static void InefficientWay(string ruta)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Console.WriteLine("--Proceso ineficiente--");
        CodigoIneficiente.InsertarDatos(ruta);

        sw.Stop();

        Console.WriteLine($"Duración: {sw.ElapsedMilliseconds} mseg");
    }

    private static void EfficientWay(string ruta)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Console.WriteLine("--Proceso eficiente--");
        CodigoEficiente.InsertarDatos(ruta);

        sw.Stop();
        Console.WriteLine($"Duración: {sw.ElapsedMilliseconds} mseg");
    }
}