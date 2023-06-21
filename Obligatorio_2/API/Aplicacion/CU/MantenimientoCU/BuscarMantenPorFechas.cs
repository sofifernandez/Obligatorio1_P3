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
    public class BuscarMantenPorFechas : IBuscarMantenPorFechas
    {
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public BuscarMantenPorFechas(IRepositorioMantenimiento repo)
        {
            RepoMantenimiento = repo;

        }

        public IEnumerable<MantenimientoDTO> BuscarEntreFechas(DateTime startDate, DateTime endDate, int CabanaId)
        {
            return RepoMantenimiento.FindMantenimientosFechas(startDate,endDate,CabanaId)
                .Select(m => new MantenimientoDTO()
            {
                Id = m.Id,
                FechaMant = m.FechaMant,
                DescMant = m.DescMant,
                CostoMant = m.CostoMant,
                Personal = m.Personal,
                Cabana= new CabanaDTO() 
                {
                    Id = m.Cabana.Id,
                    NombreCabana = m.Cabana.NombreCabana.Value,
                    DescripCabana = m.Cabana.DescripCabana.Value,
                    Jacuzzi = m.Cabana.Jacuzzi,
                    Habilitado = m.Cabana.Habilitado,
                    MaxPersonas = m.Cabana.MaxPersonas,
                    FotoCabana = m.Cabana.FotoCabana,
                    Tipo = new TipoDTO()
                    {
                        Id = m.Cabana.Tipo.Id,
                        NombreTipo = m.Cabana.Tipo.NombreTipo.Value,
                        DescTipo = m.Cabana.Tipo.DescTipo.Value,
                        CostoTipo = m.Cabana.Tipo.CostoTipo
                    },
                    TipoId = m.Cabana.TipoId
                },
                CabanaId = m.CabanaId
            });
        }
    }
}
