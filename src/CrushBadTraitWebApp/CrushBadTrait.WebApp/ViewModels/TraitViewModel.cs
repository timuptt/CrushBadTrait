namespace CrushBadTrait.WebApp.ViewModels;

public class TraitViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double AverageGrade { get; set; }
    public List<DayReportViewModel> Days { get; set; }
}