using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Data;
using EntityFrameworkExample.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PersonContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository, MyRepository>();


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


