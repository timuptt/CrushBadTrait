using Ardalis.GuardClauses;
using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Interfaces.Services;
using CrushBadTrait.Core.Secifications;

namespace CrushBadTrait.Core.Services;

public class DayReportsService : IDayReportsService
{
    private readonly IRepository<Trait> _traitRepository;
    private readonly IRepository<DayReport> _dayReportRepository;

    public DayReportsService(IRepository<Trait> traitRepository, 
        IRepository<DayReport> dayReportRepository)
    {
        _traitRepository = traitRepository;
        _dayReportRepository = dayReportRepository;
    }

    public async Task EnterDayReport(Guid traitId, string note, int periodicity, int grade)
    {
        await UpdateTrait(traitId, grade);
        
        var createdDayReport = await CreateDayReport(traitId, note, periodicity, grade);
        
        if (createdDayReport == null) throw new NotFoundException(traitId.ToString(), nameof(traitId));
    }

    public async Task<IEnumerable<(Guid, string)>> GetTraitIdAndNamesToReport(Guid userId)
    {
        var specification = new TraitsWithoutCurrentDayReportSpecification(userId);
        
        var traits = await _traitRepository.ListAsync(specification);
        
        return traits.Select(t => (t.Id, t.Name));
    }

    private async Task<DayReport> CreateDayReport(Guid traitId, string note, int periodicity, int grade)
    {
        var dayReport = new DayReport(traitId, note, periodicity, grade);

        return await _dayReportRepository.AddAsync(dayReport);
    }

    private async Task UpdateTrait(Guid traitId, int grade)
    {
        var trait = await _traitRepository.GetByIdAsync(traitId);

        if (trait == null) throw new NotFoundException(traitId.ToString(), nameof(Trait));
        
        trait.UpdateMetrics(grade);

        await _traitRepository.UpdateAsync(trait);
    }
}