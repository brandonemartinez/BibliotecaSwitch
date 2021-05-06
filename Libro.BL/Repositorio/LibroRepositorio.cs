using LibroBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Repositorio
{
    public class LibroRepositorio
    {

        public LibroRepositorio()
        {
        }

        public IEnumerable<Models.Libro> GetLibros()
        {
            List<Models.Libro> colLibros = new List<Models.Libro>();
            using (BibliotecaContext context = new BibliotecaContext())
            {
                colLibros = context.Libros.ToList();
            }
            return colLibros;
        }

        //public void Agregar(UsuarioLibro _estudiante)
        //{
            //Libro est = new Libro();
            //est.Nombre = _estudiante.Nombre;
            //est.Apellido = _estudiante.Apellido;
            //est.FechaNacimiento = _estudiante.FechaNacimiento;

            //Usuario usu = new Usuario();
            //usu.Pass = _estudiante.Pass;
            //usu.NombreUsuario = _estudiante.Usuario;
            //usu.Tipo = "Libro";

            //using (BibliotecaContext context = new BibliotecaContext())
            //{
                //context.Usuarios.Add(usu);

                //est.Usuario = usu;
                //context.Libros.Add(est);

                //context.SaveChanges();

            //};
        //}

        public Models.Libro GetLibro(int id)
        {
            Models.Libro estudiante = new Models.Libro();

            using (BibliotecaContext context = new BibliotecaContext())
            {
                estudiante = context.Libros.Find(id);
            };

            return estudiante;
        }

        //public void EditSend(Models.Libro estudiante)
        //{
        //    using (BibliotecaContext context = new BibliotecaContext())
        //    {
        //        Models.Libro Hestudiante = context.Libros.Where(w => w.NumeroLibro == estudiante.NumeroLibro).FirstOrDefault();
        //        Hestudiante.Nombre = estudiante.Nombre;
        //        Hestudiante.Apellido = estudiante.Apellido;
        //        Hestudiante.FechaNacimiento = estudiante.FechaNacimiento;

        //        context.SaveChanges();
        //    };
        //}

        //public void Remove(int id)
        //{
        //    using (BibliotecaContext context = new BibliotecaContext())
        //    {
        //        Models.Libro estudiante = context.Libros.Where(w => w.NumeroLibro == id).FirstOrDefault();
        //        context.Libros.Remove(estudiante);

        //        if (estudiante.Idusuario != null)
        //        {
        //            Usuario usuario = context.Usuarios.Find(estudiante.Idusuario);
        //            context.Usuarios.Remove(usuario);
        //        }

        //        context.SaveChanges();
        //    };
        //}

    }
}
