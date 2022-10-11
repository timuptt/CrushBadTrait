using Ardalis.Specification.EntityFrameworkCore;
using CrushBadTrait.Core.Interfaces;
using CrushBadTrait.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrushBadTrait.Infrastructure.Repositories;

public class TraitRepository<T> : RepositoryBase<T>, IRepository<T> where T: class, IAggregateRoot
{
    public TraitRepository(DbContext dbContext) : base(dbContext)
    {
    }
}