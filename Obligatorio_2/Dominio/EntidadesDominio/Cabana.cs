using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Dominio.InterfacesDominio;
using System.Text.RegularExpressions;
using Dominio.ExcepcionesPropias;
using Dominio.ValueObjects;

namespace Dominio.EntidadesDominio
{
    //[Index(nameof(NombreCabana), IsUnique = true)]

    public class Cabana
    {
        public int Id { get; set; }
        //[MaxLength(50,ErrorMessage ="El nombre no puede tener más 50 caracteres")] //-->ESTO ES PORQUE QUEREMOS QUE SEA UNIQUE Y NOS VA A TIRAR ERROR LA BASE DE DATOS, PORQUE POR DEFECTO ES NVARMAX
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public NombreCabana? NombreCabana { get; set; } //Value Object
        [Display(Name = "Descripción")]
        public DescripCabana? DescripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        [Display(Name = "Cant. de huéspedes")]
        [Range(0,15,ErrorMessage ="El valor debe estar entre 0 y 15")]
        public int? MaxPersonas { get; set; }
        [Display(Name = "Foto")]
        public string? FotoCabana { get; set; }
        public Tipo? Tipo { get; set; }
        public int TipoId { get; set; }

        
        //public static int MinDescripCabana { get; set; }
        //public static int MaxDescripCabana { get; set; }

        //private static Regex alphabetRegex = new ("^[a-zA-Z áéíóúÁÉÍÓÚ]+$");

       
       
    }
}
