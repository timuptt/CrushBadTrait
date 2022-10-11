namespace CrushBadTrait.Core.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Name { get; set; }
    public Guid UserDetailsId { get; set; }
    public UserDetails UserDetails { get; set; }
}