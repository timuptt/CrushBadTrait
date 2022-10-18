using CrushBadTrait.Core.Entities;

namespace CrushBadTrait.Core.Interfaces.Services;

public interface IDayReportsService
{
    Task EnterDayReport(Guid traitId, string note, int periodicity, int grade);
    Task<IEnumerable<(Guid, string)>> GetTraitIdAndNamesToReport(Guid userId);
}