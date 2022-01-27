using CitiesWebsite.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICityProvider, CityProvider>();
builder.Services.AddSingleton<ICityFormatter, CityFormatter>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=ShowCities}/{id?}");

app.Run();
