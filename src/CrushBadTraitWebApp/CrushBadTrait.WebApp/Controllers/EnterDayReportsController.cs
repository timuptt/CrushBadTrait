using CrushBadTrait.Core.Interfaces.Services;
using CrushBadTrait.Infrastructure.Identity.Interfaces;
using CrushBadTrait.WebApp.Interfaces;
using CrushBadTrait.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrushBadTrait.WebApp.Controllers;

[Authorize]
public class EnterDayReportsController : Controller
{
    private readonly IDayReportsService _dayReportsService;
    private readonly IDayReportViewModelService _dayReportViewModelService;
    private readonly ICurrentUserService _currentUserService;

    public EnterDayReportsController(IDayReportsService dayReportsService, 
        IDayReportViewModelService dayReportViewModelService, ICurrentUserService currentUserService)
    {
        _dayReportsService = dayReportsService;
        _dayReportViewModelService = dayReportViewModelService;
        _currentUserService = currentUserService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var traitIds = await _dayReportsService.GetTraitIdAndNamesToReport(_currentUserService.UserId);
        var dayReportViewModels = _dayReportViewModelService.CreateDayReports(traitIds);
        return View(dayReportViewModels);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(DayReportsViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", request);
        }
        
        foreach (var item in request.DayReports)
        {
            await _dayReportsService.EnterDayReport(item.TraitId, item.Note, item.Periodicity, item.Grade);
        }

        return RedirectToAction("Index", "TraitCatalog");
    }
}