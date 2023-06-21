using Aplicacion.InterfacesCU.ITipo;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.TipoCU
{
    public class BorrarTipo: IBorrarTipo
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public BorrarTipo(IRepositorioTipo repo)
        {
            RepoTipo = repo;
        }

        public void Eliminar(int idTipo)
        {
            RepoTipo.Remove(idTipo);
        }
    }
}
