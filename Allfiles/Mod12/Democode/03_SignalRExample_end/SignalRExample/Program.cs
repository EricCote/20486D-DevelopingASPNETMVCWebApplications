using SignalRExample.Services;
using SignalRExample.Middleware;
using SignalRExample.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISquareManager, SquareManager>();
builder.Services.AddSignalR();

var app = builder.Build();
app.UseStaticFiles();
app.UseNodeModules(app.Environment.ContentRootPath);



app.UseRouting();

app.MapHub<SquaresHub>("/squareshub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Square}/{action=Index}/{id?}");
    
app.Run();


