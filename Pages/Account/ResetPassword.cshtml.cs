using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using BCrypt.Net;

namespace HouseApp.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly AppDbContext _context;

        public ResetPasswordModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Token { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public IActionResult OnGet(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Account/Login");
            }

            Input = new InputModel
            {
                Token = token,
                Email = email
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == Input.Email && u.PasswordResetToken == Input.Token);

            if (user == null || user.PasswordResetTokenExpiration == null || user.PasswordResetTokenExpiration < DateTime.UtcNow)
            {
                ModelState.AddModelError(string.Empty, "Invalid or expired token.");
                return Page();
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Input.Password);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiration = null;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Login", new { reset = "success" });
        }
    }
}
