using Aplicacion.CU.CabanaCU;
using Aplicacion.InterfacesCU.ICabana;
using Dominio.ExcepcionesPropias;
using DTOs;
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Permite obtener el listado de cabañas
        /// </summary>
        /// <returns>Retorna el listado de cabañas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<CabanaDTO> cabanas = CUListadoCabana.ObtenerListado();
                return Ok(cabanas);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocurrió un error inesperado: " +ex.Message);
            }
        }

        /// <summary>
        /// Busca las cabañas por el id
        /// </summary>
        /// <param name="id">El identificador de la cabaña</param>
        /// <returns>Retorna un cabaña</returns>
        [HttpGet("{id}", Name = "FindById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("El id debe ser un entero positivo");
                CabanaDTO buscado = CUBuscarPorID.Buscar(id);
                if (buscado == null) return NotFound("No se encontró una cabaña con ese id");
                return Ok(buscado);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error inesperado");
            }

        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------

        /// <summary>
        /// Permite buscar cabañas según su nombre
        /// </summary>
        /// <param name="texto">El string que será buscado en los nombres</param>
        /// <returns>Retorna un listado de cabañas que contiene ese string en el nombre</returns>
        

        
        [HttpGet("FindByNombre/{texto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }

        /// <summary>
        /// Permite buscar cabañas según su capacidad
        /// </summary>
        /// <param name="cantidad">El integer que será utilizado como parámetro de búsqueda</param>
        /// <returns>Retorna un listado de cabañas que tiene como máximo dicha capacidad</returns>
        [HttpGet("FindByMaxHuespedes/{cantidad}", Name = "Buscar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }

        /// <summary>
        /// Permite buscar cabañas habilitadas
        /// </summary>
        /// <returns>Retorna un listado de cabañas habilitadas</returns>
        [HttpGet("FindByHabilitadas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BuscarHabilitadas()
        {

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarHabilitadas.BuscarHabilitadas();
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }

        /// <summary>
        /// Permite buscar cabañas según su Tipo
        /// </summary>
        /// <param name="idTipo">El identificador del Tipo para buscar todas las cabañas bajo esa clasificación</param>
        /// <returns>Retorna un listado de cabañas que son de ese tipo</returns>
        [HttpGet("FindByTipo/{idTipo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BuscarPorTipo(int idTipo) {

            try
            {
                IEnumerable<CabanaDTO> cabanas = CUBuscarPorTipo.BuscarPorTipo(idTipo);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception ex) { return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message); }

        }
        /// <summary>
        /// Permite buscar cabañas que tengan un precio/monto diario menor al ingresado, que está asociado al tipo de cabaña
        /// </summary>
        /// <param name="monto">El integer que será utilizado para filtrar las cabañas </param>
        /// <returns>Retorna un listado de cabañas que tienen un monto menor al ingresado</returns>
        [HttpGet("FindByMonto/{monto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FindByMonto(int monto) {
            try
            {
                IEnumerable<Object> cabanas = CUBuscarCabanaPorMonto.FindCabanaPorMonto(monto);
                if (cabanas.Count() == 0) return NotFound("No hay Cabañas para esta busqueda");
                return Ok(cabanas);
            }
            catch (Exception ex) { return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message); }
        }



        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------

        /// <summary>
        /// Permite agregar cabañas al sistema
        /// </summary>
        /// <param name="cabana">La información de cabaña</param>
        /// <returns>Devuelve la cabaña creada al cliente</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CabanaDTO? cabana)
        {
            if (cabana == null) return BadRequest("No se ingreso informacion sobre la Cabaña");
            try
            {
                CUAltaCabana.Alta(cabana);
                return Ok(cabana);
            }
            catch (AltaCabanaException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
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
