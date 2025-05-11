using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[Authorize]
public class LoanRegistrationModel : PageModel
{
    private readonly AppDbContext _context;

    public LoanRegistrationModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    [Required]
    public string FirstName { get; set; }

    [BindProperty]
    public string MiddleName { get; set; }

    [BindProperty]
    [Required]
    public string LastName { get; set; }

    [BindProperty]
    public string Suffix { get; set; }

    [BindProperty]
    [Required]
    public string Province { get; set; }

    [BindProperty]
    [Required]
    public string Municipality { get; set; }

    [BindProperty]
    [Required]
    public string Barangay { get; set; }

    [BindProperty]
    public string StreetNo { get; set; }

    [BindProperty]
    public string HouseNo { get; set; }

    [BindProperty]
    [Required]
    public int Age { get; set; }

    [BindProperty]
    [Required]
    public DateTime BirthDate { get; set; }

    [BindProperty]
    [Required]
    public string Sex { get; set; }

    [BindProperty]
    [Required]
    public string ContactNo { get; set; }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [BindProperty]
    [Required]
    public string Occupation { get; set; }

    [BindProperty]
    [Required]
    public string CivilStatus { get; set; }

    [BindProperty]
    [Required]
    public string PreferredPaymentFrequency { get; set; }

    [BindProperty]
    [Required]
    public int LoanTerm { get; set; }

    // File uploads can be handled here if needed, for now omitted for brevity

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Get user ID from claims
            var userIdClaim = User.FindFirst("UserId");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;

            // Create new Loan entity with all form fields
            var loan = new HouseApp.Models.Loan
            {
                UserId = userId,
                HouseId = null, // Explicitly set HouseId to null
                Amount = 0, // Amount is not in form, set to 0 or add field if needed
                TermMonths = LoanTerm,
                ApplicationDate = DateTime.UtcNow,
                Status = "Pending",
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Suffix = Suffix,
                Province = Province,
                Municipality = Municipality,
                Barangay = Barangay,
                StreetNo = StreetNo,
                HouseNo = HouseNo,
                Age = Age,
                BirthDate = BirthDate,
                Sex = Sex,
                ContactNo = ContactNo,
                Email = Email,
                Occupation = Occupation,
                CivilStatus = CivilStatus,
                PreferredPaymentFrequency = PreferredPaymentFrequency
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            // Show success alert and reload the page
            TempData["SuccessMessage"] = "Loan application submitted successfully.";
            return Page();
        }
}

