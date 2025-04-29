using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseApp.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly AppDbContext _context;

        public SearchResultsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<House> Houses { get; set; }

        public IActionResult OnGet(int? PropertyTypeId, int? LocationId, decimal? MinPrice, decimal? MaxPrice)
        {
            var query = _context.Houses
                .Include(h => h.PropertyType)
                .Include(h => h.Location)
                .AsQueryable();

            if (PropertyTypeId.HasValue)
            {
                query = query.Where(h => h.PropertyTypeId == PropertyTypeId.Value);
            }

            if (LocationId.HasValue)
            {
                query = query.Where(h => h.LocationId == LocationId.Value);
            }

            if (MinPrice.HasValue)
            {
                query = query.Where(h => h.Price >= MinPrice.Value);
            }

            if (MaxPrice.HasValue)
            {
                query = query.Where(h => h.Price <= MaxPrice.Value);
            }

            Houses = query.ToList();

            return Page();
        }
    }
}

