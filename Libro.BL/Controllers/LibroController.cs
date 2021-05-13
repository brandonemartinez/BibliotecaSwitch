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
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult ListaLibro()
        {
            var colLibros = foo.GetLibros();
            return View(colLibros);
        }

        public IActionResult AgregarLibro()
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult AgregarLibroDB(Libro libro)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                foo.Agregar(libro);
                return RedirectToAction("ListaLibro");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult LibroEstudiante(Libro libro)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                var hlibro = foo.GetLibro(libro.Isbn);
                return View("EditarLibro", hlibro);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult EditarLibro(int Isbn)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                var libro = foo.GetLibro(Isbn);
                return View(libro);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult EditSend(Libro libro)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                foo.EditSend(libro);
                return RedirectToAction("ListaLibro");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult DetalleLibro(Libro libro)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                var Hlibro = foo.GetLibro(libro.Isbn);
                return View(Hlibro);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
