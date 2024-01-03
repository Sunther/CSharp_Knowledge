using HttpClientFactoring.Contracts;
using HttpClientFactoring.Implementations;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    public void Main(string[] args)
    {
        var sp = ServiceCollection();

        var service = sp.GetService<IConnection>();
    }

    ///<summary>
    ///https://www.milanjovanovic.tech/blog/the-right-way-to-use-httpclient-in-dotnet?utm_source=LinkedIn&utm_medium=social&utm_campaign=25.12.2023
    ///</summary>
    private IServiceProvider ServiceCollection()
    {
        var sc = new ServiceCollection();

        /// Infrastructure
        sc.AddTransient<IConnection, Connection>();

        ///HttpClient configuration
        sc.AddHttpClient("github", (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        });
        sc.AddHttpClient<IConnection>((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
        });

        return sc.BuildServiceProvider();
    }
}