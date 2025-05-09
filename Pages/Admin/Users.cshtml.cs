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

        // Removed unused BindProperty EditUser to avoid model validation errors
        // [BindProperty]
        // public User EditUser { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync() ?? new List<User>();
        }

        // Handle Delete User (using API)
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

        // Handle Edit User (using POST method)
        public async Task<IActionResult> OnPostEditUserAsync(int id, string name, string email, string role)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return BadRequest("Model validation failed: " + errors);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = name;
            user.Email = email;
            user.Role = role;

            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true });
        }


    }
}
