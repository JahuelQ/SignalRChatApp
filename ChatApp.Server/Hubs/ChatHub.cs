using Microsoft.AspNetCore.SignalR;
using ChatApp.Shared.Models;

namespace ChatApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage (ChatMessage chatMessage)
        {
            if (string.IsNullOrWhiteSpace(chatMessage.User))
            {
                return;
            }

            // Sanitize message to prevent XSS
            chatMessage.Message = System.Net.WebUtility.HtmlEncode(chatMessage.Message);

            await Clients.All.SendAsync("RecieveMessage", chatMessage);
        }
    }
}
