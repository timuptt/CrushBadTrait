namespace CrushBadTrait.WebApp.ViewModels;

public class CreateDayReportViewModel
{
    public Guid TraitId { get; set; }
    public string TraitName { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public int Periodicity { get; set; }
    public int Grade { get; set; }
}