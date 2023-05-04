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
        public HotelContext Contexto { get; set; }

        public RepositorioMantenimiento(HotelContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            return Contexto.Mantenimientos.ToList();
        }

        public Mantenimiento FindById(int id)
        {
            //Mantenimiento no tiene ID, habria que agregarle
            return contexto.mantenimientos
                            .where(man => man.id == id)
                            .singleordefault();
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
