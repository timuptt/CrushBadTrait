using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Interfaces;

public interface IUserService
{
    Task<ProfileViewModel> GetUserProfile(Guid userId);
}