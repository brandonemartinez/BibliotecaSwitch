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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogUser(Usuario user)
        {
            LoginRepositorio foo = new LoginRepositorio();
            var helper = foo.Usuario(user.NombreUsuario, user.Pass);
            if (helper != null)
            {
                HttpContext.Session.SetString("Tipo", helper.Tipo);
                if (helper.Tipo == "Estudiante")
                {
                    var numeroEstudiante = foo.GetEstudianteId(helper.Id);
                    HttpContext.Session.SetString("NumeroEstudiante", numeroEstudiante.ToString());
                }

                return View("Index");
            }
            else
            {
                return View("LoginFailed");
            }

        }
    }
}
