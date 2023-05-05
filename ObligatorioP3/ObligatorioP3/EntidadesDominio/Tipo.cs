using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Dominio.EntidadesDominio
{
    [Index(nameof(Nombre), IsUnique=true)]
    public class Tipo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        public string DescTipo { get; set; } //TIENE PARAMETROS VARIABLES (ENTR 10 Y 200)
        public int CostoTipo { get; set; }

        //Constraints variables
        public static int MinDescripTipo { get; set; }
        public static int MaxDescripTipo { get; set; }

        private static Regex alphabetRegex = new("^[a-zA-Z ]+$");

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();

        }


        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre)) { throw new Exception("El nombre de la cabaña no puede ser nulo o vacío"); }
            if (!alphabetRegex.IsMatch(Nombre)) { throw new Exception("El nombr puede contener solo letras y espacios"); }
            if (Nombre[0].Equals(" ")) { throw new Exception("No puede haber un espacio al comienzo del nombre"); }
            if (Nombre[Nombre.Length - 1].Equals(" ")) { throw new Exception("No puede haber un espacio al final del nombre"); }
        }

        private void ValidarDescripcion()
        {
            if (DescTipo.Length < MinDescripTipo) { throw new Exception("El nombre del tema no puede tener menos de " + MinDescripTipo); }
            if (DescTipo.Length > MaxDescripTipo) { throw new Exception("El nombre del tema no puede tener más de " + MaxDescripTipo); }
        }

        //VALIDAR EL NOMBRE--> CARACTERES ALFABETICOS Y ESPACIOS EMBEBIDOS (NO AL INICIO NI AL FINAL)
    }
}
