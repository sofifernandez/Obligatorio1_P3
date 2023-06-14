using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using  Microsoft.EntityFrameworkCore;

namespace Datos.Repositorios
{
    public class RepositorioCabana: IRepositorioCabana
    {
        public HotelContext Contexto { get; set; }

        public RepositorioCabana(HotelContext ctx)
        {
            Contexto = ctx;
        }

        //------------------------------------------------------------------------------------------
        //CREATE------------------------------------------------------------------------------------
        public void Add(Cabana obj)
        {
            obj.Validar();
            Contexto.Add(obj);
            Contexto.SaveChanges();
        }

        //------------------------------------------------------------------------------------------
        //BÚSQUEDAS------------------------------------------------------------------------------------
        public Cabana FindById(int id)
        {
            Cabana buscada = Contexto.Cabanas.Find(id);
            return buscada == null ? throw new Exception("La cabana ingresada no existe") : buscada;
        }

        public IEnumerable<Cabana> FindCabanaNombre(string nombre) 
        {
            return Contexto.Cabanas
                           .Where(cabana => cabana.NombreCabana.ToLower().Contains(nombre.ToLower()))
                           .Include(cabana=>cabana.Tipo)
                           .ToList();
        }

        public IEnumerable<Cabana> FindCabanaMax(int maxPersonas)
        {

            return Contexto.Cabanas
                          .Where(cab => cab.MaxPersonas >= maxPersonas)
                          .Include(cabana => cabana.Tipo)
                          .ToList();

        }

        public IEnumerable<Cabana> FindCabanaTipo(int idTipo)
        {
            return Contexto.Cabanas
                          .Where(cab => cab.Tipo.Id == idTipo)
                          .Include(cabana => cabana.Tipo)
                          .ToList();
        }

        public IEnumerable<Cabana> FindCabanasHabilitadas()
        {
            return Contexto.Cabanas
                           .Where(cab => cab.Habilitado == true)
                           .Include(cabana => cabana.Tipo)
                           .ToList();
        }

        public IEnumerable<Cabana> FindAll()
        {
            return Contexto.Cabanas.Include(cab=>cab.Tipo).ToList();
        }




        //---------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS------------------------------------------------------------------------------------
        public void Remove(int id)
        {
            Cabana aBorrar = FindById(id);
            Contexto.Cabanas.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Cabana obj)
        {
            Contexto.Cabanas.Update(obj);
            Contexto.SaveChanges();
        }



    }
}
