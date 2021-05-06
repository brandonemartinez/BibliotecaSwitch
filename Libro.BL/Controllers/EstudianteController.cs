using Libro.BL.Models;
using Libro.BL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libro.BL.Controllers
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
            return View("Index");
        }

    }
}
