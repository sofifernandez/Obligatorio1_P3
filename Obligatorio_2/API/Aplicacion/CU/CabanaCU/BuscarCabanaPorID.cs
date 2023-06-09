﻿using Aplicacion.InterfacesCU.ICabana;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CU.CabanaCU
{
    public class BuscarCabanaPorID : IBuscarCabanaPorID
    {
        public IRepositorioCabana RepoCabana { get; set; }
        public BuscarCabanaPorID(IRepositorioCabana repo)
        {
            RepoCabana = repo;
        }
        public CabanaDTO Buscar(int id)
        {
            CabanaDTO dto = null;
            Cabana c = RepoCabana.FindById(id);
            if (c != null)
            {
                dto = new CabanaDTO()
                {
                    Id = c.Id,
                    NombreCabana = c.NombreCabana.Value,
                    DescripCabana = c.DescripCabana.Value,
                    Jacuzzi = c.Jacuzzi,
                    Habilitado = c.Habilitado,
                    MaxPersonas = c.MaxPersonas,
                    FotoCabana = c.FotoCabana,
                    Tipo = new TipoDTO()
                    {
                        Id = c.Tipo.Id,
                        NombreTipo = c.Tipo.NombreTipo.Value,
                        DescTipo = c.Tipo.DescTipo.Value,
                        CostoTipo = c.Tipo.CostoTipo
                    },
                    TipoId = c.TipoId
                };
            }
            return dto;
        }
    }
}
