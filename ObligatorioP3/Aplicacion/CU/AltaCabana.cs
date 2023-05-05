using Aplicacion.InterfacesCU;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplicacion.CU
{
    public class AltaCabana:IAltaCabana
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public IRepositorioParametro RepoParametro { get; set; }

        public AltaCabana(IRepositorioCabana repo, IRepositorioParametro repoPars)
        {
            RepoCabana = repo;
            RepoParametro = repoPars;
        }

        public void Alta(Cabana c)
        {
            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            Cabana.MinDescripCabana = int.Parse(RepoParametro.ValorParametro("MinDescripCabana"));
            Cabana.MaxDescripCabana = int.Parse(RepoParametro.ValorParametro("MaxDescripCabana"));

            RepoCabana.Add(c);
        }
    }
}
