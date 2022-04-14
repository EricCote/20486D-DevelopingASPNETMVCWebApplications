using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace CachingExample.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float BasePrice { get; set; }
    public string Description { get; set; } = null!;
    public string ImageName { get; set; } = null!;

    [Display(Name = "Price")]
    public string FormattedPrice
    {
        get
        {
            return BasePrice.ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
        }
    }

    [NotMapped]
    [Display(Name = "Last retrieved on")]
    public DateTime LoadedFromDatabase { get; set; }
}

