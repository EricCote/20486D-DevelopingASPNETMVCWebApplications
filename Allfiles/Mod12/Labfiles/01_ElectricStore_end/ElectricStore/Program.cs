using Microsoft.EntityFrameworkCore;
using ElectricStore.Middleware;
using ElectricStore.Data;
using ElectricStore.Hubs;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=electricStore.db"));

builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromSeconds(60);
    });

builder.Services.AddSignalR();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var storeContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    storeContext.Database.EnsureDeleted();
    storeContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseNodeModules(app.Environment.ContentRootPath);
app.UseSession();

app.UseRouting();

app.MapHub<ChatHub>("/chatHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}/{RefreshCache?}",
    defaults: new { controller = "Products", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


