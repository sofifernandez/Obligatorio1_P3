using Aplicacion.InterfacesCU.ICabana;
using Dominio.ExcepcionesPropias;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabanaController : ControllerBase
    {
        IAltaCabana CUAltaCabana { get; set; }
        IListadoCabana CUListadoCabana { get; set; }

        public CabanaController(IListadoCabana cabanas, IAltaCabana altaCabana)
        {
            CUAltaCabana = altaCabana;
            CUListadoCabana = cabanas;
        }

        // GET: api/<CabanaController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CabanaDTO> cabanas = CUListadoCabana.ObtenerListado();
            return Ok(cabanas);
        }

        // GET api/<CabanaController>/5
        [HttpGet("{id}" ,Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<CabanaController>
        [HttpPost]
        public IActionResult Post([FromBody] CabanaDTO? cabana)
        {
            if (cabana == null) return BadRequest("No se ingreso informacion sobre la Cabaña");
            try
            {
                CUAltaCabana.Alta(cabana);
                return CreatedAtRoute("Get", new { id = cabana.Id }, cabana);
            }
            catch (NombreCabanaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch 
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }   

            
        }

        // PUT api/<CabanaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<CabanaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
