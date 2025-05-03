using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using HouseApp.Models;

namespace HouseApp.Pages.Admin.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("IsInCart")]
        public IActionResult IsInCart(int productId)
        {
            var cart = HttpContext.Session.Get<List<CartModel.Item>>("CartItems") ?? new List<CartModel.Item>();

            var houseTitle = GetHouseTitle(productId);
            var house = cart.FirstOrDefault(item => item.Name == houseTitle);
            bool isInCart = house != null;

            return Ok(new { isInCart });
        }

        private string GetHouseTitle(int productId)
        {
            var house = _context.Houses.FirstOrDefault(h => h.Id == productId);
            return house?.Title ?? string.Empty;
        }
    }
}
