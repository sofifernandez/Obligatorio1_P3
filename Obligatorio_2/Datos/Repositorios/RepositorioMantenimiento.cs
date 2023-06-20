using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using ExcepcionesPropias;

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
        //LISTADOS------------------------------------------------------------------------------------

        public IEnumerable<Mantenimiento> FindMantenimientosCabana(int idCabana)
        {
            var resultado = Contexto.Mantenimientos
                .Where(mant => mant.CabanaId == idCabana)
                .Include(mant => mant.Cabana)
                .ToList();
            return resultado;
        }

        //------------------------------------------------------------------------------------------
        //BÚSQUEDAS------------------------------------------------------------------------------------

        public IEnumerable<Mantenimiento> FindMantenimientosFechas(DateTime startDate, DateTime endDate, int CabanaId)
        {
            var resultado = Contexto.Mantenimientos
                 .Where(mant => mant.CabanaId == CabanaId)
                 .Where(mant => mant.FechaMant.Date.CompareTo(startDate.Date) >= 0) //no funcionan los operadores = < > para comparar directamente
                 .Where(mant => mant.FechaMant.Date.CompareTo(endDate.Date) <= 0)
                 .OrderByDescending(mant => mant.CostoMant)
                 .ToList();
            return resultado;
        }



        //Dados dos valores, obtener los mantenimientos realizados a las cabañas con una capacidad
        //que esté comprendida (topes inclusive) entre ambos valores. El resultado se agrupará por
        //nombre de la persona que realizó el mantenimiento, e incluirá el nombre de la persona y el
        //monto total de los mantenimientos que realizó
        
        public IEnumerable<object> MontoMantenimientosPorCapacidad(int desde, int hasta)
        {
            var resultado = Contexto.Mantenimientos
                .Where(manten => manten.Cabana.MaxPersonas>=desde && manten.Cabana.MaxPersonas<=hasta) 
                .GroupBy(mant => mant.Personal)
                .Select(grupo => new {
                                        Personal=grupo.Key ,
                                        Total=grupo.Sum(grupo=>grupo.CostoMant)
                                     })
                
                .ToList();

            return resultado;
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
                throw new AltaMantenimientoException("Solo se pueden agregar 3 mantenimientos por cabaña por día");
            }
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
