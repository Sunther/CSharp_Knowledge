using Decorator.Contracts;
using Decorator.Extensions;
using Decorator.Implementation;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        Console.WriteLine($"Incoming: 0");
        var result = serviceProvider.GetRequiredService<IAddition>().AddOne(0);
        Console.WriteLine($"Result: {result}");
    }

    /// <summary>
    /// Registro de los servicios
    /// </summary>
    private static ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            // Decorator
            .AddTransient<IAddition, Addition>()
            .AddDecorator<IAddition, LogDecorator>()

            // Build
            .BuildServiceProvider();
    }
}