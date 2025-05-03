using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace house.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                return RedirectToPage("/SearchResults", new { title = Title });
            }
            return Page();
        }
    }
}
