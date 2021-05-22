using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibroAPI.Models;
using LibroAPI.Repositories;
using LibroAPI.Services;

namespace LibroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly BibliotecaContext _context;
        private readonly IServiceEstudiante _estudianteRepository;

        public EstudianteController(BibliotecaContext context, IServiceEstudiante estudianteRepository)
        {
            _context = context;
            _estudianteRepository = estudianteRepository;
        }

        // GET: api/Estudiante
        [HttpGet]
        public async Task<IActionResult> GetEstudiantes()
        {
            return Ok(await _estudianteRepository.GetEstudiantes());
        }

        // GET: api/Estudiante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(Estudiante estudiante)
        {

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(estudiante.NumeroEstudiante))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estudiante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.NumeroEstudiante }, estudiante);
        }

        // DELETE: api/Estudiante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.NumeroEstudiante == id);
        }
    }
}
