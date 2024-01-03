using HttpClientFactoring.Contracts;

namespace HttpClientFactoring.Implementations
{
    public class Connection : IConnection
    {
        private readonly IHttpClientFactory _factory;

        public Connection(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<HttpResponseMessage> GetUserNewAsync()
        {
            HttpResponseMessage response;

            using (var client = _factory.CreateClient())
            {
                response = await client.GetAsync(new Uri("https://api.github.com"));
            }

            return response;
        }

        public async Task<HttpResponseMessage> GetUserGitHubAsync()
        {
            HttpResponseMessage response;

            using (var client = _factory.CreateClient("github"))
            {
                response = await client.GetAsync(new Uri("https://api.github.com"));
            }

            return response;
        }
    }
}
