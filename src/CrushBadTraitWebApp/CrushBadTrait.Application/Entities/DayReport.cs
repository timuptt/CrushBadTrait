using Ardalis.GuardClauses;
using CrushBadTrait.Core.Interfaces;

namespace CrushBadTrait.Core.Entities;

public sealed class DayReport : BaseEntity, IEntity
{
    public Guid TraitId { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; } = string.Empty;
    public int Periodicity { get; set; }
    public int Grade { get; set; }

    public DayReport() { }

    public DayReport(Guid traitId, string note, int periodicity, int grade)
    {
        Guard.Against.NullOrEmpty(traitId);
        Guard.Against.NullOrWhiteSpace(note);
        Guard.Against.Negative(periodicity);
        Guard.Against.Negative(grade);
        
        Id = Guid.NewGuid();
        TraitId = traitId;
        Date = DateTime.Now;
        Note = note;
        Periodicity = periodicity;
        Grade = grade;
    }
}