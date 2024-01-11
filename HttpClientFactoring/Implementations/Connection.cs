namespace HttpClientFactoring.Implementations
{
    public class Connection : IConnection
    {
        private readonly HttpClient _client;

        public Connection(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetUserNewAsync()
        {
            HttpResponseMessage response;

            response = await _client.GetAsync(new Uri("https://api.github.com"));

            return response;
        }
    }
}
