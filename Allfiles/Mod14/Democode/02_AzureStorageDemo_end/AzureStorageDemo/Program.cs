using Microsoft.EntityFrameworkCore;
using AzureStorageDemo.Data;
using AzureStorageDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PhotoContext>(options =>
                  options.UseSqlite("Data Source=photoDb.db"));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var photoContext = scope.ServiceProvider.GetRequiredService<PhotoContext>();
    photoContext.Database.EnsureDeleted();
    photoContext.Database.EnsureCreated();
}

app.UseStaticFiles();
//app.UseStaticFiles("node_modules");

app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
