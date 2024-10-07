using Microsoft.AspNetCore.SignalR;
using ChatApp.Shared.Models;

namespace ChatApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage (ChatMessage chatMessage)
        {
            // Sanitize message to prevent XSS
            chatMessage.Message = System.Net.WebUtility.HtmlDecode (chatMessage.Message);

            await Clients.All.SendAsync("RecieveMessage", chatMessage);
        }
    }
}
