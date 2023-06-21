using ClienteMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.DTOs
{
    public class CabanaDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NombreCabana { get; set; }
        [Display(Name = "Descripción")]
        public string? DescripCabana { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        [Display(Name = "Cant. Personas")]
        public int? MaxPersonas { get; set; }
        public string? FotoCabana { get; set; }
        public TipoViewModel? Tipo { get; set; }
        public int TipoId { get; set; }

    }
}
