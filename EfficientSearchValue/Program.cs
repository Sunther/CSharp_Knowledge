using BenchmarkDotNet.Running;
using EfficientSearchValue;
using System.Collections.Frozen;
using System.Diagnostics;

public class Program
{
    private static BenchmarkSearchValue _benchmarkSearchValue { get; }

    static Program()
    {
        _benchmarkSearchValue = new BenchmarkSearchValue();
    }

    /// <summary>
    /// https://github.com/dotnet/BenchmarkDotNet?tab=readme-ov-file
    /// </summary>
    public static void Main()
    {
        //InefficientWay("dQw4w9WgXcQ");
        //EfficientWay("dQw4w9WgXcQ");
        //FrozenWay("d");

        BenchmarkRunner.Run<BenchmarkSearchValue>();
    }

    public static void InefficientWay(string value)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var resultInefficient = _benchmarkSearchValue.InefficientWay(value);
        stopWatch.Stop();
        Console.WriteLine($"{nameof(InefficientWay)}-IsBase64?: {resultInefficient} | {stopWatch.ElapsedTicks} ticks");
    }
    public static void EfficientWay(string value)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var resultEfficient = _benchmarkSearchValue.EfficientWay(value);
        stopWatch.Stop();
        Console.WriteLine($"{nameof(EfficientWay)}-IsBase64?:   {resultEfficient} | {stopWatch.ElapsedTicks} ticks");
    }
    public static void FrozenWay(char value)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var resultEfficient = _benchmarkSearchValue.FrozenWay_SimpleSearch(value);
        stopWatch.Stop();
        Console.WriteLine($"{nameof(FrozenWay)}-IsBase64?:      {resultEfficient} | {stopWatch.ElapsedTicks} ticks");
    }
}