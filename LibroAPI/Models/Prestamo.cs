using System;
using System.Collections.Generic;

#nullable disable

namespace LibroAPI.Models
{
    public partial class Prestamo
    {
        public int Isbn { get; set; }
        public int NumeroEstudiante { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual Libro IsbnNavigation { get; set; }
        public virtual Estudiante NumeroEstudianteNavigation { get; set; }
    }
}
