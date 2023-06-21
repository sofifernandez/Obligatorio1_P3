using Aplicacion.InterfacesCU.ICabana;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.CabanaCU
{
    public class BuscarCabanaPorMonto : IBuscarCabanaPorMonto
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public BuscarCabanaPorMonto(IRepositorioCabana repo)
        {
            RepoCabana = repo;
        }

        public IEnumerable<object> FindCabanaPorMonto(int monto)
        {
            IEnumerable<object> cabanas = RepoCabana.FindCabanasPorMonto(monto);

            return cabanas;
        }

       
    }
}
