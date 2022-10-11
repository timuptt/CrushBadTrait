using CrushBadTrait.Infrastructure.Common.DependencyInjection;
using CrushBadTrait.Infrastructure.Data.Contexts;
using CrushBadTrait.WebApp.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Services.ImplementPersistence(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreServices();
builder.Services.AddWebServices();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Logger.LogInformation("Seeding Database...");
using var scope = app.Services.CreateScope();
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<CrushBadTraitDbContext>();

        await CrushAndTraitDbContextSeeder.SeedAsync(context, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();