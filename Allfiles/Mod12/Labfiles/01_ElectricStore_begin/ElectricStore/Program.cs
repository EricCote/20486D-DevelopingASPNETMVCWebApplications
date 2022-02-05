using Microsoft.EntityFrameworkCore;
using ElectricStore.Middleware;
using ElectricStore.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=electricStore.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var storeContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    storeContext.Database.EnsureDeleted();
    storeContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Products", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


