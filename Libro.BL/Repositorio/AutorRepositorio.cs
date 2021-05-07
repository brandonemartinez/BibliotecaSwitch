﻿using LibroBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Repositorio
{
    public class AutorRepositorio
    {
        public AutorRepositorio()
        {
        }

        public IEnumerable<Autor> GetAutores()
        {
            List<Models.Autor> colAutores = new List<Autor>();
            using (BibliotecaContext context = new BibliotecaContext())
            {
                colAutores = context.Autors.ToList();
            }
            return colAutores;
        }

        public void Agregar(Autor autor)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                context.Autors.Add(autor);

                context.SaveChanges();

            };
        }

        public Autor GetAutor(int id)
        {
            Autor autor = new Autor();

            using (BibliotecaContext context = new BibliotecaContext())
            {
                autor = context.Autors.Find(id);
            };

            return autor;
        }

        public void EditSend(Autor autor)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                Autor Hautor = context.Autors.Where(w => w.Id == autor.Id).FirstOrDefault();
                Hautor.Nombre = autor.Nombre;
                Hautor.Apellido = autor.Apellido;
                Hautor.FechaNacimiento = autor.FechaNacimiento;

                context.SaveChanges();
            };
        }

        internal void Remove(int id)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                List<Libro> colLibros = context.Libros.Where(w => w.Idautor == id).ToList();
                foreach (Libro libro in colLibros)
                {
                    context.Libros.Remove(libro);
                }
                Autor autor = context.Autors.Where(w => w.Id == id).FirstOrDefault();
                context.Autors.Remove(autor);

                context.SaveChanges();
            }
        }
    }
}
