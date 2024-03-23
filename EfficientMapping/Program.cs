using BenchmarkDotNet.Running;
using EfficientMapping.Benchmarks;

namespace EfficientMapping;

public class Program
{
    /// <summary>
    /// https://github.com/riok/mapperly?tab=readme-ov-file
    /// Mapperly
    /// </summary>
    public static void Main()
    {
        BenchmarkRunner.Run<MappingBenchmark>();
    }
}
