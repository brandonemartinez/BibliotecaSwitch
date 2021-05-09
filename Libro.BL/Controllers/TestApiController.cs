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

            if(autores !=null)
            {
                return Ok(autores);
            }
            else
            {
                return NotFound("No hay elementos en la lista");
            }
            
            
        }
    }
}
