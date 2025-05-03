using HouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace house.Pages
{
    public class TownHousesModel : PageModel
    {
        private readonly AppDbContext _context;
        private const int PageSize = 30;

        public TownHousesModel(AppDbContext context)
        {
            _context = context;
        }

        public List<House> TownHouses { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int page = 1)
        {
            int propertyTypeId = 3;

            var query = _context.Houses
                .Where(h => h.PropertyTypeId == propertyTypeId)
                .OrderByDescending(h => h.CreatedAt);

            int totalItems = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            CurrentPage = page;

            TownHouses = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
