using Microsoft.EntityFrameworkCore;
using IceCreamCompany.Data;
using IceCreamCompany.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddDbContext<IceCreamContext>(options =>
                  options.UseSqlite("Data Source=iceCream.db"));


var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var iceCreamContext = scope.ServiceProvider.GetRequiredService<IceCreamContext>();
    iceCreamContext.Database.EnsureDeleted();
    iceCreamContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "IceCream", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


