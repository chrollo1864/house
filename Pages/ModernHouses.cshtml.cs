using HouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace house.Pages
{
public class ModernHousesModel : PageModel
{
    private readonly AppDbContext _context;
    private const int PageSize = 10;

    public ModernHousesModel(AppDbContext context)
    {
        _context = context;
    }

    public List<House> ModernHouses { get; set; }

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    public int TotalPages { get; set; }

    public async Task OnGetAsync()
    {
        int propertyTypeId = 6;

        if (CurrentPage < 1) CurrentPage = 1;

        var query = _context.Houses
            .Where(h => h.PropertyTypeId == propertyTypeId)
            .OrderByDescending(h => h.CreatedAt);

        int totalItems = await query.CountAsync();
        TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

        ModernHouses = await query
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
    }
}
}
