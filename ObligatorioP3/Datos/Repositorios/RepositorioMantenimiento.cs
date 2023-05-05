using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;

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

        public IEnumerable<Mantenimiento> FindMantenimientosFechas(DateTime startDate, DateTime endDate, int CabanaId)
        {
            var resultado = Contexto.Mantenimientos
                .Where(mant => mant.CabanaId == CabanaId)
                .Where(mant=>mant.FechaMant >= startDate)
                .Where(mant=>mant.FechaMant<= endDate)
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
    }
}
