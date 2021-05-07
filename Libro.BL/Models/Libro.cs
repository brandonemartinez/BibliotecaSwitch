using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibroBL.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        [DisplayName("ISBN")]
        public int Isbn { get; set; }
        [DisplayName("ID Autor")]
        public int? Idautor { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Titulo { get; set; }

        [DisplayName("Fecha de Lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Fecha de Nacimiento es requerido")]
        public DateTime? FechaLanzamiento { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
