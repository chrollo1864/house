using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
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
    public List<House> FeaturedProperties { get; set; }
    public List<House> Villas { get; set; }
    public List<House> FamilyHouses { get; set; }
    public List<House> Apartments { get; set; }
    public List<House> Condominiums { get; set; }
    public List<House> ModernHouses { get; set; }
    public List<House> TownHouses { get; set; }
    public List<Location> Locations { get; set; } 
    public List<PropertyType> PropertyTypes { get; set; } 

    [BindProperty(SupportsGet = true)]
    public int? propertyTypeId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? locationId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? minPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? maxPrice { get; set; }

    public async Task OnGetAsync()
    {
        try
        {
            var query = _context.Houses
                .Include(h => h.PropertyType)
                .Include(h => h.Location)
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

Properties = await query
                .OrderByDescending(h => h.RegisteredDate)
                .ToListAsync();

FeaturedProperties = await _context.Houses
                .Where(h => h.IsFeatured && h.PropertyTypeId == 6)
                .OrderByDescending(h => h.RegisteredDate)
                .Take(6)
                .ToListAsync();

            Locations = await _context.Locations.ToListAsync();
            PropertyTypes = await _context.PropertyTypes.ToListAsync();

            Villas = await _context.Houses
                .Where(p => p.PropertyTypeId == 5)
                .OrderByDescending(p => p.RegisteredDate)
                .Take(10)
                .ToListAsync();

            FamilyHouses = await _context.Houses
                .Where(p => p.PropertyTypeId == 1)
                .OrderByDescending(p => p.RegisteredDate)
                .Take(10)
                .ToListAsync();

            Apartments = await _context.Houses
                .Where(p => p.PropertyTypeId == 2)
                .OrderByDescending(p => p.RegisteredDate)
                .Take(10)
                .ToListAsync();

            Condominiums = await _context.Houses
                .Where(p => p.PropertyTypeId == 4)
                .OrderByDescending(p => p.RegisteredDate)
                .Take(10)
                .ToListAsync();

            ModernHouses = await _context.Houses
                .Where(p => p.PropertyTypeId == 6)
                .OrderByDescending(p => p.RegisteredDate)
                .Take(10)
                .ToListAsync();

            TownHouses = await _context.Houses
                .Where(p => p.PropertyTypeId == 3)
                .OrderByDescending(p => p.RegisteredDate)
                .Take(10)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving data: {ex.Message}");
        }
    }
}
