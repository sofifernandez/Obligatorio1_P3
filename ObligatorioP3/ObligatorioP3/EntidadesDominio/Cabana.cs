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
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string NombreCabana { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage ="La descripción es un campo obligatorio")]
        public string DescripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        [Display(Name = "Cant. de huéspedes")]
        [Range(0,15,ErrorMessage ="El valor debe estar entre 0 y 15")]
        [Required(ErrorMessage = "La cantidad de huéspedes es un campo obligatorio")]
        public int MaxPersonas { get; set; }
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "La foto es obligatoria")]
        public string FotoCabana { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }

        //Constraints variables de la descripción: Min=10 y Max=500
        public static int MinDescripCabana { get; set; }
        public static int MaxDescripCabana { get; set; }

        private static Regex alphabetRegex = new ("^[a-zA-Z áéíóúÁÉÍÓÚ]+$");


        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();

        }

        private void ValidarNombre() 
        {
            //if (string.IsNullOrEmpty(NombreCabana)){throw new Exception("El nombre de la cabaña no puede ser nulo o vacío");}
            if (!alphabetRegex.IsMatch(NombreCabana)){throw new Exception("El nombre puede contener solo letras y espacios");}
            if (NombreCabana[0].ToString()==" ") {throw new Exception("No puede haber un espacio al comienzo del nombre");}
            if (NombreCabana[NombreCabana.Length - 1].ToString() == " ") { throw new Exception("No puede haber un espacio al final del nombre"); }
        }

        private void ValidarDescripcion()
        {
            if (DescripCabana.Length < MinDescripCabana){throw new Exception("La descripción de la cabaña no puede tener menos de " + MinDescripCabana);}
            if (DescripCabana.Length > MaxDescripCabana){throw new Exception("La descripción de la cabaña no puede tener más de " + MaxDescripCabana);}
        }

       
        //LA FOTO
        




    }
}
