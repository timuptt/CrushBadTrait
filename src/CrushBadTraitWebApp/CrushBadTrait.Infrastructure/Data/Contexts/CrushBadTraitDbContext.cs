using CrushBadTrait.Core.Entities;
using CrushBadTrait.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrushBadTrait.Infrastructure.Data.Contexts;

public class CrushBadTraitDbContext : IdentityDbContext<User>
{
    public DbSet<DayReport> Days { get; set; } = null!;
    public DbSet<Trait> Traits { get; set; } = null!;
    public DbSet<UserDetails> UserDetails { get; set; } = null!;

    public CrushBadTraitDbContext(DbContextOptions<CrushBadTraitDbContext> options) : base(options) { }
}