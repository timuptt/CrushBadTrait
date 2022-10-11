using CrushBadTrait.Core.Interfaces;

namespace CrushBadTrait.Core.Entities;

public class DayReport : BaseEntity, IAggregateRoot
{
    public Guid TraitId { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; }
    public int Periodicity { get; set; }
    public int Grade { get; set; }
}