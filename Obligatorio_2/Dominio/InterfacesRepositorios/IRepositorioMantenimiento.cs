using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDominio;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioMantenimiento: IRepositorio<Mantenimiento>
    {
        IEnumerable<Mantenimiento> FindMantenimientosCabana(int idCabana);
        IEnumerable<Mantenimiento> FindMantenimientosFechas(DateTime startDate, DateTime endDate, int CabanaId);
        public IEnumerable<Mantenimiento> FindMantenimientosPorCapacidad(int desde, int hasta);

    }
}
