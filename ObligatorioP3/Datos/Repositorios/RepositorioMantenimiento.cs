using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositorios
{
    public class RepositorioMantenimiento : IRepositorioMantenimiento
    {   
        public HotelContext Contexto { get; set; }

        public RepositorioMantenimiento(HotelContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Mantenimiento obj)
        {
            //obj.Validar();
            Contexto.Mantenimientos.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            return Contexto.Mantenimientos.ToList();
        }

        public Mantenimiento FindById(int id)
        {
            Mantenimiento buscado = Contexto.Mantenimientos.Find(id);
            if (buscado == null)
            {
                throw new Exception("El mantenimiento no existe");
            }
            return buscado;
        }

        public IEnumerable<Mantenimiento> FindMantenimientosFechas(DateOnly startDate, DateOnly endDate, int CabanaId)
        {
           var resultado = Contexto.Mantenimientos
                .Where(mant => mant.CabanaId == CabanaId)
                .Where(mant=>mant.FechaMant.Date.CompareTo(startDate) >=0) //no funcionan los operadores = < > para comparar directamente
                .Where(mant => mant.FechaMant.Date.CompareTo(endDate) <= 0)
                .OrderByDescending(mant=>mant.CostoMant) 
                .ToList();
            return resultado;
        }

        public void Remove(int id)
        {
            Mantenimiento aBorrar = FindById(id);
            Contexto.Mantenimientos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Mantenimiento obj)
        {
            //obj.Validar();
            Contexto.Mantenimientos.Update(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Mantenimiento> FindMantenimientosCabana(int idCabana)
        {
            var resultado = Contexto.Mantenimientos
                .Where(mant => mant.CabanaId == idCabana)
                .Include(mant=>mant.Cabana)
                .ToList();
            return resultado;
        }
    }
}
