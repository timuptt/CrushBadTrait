using CrushBadTrait.Core.Interfaces;

namespace CrushBadTrait.Core.Entities;

public class Trait : BaseEntity, IAggregateRoot
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double AverageGrade { get; set; }
    public List<DayReport> Days { get; set; }
}