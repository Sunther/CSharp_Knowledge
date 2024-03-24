using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class SignalRChatHub : Hub<ISignalRChatHub>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.OnConnectedAsync($"{Context.ConnectionId} entered to the room");
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.OnDisconnectedAsync($"{Context.ConnectionId} left the room");
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessageAsync(user, message);
        }
    }
}
