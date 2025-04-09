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

    public async Task OnGetAsync() // Making the method async
    {
        Properties = await _context.Houses
            .Include(h => h.PropertyType) // Ensure PropertyType is included
            .Where(h => h.IsFeatured) // Assuming IsFeatured is a property in the House model
            .ToListAsync();

        var villas = Properties.Where(p => p.PropertyTypeId == 1).Take(10).ToList(); // Assuming 1 is the ID for Villa
        var apartments = Properties.Where(p => p.PropertyTypeId == 2).Take(10).ToList(); // Assuming 2 is the ID for Apartment
        var houses = Properties.Where(p => p.PropertyTypeId == 3).Take(10).ToList(); // Assuming 3 is the ID for House

        Properties = villas.Concat(apartments).Concat(houses).ToList();
    }
}

public class Property
{
    public string Title { get; set; }
    public string Price { get; set; }
    public string Size { get; set; }
    public string ImageUrl { get; set; }
}
