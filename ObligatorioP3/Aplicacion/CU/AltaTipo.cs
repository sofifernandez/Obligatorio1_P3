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
    public class AltaTipo : IAltaTipo
    {

        public IRepositorioTipo RepoTipo { get; set; }
        public IRepositorioParametro RepoParametro { get; set; }

        public AltaTipo(IRepositorioTipo repo, IRepositorioParametro repoPars)
        {
            RepoTipo = repo;
            RepoParametro = repoPars;
        }
        public void Alta(Tipo t)
        {
            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            Tipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
            Tipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
        }
    }
}
