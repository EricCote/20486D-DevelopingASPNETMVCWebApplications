using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        if (!(this.User.Identity?.IsAuthenticated ?? false))
        {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }
}
