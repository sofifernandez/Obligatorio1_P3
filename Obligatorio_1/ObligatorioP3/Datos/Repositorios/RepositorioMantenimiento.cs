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
        //------------------------------------------------------------------------------------------
        //CREATE------------------------------------------------------------------------------------
        public void Add(Mantenimiento obj)
        {
            obj.Validar();
            int mismaFecha=Contexto.Mantenimientos
                .Where(mant=>mant.CabanaId==obj.CabanaId)
                .Where(mant=>mant.FechaMant.Date==obj.FechaMant.Date)
                .Count();
            if (mismaFecha < 3)
            {
                Contexto.Mantenimientos.Add(obj);
                Contexto.SaveChanges();
            }
            else 
            {
                throw new Exception("Solo se pueden agregar 3 mantenimientos por cabaña por día");
            }
        }

        //------------------------------------------------------------------------------------------
        //BÚSQUEDAS------------------------------------------------------------------------------------

        public IEnumerable<Mantenimiento> FindMantenimientosCabana(int idCabana)
        {
            var resultado = Contexto.Mantenimientos
                .Where(mant => mant.CabanaId == idCabana)
                .Include(mant => mant.Cabana)
                .ToList();
            return resultado;
        }

        public IEnumerable<Mantenimiento> FindMantenimientosFechas(DateTime startDate, DateTime endDate, int CabanaId)
        {
           var resultado = Contexto.Mantenimientos
                .Where(mant => mant.CabanaId == CabanaId)
                .Where(mant=>mant.FechaMant.Date.CompareTo(startDate.Date) >=0) //no funcionan los operadores = < > para comparar directamente
                .Where(mant => mant.FechaMant.Date.CompareTo(endDate.Date) <= 0)
                .OrderByDescending(mant=>mant.CostoMant) 
                .ToList();
            return resultado;
        }


        //---------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS------------------------------------------------------------------------------------

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

        
    }
}
