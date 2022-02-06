using Microsoft.EntityFrameworkCore;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RestaurantContext>(options =>
                  options.UseSqlite("Data Source=restaurant.db"));

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                     .AllowAnyMethod()
                                                                      .AllowAnyHeader()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var restaurantContext = scope.ServiceProvider.GetRequiredService<RestaurantContext>();
    restaurantContext.Database.EnsureDeleted();
    restaurantContext.Database.EnsureCreated();
}

app.UseCors("AllowAll");

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
