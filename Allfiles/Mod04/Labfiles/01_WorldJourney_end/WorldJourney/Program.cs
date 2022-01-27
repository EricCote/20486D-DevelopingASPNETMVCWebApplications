using WorldJourney.Models;
using WorldJourney.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IData, Data>();
builder.Services.AddScoped<LogActionFilterAttribute>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "TravelerRoute",
    pattern: "{controller}/{action}/{name}",
    constraints: new { name = "[A-Za-z ]+" },
    defaults: new { controller = "Traveler", action = "Index", name = "Katie Bruce" });

app.MapControllerRoute(
   name: "default",
   pattern: "{controller}/{action}/{id?}",
   defaults: new { controller = "Home", action = "Index" },
   constraints: new { id = "[0-9]+" });

app.Run();