using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ContactModel : PageModel
{
    [BindProperty] public string Email { get; set; }
    [BindProperty] public string Subject { get; set; }
    [BindProperty] public string Message { get; set; }

    public string ResultMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var emailService = new EmailService();
        await emailService.SendEmailAsync("jazzun46@gmail.com", Subject, $"{Email}: {Message}");
        ResultMessage = "Email sent successfully!";
        return Page();
    }
}
