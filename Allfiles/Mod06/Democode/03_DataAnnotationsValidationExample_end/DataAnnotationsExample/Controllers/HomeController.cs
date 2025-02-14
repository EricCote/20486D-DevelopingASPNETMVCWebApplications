﻿using Microsoft.AspNetCore.Mvc;
using DataAnnotationsExample.Models;

namespace DataAnnotationsExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", person);
        }
        return View(person);
    }
}
