﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamCompany.Models;

public class IceCream
{
    public int IceCreamId { get; set; }

    [Range(1, 10)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    [Required]
    [StringLength(30)]
    public string Flavor { get; set; } = "";

    [DisplayName("Picture")]
    [MaxLength]
    public string? PhotoFileName { get; set; }

    [HiddenInput(DisplayValue = false)]
    public string? ImageMimeType { get; set; }

    public virtual List<IceCreamFlavorsCustomers> IceCreamFlavors { get; set; } = new List<IceCreamFlavorsCustomers>();
}
