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
            return View();
        }

        public IActionResult AgregarAutorDB(Autor autor)
        {
            foo.Agregar(autor);
            return RedirectToAction("ListaAutor");
        }

        public IActionResult BuscarAutor(Autor autor)
        {
            var HelperAutor = foo.GetAutor(autor.Id);
            return View(HelperAutor);
        }

        public IActionResult EditarAutor(int id)
        {
            var autor = foo.GetAutor(id);
            return View("EditarAutor", autor);
        }

        public IActionResult EditarAutorSend(Autor autor)
        {
            foo.EditSend(autor);
            return RedirectToAction("ListaAutor");
        }

        public IActionResult BorrarAutor(Autor autor)
        {
            foo.Remove(autor.Id);
            return RedirectToAction("ListaAutor");
        }

        public IActionResult EliminarAutor()
        {
            return View();
        }

        public IActionResult FindAutor()
        {
            return View();
        }


    }
}
