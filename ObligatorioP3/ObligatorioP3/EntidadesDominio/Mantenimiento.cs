using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Dominio.EntidadesDominio
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        [Display(Name ="Fecha y hora")]
        public DateTime FechaMant { get; set; }
        [MinLength(10, ErrorMessage ="La descripción no puede tener menos de 10 caracteres"), MaxLength(200, ErrorMessage ="La descripción no puede tener más de 200 caracteres")]
        [Display(Name = "Descripción")]
        public string? DescMant { get; set; }
        [Display(Name = "Costo")]
        public int? CostoMant { get; set; }
        public string? Personal { get; set; }
        public Cabana? Cabana { get; set; }
        public int CabanaId { get; set; }
    }
}
