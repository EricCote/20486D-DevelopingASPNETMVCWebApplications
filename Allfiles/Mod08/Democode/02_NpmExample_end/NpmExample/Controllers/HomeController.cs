using Microsoft.AspNetCore.Mvc;

namespace NpmExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
