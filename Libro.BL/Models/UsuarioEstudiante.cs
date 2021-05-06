using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libro.BL.Models
{
    public class UsuarioEstudiante
    {
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
        [Required(ErrorMessage = "{0} es requerido")]
        public string Usuario { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
        public string Tipo { get; set; }
    }

}
