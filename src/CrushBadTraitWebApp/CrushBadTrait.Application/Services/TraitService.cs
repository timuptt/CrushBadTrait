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

    public async Task<Trait> CreateTrait()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Trait>> GetTraits()
    {
        throw new NotImplementedException();
    }

    public async Task<Trait> GetTrait(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Trait> UpdateTrait(Guid id, Trait updatedTrait)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTrait(Guid id)
    {
        throw new NotImplementedException();
    }
}