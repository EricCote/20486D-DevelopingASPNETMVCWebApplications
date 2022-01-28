using Microsoft.AspNetCore.Mvc;

namespace BootstrapExample.Controllers;

public class LibraryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetScienceFictionBooks()
    {
        return View();
    }

    public IActionResult GetDramaBooks()
    {
        return View();
    }
}
