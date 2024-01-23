using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Runtime.InteropServices;

namespace EfficientLoop
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class BenchmarkLooper
    {
        private List<int> _List;

        [Params(1_000_000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _List = new List<int>();
            var random = new Random(420);
            for (int i = 0; i < Size; i++)
            {
                _List.Add(random.Next(0, 101));
            }
        }

        [Benchmark]
        public void For()
        {
            for (int i = 0; i < Size; i++)
            {
                var res = _List[i];
            }
        }

        [Benchmark]
        public void ForEach()
        {
            foreach (var element in _List) { }
        }

        [Benchmark]
        public void SpanFor()
        {
            Span<int> listSpan = CollectionsMarshal.AsSpan(_List);

            for (int i = 0; i < Size; i++)
            {
                var res = listSpan[i];
            }
        }

        [Benchmark]
        public void SpanForEach()
        {
            foreach (var element in CollectionsMarshal.AsSpan(_List)) { }
        }
    }
}
