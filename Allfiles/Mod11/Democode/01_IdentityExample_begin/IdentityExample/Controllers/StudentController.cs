using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityExample.Data;

namespace IdentityExample.Controllers
{
    public class StudentController : Controller
    {
    

        [Authorize()]
        public IActionResult Index()
        {
            return View();
        }

    }
}