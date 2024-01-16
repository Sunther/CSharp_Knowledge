using BenchmarkDotNet.Attributes;

namespace EfficientSearchValue
{
    [RPlotExporter]
    public class BenchmarkSearchValue
    {
        [Params("dQw4w9WgXcQ", "6iFbuI^pe68k")]
        public required string ExampleText { get; set; }

        [Benchmark]
        public bool InefficientWay()
        {
            return !ExampleText.AsSpan().ContainsAnyExcept(Constants.Base64);
        }

        [Benchmark]
        public bool EfficientWay()
        {
            return !ExampleText.AsSpan().ContainsAnyExcept(Constants.Base64SearchValues);
        }
    }
}
