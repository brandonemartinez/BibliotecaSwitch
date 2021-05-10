using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Models
{
    [Keyless]
    public class LibroPrestamo
    {
        public Libro Libro { get; set; }
        public Prestamo Prestamo { get; set; }

        public LibroPrestamo()
        {
            Libro = new Libro();
            Prestamo = new Prestamo();
        }

    }
}
