using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouseApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class PropertyTypesModel : PageModel
    {
        private readonly AppDbContext _context;

        public PropertyTypesModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<PropertyType> PropertyTypes { get; set; }

        public async Task OnGetAsync()
        {
            PropertyTypes = await _context.PropertyTypes.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string name, string description)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var propertyType = new PropertyType
            {
                Name = name,
                Description = description
            };

            _context.PropertyTypes.Add(propertyType);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id, string name, string description)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var propertyType = await _context.PropertyTypes.FindAsync(id);

            if (propertyType == null)
            {
                return NotFound();
            }

            propertyType.Name = name;
            propertyType.Description = description;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
