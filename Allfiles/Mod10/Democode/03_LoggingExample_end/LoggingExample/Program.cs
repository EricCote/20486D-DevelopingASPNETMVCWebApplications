using LoggingExample.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    var config = builder.Configuration.GetSection("Logging");

    logging.ClearProviders();

    if (builder.Environment.IsDevelopment())
    {
        logging.AddConfiguration(config);
        logging.AddConsole();
    }
    else
    {
        logging.AddFile(config);
    }
});

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


app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


