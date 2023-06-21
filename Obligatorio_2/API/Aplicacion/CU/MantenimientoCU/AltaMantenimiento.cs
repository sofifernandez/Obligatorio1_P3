using Aplicacion.InterfacesCU.IMantenimiento;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.MantenimientoCU
{
    public class AltaMantenimiento : IAltaMantenimiento
    {
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public AltaMantenimiento(IRepositorioMantenimiento repo)
        {
            RepoMantenimiento = repo;

        }
        public void Alta(MantenimientoDTO m)
        {

            Mantenimiento nueva = new Mantenimiento()
            {
                Id = m.Id,
                FechaMant = m.FechaMant,
                DescMant = m.DescMant,
                CostoMant = m.CostoMant,
                Personal = m.Personal,
                //Cabana = m.Cabana,
                CabanaId = m.CabanaId

            };

            RepoMantenimiento.Add(nueva);
            m.Id = nueva.Id;




        }
    }
}
