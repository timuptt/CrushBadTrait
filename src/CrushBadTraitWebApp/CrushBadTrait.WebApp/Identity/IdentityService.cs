using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Entities.Interfaces;
using CrushBadTrait.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CrushBadTrait.WebApp.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<SignInResult> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null) return SignInResult.Failed;
        
        var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, password);

        if (!passwordIsCorrect) return SignInResult.Failed;
        
        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        
        return result;
    }

    public async Task<IdentityResult> RegisterAsync(string email, string password, TimeSpan endOfDayTime, string name)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user != null)
        {
            return IdentityResult.Failed();
        }

        var newUser = new User()
        {
            Email = email,
            UserName = email,
            Name = name,
            UserDetails = new UserDetails()
            {
                Id = Guid.NewGuid(),
                StartImprovingDate = DateTime.Now,
                EndOfDayTime = endOfDayTime
            }
        };

        var newUserResponse = await _userManager.CreateAsync(newUser, password);

        if (!newUserResponse.Succeeded) return newUserResponse;
        
        var addRoleResponse = await _userManager.AddToRoleAsync(newUser, UserRoles.USER);

        return addRoleResponse;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}