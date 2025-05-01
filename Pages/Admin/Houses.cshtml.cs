using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IList<Location> Locations { get; set; }
        public IList<PropertyType> PropertyTypes { get; set; }

        public async Task OnGetAsync()
        {
            Houses = await _context.Houses
                .Include(h => h.PropertyType)
                .Include(h => h.Location)
                .ToListAsync();

            Locations = await _context.Locations.ToListAsync();
            PropertyTypes = await _context.PropertyTypes.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string title, string address, decimal price, int locationId, int propertyTypeId, bool isAvailable)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var house = new House
            {
                Title = title,
                Address = address,
                Price = price,
                LocationId = locationId,
                PropertyTypeId = propertyTypeId,
                IsAvailable = isAvailable,
                RegisteredDate = System.DateTime.Now
            };

            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id, string title, string address, decimal price, int locationId, int propertyTypeId, bool isAvailable)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            house.Title = title;
            house.Address = address;
            house.Price = price;
            house.LocationId = locationId;
            house.PropertyTypeId = propertyTypeId;
            house.IsAvailable = isAvailable;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
