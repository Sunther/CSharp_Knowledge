using HttpClientFactoring;
using HttpClientFactoring.Implementations;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main()
    {
        var serviceProvider = ServiceCollection();

        _ = await serviceProvider.GetService<IConnection>()!.GetUserNewAsync();
        _ = await serviceProvider.GetService<IExampleFactory>()!.GetUserGitHubAsync();
    }

    ///<summary>
    ///https://www.milanjovanovic.tech/blog/the-right-way-to-use-httpclient-in-dotnet?utm_source=LinkedIn&utm_medium=social&utm_campaign=25.12.2023
    ///
    /// NSwag
    /// https://elanderson.net/2019/11/use-http-client-factory-with-nswag-generated-classes-in-asp-net-core-3/
    ///</summary>
    private static IServiceProvider ServiceCollection()
    {
        var sc = new ServiceCollection();

        ///HttpClient configuration by tag
        sc.AddHttpClient("github", (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        });

        ///Registered as a transient. Links the HttpClient to the Interface:Implementation
        sc.AddHttpClient<IConnection, Connection>((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        })
        ///As Singleton management
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromSeconds(5)
            };
        })
        .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        /// Infrastructure
        sc.AddTransient<IExampleFactory, ExampleFactory>();

        return sc.BuildServiceProvider();
    }
}