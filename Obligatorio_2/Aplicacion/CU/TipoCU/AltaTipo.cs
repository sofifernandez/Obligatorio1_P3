using Aplicacion.InterfacesCU.ITipo;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.TipoCU
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
        public void Alta(TipoDTO t)
        {
            Tipo tipo = new Tipo()
            {
                Nombre = t.Nombre,
                DescTipo = t.DescTipo,
                CostoTipo = t.CostoTipo
                
            };

            //tipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
            //tipo.MaxDescripTipo = int.Parse(RepoParametro.ValorParametro("MaxDescripTipo"));


            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            //Tipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
            //Tipo.MaxDescripTipo = int.Parse(RepoParametro.ValorParametro("MaxDescripTipo"));
            RepoTipo.Add(tipo);
        }
    }
}
