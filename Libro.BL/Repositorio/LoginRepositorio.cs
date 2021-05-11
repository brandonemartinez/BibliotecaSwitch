using LibroBL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
