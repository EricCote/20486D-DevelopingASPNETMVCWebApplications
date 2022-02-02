using ShirtStoreWebsite.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShirtContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var shirtContext = scope.ServiceProvider.GetRequiredService<ShirtContext>();
    shirtContext.Database.EnsureDeleted();
    shirtContext.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shirt}/{action=Index}/{id?}");

app.Run();


