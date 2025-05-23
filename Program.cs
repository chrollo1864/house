using Microsoft.EntityFrameworkCore;
using HouseApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))));

// Add cookie authentication
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "HouseApp.AuthCookie";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

// Configure session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages(options =>
{
    // Configure authorization for admin area
    options.Conventions.AuthorizeFolder("/Admin", "AdminOnly");
});

// Add API controllers
builder.Services.AddControllers();

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("Role", "Admin"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapRazorPages();
app.MapControllers();

// Ensure upload directories exist
var uploadsPath = Path.Combine(app.Environment.WebRootPath, "uploads");
var profilesPath = Path.Combine(uploadsPath, "profiles");
var housesPath = Path.Combine(uploadsPath, "houses");

Directory.CreateDirectory(uploadsPath);
Directory.CreateDirectory(profilesPath);
Directory.CreateDirectory(housesPath);



app.Run();
