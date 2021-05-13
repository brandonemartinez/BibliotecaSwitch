using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Controllers
{
    public class AutorController : Controller
    {
        AutorRepositorio foo = new AutorRepositorio();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaAutor()
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                return View("ListaAutor", foo.GetAutores());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult AgregarAutor()
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

        public IActionResult AgregarAutorDB(Autor autor)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                foo.Agregar(autor);
                return RedirectToAction("ListaAutor");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult BuscarAutor(Autor autor)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                var HelperAutor = foo.GetAutor(autor.Id);
                return View(HelperAutor);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult EditarAutor(int id)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                var autor = foo.GetAutor(id);
                return View("EditarAutor", autor);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult EditarAutorSend(Autor autor)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                foo.EditSend(autor);
                return RedirectToAction("ListaAutor");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult BorrarAutor(Autor autor)
        {
            if ((string)ViewData["Tipo"] == "Administrador")
            {
                foo.Remove(autor.Id);
                return RedirectToAction("ListaAutor");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult EliminarAutor()
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

        public IActionResult FindAutor()
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


    }
}
