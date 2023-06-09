﻿using Aplicacion.InterfacesCU.ITipo;
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
    public class EditarTipo : IEditarTipo
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public IRepositorioParametro RepoParametro { get; set; }

        public EditarTipo(IRepositorioTipo repo, IRepositorioParametro repoPars)
        {
            RepoTipo = repo;
            RepoParametro = repoPars;
        }
        public void Editar(TipoDTO t)
        {
            //OBTENER VALORES FRESCOS DE PARÁMETROS Y SETEARLOS
            DescripTipo.MinDescripTipo = int.Parse(RepoParametro.ValorParametro("MinDescripTipo"));
            DescripTipo.MaxDescripTipo = int.Parse(RepoParametro.ValorParametro("MaxDescripTipo"));

            Tipo aModificar = new Tipo()
            {
                Id=t.Id,
                NombreTipo = new NombreTipo(t.NombreTipo),
                DescTipo = new DescripTipo(t.DescTipo),
                CostoTipo = t.CostoTipo
            };

            RepoTipo.Update(aModificar);
        }
    }
}
