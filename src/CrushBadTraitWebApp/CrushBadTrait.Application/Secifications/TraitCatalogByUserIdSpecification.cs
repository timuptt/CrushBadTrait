using Ardalis.Specification;
using CrushBadTrait.Core.Entities;

namespace CrushBadTrait.Core.Secifications;

public sealed class TraitCatalogByUserIdSpecification : Specification<Trait>
{
    public TraitCatalogByUserIdSpecification(Guid? userId)
    {
        Query.Where(t => t.UserId == userId);
    }
}