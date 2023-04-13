using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
//using  Microsoft.EntityFrameworkCore;

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
            // var resultado=Contexto.Cabanas
            // .Include(cabana ==>cabana.Tipo) --> si queremos que nos traiga la información de tipo también, sino no lo trae 
            // .Where(cabana => cabana.Nombre==nombre)
            // .ToList();
        }

        public IEnumerable<Cabana> FindCabanaMax(int maxPersonas)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindCabanaTipo(Tipo tipo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindCabanasHabilitadas(bool habilitadas)
        {
            throw new NotImplementedException();
        }

        public void Add(Cabana obj)
        {
            throw new NotImplementedException();
            //obj.Validar();
            //Contexto.Add(obj); --> es lo mismo que poner: Contexto.Entry(obj).State=EntityState.Added;
            //Contexto.SaveChanges();
        }

        public IEnumerable<Cabana> FindAll()
        {
            throw new NotImplementedException();
            //return Contexto.Cabanas.ToList();
            //return Contexto.Cabanas.Include(cabana => cabana.Tipo).ToList(); --> para traer el tipo
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
            // Cabana aBorrar= FindById(id);
            // Contexto.Remove(aBorrar);
            // Contexto.SaveChanges();
        }

        public void Update(Cabana obj)
        {
            throw new NotImplementedException();
            // Contexto.Temas.Update(obj);
            // Contexto.SaveChanges();
        }

        public Cabana FindById(int id)
        {
            throw new NotImplementedException();
            //Cabana buscada=Contexto.Cabanas.Find(id);
            // if(buscada ==null){
            //  throw new Exception('La cabana ingresada no existe');
            // }
            // return buscada;


            // con linQ: para traer los tipos con include
            // buscada = Contexto.Cabanas
            // .Include(cabana=>cabana.Tipo)
            // .Where(cabana => cabana.Id== id)
            // .SingleOrDefault(); --> para decirle que va a traer una fila
        }

        public IEnumerable<Cabana> FindCabanaTipo(int maxPersonas)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindCabanasHabilitas(int maxPersonas)
        {
            throw new NotImplementedException();
        }
    }
}
