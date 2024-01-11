namespace HttpClientFactoring.Implementations
{
    public interface IExampleFactory
    {
        Task<HttpResponseMessage> GetUserNewAsync();
        Task<HttpResponseMessage> GetUserGitHubAsync();
    }
}