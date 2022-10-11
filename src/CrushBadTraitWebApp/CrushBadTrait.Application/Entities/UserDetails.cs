namespace CrushBadTrait.Core.Entities;

public class UserDetails : BaseEntity
{
    public DateTime StartImprovingDate { get; set; }
    public TimeOnly EndOfDayTime { get; set; }
}