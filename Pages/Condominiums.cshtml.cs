using HouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace house.Pages
{
    public class CondominiumsModel : PageModel
    {
        private readonly AppDbContext _context;
        private const int PageSize = 30;

        public CondominiumsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<House> Condominiums { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int page = 1)
        {
            int propertyTypeId = 4;

            var query = _context.Houses
                .Where(h => h.PropertyTypeId == propertyTypeId)
                .OrderByDescending(h => h.CreatedAt);

            int totalItems = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            CurrentPage = page;

            Condominiums = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
