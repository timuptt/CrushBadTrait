using CrushBadTrait.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrushBadTrait.Infrastructure.Data.Contexts;

public class CrushBadTraitDbContext : IdentityDbContext<User>
{
    public DbSet<DayReport> Days { get; set; }
    public DbSet<Trait> Traits { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }
    
    public CrushBadTraitDbContext(DbContextOptions<CrushBadTraitDbContext> options) : base(options) { }
}