using Aplicacion.InterfacesCU.ITipo;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using Dominio.ValueObjects;
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
            DescripTipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
            DescripTipo.MaxDescripTipo = int.Parse(RepoParametro.ValorParametro("MaxDescripTipo"));
            
            Tipo tipo = new Tipo()
            {
                NombreTipo = new NombreTipo(t.NombreTipo),
                DescTipo = new DescripTipo(t.DescTipo),
                CostoTipo = t.CostoTipo
                
            };


            RepoTipo.Add(tipo);
            t.Id = tipo.Id;
        }
    }
}
