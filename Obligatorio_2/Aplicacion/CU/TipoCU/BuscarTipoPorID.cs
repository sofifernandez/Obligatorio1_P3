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
    public class BuscarTipoPorID : IBuscarTipoPorID
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public BuscarTipoPorID(IRepositorioTipo repo)
        {
            RepoTipo = repo;
        }
        public TipoDTO Buscar(int id)
        {
            TipoDTO dto = null;
            Tipo t = RepoTipo.FindById(id);
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
