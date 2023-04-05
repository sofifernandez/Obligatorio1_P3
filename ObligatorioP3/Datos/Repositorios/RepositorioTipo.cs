using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;

namespace Datos.Repositorios
{
    public class RepositorioTipo : IRepositorioTipo

    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioTipo(LibreriaContext ctx) 
        {
            Contexto = ctx;
        }
        public void Add(Tipo obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tipo> FindAll()
        {
            throw new NotImplementedException();
        }

        public Tipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Tipo FindTipoByNombre(string nombreTipo)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tipo obj)
        {
            throw new NotImplementedException();
        }
    }
}
