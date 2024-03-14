using CachingSystem.CachingDistributed;
using CachingSystem.CachingInMemory;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("////////// In Memory example //////////");
        var exampleM = new InMemoryExample();
        exampleM.CacheExample();
        Console.WriteLine("////////// In Memory example //////////");


        Console.WriteLine("////////// Distribued example //////////");
        var exampleD = new DistributedExample();
        exampleD.CacheExample();
        Console.WriteLine("////////// Distribued example //////////");
    }
}