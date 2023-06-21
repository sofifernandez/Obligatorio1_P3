using Aplicacion.CU.MantenimientoCU;
using Aplicacion.InterfacesCU.IMantenimiento;
using Dominio.EntidadesDominio;
using Dominio.ExcepcionesPropias;
using DTOs;
using ExcepcionesPropias;
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
        [HttpGet("{idCabana}", Name = "GetMantenimientoCabana")]
        public ActionResult GetMantenimientoCabana(int idCabana)
        {
            try
            {
                IEnumerable<MantenimientoDTO> matenimientos = CUListadoMantCabana.ObtenerListado(idCabana);
                if (matenimientos.Count() == 0) return NotFound("No hay mantenimientos para esta cabana");
                return Ok(matenimientos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        //------------------------------------------------------------------------------------------
        //BÚSQUEDAS------------------------------------------------------------------------------------

        [HttpGet("start/{startDate}/end/{endDate}/Cabana/{CabanaId}", Name = "FindMantDeCabana")]
        public ActionResult GetMantenimientoFechas(DateTime startDate, DateTime endDate, int CabanaId) 
        {
            try
            {
                IEnumerable<MantenimientoDTO> matenimientos = CUBuscarMantenPorFechas.BuscarEntreFechas(startDate, endDate, CabanaId);
                if (matenimientos.Count() == 0) return NotFound("No hay mantenimientos para esta cabana en estas fechas");
                return Ok(matenimientos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

        }

        [HttpGet("TotalPorCapacidad/{desde}/{hasta}")]
        public IActionResult ShowMontoPorCapacidad(int desde, int hasta) {
            try
            {
                IEnumerable<object> mantemonto = CUMontoPorCapacidad.MontoTotalPorCapacidad(desde, hasta);
                if (mantemonto.Count() == 0) return NotFound("No hay mantenimientos para esos parámetros de búsqueda");
                return Ok(mantemonto);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        //------------------------------------------------------------------------------------------
        //CREATE------------------------------------------------------------------------------------
        [HttpPost]
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
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

        }

    }
}
