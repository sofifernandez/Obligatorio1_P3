using Aplicacion.InterfacesCU.IParametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorios;

namespace Aplicacion.CU.ParametrosCU
{
    public class ObtenerParametro : IObtenerParametros
    {
        public IRepositorioParametro RepoPars { get; set; }

        public ObtenerParametro(IRepositorioParametro repo)
        {
            RepoPars = repo;
        }

        string IObtenerParametros.ObtenerParametro(string nomPar)
        {
            return RepoPars.ValorParametro(nomPar);
        }
    }
}
