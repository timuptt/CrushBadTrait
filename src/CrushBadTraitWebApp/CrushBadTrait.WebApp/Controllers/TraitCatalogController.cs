using CrushBadTrait.Core.Interfaces.Services;
using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrushBadTrait.WebApp.Controllers;

public class TraitCatalogController : Controller
{
    private readonly ITraitCatalogViewModelService _traitCatalogViewModelService;
    private readonly ITraitViewModelService _traitViewModelService;
    private readonly ITraitService _traitService;

    public TraitCatalogController(ITraitCatalogViewModelService traitCatalogViewModelService, 
        ITraitViewModelService traitViewModelService, ITraitService traitService)
    {
        _traitCatalogViewModelService = traitCatalogViewModelService;
        _traitViewModelService = traitViewModelService;
        _traitService = traitService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var traitCatalogVM = await GetTraitCatalogAsync();
        
        return View(traitCatalogVM);
    }
    
    public async Task<IActionResult> Detail(Guid id)
    {
        var vm = await _traitViewModelService.GetTraitByIdAsync(id);
        return View("Detail", vm);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TraitCreateViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        await _traitService.CreateTrait(Guid.Empty, request.Name, request.Description);
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var trait = await _traitViewModelService.GetTraitByIdAsync(id);
        var request = new TraitEditViewModel()
        {
            Id = trait.Id,
            Name = trait.Name,
            Description = trait.Description,
        };
        return View(request);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(TraitEditViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        await _traitService.UpdateTrait(request.Id, request.Name, request.Description);
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var vm = await _traitViewModelService.GetTraitByIdAsync(id);
        return View("Delete", vm);
    }
    

    public async Task<IActionResult> DeleteTrait(Guid id)
    {
        var vm = await _traitViewModelService.GetTraitByIdAsync(id);
        await _traitService.DeleteTrait(id);
        return RedirectToAction("Index");
    }
    
    private async Task<TraitCatalogViewModel> GetTraitCatalogAsync()
    {
        return await _traitCatalogViewModelService.GetTraitsByUserIdAsync(Guid.Empty);
    }
}