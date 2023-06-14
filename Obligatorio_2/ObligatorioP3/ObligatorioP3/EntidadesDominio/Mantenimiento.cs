using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Dominio.InterfacesDominio;

namespace Dominio.EntidadesDominio
{
    public class Mantenimiento:IValidable
    {
        public int Id { get; set; }
        [Display(Name ="Fecha y hora")]
        public DateTime FechaMant { get; set; }
        [MinLength(10, ErrorMessage ="La descripción no puede tener menos de 10 caracteres"), MaxLength(200, ErrorMessage ="La descripción no puede tener más de 200 caracteres")]
        [Display(Name = "Descripción")]
        public string? DescMant { get; set; }
        [Display(Name = "Costo")]
        [Range(0,Int32.MaxValue,ErrorMessage ="Ingrese valores mayores a 0")]
        public int? CostoMant { get; set; }
        public string? Personal { get; set; }
        public Cabana? Cabana { get; set; }
        public int CabanaId { get; set; }

        public void Validar()
        {
            if (FechaMant.Date.CompareTo(DateTime.Now.Date) < 0) 
            {
                throw new Exception("La fecha ingresada debe ser posterior a hoy");
            }

            if (CostoMant < 0) 
            {
                throw new Exception("Ingrese valores mayores a 0"); //Tuvimos un conflicto con el uso del repositorio de Git y no nos permitió hacer nuevas migraciones para agregar el Range
            }
        }
    }
}
