using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class LocationsModel : PageModel
    {
        private readonly AppDbContext _context;

        public LocationsModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Location> Locations { get; set; }

        public async Task OnGetAsync()
        {
            Locations = await _context.Locations.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string name, string state, string country)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var location = new Location
            {
                Name = name,
                State = state,
                Country = country
            };

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id, string name, string state, string country)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            location.Name = name;
            location.State = state;
            location.Country = country;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
