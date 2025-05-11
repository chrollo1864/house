using Microsoft.EntityFrameworkCore;

namespace HouseApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
    }

    public class House
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public int Bedrooms { get; set; }
        public int? Bathrooms { get; set; } // Changed to nullable int Bathrooms property
        public int? Floors { get; set; } // Changed to nullable int Floors property
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsFeatured { get; set; } // Added IsFeatured property
        public int PropertyTypeId { get; set; }
        public int LocationId { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Size { get; set; }
        public string? Description { get; set; }
        public DateTime RegisteredDate { get; set; }

        public PropertyType PropertyType { get; set; }
        public Location Location { get; set; }
        public DateTime CreatedAt { get; set; }
    }


    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiration { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }

    public class Loan
    {
        public int Id { get; set; }
        public int? HouseId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public double InterestRate { get; set; }
        public int TermMonths { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? Status { get; set; }  // Pending, Approved, Rejected

        // Extended fields from loan registration form
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string StreetNo { get; set; }
        public string HouseNo { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string CivilStatus { get; set; }
        public string PreferredPaymentFrequency { get; set; }

        public House House { get; set; }
        public User User { get; set; }
    }

    public class PropertyType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<House> Houses { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public ICollection<House> Houses { get; set; }
    }

    public class SiteSetting
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
