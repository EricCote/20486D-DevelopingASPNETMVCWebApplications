using System.ComponentModel.DataAnnotations;

namespace IdentityExample.ViewModels;

public class RegisterViewModel : LoginViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please enter your first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please enter your last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Phone Number")]
    [Required(ErrorMessage = "Please enter your phone number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
}

