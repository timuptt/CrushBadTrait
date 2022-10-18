using System.Linq;
using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Secifications;
using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Services;

public class TraitCatalogViewModelService : ITraitCatalogViewModelService
{
    private readonly IRepository<Trait> _traitRepository;

    public TraitCatalogViewModelService(IRepository<Trait> traitRepository)
    {
        _traitRepository = traitRepository;
    }
    
    public async Task<TraitCatalogViewModel> GetTraitsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TraitCatalogViewModel> GetTraitsByUserIdAsync(Guid userId)
    {
        var specification = new TraitCatalogByUserIdSpecification(userId);
        var itemsOnPage = await _traitRepository.ListAsync(specification);

        var vm = new TraitCatalogViewModel()
        {
            Traits = itemsOnPage.Select(i => new TraitViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                UserId = i.UserId,
                AverageGrade = i.AverageGrade,
            }).ToList()
        };

        return vm;
    }
}