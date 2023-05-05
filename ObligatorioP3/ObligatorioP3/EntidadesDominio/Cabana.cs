﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Dominio.EntidadesDominio
{
    [Index(nameof(NombreCabana), IsUnique = true)]

    public class Cabana
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="El nombre no puede tener más 50 caracteres")] //-->ESTO ES PORQUE QUEREMOS QUE SEA UNIQUE Y NOS VA A TIRAR ERROR LA BASE DE DATOS, PORQUE POR DEFECTO ES NVARMAX
        public string NombreCabana { get; set; }
        public string DescripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        public int MaxPersonas { get; set; }
        public string FotoCabana { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }

        //Constraints variables de la descripción: Min=10 y Max=500
        public static int MinDescripCabana { get; set; }
        public static int MaxDescripCabana { get; set; }

        //VALIDAR EL NOMBRE--> CARACTERES ALFABETICOS Y ESPACIOS EMBEBIDOS (NO AL INICIO NI AL FINAL)
        //LA FOTO
        //DESCRIPCION TIENE PARAMETROS VARIABLES




    }
}
