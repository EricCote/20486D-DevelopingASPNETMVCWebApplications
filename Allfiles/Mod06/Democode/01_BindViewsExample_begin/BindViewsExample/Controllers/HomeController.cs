using Microsoft.AspNetCore.Mvc;

namespace BindViewsExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("Home/Display")]
    public IActionResult AnotherWayToDisplay()
    {
        return View();
    }
}
