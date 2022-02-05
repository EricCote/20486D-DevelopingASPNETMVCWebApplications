using Microsoft.EntityFrameworkCore;
using CachingExample.Data;
using CachingExample.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var productContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
    productContext.Database.EnsureDeleted();
    productContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");
    
app.Run();


