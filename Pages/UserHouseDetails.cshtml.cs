using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;

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
            House = _context.Houses
                .Include(h => h.PropertyType) // Include PropertyType
                .Include(h => h.Location) // Include Location
                .FirstOrDefault(h => h.Id == id); // Retrieve the house by ID

            if (House == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
