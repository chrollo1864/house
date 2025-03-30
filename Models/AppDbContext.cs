using Microsoft.EntityFrameworkCore;

namespace HouseApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }

    public class House
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Bedrooms { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, User, etc.
    }

    public class Loan
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public double InterestRate { get; set; }
        public int TermMonths { get; set; }

        public House House { get; set; }
        public User User { get; set; }
    }
}