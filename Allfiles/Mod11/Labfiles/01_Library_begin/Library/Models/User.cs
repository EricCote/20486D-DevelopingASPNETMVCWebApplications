namespace Library.Models;

public class User
{
    public int UserID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }

    public virtual ICollection<Book> Books { get; set; } = null!;
}

