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

        public void Agregar(Libro libro)
        {
            Autor autor = new Autor();


            using (BibliotecaContext context = new BibliotecaContext())
            {
                if (libro.Idautor != null)
                {
                    libro.IdautorNavigation = context.Autors.Where(w => w.Id == libro.Idautor).FirstOrDefault();
                }
                else
                {
                    context.Libros.Add(libro);
                }
                context.Libros.Add(libro);

                context.SaveChanges();

            };
        }

        public Libro GetLibro(int id)
        {
            Libro libro = new Libro();

            using (BibliotecaContext context = new BibliotecaContext())
            {
                libro = context.Libros.Find(id);
            };

            return libro;
        }

        public void EditSend(Libro libro)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                Libro Hlibro = context.Libros.Where(w => w.Isbn == libro.Isbn).FirstOrDefault();
                Hlibro.Titulo = libro.Titulo;
                Hlibro.FechaLanzamiento = libro.FechaLanzamiento;

                context.SaveChanges();
            };
        }

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
