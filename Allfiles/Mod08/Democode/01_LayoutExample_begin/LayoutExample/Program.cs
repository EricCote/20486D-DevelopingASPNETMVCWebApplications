using LayoutExample.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentContext>(options =>
                  options.UseSqlite("Data Source=student.db"));


var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var studentContext = scope.ServiceProvider.GetRequiredService<StudentContext>();
    studentContext.Database.EnsureDeleted();
    studentContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Student", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();

