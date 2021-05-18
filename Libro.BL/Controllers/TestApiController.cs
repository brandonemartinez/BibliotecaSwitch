using LibroBL.Models;
using LibroBL.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        AutorRepositorio foo = new AutorRepositorio();

        [HttpGet]
        public IActionResult Get()
        {
            var autores = foo.GetAutores();

            if (autores != null)
            {
                return Ok(autores);
            }
            else
            {
                return NotFound("No hay elementos en la lista");
            }


        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            var autor = foo.GetAutor(id);

            if (autor != null)
            {
                return Ok(autor);
            }
            else
            {
                return NotFound("No hay elementos en la lista");
            }
        }

        [HttpPost("agregar")]
        public IActionResult Post(Autor autor)
        {   
             foo.Agregar(autor);
             return CreatedAtAction(nameof(Post), autor);
        }
    }
}
