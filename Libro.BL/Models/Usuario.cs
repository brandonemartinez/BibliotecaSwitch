using System;
using System.Collections.Generic;

#nullable disable

namespace LibroBL.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
