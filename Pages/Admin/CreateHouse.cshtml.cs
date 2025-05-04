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
public House House { get; set; } = new House(); // Initialize to avoid null reference

[BindProperty]
public bool IsFeatured { get; set; } // Add IsFeatured property

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
            //// Check if the model state is valid
            //if (!ModelState.IsValid)
            //{
            //    // Log model state errors if any
            //    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            //    {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //    // Reload the dropdown lists if validation fails
            //    PropertyTypes = new SelectList(await _context.PropertyTypes.ToListAsync(), "Id", "Name");
            //    Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");
            //    return Page();
            //}

            // Handle image upload or set default image if not provided
            string uniqueFileName = Guid.NewGuid().ToString() + "_";
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "houses");
                Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists

                uniqueFileName += Path.GetFileName(ImageFile.FileName); // Append filename instead of redeclaring
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                    Console.WriteLine("Saved image: " + uniqueFileName);
                }

                House.ImageUrl = "/uploads/houses/" + uniqueFileName; // Save with full path
            }
            else
            {
                House.ImageUrl = "/uploads/houses/default-image.png"; // fallback if no image is uploaded
            }

            // Ensure LocationId and PropertyTypeId are set
            House.LocationId = House.LocationId; // Ensure LocationId is set from the form
            House.PropertyTypeId = House.PropertyTypeId; // Ensure PropertyTypeId is set from the form

            // Set creation timestamp
            House.RegisteredDate = DateTime.UtcNow;

            // Assign the bound IsFeatured value to House.IsFeatured
            House.IsFeatured = IsFeatured;

            try
            {
                if (House.IsFeatured)
                {
                    int featuredLimit = 5;
                    var featuredHouses = await _context.Houses
                        .Where(h => h.IsFeatured)
                        .OrderBy(h => h.RegisteredDate)
                        .ToListAsync();

                    if (featuredHouses.Count >= featuredLimit)
                    {
                        var oldestFeatured = featuredHouses.First();
                        oldestFeatured.IsFeatured = false;
                        _context.Houses.Update(oldestFeatured);
                    }
                }

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
