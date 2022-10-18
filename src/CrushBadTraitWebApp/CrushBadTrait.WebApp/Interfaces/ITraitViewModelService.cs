using CrushBadTrait.WebApp.ViewModels;

namespace CrushBadTrait.WebApp.Interfaces;

public interface ITraitViewModelService
{
    Task<TraitViewModel> GetTraitByIdAsync(Guid id);
}