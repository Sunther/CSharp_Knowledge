namespace HttpClientFactoring
{
    public interface IConnection
    {
        Task<HttpResponseMessage> GetUserNewAsync();
    }
}