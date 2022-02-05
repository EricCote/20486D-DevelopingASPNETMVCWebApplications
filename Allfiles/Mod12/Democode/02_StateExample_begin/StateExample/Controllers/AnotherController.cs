using Microsoft.AspNetCore.Mvc;

namespace StateExample.Controllers;

public class AnotherController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
