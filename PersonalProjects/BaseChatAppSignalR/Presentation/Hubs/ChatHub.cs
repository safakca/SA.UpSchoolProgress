using Microsoft.AspNetCore.SignalR;
using Presentation.Models;
using System.Threading.Tasks;

namespace Presentation.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
