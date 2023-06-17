using Aplicacion.InterfacesCU.ICabana;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.CabanaCU
{
    public class BuscarPorID : IBuscarPorID
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public BuscarPorID(IRepositorioCabana repo)
        {
            RepoCabana = repo;
        }
        public CabanaDTO Buscar(int id)
        {
            CabanaDTO dto = null;
            Cabana c = RepoCabana.FindById(id);
            if (c != null)
            {
                dto = new CabanaDTO()
                {
                    Id = c.Id,
                    NombreCabana = c.NombreCabana,
                    DescripCabana = c.DescripCabana,
                    Jacuzzi = c.Jacuzzi,
                    Habilitado = c.Habilitado,
                    MaxPersonas = c.MaxPersonas,
                    FotoCabana = c.FotoCabana,
                    Tipo = c.Tipo,
                    TipoId = c.TipoId
                };
            }
            return dto;
        }
    }
}
