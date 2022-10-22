using CrushBadTrait.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CrushBadTrait.Infrastructure.Identity;

public class User : IdentityUser
{
    public string? Name { get; set; }
    public Guid UserDetailsId { get; set; }
    public UserDetails? UserDetails { get; set; }
}