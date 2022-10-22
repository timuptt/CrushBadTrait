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
        if (configuration.GetSection("UseInMemoryDb").Value?.ToLower() != "true")
        {
            services.AddDbContext<DbContext, CrushBadTraitDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                        b => b.MigrationsAssembly(typeof(CrushBadTraitDbContext).Assembly.FullName)));
            return services;
        }
        
        services.AddDbContext<DbContext, CrushBadTraitDbContext>(o => 
            o.UseInMemoryDatabase("Traits"));
            
        return services;
    }
}