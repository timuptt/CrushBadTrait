using CrushBadTrait.Core.Entities.Interfaces;
using CrushBadTrait.WebApp.Services;

namespace CrushBadTrait.WebApp.Identity;

public static class ConfigureIdentityService
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}