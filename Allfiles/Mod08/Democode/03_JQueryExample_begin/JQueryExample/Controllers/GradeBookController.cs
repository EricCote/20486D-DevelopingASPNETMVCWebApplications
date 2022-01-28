using Microsoft.AspNetCore.Mvc;

namespace JQueryExample.Controllers;

public class GradeBookController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
