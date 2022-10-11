namespace CrushBadTrait.WebApp.ViewModels;

public class DayReportViewModel
{
    public Guid Id { get; set; }
    public Guid TraitId { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; }
    public int Periodicity { get; set; }
    public int Grade { get; set; }
}