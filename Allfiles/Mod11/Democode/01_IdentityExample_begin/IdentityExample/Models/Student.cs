using Microsoft.AspNetCore.Identity;

namespace IdentityExample.Models;

public class Student : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}

