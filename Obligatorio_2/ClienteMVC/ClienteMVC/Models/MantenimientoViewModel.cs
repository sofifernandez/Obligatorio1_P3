using System.ComponentModel.DataAnnotations;
using ClienteMVC.DTOs

namespace ClienteMVC.Models
{
    public class MantenimientoViewModel
    {
        public int Id { get; set; }
        public DateTime FechaMant { get; set; }
        public string? DescMant { get; set; }
        public int? CostoMant { get; set; }
        public string? Personal { get; set; }
        public CabanaDTO? Cabana { get; set; }
        public int CabanaId { get; set; }
    }
}
