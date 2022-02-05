using SignalRExample.Services;
using SignalRExample.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISquareManager, SquareManager>();

var app = builder.Build();
app.UseStaticFiles();
app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Square}/{action=Index}/{id?}");
    
app.Run();


