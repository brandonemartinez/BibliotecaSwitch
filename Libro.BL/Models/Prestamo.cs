using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibroBL.Models
{
    public partial class Prestamo
    {
        [DisplayName("ISBN")]
        public int Isbn { get; set; }
        [DisplayName("Numero de Estudiante")]
        public int NumeroEstudiante { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Fecha Incio")]
        public DateTime? FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Fecha Fin")]
        public DateTime? FechaFin { get; set; }

        public virtual Libro IsbnNavigation { get; set; }
        public virtual Estudiante NumeroEstudianteNavigation { get; set; }
    }
}
