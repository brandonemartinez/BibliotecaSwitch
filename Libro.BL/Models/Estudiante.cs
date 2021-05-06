using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibroBL.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        [DisplayName("Numero Estudiante")]
        public int NumeroEstudiante { get; set; }

        [DisplayName("ID Usuario")]
        public int? Idusuario { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Fecha de Nacimiento es requerido")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(15, ErrorMessage = "El valor {0} no puede superar {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Nombre { get; set; }

        [StringLength(15, ErrorMessage = "El valor {0} no puede superar {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Apellido { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
