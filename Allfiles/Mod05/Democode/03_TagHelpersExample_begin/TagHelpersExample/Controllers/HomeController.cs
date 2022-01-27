using Microsoft.AspNetCore.Mvc;

namespace TagHelpersExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
