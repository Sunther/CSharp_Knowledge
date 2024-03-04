using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ParallelLinq;

[MemoryDiagnoser(true)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class BenchmarkLinq
{
    [Benchmark]
    public void Simple_Linq()
    {
        var collection = Enumerable.Range(0, 10)
                            .Select(HeavyComputation);
                            //.ForAll(i => {});
    }
    [Benchmark]
    public void Parallel_Linq()
    {
        var cancelation = new CancellationTokenSource();

        var collection = Enumerable.Range(0, 10)
                                .AsParallel()
                                .WithCancellation(cancelation.Token)
                                .AsOrdered()
                                .WithDegreeOfParallelism(2)
                            .Select(HeavyComputation);
                            //.ForAll(i => {});
    }
    [Benchmark]
    public void Parallel_Linq_With_Degree()
    {
        var collection = ParallelEnumerable.Range(0, 10)
                                .AsOrdered()
                                .WithDegreeOfParallelism(2)
                            .Select(HeavyComputation);
                            //.ForAll(i => {});
    }

    private int HeavyComputation(int n)
    {
        for (int i = 0; i < 100_000_000; i++)
        {
            n += i;
        }

        return n;
    }
}