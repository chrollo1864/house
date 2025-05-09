using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseApp.Pages
{
    public class Error404Model : PageModel
    {
        public void OnGet()
        {
            Response.StatusCode = 404;
        }
    }
}
