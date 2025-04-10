using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using System.Threading.Tasks;

namespace HouseApp.Pages.Admin
{
    public class EditUserModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditUserModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User EditUser { get; set; }

        [BindProperty]
        public string? NewPassword { get; set; }

        // Load user by Id (GET request)
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Find user by Id
            EditUser = await _context.Users.FindAsync(id);
            if (EditUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handle form submission (POST request)
        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return page if model is invalid
            }

            var userInDb = await _context.Users.FindAsync(EditUser.Id);
            if (userInDb == null)
            {
                return NotFound(); // User not found
            }

            // Update user fields
            userInDb.Name = EditUser.Name;
            userInDb.Email = EditUser.Email;
            userInDb.Role = EditUser.Role;

            // Only update the password if a new one is provided
            if (!string.IsNullOrEmpty(NewPassword))
            {
                userInDb.PasswordHash = BCrypt.Net.BCrypt.HashPassword(NewPassword);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the Admin Users page after saving
            return RedirectToPage("/Admin/Users");
        }
    }
}
