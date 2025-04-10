using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using HouseApp.Models;

namespace HouseApp.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProfileModel(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public User CurrentUser { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "New Profile Image")]
            public IFormFile NewProfileImage { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirst("UserId")?.Value;
            if (userId == null)
            {
                return RedirectToPage("/Account/Login");
            }

            CurrentUser = await _context.Users.FindAsync(int.Parse(userId));
            if (CurrentUser == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                Name = CurrentUser.Name,
                Email = CurrentUser.Email,
                PhoneNumber = CurrentUser.PhoneNumber,
                Address = CurrentUser.Address
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.FindFirst("UserId")?.Value;
            if (userId == null)
            {
                return RedirectToPage("/Account/Login");
            }

            CurrentUser = await _context.Users.FindAsync(int.Parse(userId));
            if (CurrentUser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle profile image upload
            if (Input.NewProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                Directory.CreateDirectory(uploadsFolder); // Ensure directory exists

                // Delete old profile image if exists
                if (!string.IsNullOrEmpty(CurrentUser.ProfileImage))
                {
                    string oldImagePath = Path.Combine(_environment.WebRootPath, 
                        CurrentUser.ProfileImage.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Save new profile image
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.NewProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.NewProfileImage.CopyToAsync(fileStream);
                }
                
                CurrentUser.ProfileImage = "/uploads/profiles/" + uniqueFileName;
            }

            // Update user information
            CurrentUser.Name = Input.Name;
            CurrentUser.PhoneNumber = Input.PhoneNumber;
            CurrentUser.Address = Input.Address;

            try
            {
                await _context.SaveChangesAsync();
                SuccessMessage = "Profile updated successfully!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating your profile.");
                return Page();
            }

            return RedirectToPage();
        }
    }
}
