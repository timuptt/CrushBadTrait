using CrushBadTrait.Core.Entities;
using CrushBadTrait.Infrastructure.Common.DependencyInjection;
using CrushBadTrait.Infrastructure.Data.Contexts;
using CrushBadTrait.Infrastructure.Identity;
using CrushBadTrait.WebApp.Configuration;
using CrushBadTrait.WebApp.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

// Add services to the container. Enable runtime compilation.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.ImplementPersistence(builder.Configuration);
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<CrushBadTraitDbContext>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddCoreServices();
builder.Services.AddWebServices();
builder.Services.AddIdentityService();

builder.Services.AddHttpContextAccessor();

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
        await CrushAndTraitDbContextSeeder.SeedUsersAndRolesAsync(scopedProvider, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();