using System;
using System.Collections.Generic;

#nullable disable

namespace LibroAPI.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int NumeroEstudiante { get; set; }
        public int? Idusuario { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
