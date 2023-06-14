using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.EntidadesAuxiliares;
using Dominio.InterfacesRepositorios;

namespace Datos.Repositorios
{
    public class RepositorioParametro : IRepositorioParametro
    {
        public HotelContext Contexto { get; set; }

        public RepositorioParametro(HotelContext contexto)
        {
            Contexto = contexto;
        }

        //---------------------------------------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------------------------------------
        public string ValorParametro(string nombre)
        {

            return Contexto.Parametros
                .Where(par => par.Nombre == nombre)
                .Select(par => par.Valor)
                .SingleOrDefault();

        }

        //---------------------------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADO-----------------------------------------------------------------------------------------------------------
        public void Add(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parametro> FindAll()
        {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            throw new NotImplementedException();
        }


    }
}
