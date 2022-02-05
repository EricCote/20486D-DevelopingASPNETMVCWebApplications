using Microsoft.AspNetCore.Mvc;

namespace JQueryExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
