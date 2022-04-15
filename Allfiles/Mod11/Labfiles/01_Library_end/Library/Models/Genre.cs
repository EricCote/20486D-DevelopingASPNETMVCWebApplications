namespace Library.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = null!;
}
