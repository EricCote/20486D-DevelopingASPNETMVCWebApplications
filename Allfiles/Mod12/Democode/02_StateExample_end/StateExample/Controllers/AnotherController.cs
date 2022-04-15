using Microsoft.AspNetCore.Mvc;

namespace StateExample.Controllers;

public class AnotherController : Controller
{
    public IActionResult Index()
    {
        int overallVisitsNumber = HttpContext.Session.GetInt32("Overall") ?? 0;
        int controllerVisitsNumber = HttpContext.Session.GetInt32("Home") ?? 0;
        int AnotherControllerVisitsNumber = HttpContext.Session.GetInt32("Another") ?? 0;

        overallVisitsNumber++;
        AnotherControllerVisitsNumber++;
    
        HttpContext.Session.SetInt32("Overall", overallVisitsNumber);
        HttpContext.Session.SetInt32("Home", controllerVisitsNumber);
        HttpContext.Session.SetInt32("Another", AnotherControllerVisitsNumber);
        
        return View();
    }
}
