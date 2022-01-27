using ButterfliesShop.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddSingleton<IButterfliesQuantityService, ButterfliesQuantityService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Butterfly", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();

