using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class EditHouseModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditHouseModel(AppDbContext context, IWebHostEnvironment environment)
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            House = await _context.Houses
                .Include(h => h.PropertyType)
                .Include(h => h.Location)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (House == null)
            {
                return NotFound();
            }

            // Load property types and locations for dropdowns
            PropertyTypes = new SelectList(await _context.PropertyTypes.ToListAsync(), "Id", "Name");
            Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload the dropdown lists if validation fails
                PropertyTypes = new SelectList(await _context.PropertyTypes.ToListAsync(), "Id", "Name");
                Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");
                return Page();
            }

            var houseToUpdate = await _context.Houses.FindAsync(House.Id);

            if (houseToUpdate == null)
            {
                return NotFound();
            }

            // Handle image upload if a new image is provided
            if (ImageFile != null)
            {
                // Delete old image if it exists
                if (!string.IsNullOrEmpty(houseToUpdate.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, houseToUpdate.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "houses");
                Directory.CreateDirectory(uploadsFolder); // Ensure directory exists

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                houseToUpdate.ImageUrl = "/uploads/houses/" + uniqueFileName;
            }

            // Update other properties
            houseToUpdate.Title = House.Title;
            houseToUpdate.Description = House.Description;
            houseToUpdate.Address = House.Address;
            houseToUpdate.Price = House.Price;
            houseToUpdate.Size = House.Size;
            houseToUpdate.Bedrooms = House.Bedrooms;
            houseToUpdate.PropertyTypeId = House.PropertyTypeId;
            houseToUpdate.LocationId = House.LocationId;
            houseToUpdate.IsAvailable = House.IsAvailable;
            houseToUpdate.IsFeatured = House.IsFeatured;

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "House updated successfully!";
                return RedirectToPage("./Houses");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(House.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
