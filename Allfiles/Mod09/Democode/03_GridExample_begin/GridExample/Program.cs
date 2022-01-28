using Microsoft.EntityFrameworkCore;
using GridExample.Data;
using GridExample.Middleware;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ChessLeagueContext>(options =>
                  options.UseSqlite("Data Source=chessLeague.db"));


var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var chessLeagueContext = scope.ServiceProvider.GetRequiredService<ChessLeagueContext>();
    chessLeagueContext.Database.EnsureDeleted();
    chessLeagueContext.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Chess", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();


