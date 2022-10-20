using CrushBadTrait.Core.Entities.Interfaces;
using CrushBadTrait.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrushBadTrait.WebApp.Controllers;

public class AccountController : Controller
{
    private readonly IIdentityService _identityService;

    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel request)
    {
        if (!ModelState.IsValid) return View(request);

        var result = await _identityService.LoginAsync(request.Email, request.Password);

        if (!result.Succeeded)
        {
            return View(request);
        }

        return RedirectToAction("Index", "TraitCatalog");
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel request)
    {
        if (!ModelState.IsValid) return View(request);

        var result =
            await _identityService.RegisterAsync(request.Email, request.Password, request.EndOfDayTime, request.Name);

        if (!result.Succeeded)
        {
            TempData["Error"] = string.Join(' ', result.Errors.Select(e => e.Description));
            return View(request);
        }

        return RedirectToAction("Login", new LoginViewModel() { Email = request.Email });
    }

    public async Task<IActionResult> Logout()
    {
        await _identityService.LogoutAsync();
        return RedirectToAction("Login");
    }
}