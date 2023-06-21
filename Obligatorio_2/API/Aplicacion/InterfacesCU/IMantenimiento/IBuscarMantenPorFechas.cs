using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.InterfacesCU.IMantenimiento
{
    public interface IBuscarMantenPorFechas
    {
        IEnumerable<MantenimientoDTO> BuscarEntreFechas(DateTime startDate, DateTime endDate, int CabanaId);
    }
}
