namespace Library.Models;

public class User
{
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}

