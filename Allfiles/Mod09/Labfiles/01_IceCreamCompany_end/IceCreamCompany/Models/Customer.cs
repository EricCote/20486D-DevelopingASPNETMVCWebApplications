using System.ComponentModel.DataAnnotations;

namespace IceCreamCompany.Models;

public class Customer
{
    public int CustomerId { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please enter your first name")]
    public string FirstName { get; set; } = "";

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please enter your last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please enter your email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone"), DataType(DataType.PhoneNumber)]
    public long PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please enter your adress")]
    public string Address { get; set; } = null!;

    public virtual List<IceCreamFlavorsCustomers> IceCreamFlavors { get; set; } = new List<IceCreamFlavorsCustomers>();
}

