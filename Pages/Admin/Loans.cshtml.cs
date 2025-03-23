using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class AdminLoansModel : PageModel
{
    public List<Loan> Loans { get; set; } = new()
    {
        new Loan { Id = 1, UserName = "John Doe", Amount = 50000, Status = "Pending" },
        new Loan { Id = 2, UserName = "Jane Smith", Amount = 75000, Status = "Approved" }
    };

    public void OnGet()
    {
    }
}

public class Loan
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
}
