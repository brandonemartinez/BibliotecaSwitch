using System;
using System.Collections.Generic;

#nullable disable

namespace LibroBL.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
