using Aplicacion.InterfacesCU.IMantenimiento;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.MantenimientoCU
{
    public class MontoPorCapacidad : IMontoPorCapacidad
    {
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public MontoPorCapacidad(IRepositorioMantenimiento repo)
        {
            RepoMantenimiento = repo;

        }

        public IEnumerable<object> MontoTotalPorCapacidad(int desde, int hasta)
        {
            return RepoMantenimiento.MontoMantenimientosPorCapacidad(desde, hasta);
        }
    }
}
