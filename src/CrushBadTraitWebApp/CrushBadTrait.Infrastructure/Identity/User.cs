using Microsoft.AspNetCore.Identity;

namespace CrushBadTrait.Core.Entities;

public class User : IdentityUser
{
    public string? Name { get; set; }
    public Guid UserDetailsId { get; set; }
    public UserDetails? UserDetails { get; set; }
}