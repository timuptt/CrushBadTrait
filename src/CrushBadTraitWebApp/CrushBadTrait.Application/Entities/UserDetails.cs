using CrushBadTrait.Core.Interfaces;

namespace CrushBadTrait.Core.Entities;

public class UserDetails : BaseEntity, IEntity
{
    public DateTime StartImprovingDate { get; set; }
    public TimeSpan EndOfDayTime { get; set; }
}