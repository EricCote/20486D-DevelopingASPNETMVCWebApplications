var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapControllerRoute(
   name: "firstRoute",
   pattern: "{controller}/{action}/{num:int}");

app.MapControllerRoute(
   name: "secondRoute",
   pattern: "{controller}/{action}/{id?}",
   defaults: new {controller="Home", action="Index"}
   );


app.Run();  