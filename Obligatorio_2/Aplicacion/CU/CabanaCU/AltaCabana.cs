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
            Cabana nueva = new Cabana()
            {
                NombreCabana = c.NombreCabana,
                DescripCabana = c.DescripCabana,
                Jacuzzi = c.Jacuzzi,
                Habilitado = c.Habilitado,
                MaxPersonas = c.MaxPersonas,
                FotoCabana = c.FotoCabana,
                Tipo = c.Tipo,
                TipoId = c.TipoId

            };

            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            //Cabana.MinDescripCabana = int.Parse(RepoParametro.ValorParametro("MinDescripCabana"));
            //Cabana.MaxDescripCabana = int.Parse(RepoParametro.ValorParametro("MaxDescripCabana"));
            
            RepoCabana.Add(nueva);
            c.Id = nueva.Id;
        }
    }
}
