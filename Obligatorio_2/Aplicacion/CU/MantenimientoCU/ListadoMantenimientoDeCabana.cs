using Aplicacion.InterfacesCU.IMantenimiento;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.MantenimientoCU
{
    public class ListadoMantenimientoDeCabana:IListadoMantenimientoDeCabana
    {
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }


        public ListadoMantenimientoDeCabana(IRepositorioMantenimiento repo)
        {
            RepoMantenimiento = repo;

        }

        public IEnumerable<MantenimientoDTO> ObtenerListado(int CabanaId)
        {
            return RepoMantenimiento.FindMantenimientosCabana(CabanaId).Select(m => new MantenimientoDTO()
            {
                Id =m.Id,
                FechaMant=m.FechaMant,
                DescMant=m.DescMant,
                CostoMant=m.CostoMant,
                Personal=m.Personal,
                Cabana=m.Cabana,
                CabanaId=m.CabanaId
            });
        }
    }
}
