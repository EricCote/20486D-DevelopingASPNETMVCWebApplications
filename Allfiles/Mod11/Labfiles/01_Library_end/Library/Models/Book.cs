using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Author { get; set; } = null!;

    [Display(Name = "Date Published")]
    public string DatePublished { get; set; } = null!;
    public bool Available { get; set; }
    public string ImageName { get; set; } = null!;
    public byte[]? PhotoFile { get; set; } = null!;
    public string ImageMimeType { get; set; } = null!;

    [NotMapped]
    [Display(Name = "Photo")]
    public IFormFile PhotoAvatar { get; set; } = null!;
    public bool Recommended { get; set; }

    public int GenreId { get; set; }

    [InverseProperty("Books")]
    public virtual Genre Genre { get; set; } = null!;

    [InverseProperty("Books")]
    public virtual User User { get; set; } = null!;
}

