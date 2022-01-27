using Microsoft.AspNetCore.Mvc;

namespace FiltersExample.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
         return Content("Welcome to module 4 demo 3");
    }
}
