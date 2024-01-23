using BenchmarkDotNet.Running;
using EfficientLoop;

internal class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run<BenchmarkLooper>();
    }
}