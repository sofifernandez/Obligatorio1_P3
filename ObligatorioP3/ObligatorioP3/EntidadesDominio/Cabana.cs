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


namespace Dominio.EntidadesDominio
{
    [Index(nameof(NombreCabana), IsUnique = true)]

    public class Cabana: IValidable
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="El nombre no puede tener más 50 caracteres")] //-->ESTO ES PORQUE QUEREMOS QUE SEA UNIQUE Y NOS VA A TIRAR ERROR LA BASE DE DATOS, PORQUE POR DEFECTO ES NVARMAX
        [Display(Name = "Nombre")]
        public string NombreCabana { get; set; }
        [Display(Name = "Descripción")]
        public string DescripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        [Display(Name = "Cant. de huéspedes")]
        public int MaxPersonas { get; set; }
        [Display(Name = "Foto")]
        public string FotoCabana { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }

        //Constraints variables de la descripción: Min=10 y Max=500
        public static int MinDescripCabana { get; set; }
        public static int MaxDescripCabana { get; set; }

        private static Regex alphabetRegex = new ("^[a-zA-Z ]+$");


        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();

        }

        private void ValidarNombre() 
        {
            if (string.IsNullOrEmpty(NombreCabana)){throw new Exception("El nombre de la cabaña no puede ser nulo o vacío");}
            if (!alphabetRegex.IsMatch(NombreCabana)){throw new Exception("El nombr puede contener solo letras y espacios");}
            if (NombreCabana[0].Equals(" ")) {throw new Exception("No puede haber un espacio al comienzo del nombre");}
            if (NombreCabana[NombreCabana.Length - 1].Equals(" ")) { throw new Exception("No puede haber un espacio al final del nombre"); }
        }

        private void ValidarDescripcion()
        {
            if (DescripCabana.Length < MinDescripCabana){throw new Exception("El nombre del tema no puede tener menos de " + MinDescripCabana);}
            if (DescripCabana.Length > MaxDescripCabana){throw new Exception("El nombre del tema no puede tener más de " + MaxDescripCabana);}
        }

        //VALIDAR EL NOMBRE--> CARACTERES ALFABETICOS Y ESPACIOS EMBEBIDOS (NO AL INICIO NI AL FINAL)
        //LA FOTO
        




    }
}
