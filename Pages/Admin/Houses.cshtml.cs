using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class AdminHousesModel : PageModel
{
    public List<House> Houses { get; set; } = new()
    {
        new House { Id = 1, Title = "Modern Villa", Price = 250000 },
        new House { Id = 2, Title = "Luxury Apartment", Price = 180000 }
    };

    public void OnGet()
    {
    }
}

public class House
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}
