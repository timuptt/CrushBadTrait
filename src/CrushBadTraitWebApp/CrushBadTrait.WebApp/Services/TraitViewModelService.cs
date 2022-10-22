using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Secifications;
using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrushBadTrait.WebApp.Services;

public class TraitViewModelService : ITraitViewModelService
{
    private readonly IRepository<Trait> _repository;

    public TraitViewModelService(IRepository<Trait> repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    [Route("TraitCatalog/task/{id:Guid}")]
    public async Task<TraitViewModel?> GetTraitByIdAsync(Guid id)
    {
        var specification = new TraitWithDaysByIdSpecification(id);
        var trait = await _repository.FirstOrDefaultAsync(specification);

        if (trait != null)
        {
            var vm = new TraitViewModel()
            {
                Id = trait.Id,
                Name = trait.Name,
                Description = trait.Description,
                AverageGrade = trait.AverageGrade,
                UserId = trait.UserId,
                DayReports = trait.DayReports?.Select(d => new DayReportViewModel()
                {
                    Id = d.Id,
                    TraitId = d.TraitId,
                    Date = d.Date,
                    Grade = d.Grade,
                    Note = d.Note,
                    Periodicity = d.Periodicity
                }).ToList()
            };

            return vm;
        }

        return null;
    }
}