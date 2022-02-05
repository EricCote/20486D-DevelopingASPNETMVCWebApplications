using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers;
public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
