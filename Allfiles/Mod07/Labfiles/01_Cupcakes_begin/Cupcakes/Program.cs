var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "cupcakeRoute",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Cupcake", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


