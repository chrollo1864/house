using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateHouseModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateHouseModel(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public House House { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public SelectList PropertyTypes { get; set; }
        public SelectList Locations { get; set; }

        public async Task OnGetAsync()
        {
            // Load property types and locations for dropdowns
            PropertyTypes = new SelectList(await _context.PropertyTypes.ToListAsync(), "Id", "Name");
            Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                // Log model state errors if any
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                // Reload the dropdown lists if validation fails
                PropertyTypes = new SelectList(await _context.PropertyTypes.ToListAsync(), "Id", "Name");
                Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");
                return Page();
            }

            // Handle image upload or set default image if not provided
            if (ImageFile == null)
            {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName; // Define unique file name
            House.ImageUrl = ImageFile != null ? "/uploads/houses/" + uniqueFileName : "/uploads/houses/default-image.jpg"; // Set image URL


            }
            else
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "houses");
                Directory.CreateDirectory(uploadsFolder); // Ensure directory exists

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                House.ImageUrl = "/uploads/houses/" + uniqueFileName;
            }

            // Ensure LocationId and PropertyTypeId are set
            House.LocationId = House.LocationId; // Ensure LocationId is set from the form
            House.PropertyTypeId = House.PropertyTypeId; // Ensure PropertyTypeId is set from the form


            // Set creation timestamp
            House.RegisteredDate = DateTime.UtcNow;


            try
            {
                _context.Houses.Add(House);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving house: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while saving the house. Please try again.");
                // Reload the dropdown lists if an error occurs
                PropertyTypes = new SelectList(await _context.PropertyTypes.ToListAsync(), "Id", "Name");
                Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");
                return Page();
            }


            TempData["SuccessMessage"] = "House created successfully!";
            return RedirectToPage("./Houses");
        }
    }
}
