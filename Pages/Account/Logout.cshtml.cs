using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseApp.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            // Sign out the user
            await HttpContext.SignOutAsync("CookieAuth");

            // Redirect to home page
            return RedirectToPage("/Index");
        }

        public IActionResult OnGet()
        {
            // If someone navigates to this page directly, redirect them to home
            return RedirectToPage("/Index");
        }
    }
}
