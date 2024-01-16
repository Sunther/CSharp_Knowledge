using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EfficientSearchValue;
using System.Diagnostics;

[RPlotExporter]
public class Program
{
    /// <summary>
    /// https://github.com/dotnet/BenchmarkDotNet?tab=readme-ov-file
    /// </summary>
    public static void Main()
    {
        InefficientWay("dQw4w9WgXcQ");
        EfficientWay("dQw4w9WgXcQ");

        BenchmarkRunner.Run<BenchmarkSearchValue>();
    }

    public static void InefficientWay(string value)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        //var resultInefficient = value.AsSpan().IndexOfAnyExcept(base64) == -1;
        var resultInefficient = !value.AsSpan().ContainsAnyExcept(Constants.Base64);
        stopWatch.Stop();
        Console.WriteLine($"IsBase64?: {resultInefficient} | {stopWatch.ElapsedMilliseconds} mseg");
    }
    public static void EfficientWay(string value)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        //var resultEfficient = !value.AsSpan().ContainsAnyExcept(base64SearchValues);
        var resultEfficient = value.AsSpan().IndexOfAnyExcept(Constants.Base64SearchValues) == -1;
        stopWatch.Stop();
        Console.WriteLine($"IsBase64?: {resultEfficient} | {stopWatch.ElapsedMilliseconds} mseg");
    }
}