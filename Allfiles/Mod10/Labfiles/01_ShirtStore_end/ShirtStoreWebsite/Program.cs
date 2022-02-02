using ShirtStoreWebsite.Data;
using ShirtStoreWebsite.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    var config = builder.Configuration.GetSection("Logging");

    logging.ClearProviders();

    if (builder.Environment.IsDevelopment())
    {
        logging.AddConfiguration(config);
        logging.AddConsole();
    }
    else
    {
        logging.AddFile(config);
    }

});

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShirtContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IShirtRepository, ShirtRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error.html");
}


using (var scope = app.Services.CreateScope())
{
    var shirtContext = scope.ServiceProvider.GetRequiredService<ShirtContext>();
    shirtContext.Database.EnsureDeleted();
    shirtContext.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shirt}/{action=Index}/{id?}");

app.Run();


