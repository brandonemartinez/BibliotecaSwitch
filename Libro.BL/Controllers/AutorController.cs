using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libro.BL.Controllers
{
    public class AutorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
