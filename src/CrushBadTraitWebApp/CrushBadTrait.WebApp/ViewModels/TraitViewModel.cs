namespace CrushBadTrait.WebApp.ViewModels;

public class TraitViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double AverageGrade { get; set; }
    public List<DayReportViewModel>? DayReports { get; set; }
}