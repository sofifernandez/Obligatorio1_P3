using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.Models
{
    public class TipoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NombreTipo { get; set; }
        [Display(Name = "Descripción")]
        public string? DescTipo { get; set; }
        [Display(Name = "Costo")]
        public int? CostoTipo { get; set; }
    }
}
