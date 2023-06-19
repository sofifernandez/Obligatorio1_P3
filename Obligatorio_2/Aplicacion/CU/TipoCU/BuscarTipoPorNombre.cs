using Aplicacion.InterfacesCU.ITipo;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.TipoCU
{
    public class BuscarTipoPorNombre : IBuscarTipoPorNombre
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public BuscarTipoPorNombre(IRepositorioTipo repo)
        {
            RepoTipo = repo;
        }
        public TipoDTO BuscarPorNombre(string texto)
        {
            TipoDTO dto = null;
            Tipo t = RepoTipo.FindTipoByNombre(texto);
            if (t != null)
            {
                dto = new TipoDTO()
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    DescTipo = t.DescTipo,
                    CostoTipo = t.CostoTipo
                };
            }
            return dto;
        }
    }
}
