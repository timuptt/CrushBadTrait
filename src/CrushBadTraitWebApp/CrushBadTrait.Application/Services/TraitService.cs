using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Interfaces.Services;

namespace CrushBadTrait.Core.Services;

public class TraitService : ITraitService
{
    private readonly IRepository<Trait> _traitRepository;

    public TraitService(IRepository<Trait> traitRepository)
    {
        _traitRepository = traitRepository;
    }

    public async Task<Trait> CreateTrait(Guid userId, string name, string description)
    {
        var trait = new Trait(userId, name, description);
        return await _traitRepository.AddAsync(trait);
    }

    public async Task<Trait?> UpdateTrait(Guid id, string name, string description)
    {
        var trait = await _traitRepository.GetByIdAsync(id);
        if (trait != null)
        {
            trait.Name = name;
            trait.Description = description;
            await _traitRepository.UpdateAsync(trait);
        }

        return null;
    }

    public async Task DeleteTrait(Guid id)
    {
        var trait = await _traitRepository.GetByIdAsync(id);
        if (trait != null)
        {
            await _traitRepository.DeleteAsync(trait);
        }
    }
}