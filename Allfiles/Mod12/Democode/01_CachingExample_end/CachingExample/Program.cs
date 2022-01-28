using Microsoft.EntityFrameworkCore;
using CachingExample.Data;
using CachingExample.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(connectionString));

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


