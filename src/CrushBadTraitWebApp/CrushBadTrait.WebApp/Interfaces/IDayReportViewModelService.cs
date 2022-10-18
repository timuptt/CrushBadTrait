using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Interfaces;

public interface IDayReportViewModelService
{
    DayReportsViewModel CreateDayReports(IEnumerable<(Guid, string)> idAndNames);
}