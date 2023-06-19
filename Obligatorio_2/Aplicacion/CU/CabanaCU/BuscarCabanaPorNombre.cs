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
    public class BuscarCabanaPorNombre: IBuscarCabanaPorNombre
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public BuscarCabanaPorNombre(IRepositorioCabana repo)
        {
            RepoCabana = repo;
        }

        public IEnumerable<CabanaDTO> BuscarCabanaPorTexto(string texto)
        {
            IEnumerable<CabanaDTO> cabanas = RepoCabana.FindCabanaNombre(texto).
                                                        Select(c => new CabanaDTO()
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
                                                        });

            return cabanas;
        }
    }
}
