using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Controllers
{
    public class EstudianteController : Controller
    {
        EstudianteRepositorio foo = new EstudianteRepositorio();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarEstudiante()
        {
            return View();
        }
        public IActionResult ListaEstudiante()
        {
            var list = foo.GetEstudiantes();
            return View(list);
        }

        public IActionResult AgregarEstudianteDB(UsuarioEstudiante estudiante)
        {
            foo.Agregar(estudiante);
            return RedirectToAction("ListaEstudiante");
        }

        public IActionResult BuscarEstudiante(Estudiante estudiante)
        {
            var HelperEstudiante = foo.GetEstudiante(estudiante.NumeroEstudiante);
            return View(HelperEstudiante);
        }

        public IActionResult EditarEstudiante(int id)
        {
            var estudiante = foo.GetEstudiante(id);
            return View("EditarEstudiante", estudiante);
        }

        public IActionResult EditarEstudianteSend(Estudiante estudiante)
        {
            foo.EditSend(estudiante);
            return RedirectToAction("ListaEstudiante");
        }

        public IActionResult BorrarEstudiante(Estudiante estudiante)
        {
            foo.Remove(estudiante.NumeroEstudiante);
            return RedirectToAction("ListaEstudiante");
        }

        public IActionResult EliminarEstudiante()
        {
            return View();
        }

        public IActionResult FindEstudiante()
        {
            return View();
        }
    }
}
