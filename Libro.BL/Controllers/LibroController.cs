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

        public IActionResult AgregarLibroDB(Models.Libro libro)
        {

            return RedirectToAction("ListarLibro");
        }
    }
}
