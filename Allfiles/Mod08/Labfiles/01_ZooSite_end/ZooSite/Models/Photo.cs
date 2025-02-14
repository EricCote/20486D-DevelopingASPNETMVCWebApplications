﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZooSite.Models;

public class Photo
{
    public int PhotoID { get; set; }

    [Required]
    public string Title { get; set; } = "";

    [DisplayName("Picture")]
    public string? PhotoFileName { get; set; }

    [HiddenInput(DisplayValue = false)]
    public string? ImageMimeType { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
}
