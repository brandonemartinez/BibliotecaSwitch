using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            PrestamoEstudiante prestamos;

            if (HttpContext.Session.GetString("NumeroEstudiante") != null)
            {
                prestamos = foo.BuscarPrestamoID(int.Parse(HttpContext.Session.GetString("NumeroEstudiante")));
            }
            else
            {
                prestamos = foo.BuscarPrestamoID(estudiante.NumeroEstudiante);
            }
            return View("PrestamosActualesPorEstudiante", prestamos);
        }

        public IActionResult PrestamosActualesPorEstudiante()
        {
            return View();
        }

        public IActionResult CrearPrestamo(int? ISBN)
        {
            HttpContext.Session.SetString("ISBN", ISBN.ToString());
            return View();
        }

        public IActionResult CrearPrestamoDB(Prestamo prestamo)
        {

            if (HttpContext.Session.GetString("NumeroEstudiante") != null)
            {
                Estudiante estu = new Estudiante(); 
                estu.NumeroEstudiante = int.Parse(HttpContext.Session.GetString("NumeroEstudiante"));
                prestamo.Isbn = int.Parse(HttpContext.Session.GetString("ISBN"));
                prestamo.NumeroEstudiante = int.Parse(HttpContext.Session.GetString("NumeroEstudiante"));
                foo.CrearPrestamo(prestamo);
                return RedirectToAction("PrestamosActualesEstudiante", estu);
            }
            else
            {
                foo.CrearPrestamo(prestamo);
                return RedirectToAction("PrestamosActuales");
            };
        }

        public IActionResult EliminarPrestamo(int Isbn, int NumeroEstudiante)
        {


            if (HttpContext.Session.GetString("NumeroEstudiante") != null)
            {
                Estudiante estu = new Estudiante();
                estu.NumeroEstudiante = int.Parse(HttpContext.Session.GetString("NumeroEstudiante"));
                foo.EliminarPrestamo(Isbn, NumeroEstudiante);
                return RedirectToAction("PrestamosActualesEstudiante", estu);
            }
            else
            {
                foo.EliminarPrestamo(Isbn, NumeroEstudiante);
                return RedirectToAction("PrestamosActuales");
            }

        }
    }
}
