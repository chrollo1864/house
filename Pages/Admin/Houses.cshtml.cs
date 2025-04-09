using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class HousesModel : PageModel
    {
        private readonly AppDbContext _context;

        public HousesModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<House> Houses { get; set; }
        public bool IsFeatured { get; set; } // Added IsFeatured property


        public async Task OnGetAsync()
        {
            Houses = await _context.Houses
                .Where(h => h.IsFeatured) // Include only featured houses

                            .Include(h => h.PropertyType)
                            .Include(h => h.Location)
                            .ToListAsync();
        }
    }
}
