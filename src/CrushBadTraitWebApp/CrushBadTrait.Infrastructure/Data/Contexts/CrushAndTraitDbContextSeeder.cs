using CrushBadTrait.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrushBadTrait.Infrastructure.Data.Contexts;

public class CrushAndTraitDbContextSeeder
{
    public static async Task SeedAsync(CrushBadTraitDbContext context, ILogger logger, int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (!await context.Traits.AnyAsync())
            {
                await context.AddRangeAsync(GetPreconfiguredTraits());

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;
            
            logger.LogError(ex.Message);
            await SeedAsync(context, logger, retryForAvailability);
            throw;
        }
    }

    private static IEnumerable<Trait> GetPreconfiguredTraits()
    {
        var trait2Id = Guid.NewGuid();

        return new List<Trait>()
        {
            new Trait()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Empty,
                Name = "Doomscrolling",
                Description = "Uncontroled scrolling news",
                AverageGrade = 0.0
            },
            new Trait()
            {
                Id = trait2Id,
                UserId = Guid.Empty,
                Name = "Procrastination",
                Description =
                    "unnecessarily and voluntarily delaying or postponing something despite knowing that there will be negative consequences for doing so",
                AverageGrade = 3,
                DayReports = new List<DayReport>()
                {
                    new DayReport()
                    {
                        Id = Guid.NewGuid(),
                        Note = "Still procrastinating",
                        Date = DateTime.Now.AddDays(-2),
                        Grade = 3,
                        Periodicity = 3,
                        TraitId = trait2Id
                    },
                    new DayReport()
                    {
                        Id = Guid.NewGuid(),
                        Note = "Procrastinating two times",
                        Date = DateTime.Now.AddDays(-1),
                        Grade = 3,
                        Periodicity = 2,
                        TraitId = trait2Id
                    }
                }
            }
        };
    }
}