using Aplicacion.CU.MantenimientoCU;
using Aplicacion.InterfacesCU.IMantenimiento;
using Dominio.EntidadesDominio;
using Dominio.ExcepcionesPropias;
using DTOs;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {

        IListadoMantenimientoDeCabana CUListadoMantCabana { get; set; }
        IBuscarMantenPorFechas CUBuscarMantenPorFechas { get; set; }
        IAltaMantenimiento CUAltaMantenimiento { get; set; }
        IMontoPorCapacidad CUMontoPorCapacidad { get; set; }

        public MantenimientoController(IListadoMantenimientoDeCabana cUListadoMantCabana, 
            IBuscarMantenPorFechas cuBuscarMantenPorFechas,
            IAltaMantenimiento cuAltaMantenimiento,
            IMontoPorCapacidad cUMontoPorCapacidad)
        {
            CUListadoMantCabana = cUListadoMantCabana;
            CUBuscarMantenPorFechas = cuBuscarMantenPorFechas;
            CUAltaMantenimiento = cuAltaMantenimiento;
            CUMontoPorCapacidad = cUMontoPorCapacidad;
        }


        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------

        // GET: MantenimientoController/idCabana/3
        /// <summary>
        /// Devuelve la lista de mantenimientos para una cabaña
        /// </summary>
        /// <param name="idCabana">El identificador de la cabaña para filtrar todos sus mantenimientos</param>
        /// <returns>Devuelve el listado de mantenimientos asociados a la cabaña</returns>
        [HttpGet("{idCabana}", Name = "GetMantenimientoCabana")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetMantenimientoCabana(int idCabana)
        {
            try
            {
                IEnumerable<MantenimientoDTO> matenimientos = CUListadoMantCabana.ObtenerListado(idCabana);
                if (matenimientos.Count() == 0) return NotFound("No hay mantenimientos para esta cabana");
                return Ok(matenimientos);
            }
            catch (Exception ex) { return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message); }
        }

        //------------------------------------------------------------------------------------------
        //BÚSQUEDAS------------------------------------------------------------------------------------
      
        /// <summary>
        /// Permite buscar mantenimientos para una determinadad cabaña que estén comprendidos entre dos fechas
        /// </summary>
        /// <param name="startDate">Fecha inicial</param>
        /// <param name="endDate">Fecha final</param>
        /// <param name="CabanaId">Identificador de la cabaña de interés</param>
        /// <returns>Lista de mantenimientos que cumplen con los filtros</returns>
        [HttpGet("start/{startDate}/end/{endDate}/Cabana/{CabanaId}", Name = "FindMantDeCabana")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetMantenimientoFechas(DateTime startDate, DateTime endDate, int CabanaId) 
        {
            try
            {
                if(startDate.Equals(null) || endDate.Equals(null) || CabanaId == 0) {return BadRequest("Los datos ingresados no son correctos");}
                IEnumerable<MantenimientoDTO> matenimientos = CUBuscarMantenPorFechas.BuscarEntreFechas(startDate, endDate, CabanaId);
                if (matenimientos.Count() == 0) return NotFound("No hay mantenimientos para esta cabana en estas fechas");
                return Ok(matenimientos);
            }
            catch (Exception ex) { return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message); }

        }


        /// <summary>
        /// Permite ingresar un rango de capacidad de huéspedes de la cabañas y devolver el total del costo del mantenimiento  agrupado por el personal que lo realizó
        /// </summary>
        /// <param name="desde">Capacidad mínima para la búsqueda</param>
        /// <param name="hasta">Capacidad máxima para la búsqueda</param>
        /// <returns>Devulve el personal encargado de mantenimientos y el total del costo asociado a cada uno</returns>
        [HttpGet("TotalPorCapacidad/{desde}/{hasta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ShowMontoPorCapacidad(int desde, int hasta) {
            try
            {
                IEnumerable<object> mantemonto = CUMontoPorCapacidad.MontoTotalPorCapacidad(desde, hasta);
                if (mantemonto.Count() == 0) return NotFound("No hay mantenimientos para esos parámetros de búsqueda");
                return Ok(mantemonto);
            }
            catch (Exception ex) { return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message); }
        }

        //------------------------------------------------------------------------------------------
        //CREATE------------------------------------------------------------------------------------

        /// <summary>
        /// Permite agregar un nuevo mantenimiento a una cabaña
        /// </summary>
        /// <param name="mantenimiento">Información del mantenimiento</param>
        /// <returns>Devuelve el mantenimiento creado al cliente</returns>
        /// <remarks>No permite crear mantenimientos anteriores a la fecha de hoy, ni agregar más de 3 mantenimientos para un mismo día en una cabaña</remarks>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] MantenimientoDTO? mantenimiento) 
        {
            if (mantenimiento == null) return BadRequest("No se ingreso informacion sobre el mantenimiento");
            try
            {
                CUAltaMantenimiento.Alta(mantenimiento);
                // return CreatedAtRoute("GetMantenimientoCabana", new { mantenimiento.CabanaId }, mantenimiento);
                return Ok(mantenimiento);
            }

            catch (AltaMantenimientoException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }

        }

    }
}
