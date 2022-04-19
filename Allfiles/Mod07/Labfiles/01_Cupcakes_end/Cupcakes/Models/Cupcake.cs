using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cupcakes.Models;

public class Cupcake
{
    [Key]
    public int CupcakeId { get; set; }

    [Required(ErrorMessage = "Please select a cupcake type")]
    [Display(Name = "Cupcake Type:")]
    public CupcakeType CupcakeType { get; set; } = CupcakeType.Chocolate;

    [Required(ErrorMessage = "Please enter a cupcake description")]
    [Display(Name = "Description:")]
    public string Description { get; set; } = "";

    [Display(Name = "Gluten Free:")]
    public bool GlutenFree { get; set; }

    [Display(Name = "Caloric Value:")]
    public int CaloricValue { get; set; }

    [Range(1, 15)]
    [Required(ErrorMessage = "Please enter a cupcake price")]
    [DataType(DataType.Currency)]
    [Display(Name = "Price:")]
    public double Price { get; set; } = 0D;

    [NotMapped]
    [Display(Name = "Cupcake Picture:")]
    public IFormFile? PhotoAvatar { get; set; }

    public string ImageName { get; set; } = "";

    public byte[]? PhotoFile { get; set; }

    public string ImageMimeType { get; set; } = "";

    [Required(ErrorMessage = "Please select a bakery")]
    public int BakeryId { get; set; } = 1;

    public virtual Bakery Bakery { get; set; } = null!;
}

