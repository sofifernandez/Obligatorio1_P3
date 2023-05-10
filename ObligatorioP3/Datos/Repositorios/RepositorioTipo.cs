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
            return Contexto.Tipos.ToList();
        }

        public Tipo FindById(int id)
        {
            Tipo buscado = Contexto.Tipos.Find(id);
            return buscado == null ? throw new Exception("El tipo ingresado no existe") : buscado;
        }

        public Tipo FindTipoByNombre(string nombreTipo)
        {

            return Contexto.Tipos
                           .Where(tipo => tipo.Nombre.ToLower() == nombreTipo.ToLower())
                           .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Tipo aBorrar = FindById(id);
            Contexto.Tipos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Tipo obj)
        {
            obj.Validar();
            Contexto.Tipos.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
