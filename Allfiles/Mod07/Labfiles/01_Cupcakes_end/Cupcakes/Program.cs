using Cupcakes.Data;
using Microsoft.EntityFrameworkCore;
using Cupcakes.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICupcakeRepository, CupcakeRepository>();
builder.Services.AddDbContext<CupcakeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

  
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "cupcakeRoute",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Cupcake", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


