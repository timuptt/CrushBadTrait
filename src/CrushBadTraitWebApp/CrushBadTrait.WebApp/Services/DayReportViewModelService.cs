using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Services;

public class DayReportViewModelService : IDayReportViewModelService
{
    public DayReportsViewModel CreateDayReports(IEnumerable<(Guid, string)> idAndNames)
    {
        var dayReportsViewModel = new DayReportsViewModel()
        {
            DayReports = idAndNames.Select(ian => new CreateDayReportViewModel()
                { TraitId = ian.Item1, TraitName = ian.Item2 }).ToList()
        };
        
        return dayReportsViewModel;
    }
}