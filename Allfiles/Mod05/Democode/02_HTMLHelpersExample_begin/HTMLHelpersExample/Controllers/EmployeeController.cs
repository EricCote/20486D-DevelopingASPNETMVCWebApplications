using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(string employeeName)
    {
        return View();
    }

    public IActionResult GetImage(string employeeName)
    {
        return Content("");
    }
}
