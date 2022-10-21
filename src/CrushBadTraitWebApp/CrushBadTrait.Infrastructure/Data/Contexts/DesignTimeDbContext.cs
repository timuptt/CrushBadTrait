using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CrushBadTrait.Infrastructure.Data.Contexts;

public class DesignTimeDbContext : IDesignTimeDbContextFactory<CrushBadTraitDbContext>
{
    public CrushBadTraitDbContext CreateDbContext(string[] args)
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder() as IConfigurationBuilder;
        JsonConfigurationExtensions.AddJsonFile(configurationBuilder,
            Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
        IConfigurationRoot configuration = configurationBuilder.Build();

        var connectionString = configuration.GetConnectionString("SqlServer");

        DbContextOptionsBuilder<CrushBadTraitDbContext> builder = new();
        builder.UseSqlServer(connectionString);

        return new (builder.Options);
    }
}