using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Pages.Admin.Api
{
    [Route("api/houses")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class HousesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public HousesController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            
            if (house == null)
            {
                return NotFound();
            }

            // Delete the associated image file if it exists
            if (!string.IsNullOrEmpty(house.ImageUrl))
            {
                var imagePath = Path.Combine(_environment.WebRootPath, house.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
