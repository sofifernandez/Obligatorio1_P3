using System.ComponentModel.DataAnnotations;
using ClienteMVC.DTOs;

namespace ClienteMVC.Models
{
    public class MantenimientoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FechaMant { get; set; }
        [Display(Name = "Descripción")]
        public string? DescMant { get; set; }
        [Display(Name = "Costo")]
        public int? CostoMant { get; set; }
        public string? Personal { get; set; }
        public CabanaDTO? Cabana { get; set; }
        public int CabanaId { get; set; }
    }
}
