using Aplicacion.InterfacesCU.ITipo;
using Dominio.EntidadesDominio;
using Dominio.ExcepcionesPropias;
using DTOs;
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

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<TipoDTO> tipos = CUListadoTipo.ObtenerListado();
            return Ok(tipos);
        }


        [HttpGet("{id}", Name = "GetById")]
        public ActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El id del tema debe ser un entero positivo");
            TipoDTO buscado = CUBuscarTipoPorID.Buscar(id);
            if (buscado == null) return NotFound("No se encontró una tipo de cabaña con ese ID");
            return Ok(buscado);
        }

        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------
        [HttpGet("FindByNombre/{texto}")]
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
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------

        [HttpPost]
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
                return StatusCode(500, ex.Message);
                //return StatusCode(500, "Ocurrió un error inesperado");
            }
            
        }

        // PUT api/<TemasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoDTO? tipo) //UPDATE
        {
            if (id <= 0 || tipo == null || tipo.Id != id) return BadRequest("Los datos proporcionados no son válidos");
            try
            {
                CUEditarTipo.Editar(tipo);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(tipo);
        }


        // DELETE api/<TipoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //DELETE
        {
            if (id <= 0) return BadRequest("El id proporcionado no es válido");
            try
            {
                CUBorrarTipo.Eliminar(id);
            }
            catch (Exception ex)
            {
                // return StatusCode(500, "Ocurrió un error inesperado");
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }


     
    }
}
