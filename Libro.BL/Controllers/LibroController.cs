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

        public IActionResult EditarLibro(int Isbn)
        {
            var libro = foo.GetLibro(Isbn);
            return View(libro);
        }

        public IActionResult EditSend(Libro libro)
        {
            foo.EditSend(libro);
            return RedirectToAction("ListaLibro");
        }

        public IActionResult DetalleLibro(Libro libro)
        {
            var Hlibro = foo.GetLibro(libro.Isbn);
            return View(Hlibro);
        }

        public IActionResult BorrarLibro(Libro libro)
        {
            foo.Remove(libro.Isbn);
            return RedirectToAction("ListaLibro");
        }
        public IActionResult EliminarLibro()
        {
            return View();
        }

        public IActionResult FindLibro()
        {
            return View();
        }
    }
}
