using BenchmarkDotNet.Attributes;
using MultipleOrderBy.DTOs;

namespace MultipleOrderBy
{
    [RPlotExporter]
    public class BenchmarkOrderBy
    {
        static Wrapper[] ArrT = new Wrapper[]
                                {
                                      new() { Name = 1, Price = 2 },
                                      new() { Name = 0, Price = 1 },
                                      new() { Name = 2, Price = 1 },
                                      new() { Name = 2, Price = 0 },
                                      new() { Name = 0, Price = 2 },
                                      new() { Name = 0, Price = 3 },
                                };

        [Benchmark]
        ///<summary>
        /// Reorders the list twice
        /// The 𝗢𝗿𝗱𝗲𝗿𝗕𝘆 operator is used to sort a sequence of elements based on a specified key. When multiple OrderBy calls are chained together, each subsequent call completely reorders the list, DISCARDING THE RESULTS OF THE PREVIOUS CALL. This means that only the last OrderBy call will have any effect on the final ordering of the sequence
        ///</summary>
        public IOrderedEnumerable<Wrapper> WrongWay_MultipleOrderBy()
        {
            return ArrT.OrderBy(item => item.Name)
                            .OrderBy(item => item.Price);
        }

        [Benchmark]
        ///<summary>
        /// Reoders the list applying both criteria
        /// The 𝗧𝗵𝗲𝗻𝗕𝘆 method is used after the initial OrderBy to apply additional sorting conditions. This ensures that the data is sorted first by the first field (Name in this example), and then by the second field (Price in this example).
        /// The 𝗧𝗵𝗲𝗻𝗕𝘆 method in C# can be used to chain multiple sorting criteria together, without the performance overhead of calling OrderBy multiple times.
        ///</summary>
        public IOrderedEnumerable<Wrapper> RightWay_MultipleOrderBy()
        {
            return ArrT.OrderBy(item => item.Name)
                            .ThenBy(item => item.Price);
        }
    }
}
