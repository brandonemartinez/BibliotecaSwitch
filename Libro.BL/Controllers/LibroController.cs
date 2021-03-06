using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
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
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
            {
                foo.Remove(libro.Isbn);
                return RedirectToAction("ListaLibro");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult EliminarLibro()
        {
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult FindLibro()
        {
            if (HttpContext.Session.GetString("Tipo") == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
