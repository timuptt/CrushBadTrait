using System.Security.Claims;
using CrushBadTrait.Core.Entities.Interfaces;

namespace CrushBadTrait.WebApp.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    public Guid UserId
    {
        get
        {
            var id = _httpContextAccessor.HttpContext?.User
                .Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
        }
    }
}