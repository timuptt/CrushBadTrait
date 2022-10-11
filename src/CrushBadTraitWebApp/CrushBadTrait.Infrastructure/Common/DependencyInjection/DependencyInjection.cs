using CrushBadTrait.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrushBadTrait.Infrastructure.Common.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection ImplementPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<CrushBadTraitDbContext>(o => 
            o.UseInMemoryDatabase("Traits"));
        
        // services.AddDbContext<CrushBadTraitDbContext>(options =>
        //         options.UseSqlite(configuration.GetConnectionString("SQLiteConnectionString"),
        //             b => b.MigrationsAssembly(typeof(CrushBadTraitDbContext).Assembly.FullName)), 
        //     ServiceLifetime.Transient);

        return services;
    }
}