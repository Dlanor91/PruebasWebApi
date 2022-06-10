using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebasWebApi.Controllers
{
    [Route("Customers")]//cambio la ruta ("api/[controller]") 
    [ApiController]
    public class AutoresController : ControllerBase
    {
        // GET: api/<AutoresController>/FindAll
        [Route ("FindAll")]//ruteo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<Autor>()
            {
                new Autor() { Id =1, Nombre = "Juan" , Apellido = "Perez"},
                new Autor() { Id =2, Nombre = "Ana" , Apellido = "Gomez"}
            });
        }

        // GET api/<AutoresController>/FindById/5
        [Route("FindById/{id}/Nombre/{nombre}")]//ruteo y agrego el id
        [HttpGet] //se saca el id y se ponen encima los dos parametros
        public IActionResult Get(int id, string nombre)
        {
            return Ok(new Autor() { Id =id, Nombre = nombre, Apellido = "Perez" });
        }

        // POST api/<AutoresController>
        [HttpPost]
        public IActionResult Post([FromBody] Autor a)//para que devuelva 201 
        {       
            //si no es valido
           // return BadRequest(); //si es valido

            //si es valido
            return Created("api/autores/"+a.Id,a);//Recibe URI que es ruta pra el find by id, objeto

            //Si ocurre un error
            //return StatusCode(500);

            //si no se pudo hacer el alta
            //return Conflict();
        }

        // PUT api/<AutoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Autor a)
        {
            return NoContent();
        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
