using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseApp.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {
        public void OnGet()
        {
            // Log the access denied attempt
            var user = User.Identity.Name ?? "Anonymous";
            var path = HttpContext.Request.Path;
            
            // You could add logging here if needed
            // _logger.LogWarning($"Access denied for user {user} attempting to access {path}");
        }
    }
}
