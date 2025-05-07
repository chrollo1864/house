using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;

public class FavoritesModel : PageModel
{
    private readonly AppDbContext _context;

    public FavoritesModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Item> FavoriteItems { get; set; } = new();

    [BindProperty]
    public int ItemIndex { get; set; }

    public void OnGet()
    {
        var favoriteItemsFromSession = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();
        var favoriteIds = favoriteItemsFromSession.Select(i => i.Id).ToList();

        var houses = _context.Houses
            .Where(h => favoriteIds.Contains(h.Id))
            .Include(h => h.PropertyType)
            .Include(h => h.Location)
            .ToList();

        FavoriteItems = houses.Select(h => new Item
        {
            Id = h.Id,
            Name = h.Title,
            Price = h.Price.ToString(),
            ImageUrl = h.ImageUrl,
            propertyTypeId = h.PropertyTypeId
        }).ToList();
    }

    public IActionResult OnPostClearFavorites()
    {
        HttpContext.Session.Remove("FavoriteItems");
        TempData["SuccessMessage"] = "Favorites have been cleared.";
        return RedirectToPage();
    }

    public IActionResult OnPostDeleteItem()
    {
        FavoriteItems = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();

        if (ItemIndex >= 0 && ItemIndex < FavoriteItems.Count)
        {
            FavoriteItems.RemoveAt(ItemIndex);
            HttpContext.Session.Set("FavoriteItems", FavoriteItems);
            TempData["SuccessMessage"] = "Item has been removed from favorites.";
        }

        return RedirectToPage();
    }

    public IActionResult OnPostAddFavorite(int id)
    {
        var favoriteItems = HttpContext.Session.Get<List<Item>>("FavoriteItems") ?? new List<Item>();

        if (!favoriteItems.Any(f => f.Id == id))
        {
            var house = _context.Houses.Find(id);
            if (house != null)
            {
                favoriteItems.Add(new Item
                {
                    Id = house.Id,
                    Name = house.Title,
                    Price = house.Price.ToString(),
                    ImageUrl = house.ImageUrl,
                    propertyTypeId = house.PropertyTypeId
                });
                HttpContext.Session.Set("FavoriteItems", favoriteItems);
                TempData["SuccessMessage"] = "Item has been added to favorites.";
            }
        }

        return RedirectToPage();
    }

    public class Item
    {
        public int Id { get; set; } // This is the House Id
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public int? propertyTypeId { get; set; }
    }
}

