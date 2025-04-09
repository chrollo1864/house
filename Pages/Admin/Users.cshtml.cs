using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HouseApp.Pages.Admin
{
    public class AdminUsersModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminUsersModel(AppDbContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }

        [BindProperty]
        public User NewUser { get; set; } = new User(); // Ensuring NewUser is not null

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            Users = _context.Users.ToList();
        }

        // POST handler to add a new user
        public IActionResult OnPostAddUser()
        {
            if (ModelState.IsValid)
            {
                NewUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
                NewUser.RegisteredDate = System.DateTime.Now;
                
                _context.Users.Add(NewUser);
                _context.SaveChanges();
                return RedirectToPage();
            }
            return Page();
        }

        // POST handler to delete a user
        public IActionResult OnPostDeleteUser(int id)
        {
            var user = _context.Users.Find(id); // Faster than FirstOrDefault
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
