using Microsoft.AspNetCore.Identity;

namespace CrushBadTrait.Core.Entities.Interfaces;

public interface IIdentityService
{
    Task<SignInResult> LoginAsync(string email, string password);
    Task<IdentityResult> RegisterAsync(string email, string password, TimeOnly endOfDayTime, string name);
    Task LogoutAsync();
}