using Ardalis.GuardClauses;
using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Infrastructure.Identity;
using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CrushBadTrait.WebApp.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IRepository<UserDetails> _userDetailsRepository;

    public UserService(IRepository<UserDetails> userDetailsRepository, UserManager<User> userManager)
    {
        _userDetailsRepository = userDetailsRepository;
        _userManager = userManager;
    }

    public async Task<ProfileViewModel> GetUserProfile(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null) throw new NotFoundException(userId.ToString(), nameof(User));

        var userDetails = await _userDetailsRepository.GetByIdAsync(user.UserDetailsId);
        
        if (userDetails == null) throw new NotFoundException(user.UserDetailsId.ToString(), nameof(UserDetails));

        var profile = new ProfileViewModel()
        {
            Name = user.Name,
            EndOfDayTime = userDetails.EndOfDayTime,
            StartImprovingDate = userDetails.StartImprovingDate
        };

        return profile;
    }
}