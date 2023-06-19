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
        //------------------------------------------------------------------------------------------
        //CREATE------------------------------------------------------------------------------------
        public void Add(Tipo obj)
        {
            //obj.Validar();
            Contexto.Tipos.Add(obj);
            Contexto.SaveChanges();
        }

        //------------------------------------------------------------------------------------------
        //BÚSQUEDAS------------------------------------------------------------------------------------
        public IEnumerable<Tipo> FindAll()
        {
            return Contexto.Tipos.ToList();
        }

        public Tipo FindById(int id)
        {
            Tipo buscado = Contexto.Tipos.Find(id);
            return buscado;
        }

        public Tipo FindTipoByNombre(string nombreTipo)
        {

            return Contexto.Tipos
                           .Where(tipo => tipo.NombreTipo.Value.ToLower() == nombreTipo.ToLower())
                           .SingleOrDefault();
        }

        //------------------------------------------------------------------------------------------
        //BORRAR------------------------------------------------------------------------------------
        public void Remove(int id)
        {
            Tipo aBorrar = FindById(id);
            int enUso= Contexto.Cabanas 
                .Where(cab=>cab.TipoId==id)
                .Count();
            if (enUso > 0) 
            {
                throw new Exception("No se puede eliminar el tipo porque está en uso");
            }
            Contexto.Tipos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //------------------------------------------------------------------------------------------
        //ACTUALIZAR------------------------------------------------------------------------------------
        public void Update(Tipo obj)
        {
            //obj.Validar();
            Contexto.Tipos.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
