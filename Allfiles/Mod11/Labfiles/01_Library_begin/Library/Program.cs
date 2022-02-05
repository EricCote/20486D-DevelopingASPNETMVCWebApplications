using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Library", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();
