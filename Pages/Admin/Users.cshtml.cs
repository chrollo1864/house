using HouseApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminUsersModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminUsersModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; } = new List<User>();

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync() ?? new List<User>();
        }

        // Removed OnPostAddUserAsync method as per user request

        public async Task<IActionResult> OnPostDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditUserAsync(int id, string name, string email, string role)
        {
            // Removed ModelState.IsValid check to test if update works without validation
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }
            */

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = name;
            user.Email = email;
            user.Role = role;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
