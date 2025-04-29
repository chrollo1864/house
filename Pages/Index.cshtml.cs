using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models; // Ensure this namespace is included
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context; // Injecting the context

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<House> Properties { get; set; }
    public List<Location> Locations { get; set; } // New property for locations
    public List<PropertyType> PropertyTypes { get; set; } // New property for property types

    [BindProperty(SupportsGet = true)]
    public int? propertyTypeId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? locationId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? minPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? maxPrice { get; set; }

    public async Task OnGetAsync() // Making the method async
    {
        try
        {
            var query = _context.Houses
                .Include(h => h.PropertyType) // Ensure PropertyType is included
                .Include(h => h.Location) // Ensure Location is included
                .AsQueryable();

            if (propertyTypeId.HasValue)
            {
                query = query.Where(h => h.PropertyTypeId == propertyTypeId.Value);
            }

            if (locationId.HasValue)
            {
                query = query.Where(h => h.LocationId == locationId.Value);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(h => h.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(h => h.Price <= maxPrice.Value);
            }

            Properties = await query.ToListAsync();

            Locations = await _context.Locations.ToListAsync(); // Retrieve locations dynamically
            PropertyTypes = await _context.PropertyTypes.ToListAsync(); // Retrieve property types dynamically
        }
        catch (Exception ex)
        {
            // Handle the error (e.g., log it, set a message for the view, etc.)
            Console.WriteLine($"Error retrieving data: {ex.Message}");
        }
    }
}
