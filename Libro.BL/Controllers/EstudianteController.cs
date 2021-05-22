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
    //Colocar los validadores de los requests
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
        public async Task<IActionResult> ListaEstudiante()
        {
            var list = await foo.GetEstudiante();
            return View(list);
        }

        public async Task<IActionResult> AgregarEstudianteDB(UsuarioEstudiante estudiante)
        {
            foo.Agregar(estudiante);
            return RedirectToAction("ListaEstudiante");
        }

        public async Task<IActionResult> BuscarEstudiante(Estudiante estudiante)
        {
            var HelperEstudiante = await foo.GetEstudiante(estudiante.NumeroEstudiante);
            return View(HelperEstudiante);
        }

        public async Task<IActionResult> EditarEstudiante(int id)
        {
            var estudiante = await foo.GetEstudiante(id);
            return View("EditarEstudiante", estudiante);
        }

        public async Task<IActionResult> EditarEstudianteSend(Estudiante estudiante)
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
