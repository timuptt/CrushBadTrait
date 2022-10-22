using CrushBadTrait.Core.Entities;
using CrushBadTrait.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CrushBadTrait.Infrastructure.Data.Contexts;

public class CrushAndTraitDbContextSeeder
{
    private static readonly Guid User1Id = Guid.NewGuid();
    private static readonly Guid User2Id = Guid.NewGuid(); 
    public static async Task SeedAsync(CrushBadTraitDbContext context, ILogger logger, int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync();
            }
            
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
    
    public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider, ILogger logger)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                //Roles
                logger.Log(LogLevel.Information, "Seeding user roles...");
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                
                if (!await roleManager.RoleExistsAsync(UserRoles.ADMIN))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.ADMIN));
                if (!await roleManager.RoleExistsAsync(UserRoles.USER))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.USER));

                //Users
                logger.Log(LogLevel.Information, "Seeding users...");
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "admin@example.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        Id = User2Id.ToString(),
                        UserName = "admin",
                        Name = "Admin Name",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        NormalizedEmail = adminUserEmail.ToUpper(),
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.ADMIN);
                }

                string appUserEmail = "user@example.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        Id = User1Id.ToString(),
                        UserName = "user",
                        Name = "User Name",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        UserDetails = new UserDetails()
                        {
                            EndOfDayTime = new TimeSpan(22,0,0),
                            Id = Guid.NewGuid(),
                            StartImprovingDate = DateTime.Now.AddDays(-1),
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "User1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.USER);
                }
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
                UserId = User1Id,
                Name = "Doomscrolling",
                Description = "Uncontroled scrolling news",
                AverageGrade = 0.0
            },
            new Trait()
            {
                Id = trait2Id,
                UserId = User1Id,
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