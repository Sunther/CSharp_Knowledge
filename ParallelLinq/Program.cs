using BenchmarkDotNet.Running;
using ParallelLinq;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<BenchmarkLinq>();
    }
}