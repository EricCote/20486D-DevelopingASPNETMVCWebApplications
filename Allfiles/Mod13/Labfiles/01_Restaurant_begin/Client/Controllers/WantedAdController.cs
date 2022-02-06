using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Client.Models;

namespace Client.Controllers;

public class WantedAdController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
