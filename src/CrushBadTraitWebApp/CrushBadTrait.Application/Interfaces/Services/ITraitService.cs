using CrushBadTrait.Core.Entities;

namespace CrushBadTrait.Core.Interfaces.Services;

public interface ITraitService
{
    Task<Trait> CreateTrait();
    Task<IEnumerable<Trait>> GetTraits();
    Task<Trait> GetTrait(Guid id);
    Task<Trait> UpdateTrait(Guid id, Trait updatedTrait);
    Task DeleteTrait(Guid id);
}