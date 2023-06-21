using Aplicacion.InterfacesCU.ICabana;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.CabanaCU
{
    public class ListadoCabana: IListadoCabana
    {
        public IRepositorioCabana RepoCabana { get; set; }
    

        public ListadoCabana(IRepositorioCabana repo)
        {
            RepoCabana = repo;
           
        }

        public IEnumerable<CabanaDTO> ObtenerListado()
        {
            IEnumerable<Cabana> cabanas = RepoCabana.FindAll().OfType<Cabana>();
            return cabanas.Select(c => new CabanaDTO()
                                        {
                                            Id= c.Id,
                                            NombreCabana = c.NombreCabana.Value,
                                            DescripCabana = c.DescripCabana.Value,
                                            Jacuzzi = c.Jacuzzi,
                                            Habilitado = c.Habilitado,
                                            MaxPersonas = c.MaxPersonas,
                                            FotoCabana = c.FotoCabana,
                                            Tipo = new TipoDTO() 
                                            {   Id=c.Tipo.Id,
                                                NombreTipo=c.Tipo.NombreTipo.Value,
                                                DescTipo=c.Tipo.DescTipo.Value,
                                                CostoTipo=c.Tipo.CostoTipo
                                            },
                                            TipoId = c.TipoId
                                        });
        }
    }
}
