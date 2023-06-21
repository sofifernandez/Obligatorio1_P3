using Dominio.EntidadesDominio;
using Aplicacion.InterfacesCU.ICabana;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ExcepcionesPropias;
using Dominio.ValueObjects;

namespace Aplicacion.CU.CabanaCU
{
    public class AltaCabana : IAltaCabana
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public IRepositorioParametro RepoParametro { get; set; }

        public AltaCabana(IRepositorioCabana repo, IRepositorioParametro repoPars)
        {
            RepoCabana = repo;
            RepoParametro = repoPars;
        }

        public void Alta(CabanaDTO c)
        {
            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            DescripCabana.MinDescripCabana = int.Parse(RepoParametro.ValorParametro("MinDescripCabana"));
            DescripCabana.MaxDescripCabana = int.Parse(RepoParametro.ValorParametro("MaxDescripCabana"));

            Cabana nueva = new Cabana()
            {
                NombreCabana = new NombreCabana(c.NombreCabana),
                DescripCabana = new DescripCabana(c.DescripCabana),
                Jacuzzi = c.Jacuzzi,
                Habilitado = c.Habilitado,
                MaxPersonas = c.MaxPersonas,
                FotoCabana = c.FotoCabana,
                //Tipo = new Tipo() { CostoTipo=c.Tipo.CostoTipo, DescTipo=c.Tipo.DescTipo.Value,Id=c.Tipo.Id, NombreTipo=c.Tipo.NombreTipo},
                TipoId = c.TipoId

            };

            RepoCabana.Add(nueva);
            c.Id = nueva.Id;
        }
    }
}
