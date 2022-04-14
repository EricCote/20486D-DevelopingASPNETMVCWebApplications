using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricStore.Models;

public class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Range(1, 1500)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [DisplayName("Picture")]
    public string PhotoFileName { get; set; } = null!;

    [HiddenInput(DisplayValue = false)]
    public string ImageMimeType { get; set; } = null!;

    [Display(Name = "Last retrieved on")]
    [NotMapped]
    public DateTime LoadedFromDatabase { get; set; }

    [InverseProperty("Product")]
    public virtual List<CustomersProducts> CustomerProducts { get; set; } = null!;

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public MenuCategory MenuCategory { get; set; } = null!;
}
