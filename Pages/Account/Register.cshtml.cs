using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;

namespace HouseApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public RegisterModel(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            //[Display(Name = "Profile Image")]
            //public IFormFile ProfileImage { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == Input.Email))
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                    return Page();
                }

                //string profileImagePath = null;
                //if (Input.ProfileImage != null)
                //{
                //    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                //    Directory.CreateDirectory(uploadsFolder); // Ensure directory exists
                    
                //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.ProfileImage.FileName;
                //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await Input.ProfileImage.CopyToAsync(fileStream);
                //    }
                    
                //    profileImagePath = "/uploads/profiles/" + uniqueFileName;
                //}

                var user = new User
                {
                    Name = Input.Name,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    Address = Input.Address,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(Input.Password),
                    Role = "User",
                    RegisteredDate = DateTime.UtcNow,
                    //ProfileImage = profileImagePath
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Registration successful! Please login with your credentials.";
                return RedirectToPage("/Account/Login");
            }

            return Page();
        }
    }
}
