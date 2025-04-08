using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Pages.Admin.Api
{
    [Route("api/locations")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Houses)
                .FirstOrDefaultAsync(l => l.Id == id);
            
            if (location == null)
            {
                return NotFound();
            }

            // Check if there are any houses using this location
            if (location.Houses != null && location.Houses.Any())
            {
                return BadRequest("Cannot delete location that is being used by houses.");
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
