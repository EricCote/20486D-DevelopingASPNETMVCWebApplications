using Microsoft.AspNetCore.Mvc;

namespace GulpExample.Controllers;

public class PhotoBookController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
