using LibroBL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibroBL.Repositorio
{
    public class LoginRepositorio
    {

        public Usuario Usuario(string usuario, string password)
        {
            Usuario helper = new Usuario();

            using(BibliotecaContext context = new BibliotecaContext())
            {
                helper = context.Usuarios.Where(w => w.NombreUsuario == usuario && w.Pass == password).FirstOrDefault();
            }


            if (helper != null)
            {

                return helper;
            }
            else
            {
                return null;
            }

            
        }

        public int GetEstudianteId(int id)
        {
            EstudianteRepositorio repEstu = new EstudianteRepositorio();

            int NumEstu = repEstu.GetEstudiante(id).NumeroEstudiante;

            return NumEstu;
        }
    }


}
