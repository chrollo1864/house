using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;

namespace HouseApp.Pages.Admin
{
    public class HouseDetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public HouseDetailsModel(AppDbContext context)
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
