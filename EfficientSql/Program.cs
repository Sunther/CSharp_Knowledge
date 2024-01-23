using BenchmarkDotNet.Running;
using EfficientSql;

internal class Program
{
    public const string Path = @".\data.txt";

    ///https://www.youtube.com/watch?v=sVoYqnGai_I
    private static void Main()
    {
        BenchmarkRunner.Run<BenchmarkSql>();
    }
}