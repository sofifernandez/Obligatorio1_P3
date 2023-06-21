using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.Models
{
    public class TipoViewModel
    {
        public int Id { get; set; }
        public string NombreTipo { get; set; }
        public string? DescTipo { get; set; }
        public int? CostoTipo { get; set; }
    }
}
