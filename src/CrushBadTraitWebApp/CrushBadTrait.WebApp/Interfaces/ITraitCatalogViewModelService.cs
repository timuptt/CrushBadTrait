using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Interfaces;

public interface ITraitCatalogViewModelService
{
    Task<TraitCatalogViewModel> GetTraitsByUserIdAsync(Guid userId);
}