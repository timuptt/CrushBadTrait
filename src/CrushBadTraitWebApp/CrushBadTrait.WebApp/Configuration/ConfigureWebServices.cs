using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.Services;
using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<ITraitCatalogViewModelService, TraitCatalogViewModelService>();

        return services;
    }
}