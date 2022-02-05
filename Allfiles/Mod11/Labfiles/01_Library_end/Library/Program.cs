using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Library.Data;
using Library.Middleware;
using Library.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 7;
    options.Password.RequireUppercase = true;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<LibraryContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireEmail", policy => policy.RequireClaim(ClaimTypes.Email));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var libraryContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    libraryContext.Database.EnsureDeleted();
    libraryContext.Database.EnsureCreated();
}


app.UseStaticFiles();
app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Library", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();
