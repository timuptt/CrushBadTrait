using System.ComponentModel.DataAnnotations;

namespace CrushBadTrait.WebApp.ViewModels;

public class LoginViewModel
{
    [Display(Name = "Email:")]
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}