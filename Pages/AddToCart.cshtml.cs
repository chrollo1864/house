using HouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class AddToCartModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int ProductId { get; set; }

    [BindProperty(SupportsGet = true)]
    public bool? Confirm { get; set; }

    private readonly AppDbContext _context;

    public AddToCartModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        // Fetch the cart from session
        var cart = HttpContext.Session.Get<List<CartModel.Item>>("CartItems") ?? new List<CartModel.Item>();

        // Retrieve house details from the database
        var house = _context.Houses.FirstOrDefault(h => h.Id == ProductId);
        if (house == null)
        {
            TempData["ErrorMessage"] = "House not found.";
            return RedirectToPage("/UserHouseDetails", new { id = ProductId });
        }

        // Check if item is already in cart
        bool alreadyInCart = cart.Exists(item => item.Name == house.Title);

        if (alreadyInCart && Confirm == null)
        {
            // Show warning page with options
            return Page();
        }
        else if (alreadyInCart && Confirm == false)
        {
            // User cancelled adding item, redirect back
            return RedirectToPage("/UserHouseDetails", new { id = ProductId });
        }

        // Add the new item to the cart
        cart.Add(new CartModel.Item
        {
            Name = house.Title,
            Price = house.Price.ToString("C2", new System.Globalization.CultureInfo("fil-PH")),
            ImageUrl = house.ImageUrl // Ensure house has an ImageUrl property
        });

        // Save the updated cart back to session
        HttpContext.Session.Set("CartItems", cart);

        // Set success message
        TempData["SuccessMessage"] = $"{house.Title} has been added to your cart.";

        // Redirect back to the View Details page
        return RedirectToPage("/UserHouseDetails", new { id = ProductId });
    }
}
