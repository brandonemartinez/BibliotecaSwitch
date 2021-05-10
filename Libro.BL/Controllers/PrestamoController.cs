using LibroBL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Controllers
{
    public class PrestamoController : Controller
    {

        PrestamoRepositorio foo = new PrestamoRepositorio();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrestamosActuales()
        {
            var prestamos = foo.ListaPrestamo();
            return View(prestamos);
        }

        public IActionResult BuscarEstudiante()
        {
            return View();
        }

        public IActionResult PrestamosActualesEstudiante(int id)
        {
            var prestamos = foo.BuscarPrestamoID(id);
            return RedirectToAction("PrestamosActuales", prestamos);
        }
    }
}
