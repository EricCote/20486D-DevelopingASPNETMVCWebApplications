using Microsoft.EntityFrameworkCore;
using ZooSite.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ZooContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var zooContext = scope.ServiceProvider.GetRequiredService<ZooContext>();
    zooContext.Database.EnsureDeleted();
    zooContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Zoo", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


