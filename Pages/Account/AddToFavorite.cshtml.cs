using HouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace house.Pages.Account
{
    public class AddToFavoriteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool? Confirm { get; set; }

        private readonly AppDbContext _context;

        public AddToFavoriteModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Fetch the favorites list from session
            var favorites = HttpContext.Session.Get<List<FavoritesModel.Item>>("FavoriteItems") ?? new List<FavoritesModel.Item>();

            // Retrieve house details from the database
            var house = _context.Houses.FirstOrDefault(h => h.Id == ProductId);
            if (house == null)
            {
                TempData["ErrorMessage"] = "House not found.";
                return RedirectToPage("/UserHouseDetails", new { id = ProductId });
            }

            // Check if item is already in favorites
            bool alreadyInFavorites = favorites.Exists(item => item.Name == house.Title);

            if (alreadyInFavorites && Confirm == null)
            {
                // Show warning page with options
                return Page();
            }
            else if (alreadyInFavorites && Confirm == false)
            {
                // User cancelled adding item, redirect back
                return RedirectToPage("/UserHouseDetails", new { id = ProductId });
            }

            // Add the new item to favorites
            favorites.Add(new FavoritesModel.Item
            {
                Id = house.Id,
                Name = house.Title,
                Price = house.Price.ToString("C2", new System.Globalization.CultureInfo("fil-PH")),
                ImageUrl = house.ImageUrl
            });

            // Save the updated favorites list back to session
            HttpContext.Session.Set("FavoriteItems", favorites);

            // Set success message
            TempData["SuccessMessage"] = $"{house.Title} has been added to your favorites.";

            // Redirect back to the View Details page
            return RedirectToPage("/UserHouseDetails", new { id = ProductId });
        }
    }
}
