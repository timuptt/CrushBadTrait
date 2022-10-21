using System.ComponentModel.DataAnnotations;

namespace CrushBadTrait.WebApp.ViewModels;

public class RegisterViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    [DataType(DataType.Text)]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.Time)]
    public TimeSpan EndOfDayTime { get; set; }
}