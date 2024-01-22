using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MultipleOrderBy.DTOs;

namespace MultipleOrderBy
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class BenchmarkOrderBy
    {
        [Params(5, 100, 1_000)]
        public int Size { get; set; }

        ///<summary>
        /// Reorders the list twice
        /// The 𝗢𝗿𝗱𝗲𝗿𝗕𝘆 operator is used to sort a sequence of elements based on a specified key. When multiple OrderBy calls are chained together, each subsequent call completely reorders the list, DISCARDING THE RESULTS OF THE PREVIOUS CALL. This means that only the last OrderBy call will have any effect on the final ordering of the sequence.
        ///</summary>
        [Benchmark]
        public void MultipleOrderBy()
        {
            var _arrT = new List<Wrapper>();
            var random = new Random(420);
            for (int i = 0; i < Size; i++)
            {
                int randomName = random.Next(0, 101); // Generate a random number for Name between 0 and 100
                int randomPrice = random.Next(0, 1001); // Generate a random number for Price between 0 and 1000

                _arrT.Add(new Wrapper(randomName, randomPrice));
            }

            _ = _arrT
                    .OrderBy(item => item.Price)
                    .OrderBy(item => item.Name)
                    ;
        }
        [Benchmark]
        public void Sort()
        {
            var _arrT = new List<int>();
            var random = new Random(420);
            for (int i = 0; i < Size; i++)
            {
                int r = random.Next(0, 101); // Generate a random number for Name between 0 and 100

                _arrT.Add(r);
            }
            _arrT.Sort();
        }
        ///<summary>
        /// Reoders the list applying both criteria
        /// The 𝗧𝗵𝗲𝗻𝗕𝘆 method is used after the initial OrderBy to apply additional sorting conditions. This ensures that the data is sorted first by the first field (Name in this example), and then by the second field (Price in this example).
        ///</summary>
        [Benchmark]
        public void OrderBy_ThenBy()
        {
            var _arrT = new List<Wrapper>();
            var random = new Random(420);
            for (int i = 0; i < Size; i++)
            {
                int randomName = random.Next(0, 101); // Generate a random number for Name between 0 and 100
                int randomPrice = random.Next(0, 1001); // Generate a random number for Price between 0 and 1000

                _arrT.Add(new Wrapper(randomName, randomPrice));
            }
            _ = _arrT
                    .OrderBy(item => item.Name)
                    .ThenBy(item => item.Price)
                    ;
        }
    }
}
