using Aplicacion.InterfacesCU.ITipo;
using Dominio.EntidadesDominio;
using Dominio.ExcepcionesPropias;
using DTOs;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        IListadoTipo CUListadoTipo { get; set; }
        IAltaTipo CUAltaTipo { get; set; }
        IBuscarTipoPorID CUBuscarTipoPorID { get; set; }
        IBuscarTipoPorNombre CUBuscarTipoPorNombre { get; set; }
        IEditarTipo CUEditarTipo { get; set; }
        IBorrarTipo CUBorrarTipo { get; set; }

        public TipoController(IAltaTipo cUAltaTipo, 
            IListadoTipo cuListadoTipo,
            IBuscarTipoPorID cUBuscarTipoPorID,
            IBuscarTipoPorNombre cUBuscarTipoPorNombre,
            IEditarTipo cUEditarTipo,
            IBorrarTipo cuBorrarTipo)
        {
            CUAltaTipo = cUAltaTipo;
            CUListadoTipo = cuListadoTipo;
            CUBuscarTipoPorID = cUBuscarTipoPorID;
            CUBuscarTipoPorNombre = cUBuscarTipoPorNombre;
            CUEditarTipo = cUEditarTipo;
            CUBorrarTipo = cuBorrarTipo;
        }


        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------

        /// <summary>
        /// Obtener el listado de tipos
        /// </summary>
        /// <returns>Devuelve el listado</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<TipoDTO> tipos = CUListadoTipo.ObtenerListado();
                return Ok(tipos);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtener un tipo según su identificador
        /// </summary>
        /// <param name="id">Identificador de tipo</param>
        /// <returns>Devuelve el tipo, si es que existe</returns>
        [HttpGet("{id}", Name = "GetById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("El id del tema debe ser un entero positivo");
                TipoDTO buscado = CUBuscarTipoPorID.Buscar(id);
                if (buscado == null) return NotFound("No se encontró una tipo de cabaña con ese ID");
                return Ok(buscado);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }

        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------
        /// <summary>
        /// Permite buscar un determinado tipo según su nombre
        /// </summary>
        /// <param name="texto">Nombre para filtrar el tipo deseado</param>
        /// <returns>Devuelve el tipo deseado, si es que lo encuentra</returns>
        /// <remarks>El nombre se matchea completo</remarks>
        [HttpGet("FindByNombre/{texto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult BuscarPorNombre(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return BadRequest("Debe proporcionar un texto");

            try
            {                
                TipoDTO buscado = CUBuscarTipoPorNombre.BuscarPorNombre(texto);
                if (buscado == null) return NotFound("No se encontró una tipo de cabaña con ese nombre");
                return Ok(buscado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------

        /// <summary>
        /// Agregar un nuevo tipo al sistema
        /// </summary>
        /// <param name="tipo">Información de tipo para agregar</param>
        /// <returns>Devuelve el tipo creado al cliente</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] TipoDTO? tipo)
        {
            if (tipo == null) return BadRequest("No se ingreso informacion sobre el tipo");
            try
            {
                CUAltaTipo.Alta(tipo);
                return CreatedAtRoute("GetById", new { id = tipo.Id }, tipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
                //return StatusCode(500, "Ocurrió un error inesperado");
            }
            
        }

        // PUT api/<TemasController>/5
        /// <summary>
        /// Permite editar tipos en el sistema
        /// </summary>
        /// <param name="id">Identificador del tipo</param>
        /// <param name="tipo">Información del tipo</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] TipoDTO? tipo) //UPDATE
        {
            if (id <= 0 || tipo == null || tipo.Id != id) return BadRequest("Los datos proporcionados no son válidos");
            try
            {
                CUEditarTipo.Editar(tipo);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }

            return Ok(tipo);
        }


        // DELETE api/<TipoController>/5
        /// <summary>
        /// Permite eliminar un tipo del sistema
        /// </summary>
        /// <param name="id">Identificador del tipo que se quiere eliminar</param>
        /// <returns></returns>
        /// <remarks>NO se podrá eliminar un tipo en uso</remarks>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Delete(int id) //DELETE
        {
            if (id <= 0) return BadRequest("El id proporcionado no es válido");
            try
            {
                CUBorrarTipo.Eliminar(id);
            }
            catch(TipoEnUsoException exUso)
            {
                return Conflict(exUso.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
            return NoContent();
        }


     
    }
}
