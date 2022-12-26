using Microsoft.AspNetCore.SignalR;
using SA.ChatApp.Models;

namespace SA.ChatApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(Message message) =>
        await Clients.All.SendAsync("receiveMessage", message);
}
