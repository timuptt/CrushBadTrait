namespace CrushBadTrait.Infrastructure.Identity.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
}