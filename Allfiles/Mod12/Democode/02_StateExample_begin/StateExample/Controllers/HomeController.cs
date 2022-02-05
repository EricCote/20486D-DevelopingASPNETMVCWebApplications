using Microsoft.AspNetCore.Mvc;

namespace StateExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
