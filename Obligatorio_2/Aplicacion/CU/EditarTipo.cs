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
    public class EditarTipo : IEditarTipo
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public IRepositorioParametro RepoParametro { get; set; }

        public EditarTipo(IRepositorioTipo repo, IRepositorioParametro repoPars)
        {
            RepoTipo = repo;
            RepoParametro = repoPars;
        }
        public void Editar(Tipo t)
        {
            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            Tipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
            Tipo.MaxDescripTipo = int.Parse(RepoParametro.ValorParametro("MaxDescripTipo"));
            RepoTipo.Update(t);
        }
    }
}
