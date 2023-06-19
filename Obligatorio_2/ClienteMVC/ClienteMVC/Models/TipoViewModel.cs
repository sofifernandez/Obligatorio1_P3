using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.Models
{
    public class TipoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string? DescTipo { get; set; }
        [Display(Name = "Costo")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ingrese valores mayores a 0")]
        public int? CostoTipo { get; set; }
    }
}
