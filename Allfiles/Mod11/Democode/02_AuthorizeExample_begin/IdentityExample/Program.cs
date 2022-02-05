using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityExample.Data;
using IdentityExample.Models;
using IdentityExample.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlite("Data Source=student.db"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Student>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 7;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<StudentContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var studentContext = scope.ServiceProvider.GetRequiredService<StudentContext>();
    studentContext.Database.EnsureDeleted();
    studentContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
//app.UseAuthorization();

app.UseNodeModules(app.Environment.ContentRootPath);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Student", action = "Index" },
    constraints: new { id = "[0-9]+" });

app.Run();
