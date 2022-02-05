using CachingExample.Data;
using CachingExample.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var productContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
    productContext.Database.EnsureDeleted();
    productContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
