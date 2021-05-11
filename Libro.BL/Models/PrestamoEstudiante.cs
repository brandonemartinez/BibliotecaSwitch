using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Models
{
    public class PrestamoEstudiante
    {
        public Estudiante estudiante { get; set; }
        public List<LibroPrestamo> libroPrestamos { get; set; }

        public PrestamoEstudiante()
        {
            estudiante = new Estudiante();
            libroPrestamos = new List<LibroPrestamo>();
        }

    }
}
