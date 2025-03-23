using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class AdminUsersModel : PageModel
{
    public List<User> Users { get; set; } = new()
    {
        new User { Id = 1, Name = "John Doe", Email = "john@example.com", Role = "Admin" },
        new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Role = "User" }
    };

    public void OnGet()
    {
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
