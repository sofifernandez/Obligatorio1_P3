using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Datos.Repositorios
{
    public class RepositorioTipo : IRepositorioTipo

    {
        public HotelContext Contexto { get; set; }

        public RepositorioTipo(HotelContext ctx) 
        {
            Contexto = ctx;
        }
        public void Add(Tipo obj)
        {
            obj.Validar();
            Contexto.Tipos.Add(obj);
            Contexto.SaveChanges();
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
