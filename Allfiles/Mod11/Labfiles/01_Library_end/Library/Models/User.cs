using Microsoft.AspNetCore.Identity;

namespace Library.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }

    public virtual ICollection<Book> Books { get; set; } = null!;
}

