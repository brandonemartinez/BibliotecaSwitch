using LibroAPI.Models;
using LibroAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroAPI.Repositories
{
    public class EstudianteRepository : IServiceEstudiante
    {
        private readonly BibliotecaContext _context;

        public EstudianteRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<Estudiante>> GetEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }


        public async Task<Estudiante> GetEstudiante(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }


        public bool PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.NumeroEstudiante)
            {
                return false;
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public bool PostEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();

            return true; 
        }


        public bool DeleteEstudiante(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return false;
            }

            _context.Estudiantes.Remove(estudiante);
            _context.SaveChanges();

            return true;
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.NumeroEstudiante == id);
        }
    }
}
