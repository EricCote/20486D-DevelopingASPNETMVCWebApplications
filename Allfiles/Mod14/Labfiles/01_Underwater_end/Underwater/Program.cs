using Microsoft.EntityFrameworkCore;
using Underwater.Data;
using Underwater.Middleware;
using Underwater.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUnderwaterRepository, UnderwaterRepository>();

builder.Services.AddDbContext<UnderwaterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var underwaterContext = scope.ServiceProvider.GetRequiredService<UnderwaterContext>();
    underwaterContext.Database.EnsureDeleted();
    underwaterContext.Database.EnsureCreated();
}

app.UseStaticFiles();
//app.UseStaticFiles("node_modules");

app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Aquarium", action = "Index" },
    constraints: new { id = "[0-9]+" });


app.Run();
