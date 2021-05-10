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

        public List<LibroPrestamo> BuscarPrestamoID(int id)
        {
            List<LibroPrestamo> colLibrosPrestamos = new List<LibroPrestamo>();
            LibroRepositorio RepLibro = new LibroRepositorio();
            List<Prestamo> colPrestamos = new List<Prestamo>();
            var colLibros = RepLibro.GetLibros();


            using (BibliotecaContext context = new BibliotecaContext())
            {
                colPrestamos = context.Prestamos.Where(w => w.NumeroEstudiante == id).ToList();
            }

            foreach (Prestamo prestamo in colPrestamos)
            {

                LibroPrestamo helperLibroPrestamo = new LibroPrestamo();

                helperLibroPrestamo.Libro.Isbn = libro.Isbn;
                helperLibroPrestamo.Libro.Titulo = libro.Titulo;
                helperLibroPrestamo.Prestamo.NumeroEstudiante = prestamo.NumeroEstudiante;
                helperLibroPrestamo.Prestamo.FechaInicio = prestamo.FechaInicio;
                helperLibroPrestamo.Prestamo.FechaFin = prestamo.FechaFin;
                helperLibroPrestamo.Libro.Idautor = libro.Idautor;

            }

            return prestamos;
        }
    }
}
