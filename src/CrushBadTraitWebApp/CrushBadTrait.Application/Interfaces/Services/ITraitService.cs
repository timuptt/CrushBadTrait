using CrushBadTrait.Core.Entities;

namespace CrushBadTrait.Core.Interfaces.Services;

public interface ITraitService
{
    Task<Trait> CreateTrait(Guid userId, string name, string description);
    Task<Trait?> UpdateTrait(Guid id, string name, string description);
    Task DeleteTrait(Guid id);
}