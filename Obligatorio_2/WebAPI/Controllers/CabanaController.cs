using Aplicacion.CU.CabanaCU;
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
        IBuscarCabanaPorID CUBuscarPorID { get; set; }
        IBuscarCabanaPorNombre CUBuscarPorTexto { get; set; }
        IBuscarCabanaMax CUBuscarCabanaMax { get; set; }
        IBuscarCabanasHabilitadas CUBuscarHabilitadas { get; set; }
        IBuscarCabanaPorTipo CUBuscarPorTipo { get; set; }
        IBuscarCabanaPorMonto CUBuscarCabanaPorMonto { get; set; }



        public CabanaController(IListadoCabana cabanas,
            IAltaCabana altaCabana,
            IBuscarCabanaPorID buscarPorID,
            IBuscarCabanaPorNombre cuBuscarPorTexto,
            IBuscarCabanaMax cubuscarCabanaMax,
            IBuscarCabanasHabilitadas cuBuscarHabilitadas,
            IBuscarCabanaPorTipo cuBuscarCabanaPorTipo,
            IBuscarCabanaPorMonto cuBuscarCabanaPorMonto)
        {
            CUAltaCabana = altaCabana;
            CUListadoCabana = cabanas;
            CUBuscarPorID = buscarPorID;
            CUBuscarPorTexto = cuBuscarPorTexto;
            CUBuscarCabanaMax = cubuscarCabanaMax;
            CUBuscarHabilitadas = cuBuscarHabilitadas;
            CUBuscarPorTipo = cuBuscarCabanaPorTipo;
            CUBuscarCabanaPorMonto = cuBuscarCabanaPorMonto;
        }


        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------

        // GET: api/<CabanaController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CabanaDTO> cabanas = CUListadoCabana.ObtenerListado();
            return Ok(cabanas);
        }

        // GET api/<CabanaController>/5
        [HttpGet("{id}", Name = "FindById")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("El id del tema debe ser un entero positivo");
                CabanaDTO buscado = CUBuscarPorID.Buscar(id);
                if (buscado == null) return NotFound("No se encontró una cabaña con ese ID");
                return Ok(buscado);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error inesperado");
            }

        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------

        // GET api/<CabanaController>/FindByNombre/asd
        [HttpGet("FindByNombre/{texto}")]
        public IActionResult BuscarPorNombre(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return BadRequest("Debe proporcionar un texto");

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarPorTexto.BuscarCabanaPorTexto(texto);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        // GET api/<CabanaController>/FindByMaxHuespedes/5
        [HttpGet("FindByMaxHuespedes/{cantidad}", Name = "Buscar")]
        public IActionResult BuscarPorMaxHuespedes(int cantidad)
        {
            if (cantidad == null)
                return BadRequest("Debe proporcionar un numero");

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarCabanaMax.BuscarCabanaPorPersonas(cantidad);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        // GET api/<CabanaController>/FindByHabilitadas
        [HttpGet("FindByHabilitadas")]
        public IActionResult BuscarHabilitadas()
        {

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarHabilitadas.BuscarHabilitadas();
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        [HttpGet("FindByTipo/{idTipo}")]
        public IActionResult BuscarPorTipo(int idTipo) {

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarPorTipo.BuscarPorTipo(idTipo);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

        }

        [HttpGet("FindByMonto/{monto}")]
        public IActionResult FindByMonto(int monto) {
            try
            {
                IEnumerable<Object> cabanas= CUBuscarCabanaPorMonto.FindCabanaPorMonto(monto);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }



        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------

        // POST api/<CabanaController>
        [HttpPost]
        public IActionResult Post([FromBody] CabanaDTO? cabana)
        {
            if (cabana == null) return BadRequest("No se ingreso informacion sobre la Cabaña");
            try
            {
                CUAltaCabana.Alta(cabana);
                return Ok(cabana);
            }
            catch (NombreCabanaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }    
        }


        //-------------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS-----------------------------------------------------------------------------------------

        /*

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
        */
    }
}
