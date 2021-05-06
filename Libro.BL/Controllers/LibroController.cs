using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Controllers
{
    public class LibroController : Controller
    {
        LibroRepositorio foo = new LibroRepositorio();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaLibro()
        {
            var colLibros = foo.GetLibros();
            return View(colLibros);
        }

        public IActionResult AgregarLibro()
        {
            return View();
        }

        public IActionResult AgregarLibroDB(Libro libro)
        {
            foo.Agregar(libro);
            return RedirectToAction("ListaLibro");
        }

        public IActionResult LibroEstudiante(Libro libro)
        {
            var hlibro = foo.GetLibro(libro.Isbn);
            return View("EditarLibro", hlibro);
        }

        public IActionResult EditarEstudianteSend(Libro libro)
        {
            foo.EditSend(libro);
            return RedirectToAction("ListaEstudiante");
        }
    }
}
