using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhotoSharingSample.Models;

public class Photo
{
    public int PhotoID { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [DisplayName("Picture")]
    [MaxLength]
    public string PhotoFileName { get; set; } = null!;

    [HiddenInput(DisplayValue = false)]
    public string ImageMimeType { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = null!;

    [DataType(DataType.DateTime)]
    [DisplayName("Created Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }
}
