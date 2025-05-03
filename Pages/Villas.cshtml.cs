using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class VillaModel : PageModel
{
    private readonly AppDbContext _context;
    private const int PageSize = 30;

    public VillaModel(AppDbContext context)
    {
        _context = context;
    }

    public List<House> Villas { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

    public async Task OnGetAsync(int page = 1)
    {
        int propertyTypeId = 5; 

        var query = _context.Houses
            .Where(h => h.PropertyTypeId == propertyTypeId)
            .OrderByDescending(h => h.CreatedAt);

        int totalItems = await query.CountAsync();
        TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
        CurrentPage = page;

        Villas = await query
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
    }
}
