using System.ComponentModel.DataAnnotations;

namespace JQueryExample.Models;

public class Pizza
{
    public int Id { get; set; }

    [DataType(DataType.Currency)]
    public float Price { get; set; }

    public string Toppings { get; set; }
}

