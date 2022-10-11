using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Interfaces;

public interface ITraitCatalogViewModelService
{
    Task<TraitCatalogViewModel> GetTraitsAsync();
    Task<TraitCatalogViewModel> GetTraitsByUserIdAsync(Guid userId);
}