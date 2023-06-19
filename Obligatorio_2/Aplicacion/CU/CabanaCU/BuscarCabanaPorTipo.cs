using Aplicacion.InterfacesCU.ICabana;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.CabanaCU
{
    public class BuscarCabanaPorTipo : IBuscarCabanaPorTipo
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public BuscarCabanaPorTipo(IRepositorioCabana repo)
        {
            RepoCabana = repo;
        }
        public IEnumerable<CabanaDTO> BuscarPorTipo(int idTipo)
        {
            IEnumerable<CabanaDTO> cabanas = RepoCabana.FindCabanaTipo(idTipo).
                                                        Select(c => new CabanaDTO()
                                                        {
                                                            Id = c.Id,
                                                            NombreCabana = c.NombreCabana.Value,
                                                            DescripCabana = c.DescripCabana.Value,
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
