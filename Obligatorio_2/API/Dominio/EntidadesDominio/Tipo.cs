using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Dominio.InterfacesDominio;
using Dominio.ValueObjects;

namespace Dominio.EntidadesDominio
{
   // [Index(nameof(Nombre), IsUnique=true)]

    public class Tipo

    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es un campo obligatorio")]
        public NombreTipo? NombreTipo { get; set; }
        [Display(Name = "Descripción")]
        public DescripTipo? DescTipo { get; set; }
        [Display(Name = "Costo")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ingrese valores mayores a 0")]
        public int? CostoTipo { get; set; }

        //Constraints variables
        //public static int MinDescripTipo { get; set; }
        //public static int MaxDescripTipo { get; set; }

       

    }
}
