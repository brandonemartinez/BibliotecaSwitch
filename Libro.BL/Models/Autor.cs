using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibroBL.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        [DisplayName("ID Autor")]
        public int Id { get; set; }
        [StringLength(15, ErrorMessage = "El valor {0} no puede superar {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Nombre { get; set; }
        [StringLength(15, ErrorMessage = "El valor {0} no puede superar {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Apellido { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Fecha de Nacimiento es requerido")]
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
