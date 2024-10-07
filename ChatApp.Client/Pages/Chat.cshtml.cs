using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Client.Pages
{
    public class ChatModel : PageModel
    {
        public string Username { get; set; }

        public void OnGet(string username)
        {
            Username = username;
        }
    }
}
