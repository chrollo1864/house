using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models; // Ensure this namespace is included
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public async Task OnGetAsync() // Making the method async
    {
        try
        {
            Properties = await _context.Houses
                .Include(h => h.PropertyType) // Ensure PropertyType is included
                .Include(h => h.Location) // Ensure Location is included
                .Where(h => h.IsFeatured) // Assuming IsFeatured is a property in the House model
                .ToListAsync();

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
