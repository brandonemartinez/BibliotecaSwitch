using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

        public IActionResult PrestamosActualesEstudiante(Estudiante estudiante)
        {
            var prestamos = foo.BuscarPrestamoID(estudiante.NumeroEstudiante);
            return View("PrestamosActualesPorEstudiante", prestamos);
        }

        public IActionResult PrestamosActualesPorEstudiante()
        {
            return View();
        }
    }
}
