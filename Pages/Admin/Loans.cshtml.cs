using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class AdminLoansModel : PageModel
{
    private readonly AppDbContext _context;

    public AdminLoansModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Loan> Loans { get; set; }

    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; }
    public int PageSize { get; set; } = 10;

    public async Task OnGetAsync(int? currentPage)
    {
        CurrentPage = currentPage ?? 1;
        var totalLoans = await _context.Loans.CountAsync();
        TotalPages = (int)System.Math.Ceiling(totalLoans / (double)PageSize);

        Loans = await _context.Loans
            .Include(l => l.User)
            .OrderBy(l => l.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostApproveAsync(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan == null)
        {
            return NotFound();
        }
        loan.Status = "Approved";
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostRejectAsync(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan == null)
        {
            return NotFound();
        }
        loan.Status = "Rejected";
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }
}
