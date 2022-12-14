using Ardalis.Specification;
using CrushBadTrait.Core.Entities;

namespace CrushBadTrait.Core.Secifications;

public sealed class TraitsWithoutCurrentDayReportSpecification : Specification<Trait>
{
    public TraitsWithoutCurrentDayReportSpecification(Guid userId)
    {
        Query.Include(t => t.DayReports)
            .Where(t=> t.UserId == userId)
            .Where(t => t.DayReports!.Count == 0 || t.DayReports.AsEnumerable()
                .OrderBy(d => d.Date).Last().Date.Date < DateTime.Now.Date); 
    }
}