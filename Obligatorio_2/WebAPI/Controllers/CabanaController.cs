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
        IBuscarPorID CUBuscarPorID { get; set; }
        IBuscarPorTexto CUBuscarPorTexto { get; set; }

        public CabanaController(IListadoCabana cabanas, IAltaCabana altaCabana, IBuscarPorID buscarPorID, IBuscarPorTexto cUBuscarPorTexto)
        {
            CUAltaCabana = altaCabana;
            CUListadoCabana = cabanas;
            CUBuscarPorID = buscarPorID;
            CUBuscarPorTexto = cUBuscarPorTexto;
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
            if (id <= 0) return BadRequest("El id del tema debe ser un entero positivo");
            CabanaDTO buscado = CUBuscarPorID.Buscar(id);
            if (buscado == null) return NotFound();
            return Ok(buscado);
     
        }

        // GET api/<CabanaController>/BuscarEnNombre/asd
        [HttpGet("BuscarEnNombre/{texto}")]
        public IActionResult Get(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return BadRequest("Debe proporcionar un texto");

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarPorTexto.BuscarCabanaPorTexto(texto);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
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
