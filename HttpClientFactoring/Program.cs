using HttpClientFactoring;
using HttpClientFactoring.Implementations;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = ServiceCollection();

        var service = serviceProvider.GetService<IConnection>();
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
        sc.AddHttpClient<IConnection>((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        });

        /// Infrastructure
        sc.AddTransient<IConnection, Connection>();

        return sc.BuildServiceProvider();
    }
}