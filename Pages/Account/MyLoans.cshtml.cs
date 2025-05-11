using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

namespace house.Pages.Account

{
    public class MyLoansModel : PageModel
    {
        private readonly AppDbContext _context;

        public MyLoansModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Loan> Loans { get; set; }

        public async Task OnGetAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                Loans = new List<Loan>();
                return;
            }

            int userId = int.Parse(userIdClaim.Value);

            Loans = await _context.Loans
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }
    }
}
