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

namespace Dominio.EntidadesDominio
{
    [Index(nameof(Nombre), IsUnique=true)]

    public class Tipo: IValidable

    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string? DescTipo { get; set; }
        [Display(Name = "Costo")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ingrese valores mayores a 0")]
        public int? CostoTipo { get; set; }

        //Constraints variables
        public static int MinDescripTipo { get; set; }
        public static int MaxDescripTipo { get; set; }

        private static Regex alphabetRegex = new("^[a-zA-Z áéíóúÁÉÍÓÚ]+$");

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();

        }


        private void ValidarNombre()
        {
            //if (string.IsNullOrEmpty(Nombre)) { throw new Exception("El nombre del tipo no puede ser nulo o vacío"); }
            if (!alphabetRegex.IsMatch(Nombre)) { throw new Exception("El nombre puede contener solo letras y espacios"); }
            if (Nombre[0].ToString()==" ") { throw new Exception("No puede haber un espacio al comienzo del nombre"); }
            if (Nombre[Nombre.Length - 1].ToString()==" ") { throw new Exception("No puede haber un espacio al final del nombre"); }
        }

        private void ValidarDescripcion()
        {
            if (DescTipo.Length < MinDescripTipo) { throw new Exception("La descripción del tipo no puede tener menos de " + MinDescripTipo); }
            if (DescTipo.Length > MaxDescripTipo) { throw new Exception("La descripción del tipo no puede tener más de " + MaxDescripTipo); }
        }

    }
}
