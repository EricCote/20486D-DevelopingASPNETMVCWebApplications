﻿using Microsoft.AspNetCore.Mvc;
using FiltersExample.Filters;

namespace FiltersExample.Controllers;
public class HomeController : Controller
{
    [CustomActionFilter]
    public IActionResult Index()
    {
        return Content("Welcome to module 4 demo 3");
    }
}
