using HttpClientFactoring;
using HttpClientFactoring.Implementations;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = ServiceCollection();

        _ = await serviceProvider.GetService<IConnection>().GetUserNewAsync();
        _ = await serviceProvider.GetService<IExampleFactory>().GetUserGitHubAsync();
    }

    ///<summary>
    ///https://www.milanjovanovic.tech/blog/the-right-way-to-use-httpclient-in-dotnet?utm_source=LinkedIn&utm_medium=social&utm_campaign=25.12.2023
    ///</summary>
    private static IServiceProvider ServiceCollection()
    {
        var sc = new ServiceCollection();

        ///HttpClient configuration
        sc.AddHttpClient("github", (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        });
        //Registered as a Transient
        sc.AddHttpClient<IConnection>((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        })
        //As Singleton management
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromSeconds(5)
            };
        })
        .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        /// Infrastructure
        sc.AddTransient<IConnection, Connection>();
        sc.AddTransient<IExampleFactory, ExampleFactory>();

        return sc.BuildServiceProvider();
    }
}