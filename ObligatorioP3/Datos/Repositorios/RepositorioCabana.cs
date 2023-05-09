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
        // Ver cque nombre este dentro de NombreCabana****
        public IEnumerable<Cabana> FindCabanaNombre(string nombre) 
        {
            return Contexto.Cabanas
                           .Where(cabana => cabana.NombreCabana.Contains(nombre))
                           .ToList();
        }

        public IEnumerable<Cabana> FindCabanaMax(int maxPersonas)
        {

            return Contexto.Cabanas
                          .Where(cab => cab.MaxPersonas == maxPersonas)
                          .ToList();

        }

        public IEnumerable<Cabana> FindCabanaTipo(Tipo tipo)
        {
            return Contexto.Cabanas
                          .Where(cab => cab.Tipo.Id == tipo.Id)
                          .ToList();
        }

        public IEnumerable<Cabana> FindCabanasHabilitadas(bool habilitadas)
        {
            return Contexto.Cabanas
                           .Where(cab => cab.Habilitado == habilitadas)
                           .ToList();
        }

        public void Add(Cabana obj)
        {

            obj.Validar();
            Contexto.Add(obj); 
            Contexto.SaveChanges();
        }

        public IEnumerable<Cabana> FindAll()
        {
            return Contexto.Cabanas.Include(cab=>cab.Tipo).ToList();
        }

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

        public Cabana FindById(int id)
        {
            Cabana buscada = Contexto.Cabanas.Find(id);
            return buscada == null ? throw new Exception("La cabana ingresada no existe") : buscada;


            // con linQ: para traer los tipos con include
            // buscada = Contexto.Cabanas
            // .Include(cabana=>cabana.Tipo)
            // .Where(cabana => cabana.Id== id)
            // .SingleOrDefault(); --> para decirle que va a traer una fila
        }




    }
}
