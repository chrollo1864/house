using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    public List<Property> Properties { get; set; }

    public void OnGet()
    {
        Properties = new List<Property>
        {
            new Property { Title = "Luxury Villa", Price = "$500,000", Size = "3500", ImageUrl = "/images/house1.jpg" },
            new Property { Title = "Modern Apartment", Price = "$250,000", Size = "1200", ImageUrl = "/images/house2.jpg" },
            new Property { Title = "Beach House", Price = "$750,000", Size = "5000", ImageUrl = "/images/house3.jpg" }
        };
    }
}

public class Property
{
    public string Title { get; set; }
    public string Price { get; set; }
    public string Size { get; set; }
    public string ImageUrl { get; set; }
}
