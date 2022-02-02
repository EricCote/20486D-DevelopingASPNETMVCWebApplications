using EntityFrameworkExample.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PersonContext>(options =>
                  options.UseSqlite("Data Source=person.db"));


var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var personContext = scope.ServiceProvider.GetRequiredService<PersonContext>();
    personContext.Database.EnsureDeleted();
    personContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Person}/{action=Index}/{id?}");
app.Run();

