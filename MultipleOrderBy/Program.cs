using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace MultipleOrderBy
{
    public static class Program
    {
        private static readonly BenchmarkOrderBy _benchmarkOrderBy;

        static Program()
        {
            _benchmarkOrderBy = new BenchmarkOrderBy();
        }

        public static void Main()
        {
            //OrderBy();
            //ThenBy();

            BenchmarkRunner.Run<BenchmarkOrderBy>();
        }

        private static void OrderBy()
        {

            var sw = new Stopwatch();
            sw.Start();
            //_benchmarkOrderBy.MultipleOrderBy(_benchmarkOrderBy.GetEnumerable());
            sw.Stop();

            Console.WriteLine($"Time with OrderBy:  {sw.ElapsedTicks} ticks");
        }

        private static void ThenBy()
        {
            var sw = new Stopwatch();
            sw.Start();
            //_benchmarkOrderBy.OrderBy_ThenBy(_benchmarkOrderBy.GetEnumerable());
            sw.Stop();

            Console.WriteLine($"Time with ThenBy:   {sw.ElapsedTicks} ticks");
        }
    }
}