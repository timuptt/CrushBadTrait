using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Interfaces.Services;
using CrushBadTrait.Core.Services;
using CrushBadTrait.Infrastructure.Repositories;

namespace CrushBadTrait.WebApp.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(TraitRepository<>));

        services.AddScoped<ITraitService, TraitService>();

        return services;
    }
}