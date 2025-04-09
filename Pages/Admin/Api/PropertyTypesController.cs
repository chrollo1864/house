using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Pages.Admin.Api
{
    [Route("api/propertytypes")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class PropertyTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertyTypesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var propertyType = await _context.PropertyTypes
                .Include(pt => pt.Houses)
                .FirstOrDefaultAsync(pt => pt.Id == id);
            
            if (propertyType == null)
            {
                return NotFound();
            }

            // Check if there are any houses using this property type
            if (propertyType.Houses != null && propertyType.Houses.Any())
            {
                return BadRequest("Cannot delete property type that is being used by houses.");
            }

            _context.PropertyTypes.Remove(propertyType);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
