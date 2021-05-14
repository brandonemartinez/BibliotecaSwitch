using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibroBL.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [DisplayName("ID Usuario")]
        public int Id { get; set; }
        [DisplayName("Nombre de Usuario")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Text)]
        public string NombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
        [DisplayName("Nombre de Usuario")]
        public string Tipo { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
