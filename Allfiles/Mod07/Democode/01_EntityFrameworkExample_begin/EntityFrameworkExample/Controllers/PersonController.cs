using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkExample.Controllers;

public class PersonController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
