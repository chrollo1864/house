using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Pages.Admin.Api
{
    [Route("api/User")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users
                .Include(u => u.Loans) // Include related loans
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Optional: Prevent deletion if user has loans
            if (user.Loans != null && user.Loans.Any())
            {
                return BadRequest("Cannot delete user with existing loans.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
