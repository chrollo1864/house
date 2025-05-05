using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;

namespace HouseApp.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public ForgotPasswordModel(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == Input.Email);
            if (user == null)
            {
                // Do not reveal that the user does not exist
                return RedirectToPage("/Account/ForgotPasswordConfirmation");
            }

            // Generate a secure token
            user.PasswordResetToken = GenerateToken();
            user.PasswordResetTokenExpiration = DateTime.UtcNow.AddMinutes(5);

            await _context.SaveChangesAsync();

            var resetLink = Url.Page(
                "/Account/ResetPassword",
                null,
                new { token = user.PasswordResetToken, email = user.Email },
                Request.Scheme);

            var message = $"Please reset your password by clicking here: {resetLink}";

            await _emailService.SendEmailAsync(user.Email, "Password Reset Request", message);

            return RedirectToPage("/Account/ForgotPasswordConfirmation");
        }

        private string GenerateToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[32];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
