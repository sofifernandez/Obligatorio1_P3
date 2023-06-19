using Aplicacion.InterfacesCU.ITipo;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.TipoCU
{
    public class EliminarTipo : IEliminarTipo
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public EliminarTipo(IRepositorioTipo repo)
        {
            RepoTipo = repo;
        }

        public void Eliminar(int IdTipo)
        {
            RepoTipo.Remove(IdTipo);
        }
    }
}
