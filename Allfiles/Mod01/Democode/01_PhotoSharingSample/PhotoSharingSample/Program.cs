using Microsoft.EntityFrameworkCore;
using PhotoSharingSample.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PhotoSharingContext");
builder.Services.AddDbContext<PhotoSharingDB>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var photoSharingDB = scope.ServiceProvider.GetRequiredService<PhotoSharingDB>();
    photoSharingDB.Database.EnsureDeleted();
    photoSharingDB.Database.EnsureCreated();
}


app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();











// namespace PhotoSharingSample
// {
// 	public class Program
// 	{
// 		public static void Main(string[] args)
// 		{
// 			CreateHostBuilder(args).Build().Run();
// 		}

// 		public static IHostBuilder CreateHostBuilder(string[] args) =>
// 			Host.CreateDefaultBuilder(args)
// 				.ConfigureWebHostDefaults(webBuilder =>
// 					{
// 						webBuilder.UseStartup<Startup>();
// 					});
// 	}
// }

