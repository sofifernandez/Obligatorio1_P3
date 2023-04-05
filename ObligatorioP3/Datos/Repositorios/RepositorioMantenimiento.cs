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
    internal class RepositorioMantenimiento : IRepositorioMantenimiento
    {   
        public LibreriaContext Contexto { get; set; }

        public RepositorioMantenimiento(LibreriaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public Mantenimiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> FindMantenimientosFechas(DateTime startDate, DateTime endDate, Cabana miCabana)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
