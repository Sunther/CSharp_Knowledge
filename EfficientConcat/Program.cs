using Microsoft.Extensions.ObjectPool;
using System.Diagnostics;
using System.Text;

namespace EfficientConcat
{
    public class Program
    {
        private readonly static IEnumerable<int> _naturalNumbers = Enumerable.Range(1, 10000);

        public static void Main()
        {
            UsingConcat();
            UsingStringBuilder();
            UsingObjectPool();
        }

        private static void UsingConcat()
        {
            var sw = new Stopwatch();
            sw.Start();
            var naturalString = string.Empty;

            foreach (int item in _naturalNumbers)
            {
                if (item % 2 == 0)
                {
                    naturalString += $"{item} is Even";
                }
                else
                {
                    naturalString += $"{item} is Odd";
                }
            }
            sw.Stop();

            Console.WriteLine($"{nameof(UsingConcat)} {sw.ElapsedMilliseconds} mseg");
        }
        private static void UsingStringBuilder()
        {
            var sw = new Stopwatch();
            sw.Start();
            var naturalStringBuilder = new StringBuilder();

            foreach (int item in _naturalNumbers)
            {
                if (item % 2 == 0)
                {
                    naturalStringBuilder.Append($"{item} is Even");
                }
                else
                {
                    naturalStringBuilder.Append($"{item} is Odd");
                }
            }
            sw.Stop();

            Console.WriteLine($"{nameof(UsingStringBuilder)} {sw.ElapsedMilliseconds} mseg");
        }
        /// <summary>
        /// Microsoft.Extensions.ObjectPool is part of the ASP.NET Core infrastructure that supports keeping a group of objects in memory for reuse rather than allowing the objects to be garbage collected. All the static and instance methods in Microsoft.Extensions.ObjectPool are thread-safe.
        ///Apps might want to use the object pool if the objects that are being managed are:
        ///Expensive to allocate/initialize.
        ///Represent a limited resource.
        ///Used predictably and frequently.
        /// </summary>
        private static void UsingObjectPool()
        {
            var sw = new Stopwatch();
            sw.Start();
            ObjectPool<StringBuilder> stringBuilderPool = new DefaultObjectPoolProvider().CreateStringBuilderPool();
            var stringBuilder = stringBuilderPool.Get();

            foreach (int item in _naturalNumbers)
            {
                if (item % 2 == 0)
                {
                    stringBuilder.Append($"{item} is Even");
                }
                else
                {
                    stringBuilder.Append($"{item} is Odd");
                }
            }
            sw.Stop();

            Console.WriteLine($"{nameof(UsingObjectPool)} {sw.ElapsedMilliseconds} mseg");
        }
    }
}