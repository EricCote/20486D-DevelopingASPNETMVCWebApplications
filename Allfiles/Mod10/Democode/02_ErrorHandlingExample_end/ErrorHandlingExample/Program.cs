using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICounter, Counter>();
builder.Services.AddSingleton<IDivisionCalculator, DivisionCalculator>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error.html");
}

app.UseStaticFiles();

var cnt = app.Services.GetRequiredService<ICounter>();

app.Use(async (context, next) =>
{
    cnt.IncrementRequestPathCount(context.Request.GetDisplayUrl());
    await next.Invoke();
});

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


