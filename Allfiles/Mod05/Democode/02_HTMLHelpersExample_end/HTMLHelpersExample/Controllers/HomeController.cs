using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
