var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();;

var app = builder.Build();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
