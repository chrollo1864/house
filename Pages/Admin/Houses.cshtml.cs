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

        public async Task OnGetAsync()
        {
            Houses = await _context.Houses
                .Include(h => h.PropertyType)
                .Include(h => h.Location)
                .ToListAsync();
        }
    }
}
