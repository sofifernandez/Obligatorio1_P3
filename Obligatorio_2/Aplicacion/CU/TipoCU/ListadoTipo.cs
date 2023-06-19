using Aplicacion.InterfacesCU.ITipo;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.TipoCU
{
    public class ListadoTipo : IListadoTipo
    {
        public IRepositorioTipo RepoTipo { get; set; }


        public ListadoTipo(IRepositorioTipo repo)
        {
            RepoTipo = repo;

        }

        public IEnumerable<TipoDTO> ObtenerListado()
        {
            return RepoTipo.FindAll().Select(t => new TipoDTO()
            {
                Id = t.Id,
                NombreTipo = t.NombreTipo.Value,
                DescTipo = t.DescTipo.Value,
                CostoTipo = t.CostoTipo,

            });
        }
    }
}
