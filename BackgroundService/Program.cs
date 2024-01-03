using BackgroundTasks.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    _ = ServiceProvider(services);
                })
                .Build()
                .RunAsync();
    }

    private static IServiceProvider ServiceProvider(IServiceCollection sc)
    {
        /// Infrastructure
        sc.AddHostedService<PeriodicBackgroundTask>();

        return sc.BuildServiceProvider();
    }
}