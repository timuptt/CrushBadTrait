using CrushBadTrait.Infrastructure.Identity.Interfaces;
using CrushBadTrait.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrushBadTrait.WebApp.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public UserController(IUserService userService, ICurrentUserService currentUserService)
    {
        _userService = userService;
        _currentUserService = currentUserService;
    }

    // GET
    public async Task<IActionResult> Profile()
    {
        var profileViewModel = await _userService.GetUserProfile(_currentUserService.UserId);
        return View(profileViewModel);
    }
}