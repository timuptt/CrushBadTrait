using Ardalis.Specification;
using CrushBadTrait.Core.Entities;

namespace CrushBadTrait.Core.Secifications;

public sealed class TraitWithDaysByIdSpecification : Specification<Trait>
{
    public TraitWithDaysByIdSpecification(Guid id)
    {
        Query.Where(t => t.Id == id)
            .Include(t => t.DayReports);
    }
}