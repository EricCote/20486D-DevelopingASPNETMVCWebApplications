using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityExample.Models;

public class Student : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}

