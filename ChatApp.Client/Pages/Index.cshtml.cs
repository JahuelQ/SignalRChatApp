using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Client.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("Chat", new { username = Username });
            }

            return Page();
        }
    }
}
