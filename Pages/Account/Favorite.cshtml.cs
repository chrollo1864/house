using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class FavoritesModel : PageModel
{
    public List<Item> FavoriteItems { get; set; } = new List<Item>();

    [BindProperty]
    public int ItemIndex { get; set; }

    public void OnGet()
    {
        // Fetch favorite items from session
        FavoriteItems = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();
    }

    public IActionResult OnPostClearFavorites()
    {
        // Clear the session key for favorites
        HttpContext.Session.Remove("FavoriteItems");
        TempData["SuccessMessage"] = "Favorites have been cleared.";
        return RedirectToPage();
    }

    public IActionResult OnPostDeleteItem()
    {
        // Fetch favorite items from session
        FavoriteItems = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();

        // Remove the item at the specified index
        if (ItemIndex >= 0 && ItemIndex < FavoriteItems.Count)
        {
            FavoriteItems.RemoveAt(ItemIndex);
            HttpContext.Session.Set("FavoriteItems", FavoriteItems);
            TempData["SuccessMessage"] = "Item has been removed from favorites.";
        }

        return RedirectToPage();
    }

    public IActionResult OnPostLoanFavorite()
    {
        FavoriteItems = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();

        if (ItemIndex >= 0 && ItemIndex < FavoriteItems.Count)
        {
            TempData["SuccessMessage"] = $"Loan process started for {FavoriteItems[ItemIndex].Name}.";
        }
        else
        {
            TempData["SuccessMessage"] = "Invalid item selected for loan.";
        }

        return RedirectToPage();
    }

    public IActionResult OnPostBuyFavorite()
    {
        FavoriteItems = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();

        if (ItemIndex >= 0 && ItemIndex < FavoriteItems.Count)
        {
            TempData["SuccessMessage"] = $"Purchase successful for {FavoriteItems[ItemIndex].Name}.";

            // Optionally remove after purchase
            FavoriteItems.RemoveAt(ItemIndex);
            HttpContext.Session.Set("FavoriteItems", FavoriteItems);
        }
        else
        {
            TempData["SuccessMessage"] = "Invalid item selected for purchase.";
        }

        return RedirectToPage();
    }

    public class Item
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
