using LibroBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Repositorio
{
    public class PrestamoRepositorio
    {
        public List<LibroPrestamo> ListaPrestamo()
        {
            LibroRepositorio RepLibro = new LibroRepositorio();
            var colLibros = RepLibro.GetLibros();

            List<LibroPrestamo> helperLibros = new List<LibroPrestamo>();

            List<Prestamo> colPrestamos;

            using (BibliotecaContext context = new BibliotecaContext())
            {
                colPrestamos = context.Prestamos.ToList();
            }

            foreach (Prestamo prestamo in colPrestamos)
            {
                LibroPrestamo helperLibroPrestamo = new LibroPrestamo();

                var libro = colLibros.Where(w => w.Isbn == prestamo.Isbn).FirstOrDefault();


                helperLibroPrestamo.Libro.Isbn = libro.Isbn;
                helperLibroPrestamo.Libro.Titulo = libro.Titulo;
                helperLibroPrestamo.Prestamo.NumeroEstudiante = prestamo.NumeroEstudiante;
                helperLibroPrestamo.Prestamo.FechaInicio = prestamo.FechaInicio;
                helperLibroPrestamo.Prestamo.FechaFin = prestamo.FechaFin;
                helperLibroPrestamo.Libro.Idautor = libro.Idautor;

                helperLibros.Add(helperLibroPrestamo);

            }

            return helperLibros;
        }

        public PrestamoEstudiante BuscarPrestamoID(int id)
        {
            PrestamoEstudiante prestamoEstudiante = new PrestamoEstudiante();

            //Se crea instancia de los repositos y se obtiene lista de Libros
            //y Estudiantes
            EstudianteRepositorio repEstu = new EstudianteRepositorio();

            //prestamoEstudiante.estudiante = repEstu.GetEstudiante(id);

            LibroRepositorio repLibro = new LibroRepositorio();
            List<Libro> colLibros = repLibro.GetLibros();

            List<Prestamo> colPrestamos = new List<Prestamo>();

            using (BibliotecaContext context = new BibliotecaContext())
            {
                colPrestamos = context.Prestamos.Where(w => w.NumeroEstudiante == prestamoEstudiante.estudiante.NumeroEstudiante).ToList();
            }

            foreach (Prestamo prestamo in colPrestamos)
            {
                LibroPrestamo helper = new LibroPrestamo();
                helper.Prestamo = prestamo;
                helper.Libro = colLibros.Where(w => w.Isbn == prestamo.Isbn).FirstOrDefault();

                prestamoEstudiante.libroPrestamos.Add(helper);
            }

            return prestamoEstudiante;
        }

        public void CrearPrestamo(Prestamo pres)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                context.Prestamos.Add(pres);

                context.SaveChanges();
            }
        }
        public void EliminarPrestamo(int isbn, int numeroEstudiante)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                Prestamo pres = context.Prestamos.Where(w => w.Isbn == isbn && w.NumeroEstudiante == numeroEstudiante).FirstOrDefault();
                context.Remove(pres);
                context.SaveChanges();
            };
        }
    }
}
