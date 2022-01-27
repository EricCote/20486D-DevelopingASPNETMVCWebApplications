using Microsoft.AspNetCore.Mvc;

namespace RazorSyntaxExample.Controllers;
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
