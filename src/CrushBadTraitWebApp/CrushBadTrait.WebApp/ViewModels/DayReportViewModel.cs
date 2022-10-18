using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace CrushBadTrait.WebApp.ViewModels;

public class DayReportViewModel
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid TraitId { get; set; }
    public DateTime Date { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Note { get; set; }
    
    [Required]
    [NonNegativeValue]
    public int Periodicity { get; set; }
    
    [Required]
    [NonNegativeValue]
    public int Grade { get; set; }
}