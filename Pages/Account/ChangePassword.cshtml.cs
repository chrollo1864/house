using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using HouseApp.Models;

namespace HouseApp.Pages.Account
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly AppDbContext _context;

        public ChangePasswordModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirst("UserId")?.Value;
            if (userId == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var user = await _context.Users.FindAsync(int.Parse(userId));
            if (user == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirst("UserId")?.Value;
            if (userId == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var user = await _context.Users.FindAsync(int.Parse(userId));
            if (user == null)
            {
                return NotFound();
            }

            // Verify current password
            if (!BCrypt.Net.BCrypt.Verify(Input.OldPassword, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Current password is incorrect.");
                return Page();
            }

            // Update password
            try
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Input.NewPassword);
                await _context.SaveChangesAsync();
                
                StatusMessage = "Your password has been changed successfully.";
                return RedirectToPage();
            }
            catch (Exception)
            {
                StatusMessage = "Error: An error occurred while changing your password.";
                return Page();
            }
        }
    }
}
