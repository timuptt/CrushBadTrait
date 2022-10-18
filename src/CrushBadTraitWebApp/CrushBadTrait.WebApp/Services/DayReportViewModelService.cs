using CrushBadTrait.Core.Interfaces.Services;
using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Services;

public class DayReportViewModelService : IDayReportViewModelService
{
    public DayReportsViewModel CreateDayReports(IEnumerable<(Guid, string)> idAndNames)
    {
        var dayReportsViewModel = new DayReportsViewModel()
        {
            DayReports = idAndNames.Select(idAndNames => new CreateDayReportViewModel()
                { TraitId = idAndNames.Item1, TraitName = idAndNames.Item2 }).ToList()
        };
        
        return dayReportsViewModel;
    }
}