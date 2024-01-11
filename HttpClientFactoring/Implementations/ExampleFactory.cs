namespace HttpClientFactoring.Implementations
{
    public class ExampleFactory : IExampleFactory
    {
        private readonly IHttpClientFactory _factory;

        public ExampleFactory(IHttpClientFactory factory)
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
