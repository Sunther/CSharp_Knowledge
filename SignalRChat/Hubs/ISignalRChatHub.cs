namespace SignalRChat.Hubs
{
    public interface ISignalRChatHub
    {
        Task ReceiveMessageAsync(string user, string message);
        Task OnConnectedAsync(string message);
        Task OnDisconnectedAsync(string message);
    }
}
