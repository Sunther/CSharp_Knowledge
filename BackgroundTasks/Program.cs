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
                    if (false)
                    {
                        _ = ServiceProviderDotNet(services);
                    }
                    else
                    {
                        //_ = ServiceProviderDotNet8(services);
                        _ = ServiceProviderDotNet8LifeCycle(services);
                    }
                })
                .Build()
                .RunAsync();
    }

    private static IServiceProvider ServiceProviderDotNet(IServiceCollection sc)
    {
        sc.AddHostedService<PeriodicBackgroundTask>();

        return sc.BuildServiceProvider();
    }
    private static IServiceProvider ServiceProviderDotNet8(IServiceCollection sc)
    {
        sc.Configure<HostOptions>(x =>
        {
            x.ServicesStartConcurrently = true;
            x.ServicesStopConcurrently = false;
        });

        sc.AddHostedService<PeriodicHostedService>();

        return sc.BuildServiceProvider();
    }
    private static IServiceProvider ServiceProviderDotNet8LifeCycle(IServiceCollection sc)
    {
        sc.Configure<HostOptions>(x =>
        {
            x.ServicesStartConcurrently = true;
            x.ServicesStopConcurrently = false;
        });

        sc.AddHostedService<PeriodicHostedLifecycleService>();

        return sc.BuildServiceProvider();
    }
}