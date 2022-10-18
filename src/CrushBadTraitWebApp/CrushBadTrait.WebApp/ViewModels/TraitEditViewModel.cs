using System.ComponentModel.DataAnnotations;

namespace CrushBadTrait.WebApp.ViewModels;

public class TraitEditViewModel
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Name required")]
    [MinLength(3, ErrorMessage = "Name should be more than 2 character")]
    [MaxLength(100, ErrorMessage = "Name should be less than 101 character")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Description required")]
    [MaxLength(300, ErrorMessage = "Description should be less than 301 character")]
    public string Description { get; set; } = string.Empty;
}