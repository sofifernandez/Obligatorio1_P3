using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;

namespace Datos.Repositorios
{
    public class RepositorioCabana: IRepositorioCabana
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioCabana(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public IEnumerable<Cabana> FindCabanaNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindCabanaMax(int maxPersonas)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindCabanaTipo(int maxPersonas)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindCabanasHabilitas(int maxPersonas)
        {
            throw new NotImplementedException();
        }

        public void Add(Cabana obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cabana obj)
        {
            throw new NotImplementedException();
        }

        public Cabana FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
