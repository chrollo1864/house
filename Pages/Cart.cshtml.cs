using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class CartModel : PageModel
{
    public List<Item> CartItems { get; set; } = new List<Item>();

    [BindProperty]
    public int ItemIndex { get; set; }

    public void OnGet()
    {
        // Fetch cart items from session
        CartItems = HttpContext.Session.Get<List<Item>>("CartItems") ?? new List<Item>();
    }

    public IActionResult OnPostClearCart()
    {
        // Clear the session key for the cart
        HttpContext.Session.Remove("CartItems");
        TempData["SuccessMessage"] = "Cart has been cleared.";
        return RedirectToPage();
    }

    public IActionResult OnPostDeleteItem()
    {
        // Fetch cart items from session
        CartItems = HttpContext.Session.Get<List<Item>>("CartItems") ?? new List<Item>();

        // Remove the item at the specified index
        if (ItemIndex >= 0 && ItemIndex < CartItems.Count)
        {
            CartItems.RemoveAt(ItemIndex);
            HttpContext.Session.Set("CartItems", CartItems);
            TempData["SuccessMessage"] = "Item has been removed from the cart.";
        }

        return RedirectToPage();
    }

    public IActionResult OnPostLoanCart()
    {
        // Fetch cart items from session
        CartItems = HttpContext.Session.Get<List<Item>>("CartItems") ?? new List<Item>();

        if (ItemIndex >= 0 && ItemIndex < CartItems.Count)
        {
            // Simulate loan process for the item
            TempData["SuccessMessage"] = $"Loan process started for {CartItems[ItemIndex].Name}.";
        }
        else
        {
            TempData["SuccessMessage"] = "Invalid item selected for loan.";
        }

        return RedirectToPage();
    }

    public IActionResult OnPostBuyCart()
    {
        // Fetch cart items from session
        CartItems = HttpContext.Session.Get<List<Item>>("CartItems") ?? new List<Item>();

        if (ItemIndex >= 0 && ItemIndex < CartItems.Count)
        {
            // Simulate buy process for the item
            TempData["SuccessMessage"] = $"Purchase successful for {CartItems[ItemIndex].Name}.";

            // Optionally remove the item from cart after purchase
            CartItems.RemoveAt(ItemIndex);
            HttpContext.Session.Set("CartItems", CartItems);
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

// Session extension methods
public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}
