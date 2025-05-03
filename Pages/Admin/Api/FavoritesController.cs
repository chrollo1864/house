using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using HouseApp.Models;

namespace HouseApp.Pages.Admin.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoritesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("IsInFavorites")]
        public IActionResult IsInFavorites(int productId)
        {
            var favorites = HttpContext.Session.Get<List<FavoritesModel.Item>>("FavoriteItems") ?? new List<FavoritesModel.Item>();

            var houseTitle = GetHouseTitle(productId);
            var favorite = favorites.FirstOrDefault(item => item.Name == houseTitle);
            bool isInFavorites = favorite != null;

            return Ok(new { isInFavorites });
        }

        private string GetHouseTitle(int productId)
        {
            var house = _context.Houses.FirstOrDefault(h => h.Id == productId);
            return house?.Title ?? string.Empty;
        }
    }
}
