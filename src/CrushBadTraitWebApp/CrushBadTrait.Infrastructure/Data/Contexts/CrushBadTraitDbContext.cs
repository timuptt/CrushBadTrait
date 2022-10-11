using System.Reflection;
using CrushBadTrait.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrushBadTrait.Infrastructure.Data.Contexts;

public class CrushBadTraitDbContext : DbContext
{
    public DbSet<DayReport> Days { get; set; }
    public DbSet<Trait> Traits { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }
    
    public CrushBadTraitDbContext(DbContextOptions<CrushBadTraitDbContext> options) : base(options) { }
}