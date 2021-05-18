using System;
using System.Collections.Generic;

#nullable disable

namespace LibroAPI.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Isbn { get; set; }
        public int? Idautor { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaLanzamiento { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
