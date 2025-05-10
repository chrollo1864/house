using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;

namespace HouseApp.Pages
{
    public class UserHouseDetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public UserHouseDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public House House { get; set; }

        public IActionResult OnGet(int id)
        {
            House = _context.Houses.Find(id);
            if (House == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
