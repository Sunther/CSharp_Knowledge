using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Collections.Frozen;

namespace EfficientSearchValue
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class BenchmarkSearchValue
    {
        public IEnumerable<FrozenSet<char>> FrozenExamples()
        {
            yield return First_Example_FrozenSet();
            yield return Second_Example_FrozenSet();
        }
        private FrozenSet<char> First_Example_FrozenSet()
        {
            return "dQw4w9WgXcQ".ToArray().ToFrozenSet();
        }
        private FrozenSet<char> Second_Example_FrozenSet()
        {
            return "6iFbuI^pe68k".ToArray().ToFrozenSet();
        }

        [GlobalSetup]
        public void Setup() { }
        [GlobalCleanup]
        public void CleanUp() { }

        [Benchmark]
        [Arguments("dQw4w9WgXcQ")]
        [Arguments("6iFbuI^pe68k")]
        public bool InefficientWay(string exampleText)
        {
            return !exampleText.AsSpan().ContainsAnyExcept(Constants.Base64);
        }
        [Benchmark]
        [Arguments("dQw4w9WgXcQ")]
        [Arguments("6iFbuI^pe68k")]
        public bool EfficientWay(string exampleText)
        {
            return !exampleText.AsSpan().ContainsAnyExcept(Constants.Base64SearchValues);
        }
        [Benchmark]
        [Arguments('a')]
        [Arguments('^')]
        public bool FrozenWay_SimpleSearch(char find)
        {
            return Constants.Base64Frozen.Contains(find);
        }
        [Benchmark]
        [ArgumentsSource(nameof(FrozenExamples))]
        public bool FrozenWay(FrozenSet<char> collection)
        {
            return collection.All(Constants.Base64Frozen.Contains);
        }
    }
}
