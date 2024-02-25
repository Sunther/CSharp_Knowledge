using Newtonsoft.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft
{
    internal class Program
    {
        static void Main()
        {
            var d = new DemoEntity()
            {
                Id = 1,
                Name = "test",
                Description = Enumerable.Empty<string>(),
                Tags = new Dictionary<string, string>()
            };

            Console.WriteLine(JsonConvert.SerializeObject(d));

            d = new DemoEntity()
            {
                Id = 1,
                Name = "test",
                Description = new List<string>() { "1", "2" },
                Tags = new Dictionary<string, string>()
            };

            Console.WriteLine(JsonConvert.SerializeObject(d));
        }
    }
}
