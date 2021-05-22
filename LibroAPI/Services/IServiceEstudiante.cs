using LibroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroAPI.Services
{
    public interface IServiceEstudiante
    {
        public Task<List<Estudiante>> GetEstudiantes();
        public Task<Estudiante> GetEstudiante(int id);
        public bool PutEstudiante(int id, Estudiante estudiante);
        public bool PostEstudiante(Estudiante estudiante);
        public bool DeleteEstudiante(int id);

    }
}
