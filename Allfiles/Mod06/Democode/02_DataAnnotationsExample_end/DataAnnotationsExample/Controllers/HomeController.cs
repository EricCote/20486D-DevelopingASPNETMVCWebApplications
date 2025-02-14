﻿using Microsoft.AspNetCore.Mvc;
using DataAnnotationsExample.Models;

namespace DataAnnotationsExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(User user)
    {
        return View(user);
    }
}
